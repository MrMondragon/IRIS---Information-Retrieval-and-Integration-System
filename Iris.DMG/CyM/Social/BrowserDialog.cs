using Databridge.Engine.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iris.DMG.CyM.Social
{
  public partial class BrowserDialog : Form
  {
    public BrowserDialog()
    {
      InitializeComponent();
      webBrowser.ScriptErrorsSuppressed = true;
    }

    public void Navigate(string url)
    {
      Url = url;
      webBrowser.Navigate(url);
      Show();
    }

    public string Html { get; set; }
    public string Url { get; set; }

    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      Html = webBrowser.DocumentText;
      DocCompleted?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler DocCompleted;
    public string doNavigateSync(string url, string targetFrameName = null,
      byte[] postData = null, string additionalHeaders = null)
    {
      Show();
      webBrowser.Navigate(url, targetFrameName, postData, additionalHeaders);
      while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
        Application.DoEvents();
      while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
        Application.DoEvents();
      string result = webBrowser.DocumentText;

     // Hide();
      return result;
    }


    public static string NavigateSync(string url, string targetFrameName = null,
    byte[] postData = null, string additionalHeaders = null)
    {
      using (BrowserDialog dlg = new BrowserDialog())
      {
        return dlg.doNavigateSync(url,targetFrameName,postData, additionalHeaders);
      }
    }

    public void WaitForPost()
    {
      while (webBrowser.ReadyState == WebBrowserReadyState.Complete)
        Application.DoEvents();
      while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
        Application.DoEvents();
    }

    readonly SemaphoreSlim semaphore = new SemaphoreSlim(1);

    public async Task<string> NavigateAsync(string url, string targetFrameName = null,
      byte[] postData = null, string additionalHeaders = null,
      CancellationToken cancellationToken = default(CancellationToken))
    {
      await semaphore.WaitAsync(cancellationToken);

      TaskCompletionSource<string> tcSource = new TaskCompletionSource<string>(null);
#pragma warning disable 4014
      Task.Factory.StartNew(() =>
#pragma warning restore 4014
      {
        void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
          if (e.Url.AbsolutePath != webBrowser.Url.AbsolutePath)
            return;

          webBrowser.DocumentCompleted -= OnDocumentCompleted;

          semaphore.Release();
          tcSource.SetResult(webBrowser.DocumentText);
        }

        webBrowser.Navigate(url, targetFrameName, postData, additionalHeaders);
        webBrowser.DocumentCompleted += OnDocumentCompleted;
      }, cancellationToken);
      return await tcSource.Task;
    }

  }
}
