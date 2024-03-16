using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QWhale.Common;
using QWhale.Syntax;
using QWhale.Editor;

namespace Notification
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnDescription;
		private System.Windows.Forms.Label laDescription;
		private System.Windows.Forms.Label laSourceState;
		private System.Windows.Forms.Panel pnSettings;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel sbpPosition;
		private System.Windows.Forms.StatusBarPanel sbpModified;
		private System.Windows.Forms.StatusBarPanel sbpOverwrite;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tbSourceStates;
		private QWhale.Editor.SyntaxEdit syntaxEdit1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem miEdit;
		private System.Windows.Forms.MenuItem miMoveCaret;
		private System.Windows.Forms.MenuItem miSetBookmark;
		private System.Windows.Forms.MenuItem miUndo;
		private System.Windows.Forms.MenuItem miRedo;
		private System.Windows.Forms.MenuItem miDeleteLine;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem miSave;
		private System.Windows.Forms.MenuItem miInsertLine;
		private QWhale.Syntax.Parser parser1;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pnSettings = new System.Windows.Forms.Panel();
			this.laSourceState = new System.Windows.Forms.Label();
			this.pnDescription = new System.Windows.Forms.Panel();
			this.laDescription = new System.Windows.Forms.Label();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.sbpPosition = new System.Windows.Forms.StatusBarPanel();
			this.sbpModified = new System.Windows.Forms.StatusBarPanel();
			this.sbpOverwrite = new System.Windows.Forms.StatusBarPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tbSourceStates = new System.Windows.Forms.TextBox();
			this.syntaxEdit1 = new QWhale.Editor.SyntaxEdit(this.components);
			this.parser1 = new QWhale.Syntax.Parser();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.miEdit = new System.Windows.Forms.MenuItem();
			this.miMoveCaret = new System.Windows.Forms.MenuItem();
			this.miSetBookmark = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miUndo = new System.Windows.Forms.MenuItem();
			this.miRedo = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.miInsertLine = new System.Windows.Forms.MenuItem();
			this.miDeleteLine = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.miSave = new System.Windows.Forms.MenuItem();
			this.pnSettings.SuspendLayout();
			this.pnDescription.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sbpPosition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpModified)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpOverwrite)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnSettings
			// 
			this.pnSettings.Controls.Add(this.laSourceState);
			this.pnSettings.Controls.Add(this.pnDescription);
			this.pnSettings.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnSettings.Location = new System.Drawing.Point(0, 0);
			this.pnSettings.Name = "pnSettings";
			this.pnSettings.Size = new System.Drawing.Size(568, 48);
			this.pnSettings.TabIndex = 1;
			// 
			// laSourceState
			// 
			this.laSourceState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.laSourceState.AutoSize = true;
			this.laSourceState.Location = new System.Drawing.Point(368, 26);
			this.laSourceState.Name = "laSourceState";
			this.laSourceState.Size = new System.Drawing.Size(75, 16);
			this.laSourceState.TabIndex = 15;
			this.laSourceState.Text = "Source States";
			// 
			// pnDescription
			// 
			this.pnDescription.Controls.Add(this.laDescription);
			this.pnDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnDescription.Location = new System.Drawing.Point(0, 0);
			this.pnDescription.Name = "pnDescription";
			this.pnDescription.Size = new System.Drawing.Size(568, 24);
			this.pnDescription.TabIndex = 8;
			// 
			// laDescription
			// 
			this.laDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.laDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.laDescription.Location = new System.Drawing.Point(0, 0);
			this.laDescription.Name = "laDescription";
			this.laDescription.Size = new System.Drawing.Size(568, 24);
			this.laDescription.TabIndex = 1;
			this.laDescription.Text = "This demo shows how to respond notification when edit control\'s content is change" +
				"d.";
			this.laDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 296);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.sbpPosition,
																						  this.sbpModified,
																						  this.sbpOverwrite});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(568, 22);
			this.statusBar1.TabIndex = 14;
			// 
			// sbpOverwrite
			// 
			this.sbpOverwrite.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.sbpOverwrite.Width = 352;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tbSourceStates);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(360, 48);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(208, 248);
			this.panel1.TabIndex = 15;
			// 
			// tbSourceStates
			// 
			this.tbSourceStates.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbSourceStates.Enabled = false;
			this.tbSourceStates.Location = new System.Drawing.Point(0, 0);
			this.tbSourceStates.Multiline = true;
			this.tbSourceStates.Name = "tbSourceStates";
			this.tbSourceStates.Size = new System.Drawing.Size(208, 248);
			this.tbSourceStates.TabIndex = 14;
			this.tbSourceStates.Text = "None";
			// 
			// syntaxEdit1
			// 
			this.syntaxEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.syntaxEdit1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.syntaxEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.syntaxEdit1.Font = new System.Drawing.Font("Courier New", 10F);
			this.syntaxEdit1.Lexer = this.parser1;
			this.syntaxEdit1.Location = new System.Drawing.Point(0, 48);
			this.syntaxEdit1.Name = "syntaxEdit1";
			this.syntaxEdit1.Size = new System.Drawing.Size(360, 248);
			this.syntaxEdit1.TabIndex = 16;
			this.syntaxEdit1.Text = "using System;\r\n\r\npublic class Person\r\n{\r\n   public int age;\r\n   public string nam" +
				"e;\r\n}\r\n\r\npublic class MainClass \r\n{\r\n   static void Main() \r\n   {\r\n      Person " +
				"p = new Person(); \r\n\r\n      Console.Write(\"Name: {0}, Age: {1}\",p.name, p.age);\r" +
				"\n   }\r\n}";
			this.syntaxEdit1.SourceStateChanged += new QWhale.Editor.NotifyEvent(this.syntaxEdit1_SourceStateChanged);
			// 
			// parser1
			// 
			this.parser1.DefaultState = 0;
			this.parser1.XmlScheme = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<LexScheme xmlns:xsd=\"http://www.w3.org/" +
				"2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Autho" +
				"r>Quantum\tWhale</Author>\r\n  <Name>C# language</Name>\r\n  <Desc>Syntax Scheme for " +
				"C# Language</Desc>\r\n  <Copyright>Copyright Quantum Whale, 2003</Copyright>\r\n  <F" +
				"ileExtension>.cs</FileExtension>\r\n  <FileType>c#</FileType>\r\n  <Version>1.1</Ver" +
				"sion>\r\n  <Styles>\r\n    <Style>\r\n      <Name>idents</Name>\r\n      <ForeColor>Cont" +
				"rolText</ForeColor>\r\n      <Index>0</Index>\r\n    </Style>\r\n    <Style>\r\n      <N" +
				"ame>numbers</Name>\r\n      <ForeColor>ControlText</ForeColor>\r\n      <Index>1</In" +
				"dex>\r\n    </Style>\r\n    <Style>\r\n      <Name>reswords</Name>\r\n      <ForeColor>B" +
				"lue</ForeColor>\r\n      <Index>2</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>" +
				"comments</Name>\r\n      <ForeColor>Green</ForeColor>\r\n      <Index>3</Index>\r\n   " +
				"   <PlainText>true</PlainText>\r\n    </Style>\r\n    <Style>\r\n      <Name>xml_comme" +
				"nts</Name>\r\n      <ForeColor>Silver</ForeColor>\r\n      <Index>4</Index>\r\n      <" +
				"PlainText>true</PlainText>\r\n    </Style>\r\n    <Style>\r\n      <Name>symbol</Name>" +
				"\r\n      <ForeColor>Gray</ForeColor>\r\n      <Index>5</Index>\r\n    </Style>\r\n    <" +
				"Style>\r\n      <Name>whitespace</Name>\r\n      <ForeColor>WindowText</ForeColor>\r\n" +
				"      <Index>6</Index>\r\n    </Style>\r\n    <Style>\r\n      <Name>strings</Name>\r\n " +
				"     <ForeColor>ControlText</ForeColor>\r\n      <Index>7</Index>\r\n    </Style>\r\n " +
				"   <Style>\r\n      <Name>directives</Name>\r\n      <ForeColor>Blue</ForeColor>\r\n  " +
				"    <Index>8</Index>\r\n    </Style>\r\n  </Styles>\r\n  <States>\r\n    <State>\r\n      " +
				"<Name>normal</Name>\r\n      <CaseSensitive>true</CaseSensitive>\r\n      <SyntaxBlo" +
				"cks>\r\n        <SyntaxBlock>\r\n          <Name>directive</Name>\r\n          <LexSty" +
				"le>0</LexStyle>\r\n          <LeaveState>0</LeaveState>\r\n          <ResWordSets>\r\n" +
				"            <ResWordSet>\r\n              <Name />\r\n              <Index>0</Index>" +
				"\r\n              <ResWordStyle>8</ResWordStyle>\r\n              <ResWords>\r\n      " +
				"          <word>#region</word>\r\n                <word>#elif</word>\r\n            " +
				"    <word>#undef</word>\r\n                <word>#endif/word</word>\r\n             " +
				"   <word>#if</word>\r\n                <word>#line</word>\r\n                <word>#" +
				"warning</word>\r\n                <word>#endregion</word>\r\n                <word>#" +
				"else</word>\r\n                <word>#error</word>\r\n                <word>#define<" +
				"/word>\r\n              </ResWords>\r\n            </ResWordSet>\r\n          </ResWor" +
				"dSets>\r\n          <Expressions>\r\n            <string>\\#[a-zA-Z_][a-zA-Z0-9_]*</s" +
				"tring>\r\n          </Expressions>\r\n          <Index>0</Index>\r\n        </SyntaxBl" +
				"ock>\r\n        <SyntaxBlock>\r\n          <Name>idents</Name>\r\n          <LexStyle>" +
				"0</LexStyle>\r\n          <LeaveState>0</LeaveState>\r\n          <ResWordSets>\r\n   " +
				"         <ResWordSet>\r\n              <Name />\r\n              <Index>0</Index>\r\n " +
				"             <ResWordStyle>2</ResWordStyle>\r\n              <ResWords>\r\n         " +
				"       <word>protected</word>\r\n                <word>else</word>\r\n              " +
				"  <word>foreach</word>\r\n                <word>int</word>\r\n                <word>" +
				"switch</word>\r\n                <word>operator</word>\r\n                <word>uint" +
				"</word>\r\n                <word>out</word>\r\n                <word>ushort</word>\r\n" +
				"                <word>long</word>\r\n                <word>enum</word>\r\n          " +
				"      <word>class</word>\r\n                <word>ref</word>\r\n                <wor" +
				"d>char</word>\r\n                <word>false</word>\r\n                <word>this</w" +
				"ord>\r\n                <word>sbyte</word>\r\n                <word>throw</word>\r\n  " +
				"              <word>struct</word>\r\n                <word>checked</word>\r\n       " +
				"         <word>event</word>\r\n                <word>private</word>\r\n             " +
				"   <word>explicit</word>\r\n                <word>short</word>\r\n                <w" +
				"ord>interface</word>\r\n                <word>const</word>\r\n                <word>" +
				"float</word>\r\n                <word>using</word>\r\n                <word>while</w" +
				"ord>\r\n                <word>new</word>\r\n                <word>for</word>\r\n      " +
				"          <word>override</word>\r\n                <word>base</word>\r\n            " +
				"    <word>continue</word>\r\n                <word>goto</word>\r\n                <w" +
				"ord>finally</word>\r\n                <word>is</word>\r\n                <word>ulong" +
				"</word>\r\n                <word>try</word>\r\n                <word>namespace</word" +
				">\r\n                <word>break</word>\r\n                <word>do</word>\r\n        " +
				"        <word>word</word>\r\n                <word>return</word>\r\n                " +
				"<word>abstract</word>\r\n                <word>case</word>\r\n                <word>" +
				"void</word>\r\n                <word>unchecked</word>\r\n                <word>lock<" +
				"/word>\r\n                <word>default</word>\r\n                <word>public</word" +
				">\r\n                <word>extern</word>\r\n                <word>virtual</word>\r\n  " +
				"              <word>true</word>\r\n                <word>unsafe</word>\r\n          " +
				"      <word>if</word>\r\n                <word>null</word>\r\n                <word>" +
				"catch</word>\r\n                <word>params</word>\r\n                <word>bool</w" +
				"ord>\r\n                <word>typeof</word>\r\n                <word>in</word>\r\n    " +
				"            <word>sealed</word>\r\n                <word>readonly</word>\r\n        " +
				"        <word>byte</word>\r\n                <word>decimal</word>\r\n               " +
				" <word>static</word>\r\n                <word>object</word>\r\n                <word" +
				">sizeof</word>\r\n                <word>internal</word>\r\n                <word>fix" +
				"ed</word>\r\n                <word>implicit</word>\r\n                <word>double</" +
				"word>\r\n                <word>delegate</word>\r\n              </ResWords>\r\n       " +
				"     </ResWordSet>\r\n          </ResWordSets>\r\n          <Expressions>\r\n         " +
				"   <string>[a-zA-Z_][a-zA-Z0-9_]*</string>\r\n            <string>@[a-zA-Z_][a-zA-" +
				"Z0-9_]*</string>\r\n          </Expressions>\r\n          <Index>1</Index>\r\n        " +
				"</SyntaxBlock>\r\n        <SyntaxBlock>\r\n          <Name>comment1</Name>\r\n        " +
				"  <LexStyle>3</LexStyle>\r\n          <LeaveState>1</LeaveState>\r\n          <Expre" +
				"ssions>\r\n            <string>/\\*</string>\r\n          </Expressions>\r\n          <" +
				"Index>2</Index>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n          <Name>" +
				"comment2</Name>\r\n          <LexStyle>4</LexStyle>\r\n          <LeaveState>2</Leav" +
				"eState>\r\n          <Expressions>\r\n            <string>///</string>\r\n          </" +
				"Expressions>\r\n          <Index>3</Index>\r\n        </SyntaxBlock>\r\n        <Synta" +
				"xBlock>\r\n          <Name>comment3</Name>\r\n          <LexStyle>3</LexStyle>\r\n    " +
				"      <LeaveState>0</LeaveState>\r\n          <Expressions>\r\n            <string>/" +
				"/.*</string>\r\n          </Expressions>\r\n          <Index>4</Index>\r\n        </Sy" +
				"ntaxBlock>\r\n        <SyntaxBlock>\r\n          <Name>numbers</Name>\r\n          <Le" +
				"xStyle>1</LexStyle>\r\n          <LeaveState>0</LeaveState>\r\n          <Expression" +
				"s>\r\n            <string>([0-9]+\\.[0-9]*(e|E)(\\+|\\-)?[0-9]+)|([0-9]+\\.[0-9]*)|(0(" +
				"x|X)[0-9a-fA-F]+)|([0-9]+)</string>\r\n          </Expressions>\r\n          <Index>" +
				"5</Index>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n          <Name>string" +
				"1</Name>\r\n          <LexStyle>7</LexStyle>\r\n          <LeaveState>0</LeaveState>" +
				"\r\n          <Expressions>\r\n            <string>(\"\")|\"((((\\\\\")|(\"\")|[^\"])*\")|(((\\" +
				"\\\")|(\"\")|[^\"])*))</string>\r\n            <string>@(\"\")|\"((((\\\\\")|(\"\")|[^\"])*\")|((" +
				"(\\\\\")|(\"\")|[^\"])*))</string>\r\n            <string>(\'\')|\'((((\\\\\')|(\'\')|[^\'])*\')|(" +
				"((\\\\\')|(\'\')|[^\'])*))</string>\r\n          </Expressions>\r\n          <Index>6</Ind" +
				"ex>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n          <Name>whitespace</" +
				"Name>\r\n          <LexStyle>6</LexStyle>\r\n          <LeaveState>0</LeaveState>\r\n " +
				"         <Expressions>\r\n            <string>(\\s)+</string>\r\n          </Expressi" +
				"ons>\r\n          <Index>7</Index>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r" +
				"\n          <Name>symbol</Name>\r\n          <LexStyle>5</LexStyle>\r\n          <Lea" +
				"veState>0</LeaveState>\r\n          <Expressions>\r\n            <string>\\W</string>" +
				"\r\n          </Expressions>\r\n          <Index>8</Index>\r\n        </SyntaxBlock>\r\n" +
				"      </SyntaxBlocks>\r\n      <Index>0</Index>\r\n    </State>\r\n    <State>\r\n      " +
				"<Name>comment</Name>\r\n      <CaseSensitive>true</CaseSensitive>\r\n      <SyntaxBl" +
				"ocks>\r\n        <SyntaxBlock>\r\n          <Name>comment21</Name>\r\n          <LexSt" +
				"yle>3</LexStyle>\r\n          <LeaveState>0</LeaveState>\r\n          <Expressions>\r" +
				"\n            <string>\\*/</string>\r\n          </Expressions>\r\n          <Index>0<" +
				"/Index>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n          <Name>comment2" +
				"2</Name>\r\n          <LexStyle>3</LexStyle>\r\n          <LeaveState>1</LeaveState>" +
				"\r\n          <Expressions>\r\n            <string>((?!\\*/).)+</string>\r\n          <" +
				"/Expressions>\r\n          <Index>1</Index>\r\n        </SyntaxBlock>\r\n      </Synta" +
				"xBlocks>\r\n      <Index>1</Index>\r\n    </State>\r\n    <State>\r\n      <Name>comment" +
				"XML</Name>\r\n      <CaseSensitive>true</CaseSensitive>\r\n      <SyntaxBlocks>\r\n   " +
				"     <SyntaxBlock>\r\n          <Name>comment31</Name>\r\n          <LexStyle>4</Lex" +
				"Style>\r\n          <LeaveState>4</LeaveState>\r\n          <Expressions>\r\n         " +
				"   <string>\\u003C</string>\r\n          </Expressions>\r\n          <Index>0</Index>" +
				"\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n          <Name>comment32</Name" +
				">\r\n          <LexStyle>4</LexStyle>\r\n          <LeaveState>0</LeaveState>\r\n     " +
				"     <Expressions>\r\n            <string>$</string>\r\n          </Expressions>\r\n  " +
				"        <Index>1</Index>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n       " +
				"   <Name>comment33</Name>\r\n          <LexStyle>3</LexStyle>\r\n          <LeaveSta" +
				"te>3</LeaveState>\r\n          <Expressions>\r\n            <string>[^\\u003C]*</stri" +
				"ng>\r\n          </Expressions>\r\n          <Index>2</Index>\r\n        </SyntaxBlock" +
				">\r\n      </SyntaxBlocks>\r\n      <Index>2</Index>\r\n    </State>\r\n    <State>\r\n   " +
				"   <Name>xml_comment</Name>\r\n      <CaseSensitive>true</CaseSensitive>\r\n      <S" +
				"yntaxBlocks>\r\n        <SyntaxBlock>\r\n          <Name>comment41</Name>\r\n         " +
				" <LexStyle>4</LexStyle>\r\n          <LeaveState>4</LeaveState>\r\n          <Expres" +
				"sions>\r\n            <string>\\u003C</string>\r\n          </Expressions>\r\n         " +
				" <Index>0</Index>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n          <Nam" +
				"e>comment42</Name>\r\n          <LexStyle>3</LexStyle>\r\n          <LeaveState>0</L" +
				"eaveState>\r\n          <Expressions>\r\n            <string>$</string>\r\n          <" +
				"/Expressions>\r\n          <Index>1</Index>\r\n        </SyntaxBlock>\r\n        <Synt" +
				"axBlock>\r\n          <Name>comment43</Name>\r\n          <LexStyle>3</LexStyle>\r\n  " +
				"        <LeaveState>3</LeaveState>\r\n          <Expressions>\r\n            <string" +
				">[^\\u003C]*</string>\r\n          </Expressions>\r\n          <Index>2</Index>\r\n    " +
				"    </SyntaxBlock>\r\n      </SyntaxBlocks>\r\n      <Index>3</Index>\r\n    </State>\r" +
				"\n    <State>\r\n      <Name>tag_comment</Name>\r\n      <CaseSensitive>true</CaseSen" +
				"sitive>\r\n      <SyntaxBlocks>\r\n        <SyntaxBlock>\r\n          <Name>comment51<" +
				"/Name>\r\n          <LexStyle>4</LexStyle>\r\n          <LeaveState>0</LeaveState>\r\n" +
				"          <Expressions>\r\n            <string>$</string>\r\n          </Expressions" +
				">\r\n          <Index>0</Index>\r\n        </SyntaxBlock>\r\n        <SyntaxBlock>\r\n  " +
				"        <Name>comment52</Name>\r\n          <LexStyle>4</LexStyle>\r\n          <Lea" +
				"veState>3</LeaveState>\r\n          <Expressions>\r\n            <string>\\u003E</str" +
				"ing>\r\n          </Expressions>\r\n          <Index>1</Index>\r\n        </SyntaxBloc" +
				"k>\r\n        <SyntaxBlock>\r\n          <Name>comment53</Name>\r\n          <LexStyle" +
				">4</LexStyle>\r\n          <LeaveState>4</LeaveState>\r\n          <Expressions>\r\n  " +
				"          <string>[^\\u003E]*</string>\r\n          </Expressions>\r\n          <Inde" +
				"x>2</Index>\r\n        </SyntaxBlock>\r\n      </SyntaxBlocks>\r\n      <Index>4</Inde" +
				"x>\r\n    </State>\r\n  </States>\r\n</LexScheme>";
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miEdit});
			// 
			// miEdit
			// 
			this.miEdit.Index = 0;
			this.miEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miMoveCaret,
																				   this.miSetBookmark,
																				   this.menuItem1,
																				   this.miUndo,
																				   this.miRedo,
																				   this.menuItem2,
																				   this.miInsertLine,
																				   this.miDeleteLine,
																				   this.menuItem3,
																				   this.miSave});
			this.miEdit.Text = "Edit";
			this.miEdit.Popup += new System.EventHandler(this.miEdit_Popup);
			// 
			// miMoveCaret
			// 
			this.miMoveCaret.Index = 0;
			this.miMoveCaret.Text = "Move Caret";
			this.miMoveCaret.Click += new System.EventHandler(this.miMoveCaret_Click);
			// 
			// miSetBookmark
			// 
			this.miSetBookmark.Index = 1;
			this.miSetBookmark.Text = "Set Bookmark";
			this.miSetBookmark.Click += new System.EventHandler(this.miSetBookmark_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 2;
			this.menuItem1.Text = "-";
			// 
			// miUndo
			// 
			this.miUndo.Index = 3;
			this.miUndo.Text = "Undo";
			this.miUndo.Click += new System.EventHandler(this.miUndo_Click);
			// 
			// miRedo
			// 
			this.miRedo.Index = 4;
			this.miRedo.Text = "Redo";
			this.miRedo.Click += new System.EventHandler(this.miRedo_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Text = "-";
			// 
			// miInsertLine
			// 
			this.miInsertLine.Index = 6;
			this.miInsertLine.Text = "Insert Line";
			this.miInsertLine.Click += new System.EventHandler(this.miInsertLine_Click);
			// 
			// miDeleteLine
			// 
			this.miDeleteLine.Index = 7;
			this.miDeleteLine.Text = "Delete Line";
			this.miDeleteLine.Click += new System.EventHandler(this.miDeleteLine_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 8;
			this.menuItem3.Text = "-";
			// 
			// miSave
			// 
			this.miSave.Index = 9;
			this.miSave.Text = "Save";
			this.miSave.Click += new System.EventHandler(this.miSave_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 318);
			this.Controls.Add(this.syntaxEdit1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.pnSettings);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pnSettings.ResumeLayout(false);
			this.pnDescription.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sbpPosition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpModified)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpOverwrite)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void DoSourceStateChanged(object sender, NotifyEventArgs e)
		{
			UpdateTextBox(e.State);
		}
		private void UpdateTextBox(NotifyState state)
		{
			string s = string.Empty;
			foreach(int i in Enum.GetValues(typeof(NotifyState)))
			{
				if (((NotifyState)i & state) != 0)
					s = s + ((s == string.Empty) ? string.Format("{0}", (NotifyState)i) : string.Format(",{0}", (NotifyState)i));
			}
			tbSourceStates.Lines = s.Split(',');
		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
			syntaxEdit1.SourceStateChanged += new NotifyEvent(DoSourceStateChanged);
		}
		public void UpdateStatusBar()
		{
			sbpPosition.Text = string.Format("Line: {0}, Char: {1}", syntaxEdit1.Source.Position.Y, syntaxEdit1.Source.Position.X);
			if (syntaxEdit1.Source.Readonly)
				sbpModified.Text = "ReadOnly";
			else
				if (syntaxEdit1.Source.Modified)
				sbpModified.Text = "Modified";
			else
				sbpModified.Text = string.Empty;
			if (syntaxEdit1.Source.OverWrite)
				sbpOverwrite.Text = "Overwrite";
			else
				sbpOverwrite.Text = string.Empty;
		}

		private void syntaxEdit1_SourceStateChanged(object sender, QWhale.Editor.NotifyEventArgs e)
		{
			if (e.State == NotifyState.PositionChanged)
				UpdateStatusBar();
		}

		private void miMoveCaret_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.MoveCharRight();
		}

		private void miSetBookmark_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.Source.BookMarks.SetBookMark(syntaxEdit1.Position, 11);
		}

		private void miUndo_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.Source.Undo();
		}

		private void miRedo_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.Source.Redo();
		}

		private void miInsertLine_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.Source.BeginUpdate();
			try
			{
				syntaxEdit1.MoveTo(int.MaxValue, syntaxEdit1.Position.Y);
				syntaxEdit1.Source.NewLine();
			}
			finally
			{
				syntaxEdit1.Source.EndUpdate();
			}
		}

		private void miDeleteLine_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.Source.BeginUpdate();
			try
			{
				syntaxEdit1.MoveTo(0, syntaxEdit1.Position.Y);
				syntaxEdit1.Source.DeleteRight(int.MaxValue);
				syntaxEdit1.Source.UnBreakLine();
			}
			finally
			{
				syntaxEdit1.Source.EndUpdate();
			}
		}

		private void miSave_Click(object sender, System.EventArgs e)
		{
			syntaxEdit1.Modified = false;
		}

		private void miEdit_Popup(object sender, System.EventArgs e)
		{
			miUndo.Enabled = syntaxEdit1.Source.CanUndo();
			miRedo.Enabled = syntaxEdit1.Source.CanRedo();
		}
	}
}
