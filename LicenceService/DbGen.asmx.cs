using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Databridge.Engine.Criptography;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace LicenceService
{
  /// <summary>
  /// Summary description for DbGen1
  /// </summary>
  [WebService(Namespace = "http://www.databridge.com/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [System.ComponentModel.ToolboxItem(false)]
  // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
  // [System.Web.Script.Services.ScriptService]
  public class DbGen : System.Web.Services.WebService
  {
    #region Script Constant

    private const string script = @"/****** Object:  Table [AdmUsers]    Script Date: 07/28/2010 16:09:11 ******/

CREATE TABLE [AdmUsers](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[EMail] [varchar](50) NOT NULL,
	[Certificate] [text] NOT NULL,
 CONSTRAINT [PK_AdmUsers] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Products]    Script Date: 07/28/2010 16:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Products](
	[Prd_ID] [varchar](5) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastVersion] [varchar](10) NOT NULL,
	[ReleaseDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Prd_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [Idx_Name] ON [Products] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [Clients]    Script Date: 07/28/2010 16:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clients](
	[Cli_ID] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Certificate] [text] NOT NULL,
	[DefaultEMail] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Cli_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [Idx_Name] ON [Clients] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [ClientAuditLog]    Script Date: 07/28/2010 16:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [ClientAuditLog](
	[Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cli_ID] [varchar](50) NOT NULL,
	[ComputerName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[Operation] [text] NOT NULL,
 CONSTRAINT [PK_ClientAuditLog] PRIMARY KEY CLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [Idx_Cli_ID] ON [ClientAuditLog] 
(
	[Cli_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Idx_Cli_ID_EntryDate] ON [ClientAuditLog] 
(
	[Cli_ID] ASC,
	[EntryDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Idx_EntryDate] ON [ClientAuditLog] 
(
	[EntryDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [AvailableLicences]    Script Date: 07/28/2010 16:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [AvailableLicences](
	[AvLic_ID] [int] IDENTITY(1,1) NOT NULL,
	[Prd_ID] [varchar](5) NOT NULL,
	[Cli_ID] [varchar](50) NOT NULL,
	[LicenceType] [varchar](10) NOT NULL,
	[Licences] [int] NOT NULL,
 CONSTRAINT [PK_AvailableLicences] PRIMARY KEY CLUSTERED 
(
	[AvLic_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [Idx_Cli_ID] ON [AvailableLicences] 
(
	[Cli_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [idx_Prd_ID] ON [AvailableLicences] 
(
	[Prd_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [AdmAuditLog]    Script Date: 07/28/2010 16:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [AdmAuditLog](
	[Log_ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[Operation] [text] NOT NULL,
 CONSTRAINT [PK_AdmAuditLog] PRIMARY KEY CLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [Idx_EntryDate] ON [AdmAuditLog] 
(
	[EntryDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Idx_UserName] ON [AdmAuditLog] 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [Idx_UsrName_EntryDate] ON [AdmAuditLog] 
(
	[UserName] ASC,
	[EntryDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [RegisteredServers]    Script Date: 07/28/2010 16:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [RegisteredServers](
	[Srv_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cli_ID] [varchar](50) NOT NULL,
	[Prd_ID] [varchar](5) NOT NULL,
	[MACAddress] [varchar](16) NOT NULL,
	[LicenceType] [varchar](10) NOT NULL,
 CONSTRAINT [PK_RegisteredServers] PRIMARY KEY CLUSTERED 
(
	[Srv_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [Idx_Cli_ID_Prd_ID] ON [RegisteredServers] 
(
	[Cli_ID] ASC,
	[Prd_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [RegisteredPlugins]    Script Date: 07/28/2010 16:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [RegisteredPlugins](
	[Plug_ID] [int] IDENTITY(1,1) NOT NULL,
	[Srv_ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Asm] [varchar](50) NOT NULL,
	[ExpireDate] [datetime] NOT NULL,
 CONSTRAINT [PK_RegisteredPlugins] PRIMARY KEY CLUSTERED 
(
	[Plug_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [Idx_Srv_ID] ON [RegisteredPlugins] 
(
	[Srv_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_ClientAuditLog_Clients]    Script Date: 07/28/2010 16:09:11 ******/
ALTER TABLE [ClientAuditLog]  WITH CHECK ADD  CONSTRAINT [FK_ClientAuditLog_Clients] FOREIGN KEY([Cli_ID])
REFERENCES [Clients] ([Cli_ID])
GO
ALTER TABLE [ClientAuditLog] CHECK CONSTRAINT [FK_ClientAuditLog_Clients]
GO
/****** Object:  ForeignKey [FK_AvailableLicences_Clients]    Script Date: 07/28/2010 16:09:11 ******/
ALTER TABLE [AvailableLicences]  WITH CHECK ADD  CONSTRAINT [FK_AvailableLicences_Clients] FOREIGN KEY([Cli_ID])
REFERENCES [Clients] ([Cli_ID])
GO
ALTER TABLE [AvailableLicences] CHECK CONSTRAINT [FK_AvailableLicences_Clients]
GO
/****** Object:  ForeignKey [FK_AvailableLicences_Products]    Script Date: 07/28/2010 16:09:11 ******/
ALTER TABLE [AvailableLicences]  WITH CHECK ADD  CONSTRAINT [FK_AvailableLicences_Products] FOREIGN KEY([Prd_ID])
REFERENCES [Products] ([Prd_ID])
GO
ALTER TABLE [AvailableLicences] CHECK CONSTRAINT [FK_AvailableLicences_Products]
GO
/****** Object:  ForeignKey [FK_AdmAuditLog_AdmUsers]    Script Date: 07/28/2010 16:09:11 ******/
ALTER TABLE [AdmAuditLog]  WITH CHECK ADD  CONSTRAINT [FK_AdmAuditLog_AdmUsers] FOREIGN KEY([UserName])
REFERENCES [AdmUsers] ([UserName])
GO
ALTER TABLE [AdmAuditLog] CHECK CONSTRAINT [FK_AdmAuditLog_AdmUsers]
GO
/****** Object:  ForeignKey [FK_RegisteredServers_Clients]    Script Date: 07/28/2010 16:09:11 ******/
ALTER TABLE [RegisteredServers]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredServers_Clients] FOREIGN KEY([Cli_ID])
REFERENCES [Clients] ([Cli_ID])
GO
ALTER TABLE [RegisteredServers] CHECK CONSTRAINT [FK_RegisteredServers_Clients]
GO
/****** Object:  ForeignKey [FK_RegisteredServers_Products]    Script Date: 07/28/2010 16:09:11 ******/
ALTER TABLE [RegisteredServers]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredServers_Products] FOREIGN KEY([Prd_ID])
REFERENCES [Products] ([Prd_ID])
GO
ALTER TABLE [RegisteredServers] CHECK CONSTRAINT [FK_RegisteredServers_Products]
GO
/****** Object:  ForeignKey [FK_RegisteredPlugins_RegisteredServers]    Script Date: 07/28/2010 16:09:11 ******/
ALTER TABLE [RegisteredPlugins]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredPlugins_RegisteredServers] FOREIGN KEY([Srv_ID])
REFERENCES [RegisteredServers] ([Srv_ID])
GO
ALTER TABLE [RegisteredPlugins] CHECK CONSTRAINT [FK_RegisteredPlugins_RegisteredServers]
GO
";

    #endregion

    #region MasterKey

    string internalKey = @"qUSgZ8zwZ0X1YUSgZ8zwZUSgZ12bY8zwZZQqRaEMqtgMuTWZqE9PHVYJhXJhXIkxMmEBUuTWZmEBUF2rMqE9PHVYIkxMIkxMF2rMmEBUJhXqE9mEBUJhXmEBUPHVYJhXF2rMpqlIkxM159fVWZpKSM9RkM9RkMpajMaV159aVFhYZfVWZpKSMpajMpajMFhYZaV9RkMf";


    #endregion

    //[WebMethod]
    //public string GenerateDB(string token1, string token2, string token3)
    //{

    //  Cube cube = new Cube(internalKey);

    //  DateTime dt1 = Validator.ValidateToken(token1, cube);
    //  DateTime dt2 = Validator.ValidateToken(token2, cube);
    //  DateTime dt3 = Validator.ValidateToken(token3, cube);
    //  StringBuilder msgs = new StringBuilder();

    //  if ((dt1 == dt2) && (dt2 == dt3))
    //  {
    //    msgs.AppendLine("Dates validated");
    //    msgs.AppendLine();
    //    msgs.AppendLine();

    //    string connectionString = ConfigurationManager.ConnectionStrings["LicensingConnectionString"].ConnectionString;

    //    SqlConnection connection = new SqlConnection(connectionString);
    //    SqlCommand cmd = new SqlCommand(script, connection);
    //    cmd.CommandType = System.Data.CommandType.Text;


    //    connection.Open();
    //    try
    //    {
    //      List<string> scriptLines = script.Split('\r').Select(x => x.TrimEnd()).ToList();
    //      StringBuilder sb = new StringBuilder();

    //      foreach (string line in scriptLines)
    //      {
    //        if (line.ToUpper().Trim() == "GO")
    //        {
    //          cmd.CommandText = sb.ToString();
    //          msgs.AppendLine();
    //          msgs.AppendLine();
    //          msgs.AppendLine(cmd.CommandText);
    //          msgs.AppendLine();
    //          msgs.AppendLine();

    //          sb = new StringBuilder();
    //          try
    //          {
    //            cmd.ExecuteNonQuery();
    //          }
    //          catch (Exception ex)
    //          {
    //            msgs.AppendLine(ex.Message);
    //            msgs.AppendLine();
    //          }

    //        }
    //        else
    //        {
    //          if (!string.IsNullOrEmpty(line))
    //            sb.AppendLine(line);
    //        }
    //      }

    //    }
    //    finally
    //    {
    //      connection.Close();
    //      msgs.AppendLine();
    //      msgs.AppendLine("ConnectionClosed");
    //      msgs.AppendLine();
    //      msgs.AppendLine();

    //    }

    //  }
    //  return msgs.ToString();

    //}

  }
}
