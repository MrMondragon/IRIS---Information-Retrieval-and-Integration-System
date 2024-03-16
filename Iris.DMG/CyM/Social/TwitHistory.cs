using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Iris.Runtime.Model.DisignSuport;
using Iris.Runtime.Model.BaseObjects;
using Iris.Runtime.Model.Entities;
using Iris.Interfaces;
using System.Data;
using System.ComponentModel;
using System.Drawing.Design;
using Iris.Runtime.Model.Entities.Schemas;
using Databridge.Engine.Extensions;
using System.Windows.Forms.Design;
using Iris.Runtime.Model.Operations.ColumnBasedOperations;
using System.Net;
using Databridge.Engine.Web;
using HtmlAgilityPack;
using Databridge.Social.Twitter;
using System.Threading;

namespace Iris.DMG.CyM.Social
{
  [Serializable]
  [OperationCategory("Databridge", "TwitterCrawler")]
  public class TwitHistory : BaseSocialOperation
  {
    public TwitHistory(Structure aStructure, string aName) : base(aStructure, aName)
    {
      SetOutputs("Tweets", "Hashtags", "Entities", "Links");
      MaxRetries = 15;
      SleepTime = 5;
    }


    public DateTime? SinceDate { get; set; }
    public DateTime? UntilDate { get; set; }
    public SearchType SearchType { get; set; }
    public SeedType SeedType { get; set; }

    public int MaxRetries { get; set; }
    [Description("Timeout em minutos para novas tentativas em caso de balão")]
    public int SleepTime { get; set; }

    protected override IEntity doExecute()
    {
      TwitterCrawler crawler = new TwitterCrawler();
      crawler.SinceDate = SinceDate;
      crawler.UntilDate = UntilDate;
      crawler.SearchType = SearchType;

      ResultSet resultset = (ResultSet)GetInput("Entrada").EntityValue;
      DataTable entrada = resultset.Table;

      List<Tweet> tweets = new List<Tweet>();
      List<string> seeds = entrada.Rows.Cast<DataRow>().Select(x => Convert.ToString(x[ColunaBase])).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
      try
      {
        foreach (string seed in seeds)
        {
          retries = 0;
          CrawlThroughSeed(crawler, tweets, seed);

        }
      }
      finally
      {
        if (tweets.Count > 0)
        {
          if (GetOutput("Tweets") != null)
          {
            ResultSet rs = (ResultSet)GetOutput("Tweets").EntityValue;
            rs.Table = Tweet.GetTweetTable(tweets);
            rs.Table.TableName = rs.Name;
          }

          if (GetOutput("Hashtags") != null)
          {
            ResultSet rs = (ResultSet)GetOutput("Hashtags").EntityValue;
            rs.Table = Tweet.GetHashtagsTable(tweets);
            rs.Table.TableName = rs.Name;
          }

          if (GetOutput("Entities") != null)
          {
            ResultSet rs = (ResultSet)GetOutput("Entities").EntityValue;
            rs.Table = Tweet.GetEntitiesTable(tweets);
            rs.Table.TableName = rs.Name;
          }

          if (GetOutput("Links") != null)
          {
            ResultSet rs = (ResultSet)GetOutput("Links").EntityValue;
            rs.Table = Tweet.GetLinksTable(tweets);
            rs.Table.TableName = rs.Name;
          }
        }

      }

      return null;
    }

    private int retries;

    private void CrawlThroughSeed(TwitterCrawler crawler, List<Tweet> tweets, string seed)
    {
      List<Tweet> localList = new List<Tweet>();
      try
      {
        Structure.AddToLog($" Início da varredura {seed}", this);
        switch (SeedType)
        {
          case SeedType.FromAccount:
            crawler.FromAccount = seed;
            localList.AddRange(crawler.Search());
            break;
          case SeedType.ToAccount:
            crawler.ToAccount = seed;
            localList.AddRange(crawler.Search());
            break;
          case SeedType.Search:
            crawler.ExactTerms = seed;
            localList.AddRange(crawler.Search());
            break;
          case SeedType.Url:
            localList.AddRange(crawler.Search(seed));
            break;
        }

        tweets.AddRange(localList.Where(x => !string.IsNullOrEmpty(x.UserName) && !string.IsNullOrEmpty(x.TweetId)));
        Structure.AddToLog($"  fim da varredura {seed}", this);
      }
      catch(Exception ex)
      {
        retries++;
        Structure.AddToLog($"Falha número {retries} de {MaxRetries}", ex, this);
        if(retries < MaxRetries)
        {
          Thread.Sleep(SleepTime * 1000 * 60);
          CrawlThroughSeed(crawler, tweets, seed);
        }
      }

    }
  }

  public enum SeedType
  {
    FromAccount,
    ToAccount,
    Search,
    Url

  }
}
