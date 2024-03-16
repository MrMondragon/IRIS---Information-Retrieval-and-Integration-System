Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports QWhale.Common
Imports QWhale.Syntax
Imports QWhale.Editor
Imports QWhale.Syntax.Schemes

Public Class Form1
    Inherits System.Windows.Forms.Form
    <STAThread()> Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1)
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pnSettings As System.Windows.Forms.Panel
    Friend WithEvents pnDescription As System.Windows.Forms.Panel
    Friend WithEvents laDescription As System.Windows.Forms.Label
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbLanguages As System.Windows.Forms.ListBox
    Friend WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents laLanguages As System.Windows.Forms.Label
    Friend WithEvents syntaxEdit1 As QWhale.Editor.SyntaxEdit
    Friend WithEvents LanguageParser1 As QWhale.Syntax.Schemes.LanguageParser
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnSettings = New System.Windows.Forms.Panel
        Me.pnDescription = New System.Windows.Forms.Panel
        Me.laDescription = New System.Windows.Forms.Label
        Me.panel1 = New System.Windows.Forms.Panel
        Me.lbLanguages = New System.Windows.Forms.ListBox
        Me.panel2 = New System.Windows.Forms.Panel
        Me.laLanguages = New System.Windows.Forms.Label
        Me.syntaxEdit1 = New QWhale.Editor.SyntaxEdit(Me.components)
        Me.LanguageParser1 = New QWhale.Syntax.Schemes.LanguageParser
        Me.pnSettings.SuspendLayout()
        Me.pnDescription.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnSettings
        '
        Me.pnSettings.Controls.Add(Me.pnDescription)
        Me.pnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnSettings.Name = "pnSettings"
        Me.pnSettings.Size = New System.Drawing.Size(568, 24)
        Me.pnSettings.TabIndex = 2
        '
        'pnDescription
        '
        Me.pnDescription.Controls.Add(Me.laDescription)
        Me.pnDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnDescription.Location = New System.Drawing.Point(0, 0)
        Me.pnDescription.Name = "pnDescription"
        Me.pnDescription.Size = New System.Drawing.Size(568, 24)
        Me.pnDescription.TabIndex = 8
        '
        'laDescription
        '
        Me.laDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.laDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.laDescription.Location = New System.Drawing.Point(0, 0)
        Me.laDescription.Name = "laDescription"
        Me.laDescription.Size = New System.Drawing.Size(568, 24)
        Me.laDescription.TabIndex = 1
        Me.laDescription.Text = "This demo shows how to use predefined syntax highlighting schemes for various lan" & _
        "guages."
        Me.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.lbLanguages)
        Me.panel1.Controls.Add(Me.panel2)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.panel1.Location = New System.Drawing.Point(0, 24)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(136, 294)
        Me.panel1.TabIndex = 3
        '
        'lbLanguages
        '
        Me.lbLanguages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbLanguages.Location = New System.Drawing.Point(0, 24)
        Me.lbLanguages.Name = "lbLanguages"
        Me.lbLanguages.Size = New System.Drawing.Size(136, 264)
        Me.lbLanguages.TabIndex = 2
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.laLanguages)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel2.Location = New System.Drawing.Point(0, 0)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(136, 24)
        Me.panel2.TabIndex = 1
        '
        'laLanguages
        '
        Me.laLanguages.AutoSize = True
        Me.laLanguages.Location = New System.Drawing.Point(4, 4)
        Me.laLanguages.Name = "laLanguages"
        Me.laLanguages.Size = New System.Drawing.Size(60, 16)
        Me.laLanguages.TabIndex = 0
        Me.laLanguages.Text = "Languages"
        '
        'syntaxEdit1
        '
        Me.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window
        Me.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.syntaxEdit1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.syntaxEdit1.Lexer = Me.LanguageParser1
        Me.syntaxEdit1.Location = New System.Drawing.Point(136, 24)
        Me.syntaxEdit1.Name = "syntaxEdit1"
        Me.syntaxEdit1.Size = New System.Drawing.Size(432, 294)
        Me.syntaxEdit1.TabIndex = 4
        Me.syntaxEdit1.Text = "Imports System" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports system.Collections" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports System.Collections.Specialize" & _
        "d" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports System.Web" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports System.Web.UI" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports System.Web.UI.WebControls" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports System.Web.UI.HtmlControls" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports System.Data" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports System.Data.Sq" & _
        "lClient" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports PortalModulePage" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Imports Microsoft.VisualBasic" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Public Class" & _
        " Customize : Inherits PortalModulePage" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  Public pageName As String" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  Public " & _
        "txtPageName As HtmlInputControl" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  Public myDataGrid As DataGrid" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  Private m_" & _
        "pageIndex As Integer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  Private m_pageList() As String" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  Private m_Source As Ar" & _
        "rayList" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  Protected Sub Page_Load(sender As Object, e As EventArgs)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Di" & _
        "m hshTable as NameValueCollection = CType(Context.GetConfig(""system.web/dsnstore" & _
        """), NameValueCollection)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim dsn as String = CType(hshTable.Item(""portaldb""" & _
        "), String)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim myAdapter As SqlDataAdapter = New SqlDataAdapter()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    my" & _
        "Adapter.SelectCommand = New SqlCommand()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    myAdapter.SelectCommand.Connection" & _
        " = New SqlConnection(dsn)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    myAdapter.SelectCommand.CommandText =  ""GetPublic" & _
        "Modules""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    myAdapter.SelectCommand.CommandType = CommandType.StoredProcedure" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim myDataSet As DataSet = New DataSet()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    myAdapter.Fill(myDataSet,""R" & _
        "esults"")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    If (Not Request.Cookies(""_PageIndex"") Is Nothing) Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      m_" & _
        "pageIndex = Int32.Parse(Request.Cookies(""_PageIndex"").Value)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Else" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      m_" & _
        "pageIndex = 0" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    m_pageList = Split(UserState(""PageNames""),"";"")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    pageName = m_pageList(m_pageIndex)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim moduleHash As Hashtable = new" & _
        " Hashtable()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim leftModules As String = UserState(""PageModules_"" + m_pageI" & _
        "ndex.ToString() + ""L"")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim i As Integer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    If (leftModules <> """") Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Dim leftModuleList() As String = Split(leftModules,"";"")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      For i=0 " & _
        "To leftModuleList.Length-1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "         moduleHash(leftModuleList(i)) = True" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " Next" & _
        " i" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim rightModules As String = UserState(""PageModules_"" + m_" & _
        "pageIndex.ToString() + ""R"")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    If (rightModules <> """") Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Dim right" & _
        "ModuleList() As String = Split(rightModules, "";"")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      For i=0 To rightModul" & _
        "eList.Length-1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "         moduleHash(rightModuleList(i)) = True" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Next i" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "  End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim rows As DataRowCollection = myDataSet.Tables(0).Rows" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    " & _
        "m_Source = New ArrayList()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    For i=0 To rows.Count-1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Dim propertyBag" & _
        " As Hashtable = new Hashtable()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Dim j As Integer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      For j=0 To myDa" & _
        "taSet.Tables(0).Columns.Count-1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Dim value As Object = rows(i).Item(myDa" & _
        "taSet.Tables(0).Columns(j))" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        propertyBag(myDataSet.Tables(0).Columns(j)." & _
        "ToString()) = IIf(value Is Nothing, """", value.ToString())" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Next j" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "     " & _
        " If (Not moduleHash(propertyBag(""Source"")) Is Nothing) Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "         propertyBa" & _
        "g(""IsChecked"") = True" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      else" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "         propertyBag(""IsChecked"") = false" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  " & _
        "    End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      m_Source.Add(propertyBag)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Next i" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    myDataGrid.Data" & _
        "Source = m_Source" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    If (Not IsPostBack) Then DataBind()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  Pro" & _
        "tected Sub Submit_Click(sender As Object, e As EventArgs)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim sLeft As St" & _
        "ring = """"" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim sRight As String = """"" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim i As Integer" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    For i=0 To" & _
        " myDataGrid.Items.Count-1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Dim mSelected As HtmlInputCheckBox = CType(my" & _
        "DataGrid.Items(i).FindControl(""mSelected""), HtmlInputCheckBox)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Dim mType " & _
        "As Label = CType(myDataGrid.Items(i).FindControl(""mType""), Label)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      Dim hsh" & _
        " As Hashtable = CType(m_Source(i), Hashtable)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      If (mSelected.Checked) Th" & _
        "en" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        If (String.Compare (mType.Text ,""L"") = 0) Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          sLeft += h" & _
        "sh(""Source"").ToString() + "";""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        Else" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "          sRight += hsh(""Source"").T" & _
        "oString() + "";""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "        End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Next i" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    If (Request.C" & _
        "ookies(""_PageIndex"") Is Nothing ) Then m_pageIndex = 0" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    If (String.Compare" & _
        "(UserState(""UserId""),""ANONYMOUS"") <> 0) Then" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      UserState(""PageModules_"" + m" & _
        "_pageIndex.ToString() + ""L"") = TrimEnd(sLeft, "";"")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      UserState(""PageModules" & _
        "_"" + m_pageIndex.ToString() + ""R"") = TrimEnd(sRight, "";"")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    End If" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  m_pag" & _
        "eList(m_pageIndex) = txtPageName.Value" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim s As String = """"" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & " for i=0 T" & _
        "o m_pageList.Length-1" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "      s += m_pageList(i) + "";""" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Next i" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "   UserStat" & _
        "e(""PageNames"") = TrimEnd(s, "";"")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Response.Redirect(""/Quickstart/aspplus/sam" & _
        "ples/portal/VB/default.aspx"")" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  End Sub" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  Private Function TrimEnd(source " & _
        "As String, trimchar as String) As String" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    Dim tc() as Char = trimchar.ToCh" & _
        "arArray()" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "    TrimEnd = source.TrimEnd(tc)" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "  End Function" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "End Class"
        '
        'LanguageParser1
        '
        Me.LanguageParser1.DefaultState = 0
        Me.LanguageParser1.Language = QWhale.Syntax.Schemes.Languages.VbNet
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 318)
        Me.Controls.Add(Me.syntaxEdit1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.pnSettings)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.pnSettings.ResumeLayout(False)
        Me.pnDescription.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Structure LanguageInfo
        Public FileType As String
        Public FileExt As String
        Public Description As String
        Public Sub New(ByVal AFileType As String, ByVal AFileExt As String, ByVal ADescription As String)
            FileType = AFileType
            FileExt = AFileExt
            Description = ADescription
        End Sub
    End Structure
    
    Private LangItems As LanguageInfo() = New LanguageInfo() {New LanguageInfo("c#", "*.cs", "C# Language"), New LanguageInfo("assembler", "*.assembler", "Assembler Language"), New LanguageInfo("dfm", "*.dfm", "DFM File Language"), New LanguageInfo("cbuilder", "*.cbuilder", "C++ Builder Language"), New LanguageInfo("c", "*.c", "C Language"), New LanguageInfo("delphi", "*.delphi", "Delphi Language"), New LanguageInfo("html", "*.html", "HTML Language"), New LanguageInfo("htmlscripts", "*.htmlscripts", "ASP, VB, PHP, Java Scripts in HTML Language"), New LanguageInfo("js", "*.js", "Java Language"), New LanguageInfo("jscript", "*.jscript", "Java Script Language"), New LanguageInfo("perl", "*.perl", "Perl Language"), New LanguageInfo("php", "*.php", "PHP Language"), New LanguageInfo("python", "*.python", "Python Language"), New LanguageInfo("sql", "*.sql", "SQL Language"), New LanguageInfo("tcltk", "*.tcltk", "TclTk Language"), New LanguageInfo("unixshell", "*.unixshell", "Unix Shell Language"), New LanguageInfo("vbscript", "*.vbscript", "VB Script Language"), New LanguageInfo("vbs_script_html", "*.htm;*.html", "VB Script in HTML Language"), New LanguageInfo("vbnet", "*.vbnet", "Visual Basic NET Language"), New LanguageInfo("xml", "*.xml", "XML Language"), New LanguageInfo("xmlscripts", "*.xmlscripts", "PHP, VB, Java Scripts in XML Language"), New LanguageInfo("text", "*.txt", "Text files"), New LanguageInfo("batch", "*.batch", "Ms-Dos Batch Language"), New LanguageInfo("il", "*.il", "MSIL Language"), New LanguageInfo("ini", "*.ini", "Ini files"), New LanguageInfo("all", "*.*", "All files")}

    Private Dir As String = Application.StartupPath + "\..\..\..\"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim s As String() = [Enum].GetNames(GetType(Languages))
        lbLanguages.Items.AddRange(s)
        lbLanguages.Items.RemoveAt(lbLanguages.Items.Count - 1)
        LanguageParser1.Language = Languages.VbNet
        lbLanguages.SelectedIndex = LanguageParser1.Language
    End Sub

    Private Sub lbLanguages_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLanguages.SelectedIndexChanged
        UpdateLanguage(lbLanguages.SelectedIndex)
    End Sub
    Private Sub UpdateLanguage(ByVal index As Integer)
        LanguageParser1.Language = CType(index, Languages)
        Dim s As String = String.Empty
        If (GetFileByLanguage(LanguageParser1.Language, s)) Then
            syntaxEdit1.LoadFile(s)
        Else
            syntaxEdit1.Lines.Clear()
        End If
    End Sub

    Private Function FindLangByExt(ByVal ext As String) As Integer
        For i As Integer = 0 To LangItems.Length - 1
            If (LangItems(i).FileExt.Substring(1).ToLower() = ext.ToLower()) Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Function GetFileByLanguage(ByVal language As Languages, ByRef fileName As String) As Boolean
        fileName = String.Empty
        Dim info As DirectoryInfo = New DirectoryInfo(Dir + "text")
        If (info.Exists) Then
            If (language = Languages.Custom) Then
                fileName = Dir + "text\cs.txt"
            End If
            Dim idx As Integer = FindLangByExt("." + language.ToString())
            If (idx >= 0) Then
                fileName = info.FullName + "\" + LangItems(idx).FileType + ".txt"
            End If
        End If
        If fileName <> String.Empty Then
            Return New FileInfo(fileName).Exists
        Else
            Return False
        End If
        Return False
    End Function

End Class
