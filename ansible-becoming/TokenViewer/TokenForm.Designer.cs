namespace TokenViewer
{
    partial class TokenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabPage tabPageMain;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.GroupBox groupBoxToken;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label lblTokenType;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label lblImpLevel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.TabPage tabPageGroups;
            System.Windows.Forms.ColumnHeader columnHeaderName;
            System.Windows.Forms.ColumnHeader columnHeaderFlags;
            System.Windows.Forms.TabPage tabPageDefaultDacl;
            System.Windows.Forms.ColumnHeader columnHeaderGroup;
            System.Windows.Forms.ColumnHeader columnHeaderAccess;
            System.Windows.Forms.ColumnHeader columnHeaderDaclFlags;
            System.Windows.Forms.ColumnHeader columnHeaderDaclType;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.GroupBox groupBoxDuplicate;
            System.Windows.Forms.Label lblILForDup;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.Label label29;
            System.Windows.Forms.Label label28;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.GroupBox groupBoxSafer;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.GroupBox groupBox4;
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.ColumnHeader columnHeader5;
            System.Windows.Forms.ColumnHeader columnHeader6;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelSecurity;
            System.Windows.Forms.Label lblProcessId;
            System.Windows.Forms.Label lblImagePath;
            System.Windows.Forms.Label lblCommandLine;
            System.Windows.Forms.GroupBox groupProcess;
            System.Windows.Forms.Label lblThreadId;
            System.Windows.Forms.Label lblThreadName;
            System.Windows.Forms.Label label30;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TokenForm));
            this.groupBoxSource = new System.Windows.Forms.GroupBox();
            this.txtSourceId = new System.Windows.Forms.TextBox();
            this.txtSourceName = new System.Windows.Forms.TextBox();
            this.txtIsElevated = new System.Windows.Forms.TextBox();
            this.btnSetIL = new System.Windows.Forms.Button();
            this.comboBoxIL = new System.Windows.Forms.ComboBox();
            this.txtOriginLoginId = new System.Windows.Forms.TextBox();
            this.btnLinkedToken = new System.Windows.Forms.Button();
            this.txtElevationType = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtSessionId = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUserSid = new System.Windows.Forms.Label();
            this.txtUserSid = new System.Windows.Forms.TextBox();
            this.txtTokenType = new System.Windows.Forms.TextBox();
            this.txtModifiedId = new System.Windows.Forms.TextBox();
            this.txtImpLevel = new System.Windows.Forms.TextBox();
            this.txtAuthId = new System.Windows.Forms.TextBox();
            this.txtTokenId = new System.Windows.Forms.TextBox();
            this.listViewGroups = new System.Windows.Forms.ListView();
            this.contextMenuStripGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewDefDacl = new System.Windows.Forms.ListView();
            this.contextMenuStripDefaultDacl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllDaclToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItemDacl = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAsSDDLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPrimaryGroup = new System.Windows.Forms.TextBox();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.btnImpersonate = new System.Windows.Forms.Button();
            this.comboBoxILForDup = new System.Windows.Forms.ComboBox();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.comboBoxImpLevel = new System.Windows.Forms.ComboBox();
            this.comboBoxTokenType = new System.Windows.Forms.ComboBox();
            this.checkBoxUseNetLogon = new System.Windows.Forms.CheckBox();
            this.checkBoxUseWmi = new System.Windows.Forms.CheckBox();
            this.checkBoxMakeInteractive = new System.Windows.Forms.CheckBox();
            this.btnCreateProcess = new System.Windows.Forms.Button();
            this.txtCommandLine = new System.Windows.Forms.TextBox();
            this.txtTokenFlags = new System.Windows.Forms.TextBox();
            this.txtTrustLevel = new System.Windows.Forms.TextBox();
            this.btnToggleVirtualizationEnabled = new System.Windows.Forms.Button();
            this.txtHandleAccess = new System.Windows.Forms.TextBox();
            this.btnToggleUIAccess = new System.Windows.Forms.Button();
            this.treeViewSecurityAttributes = new System.Windows.Forms.TreeView();
            this.llbSecurityAttributes = new System.Windows.Forms.Label();
            this.txtMandatoryILPolicy = new System.Windows.Forms.TextBox();
            this.txtVirtualizationEnabled = new System.Windows.Forms.TextBox();
            this.txtVirtualizationAllowed = new System.Windows.Forms.TextBox();
            this.txtSandboxInert = new System.Windows.Forms.TextBox();
            this.txtUIAccess = new System.Windows.Forms.TextBox();
            this.btnCreateSandbox = new System.Windows.Forms.Button();
            this.comboBoxSaferLevel = new System.Windows.Forms.ComboBox();
            this.checkBoxSaferMakeInert = new System.Windows.Forms.CheckBox();
            this.btnComputeSafer = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileContents = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnEditPermissions = new System.Windows.Forms.Button();
            this.securityDescriptorViewerControl = new NtApiDotNet.Forms.SecurityDescriptorViewerControl();
            this.txtProcessCommandLine = new System.Windows.Forms.TextBox();
            this.txtProcessId = new System.Windows.Forms.TextBox();
            this.txtProcessImagePath = new System.Windows.Forms.TextBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPagePrivs = new System.Windows.Forms.TabPage();
            this.listViewPrivs = new System.Windows.Forms.ListView();
            this.contextMenuStripPrivileges = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enablePrivilegeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePrivilegeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllPrivsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItemPrivs = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageRestricted = new System.Windows.Forms.TabPage();
            this.listViewRestrictedSids = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStripDefaultGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopyGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopySidsGeneric = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageAppContainer = new System.Windows.Forms.TabPage();
            this.txtPackageSid = new System.Windows.Forms.TextBox();
            this.txtACNumber = new System.Windows.Forms.TextBox();
            this.listViewCapabilities = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.txtPackageName = new System.Windows.Forms.TextBox();
            this.tabPageMisc = new System.Windows.Forms.TabPage();
            this.tabPageOperations = new System.Windows.Forms.TabPage();
            this.tabPageTokenSource = new System.Windows.Forms.TabPage();
            this.groupThread = new System.Windows.Forms.GroupBox();
            this.txtThreadId = new System.Windows.Forms.TextBox();
            this.txtThreadName = new System.Windows.Forms.TextBox();
            this.tabPageSecurity = new System.Windows.Forms.TabPage();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDpapiContents = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            tabPageMain = new System.Windows.Forms.TabPage();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            groupBoxToken = new System.Windows.Forms.GroupBox();
            label25 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            lblTokenType = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            lblImpLevel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tabPageGroups = new System.Windows.Forms.TabPage();
            columnHeaderName = new System.Windows.Forms.ColumnHeader();
            columnHeaderFlags = new System.Windows.Forms.ColumnHeader();
            tabPageDefaultDacl = new System.Windows.Forms.TabPage();
            columnHeaderGroup = new System.Windows.Forms.ColumnHeader();
            columnHeaderAccess = new System.Windows.Forms.ColumnHeader();
            columnHeaderDaclFlags = new System.Windows.Forms.ColumnHeader();
            columnHeaderDaclType = new System.Windows.Forms.ColumnHeader();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            groupBoxDuplicate = new System.Windows.Forms.GroupBox();
            lblILForDup = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label16 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label29 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            groupBoxSafer = new System.Windows.Forms.GroupBox();
            label21 = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            label24 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            label27 = new System.Windows.Forms.Label();
            tableLayoutPanelSecurity = new System.Windows.Forms.TableLayoutPanel();
            lblProcessId = new System.Windows.Forms.Label();
            lblImagePath = new System.Windows.Forms.Label();
            lblCommandLine = new System.Windows.Forms.Label();
            groupProcess = new System.Windows.Forms.GroupBox();
            lblThreadId = new System.Windows.Forms.Label();
            lblThreadName = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            tabPageMain.SuspendLayout();
            this.groupBoxSource.SuspendLayout();
            groupBoxToken.SuspendLayout();
            tabPageGroups.SuspendLayout();
            this.contextMenuStripGroups.SuspendLayout();
            tabPageDefaultDacl.SuspendLayout();
            this.contextMenuStripDefaultDacl.SuspendLayout();
            groupBoxDuplicate.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBoxSafer.SuspendLayout();
            groupBox4.SuspendLayout();
            tableLayoutPanelSecurity.SuspendLayout();
            groupProcess.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPagePrivs.SuspendLayout();
            this.contextMenuStripPrivileges.SuspendLayout();
            this.tabPageRestricted.SuspendLayout();
            this.contextMenuStripDefaultGroups.SuspendLayout();
            this.tabPageAppContainer.SuspendLayout();
            this.tabPageMisc.SuspendLayout();
            this.tabPageOperations.SuspendLayout();
            this.tabPageTokenSource.SuspendLayout();
            this.groupThread.SuspendLayout();
            this.tabPageSecurity.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageMain
            // 
            tabPageMain.Controls.Add(this.groupBoxSource);
            tabPageMain.Controls.Add(groupBoxToken);
            tabPageMain.Location = new System.Drawing.Point(4, 29);
            tabPageMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageMain.Name = "tabPageMain";
            tabPageMain.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageMain.Size = new System.Drawing.Size(625, 709);
            tabPageMain.TabIndex = 0;
            tabPageMain.Text = "Main Details";
            tabPageMain.UseVisualStyleBackColor = true;
            // 
            // groupBoxSource
            // 
            this.groupBoxSource.Controls.Add(this.txtSourceId);
            this.groupBoxSource.Controls.Add(label7);
            this.groupBoxSource.Controls.Add(this.txtSourceName);
            this.groupBoxSource.Controls.Add(label6);
            this.groupBoxSource.Location = new System.Drawing.Point(8, 532);
            this.groupBoxSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSource.Name = "groupBoxSource";
            this.groupBoxSource.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSource.Size = new System.Drawing.Size(604, 118);
            this.groupBoxSource.TabIndex = 20;
            this.groupBoxSource.TabStop = false;
            this.groupBoxSource.Text = "Source";
            // 
            // txtSourceId
            // 
            this.txtSourceId.Location = new System.Drawing.Point(153, 69);
            this.txtSourceId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSourceId.Name = "txtSourceId";
            this.txtSourceId.ReadOnly = true;
            this.txtSourceId.Size = new System.Drawing.Size(188, 27);
            this.txtSourceId.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(11, 74);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(25, 20);
            label7.TabIndex = 21;
            label7.Text = "Id:";
            // 
            // txtSourceName
            // 
            this.txtSourceName.Location = new System.Drawing.Point(153, 29);
            this.txtSourceName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSourceName.Name = "txtSourceName";
            this.txtSourceName.ReadOnly = true;
            this.txtSourceName.Size = new System.Drawing.Size(188, 27);
            this.txtSourceName.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(11, 34);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(52, 20);
            label6.TabIndex = 19;
            label6.Text = "Name:";
            // 
            // groupBoxToken
            // 
            groupBoxToken.Controls.Add(this.txtIsElevated);
            groupBoxToken.Controls.Add(label25);
            groupBoxToken.Controls.Add(this.btnSetIL);
            groupBoxToken.Controls.Add(this.comboBoxIL);
            groupBoxToken.Controls.Add(this.txtOriginLoginId);
            groupBoxToken.Controls.Add(label13);
            groupBoxToken.Controls.Add(this.btnLinkedToken);
            groupBoxToken.Controls.Add(this.txtElevationType);
            groupBoxToken.Controls.Add(label8);
            groupBoxToken.Controls.Add(this.lblUsername);
            groupBoxToken.Controls.Add(this.txtSessionId);
            groupBoxToken.Controls.Add(this.txtUsername);
            groupBoxToken.Controls.Add(label5);
            groupBoxToken.Controls.Add(this.lblUserSid);
            groupBoxToken.Controls.Add(this.txtUserSid);
            groupBoxToken.Controls.Add(lblTokenType);
            groupBoxToken.Controls.Add(label4);
            groupBoxToken.Controls.Add(this.txtTokenType);
            groupBoxToken.Controls.Add(this.txtModifiedId);
            groupBoxToken.Controls.Add(lblImpLevel);
            groupBoxToken.Controls.Add(label3);
            groupBoxToken.Controls.Add(this.txtImpLevel);
            groupBoxToken.Controls.Add(this.txtAuthId);
            groupBoxToken.Controls.Add(label1);
            groupBoxToken.Controls.Add(label2);
            groupBoxToken.Controls.Add(this.txtTokenId);
            groupBoxToken.Location = new System.Drawing.Point(8, 9);
            groupBoxToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxToken.Name = "groupBoxToken";
            groupBoxToken.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxToken.Size = new System.Drawing.Size(604, 512);
            groupBoxToken.TabIndex = 19;
            groupBoxToken.TabStop = false;
            groupBoxToken.Text = "Token";
            // 
            // txtIsElevated
            // 
            this.txtIsElevated.Location = new System.Drawing.Point(153, 466);
            this.txtIsElevated.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIsElevated.Name = "txtIsElevated";
            this.txtIsElevated.ReadOnly = true;
            this.txtIsElevated.Size = new System.Drawing.Size(188, 27);
            this.txtIsElevated.TabIndex = 27;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(11, 471);
            label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(83, 20);
            label25.TabIndex = 26;
            label25.Text = "Is Elevated:";
            // 
            // btnSetIL
            // 
            this.btnSetIL.Enabled = false;
            this.btnSetIL.Location = new System.Drawing.Point(384, 341);
            this.btnSetIL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetIL.Name = "btnSetIL";
            this.btnSetIL.Size = new System.Drawing.Size(135, 35);
            this.btnSetIL.TabIndex = 25;
            this.btnSetIL.Text = "Set Integrity Level";
            this.btnSetIL.UseVisualStyleBackColor = true;
            this.btnSetIL.Click += new System.EventHandler(this.btnSetIL_Click);
            // 
            // comboBoxIL
            // 
            this.comboBoxIL.FormattingEnabled = true;
            this.comboBoxIL.Location = new System.Drawing.Point(153, 345);
            this.comboBoxIL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxIL.Name = "comboBoxIL";
            this.comboBoxIL.Size = new System.Drawing.Size(188, 28);
            this.comboBoxIL.TabIndex = 24;
            this.comboBoxIL.SelectedIndexChanged += new System.EventHandler(this.comboBoxIL_SelectedIndexChanged);
            this.comboBoxIL.TextUpdate += new System.EventHandler(this.comboBoxIL_TextUpdate);
            // 
            // txtOriginLoginId
            // 
            this.txtOriginLoginId.Location = new System.Drawing.Point(153, 262);
            this.txtOriginLoginId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOriginLoginId.Name = "txtOriginLoginId";
            this.txtOriginLoginId.ReadOnly = true;
            this.txtOriginLoginId.Size = new System.Drawing.Size(188, 27);
            this.txtOriginLoginId.TabIndex = 23;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(11, 268);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(113, 20);
            label13.TabIndex = 22;
            label13.Text = "Origin Login ID:";
            // 
            // btnLinkedToken
            // 
            this.btnLinkedToken.Location = new System.Drawing.Point(384, 422);
            this.btnLinkedToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLinkedToken.Name = "btnLinkedToken";
            this.btnLinkedToken.Size = new System.Drawing.Size(135, 35);
            this.btnLinkedToken.TabIndex = 21;
            this.btnLinkedToken.Text = "Linked Token";
            this.btnLinkedToken.UseVisualStyleBackColor = true;
            this.btnLinkedToken.Click += new System.EventHandler(this.btnLinkedToken_Click);
            // 
            // txtElevationType
            // 
            this.txtElevationType.Location = new System.Drawing.Point(153, 426);
            this.txtElevationType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtElevationType.Name = "txtElevationType";
            this.txtElevationType.ReadOnly = true;
            this.txtElevationType.Size = new System.Drawing.Size(188, 27);
            this.txtElevationType.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(11, 431);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(108, 20);
            label8.TabIndex = 19;
            label8.Text = "Elevation Type:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(8, 25);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(41, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "User:";
            // 
            // txtSessionId
            // 
            this.txtSessionId.Location = new System.Drawing.Point(153, 386);
            this.txtSessionId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSessionId.Name = "txtSessionId";
            this.txtSessionId.ReadOnly = true;
            this.txtSessionId.Size = new System.Drawing.Size(188, 27);
            this.txtSessionId.TabIndex = 18;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(153, 25);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(355, 27);
            this.txtUsername.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(11, 391);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(80, 20);
            label5.TabIndex = 17;
            label5.Text = "Session ID:";
            // 
            // lblUserSid
            // 
            this.lblUserSid.AutoSize = true;
            this.lblUserSid.Location = new System.Drawing.Point(8, 68);
            this.lblUserSid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserSid.Name = "lblUserSid";
            this.lblUserSid.Size = new System.Drawing.Size(68, 20);
            this.lblUserSid.TabIndex = 2;
            this.lblUserSid.Text = "User SID:";
            // 
            // txtUserSid
            // 
            this.txtUserSid.Location = new System.Drawing.Point(153, 65);
            this.txtUserSid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserSid.Name = "txtUserSid";
            this.txtUserSid.ReadOnly = true;
            this.txtUserSid.Size = new System.Drawing.Size(355, 27);
            this.txtUserSid.TabIndex = 3;
            // 
            // lblTokenType
            // 
            lblTokenType.AutoSize = true;
            lblTokenType.Location = new System.Drawing.Point(11, 109);
            lblTokenType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTokenType.Name = "lblTokenType";
            lblTokenType.Size = new System.Drawing.Size(86, 20);
            lblTokenType.TabIndex = 4;
            lblTokenType.Text = "Token Type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(11, 349);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(105, 20);
            label4.TabIndex = 14;
            label4.Text = "Integrity Level:";
            // 
            // txtTokenType
            // 
            this.txtTokenType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTokenType.Location = new System.Drawing.Point(153, 105);
            this.txtTokenType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTokenType.Name = "txtTokenType";
            this.txtTokenType.ReadOnly = true;
            this.txtTokenType.Size = new System.Drawing.Size(188, 27);
            this.txtTokenType.TabIndex = 5;
            // 
            // txtModifiedId
            // 
            this.txtModifiedId.Location = new System.Drawing.Point(153, 305);
            this.txtModifiedId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtModifiedId.Name = "txtModifiedId";
            this.txtModifiedId.ReadOnly = true;
            this.txtModifiedId.Size = new System.Drawing.Size(188, 27);
            this.txtModifiedId.TabIndex = 13;
            // 
            // lblImpLevel
            // 
            lblImpLevel.AutoSize = true;
            lblImpLevel.Location = new System.Drawing.Point(11, 148);
            lblImpLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblImpLevel.Name = "lblImpLevel";
            lblImpLevel.Size = new System.Drawing.Size(146, 20);
            lblImpLevel.TabIndex = 6;
            lblImpLevel.Text = "Impersonation Level:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(11, 309);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(92, 20);
            label3.TabIndex = 12;
            label3.Text = "Modified ID:";
            // 
            // txtImpLevel
            // 
            this.txtImpLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtImpLevel.Location = new System.Drawing.Point(153, 142);
            this.txtImpLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtImpLevel.Name = "txtImpLevel";
            this.txtImpLevel.ReadOnly = true;
            this.txtImpLevel.Size = new System.Drawing.Size(188, 27);
            this.txtImpLevel.TabIndex = 7;
            // 
            // txtAuthId
            // 
            this.txtAuthId.Location = new System.Drawing.Point(153, 222);
            this.txtAuthId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAuthId.Name = "txtAuthId";
            this.txtAuthId.ReadOnly = true;
            this.txtAuthId.Size = new System.Drawing.Size(188, 27);
            this.txtAuthId.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 188);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(70, 20);
            label1.TabIndex = 8;
            label1.Text = "Token ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 228);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(128, 20);
            label2.TabIndex = 10;
            label2.Text = "Authentication ID:";
            // 
            // txtTokenId
            // 
            this.txtTokenId.Location = new System.Drawing.Point(153, 182);
            this.txtTokenId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTokenId.Name = "txtTokenId";
            this.txtTokenId.ReadOnly = true;
            this.txtTokenId.Size = new System.Drawing.Size(188, 27);
            this.txtTokenId.TabIndex = 9;
            // 
            // tabPageGroups
            // 
            tabPageGroups.Controls.Add(this.listViewGroups);
            tabPageGroups.Location = new System.Drawing.Point(4, 25);
            tabPageGroups.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageGroups.Name = "tabPageGroups";
            tabPageGroups.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageGroups.Size = new System.Drawing.Size(625, 713);
            tabPageGroups.TabIndex = 1;
            tabPageGroups.Text = "Groups";
            tabPageGroups.UseVisualStyleBackColor = true;
            // 
            // listViewGroups
            // 
            this.listViewGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeaderName, columnHeaderFlags });
            this.listViewGroups.ContextMenuStrip = this.contextMenuStripGroups;
            this.listViewGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGroups.FullRowSelect = true;
            this.listViewGroups.HideSelection = false;
            this.listViewGroups.Location = new System.Drawing.Point(4, 5);
            this.listViewGroups.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewGroups.Name = "listViewGroups";
            this.listViewGroups.Size = new System.Drawing.Size(617, 703);
            this.listViewGroups.TabIndex = 0;
            this.listViewGroups.UseCompatibleStateImageBehavior = false;
            this.listViewGroups.View = System.Windows.Forms.View.Details;
            this.listViewGroups.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 210;
            // 
            // columnHeaderFlags
            // 
            columnHeaderFlags.Text = "Flags";
            columnHeaderFlags.Width = 194;
            // 
            // contextMenuStripGroups
            // 
            this.contextMenuStripGroups.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.enableGroupToolStripMenuItem, this.selectAllGroupsToolStripMenuItem, this.copyToolStripMenuItem, this.copySidToolStripMenuItem });
            this.contextMenuStripGroups.Name = "contextMenuStripGroups";
            this.contextMenuStripGroups.Size = new System.Drawing.Size(193, 100);
            this.contextMenuStripGroups.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripGroups_Opening);
            // 
            // enableGroupToolStripMenuItem
            // 
            this.enableGroupToolStripMenuItem.Name = "enableGroupToolStripMenuItem";
            this.enableGroupToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.enableGroupToolStripMenuItem.Text = "Enable Group";
            this.enableGroupToolStripMenuItem.Click += new System.EventHandler(this.enableGroupToolStripMenuItem_Click);
            // 
            // selectAllGroupsToolStripMenuItem
            // 
            this.selectAllGroupsToolStripMenuItem.Name = "selectAllGroupsToolStripMenuItem";
            this.selectAllGroupsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllGroupsToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.selectAllGroupsToolStripMenuItem.Text = "Select All";
            this.selectAllGroupsToolStripMenuItem.Click += new System.EventHandler(this.selectAllGroupsToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyListViewItems);
            // 
            // copySidToolStripMenuItem
            // 
            this.copySidToolStripMenuItem.Name = "copySidToolStripMenuItem";
            this.copySidToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.copySidToolStripMenuItem.Text = "Copy Sid";
            this.copySidToolStripMenuItem.Click += new System.EventHandler(this.CopySidListViewItems);
            // 
            // tabPageDefaultDacl
            // 
            tabPageDefaultDacl.Controls.Add(this.listViewDefDacl);
            tabPageDefaultDacl.Controls.Add(label10);
            tabPageDefaultDacl.Controls.Add(this.txtPrimaryGroup);
            tabPageDefaultDacl.Controls.Add(label9);
            tabPageDefaultDacl.Controls.Add(this.txtOwner);
            tabPageDefaultDacl.Location = new System.Drawing.Point(4, 25);
            tabPageDefaultDacl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageDefaultDacl.Name = "tabPageDefaultDacl";
            tabPageDefaultDacl.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageDefaultDacl.Size = new System.Drawing.Size(625, 713);
            tabPageDefaultDacl.TabIndex = 2;
            tabPageDefaultDacl.Text = "Default Dacl";
            tabPageDefaultDacl.UseVisualStyleBackColor = true;
            // 
            // listViewDefDacl
            // 
            this.listViewDefDacl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewDefDacl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeaderGroup, columnHeaderAccess, columnHeaderDaclFlags, columnHeaderDaclType });
            this.listViewDefDacl.ContextMenuStrip = this.contextMenuStripDefaultDacl;
            this.listViewDefDacl.FullRowSelect = true;
            this.listViewDefDacl.HideSelection = false;
            this.listViewDefDacl.Location = new System.Drawing.Point(4, 106);
            this.listViewDefDacl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewDefDacl.Name = "listViewDefDacl";
            this.listViewDefDacl.Size = new System.Drawing.Size(613, 582);
            this.listViewDefDacl.TabIndex = 10;
            this.listViewDefDacl.UseCompatibleStateImageBehavior = false;
            this.listViewDefDacl.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderGroup
            // 
            columnHeaderGroup.Text = "Group";
            columnHeaderGroup.Width = 160;
            // 
            // columnHeaderAccess
            // 
            columnHeaderAccess.Text = "Access";
            columnHeaderAccess.Width = 83;
            // 
            // columnHeaderDaclFlags
            // 
            columnHeaderDaclFlags.Text = "Flags";
            columnHeaderDaclFlags.Width = 103;
            // 
            // columnHeaderDaclType
            // 
            columnHeaderDaclType.Text = "Type";
            // 
            // contextMenuStripDefaultDacl
            // 
            this.contextMenuStripDefaultDacl.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripDefaultDacl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.selectAllDaclToolStripMenuItem, this.copyToolStripMenuItemDacl, this.copyAsSDDLToolStripMenuItem });
            this.contextMenuStripDefaultDacl.Name = "contextMenuStripDefaultDacl";
            this.contextMenuStripDefaultDacl.Size = new System.Drawing.Size(193, 76);
            // 
            // selectAllDaclToolStripMenuItem
            // 
            this.selectAllDaclToolStripMenuItem.Name = "selectAllDaclToolStripMenuItem";
            this.selectAllDaclToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllDaclToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.selectAllDaclToolStripMenuItem.Text = "Select All";
            this.selectAllDaclToolStripMenuItem.Click += new System.EventHandler(this.selectAllDaclToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItemDacl
            // 
            this.copyToolStripMenuItemDacl.Name = "copyToolStripMenuItemDacl";
            this.copyToolStripMenuItemDacl.Size = new System.Drawing.Size(192, 24);
            this.copyToolStripMenuItemDacl.Text = "Copy";
            this.copyToolStripMenuItemDacl.Click += new System.EventHandler(this.CopyListViewItems);
            // 
            // copyAsSDDLToolStripMenuItem
            // 
            this.copyAsSDDLToolStripMenuItem.Name = "copyAsSDDLToolStripMenuItem";
            this.copyAsSDDLToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.copyAsSDDLToolStripMenuItem.Text = "Copy as SDDL";
            this.copyAsSDDLToolStripMenuItem.Click += new System.EventHandler(this.copyAsSDDLToolStripMenuItem_Click);
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(29, 61);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(107, 20);
            label10.TabIndex = 8;
            label10.Text = "Primary Group:";
            // 
            // txtPrimaryGroup
            // 
            this.txtPrimaryGroup.Location = new System.Drawing.Point(175, 61);
            this.txtPrimaryGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrimaryGroup.Name = "txtPrimaryGroup";
            this.txtPrimaryGroup.ReadOnly = true;
            this.txtPrimaryGroup.Size = new System.Drawing.Size(355, 27);
            this.txtPrimaryGroup.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(29, 21);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(108, 20);
            label9.TabIndex = 6;
            label9.Text = "Default Owner:";
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(175, 21);
            this.txtOwner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(355, 27);
            this.txtOwner.TabIndex = 7;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(29, 21);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(110, 20);
            label11.TabIndex = 8;
            label11.Text = "Package Name:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(29, 102);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(166, 20);
            label12.TabIndex = 11;
            label12.Text = "App Container Number:";
            // 
            // groupBoxDuplicate
            // 
            groupBoxDuplicate.Controls.Add(this.btnImpersonate);
            groupBoxDuplicate.Controls.Add(lblILForDup);
            groupBoxDuplicate.Controls.Add(this.comboBoxILForDup);
            groupBoxDuplicate.Controls.Add(this.btnDuplicate);
            groupBoxDuplicate.Controls.Add(label15);
            groupBoxDuplicate.Controls.Add(this.comboBoxImpLevel);
            groupBoxDuplicate.Controls.Add(label14);
            groupBoxDuplicate.Controls.Add(this.comboBoxTokenType);
            groupBoxDuplicate.Location = new System.Drawing.Point(4, 9);
            groupBoxDuplicate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxDuplicate.Name = "groupBoxDuplicate";
            groupBoxDuplicate.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxDuplicate.Size = new System.Drawing.Size(608, 179);
            groupBoxDuplicate.TabIndex = 0;
            groupBoxDuplicate.TabStop = false;
            groupBoxDuplicate.Text = "Duplicate Token";
            // 
            // btnImpersonate
            // 
            this.btnImpersonate.Location = new System.Drawing.Point(451, 118);
            this.btnImpersonate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImpersonate.Name = "btnImpersonate";
            this.btnImpersonate.Size = new System.Drawing.Size(100, 35);
            this.btnImpersonate.TabIndex = 7;
            this.btnImpersonate.Text = "Round-Trip";
            this.toolTip.SetToolTip(this.btnImpersonate, "This impersonates the token then reads it back from the thread");
            this.btnImpersonate.UseVisualStyleBackColor = true;
            this.btnImpersonate.Click += new System.EventHandler(this.btnImpersonate_Click);
            // 
            // lblILForDup
            // 
            lblILForDup.AutoSize = true;
            lblILForDup.Location = new System.Drawing.Point(345, 39);
            lblILForDup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblILForDup.Name = "lblILForDup";
            lblILForDup.Size = new System.Drawing.Size(66, 20);
            lblILForDup.TabIndex = 6;
            lblILForDup.Text = "Token IL:";
            // 
            // comboBoxILForDup
            // 
            this.comboBoxILForDup.FormattingEnabled = true;
            this.comboBoxILForDup.Location = new System.Drawing.Point(423, 34);
            this.comboBoxILForDup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxILForDup.Name = "comboBoxILForDup";
            this.comboBoxILForDup.Size = new System.Drawing.Size(160, 28);
            this.comboBoxILForDup.TabIndex = 5;
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Location = new System.Drawing.Point(12, 118);
            this.btnDuplicate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(100, 35);
            this.btnDuplicate.TabIndex = 4;
            this.btnDuplicate.Text = "Duplicate";
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(8, 75);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(146, 20);
            label15.TabIndex = 3;
            label15.Text = "Impersonation Level:";
            // 
            // comboBoxImpLevel
            // 
            this.comboBoxImpLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImpLevel.FormattingEnabled = true;
            this.comboBoxImpLevel.Location = new System.Drawing.Point(156, 71);
            this.comboBoxImpLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxImpLevel.Name = "comboBoxImpLevel";
            this.comboBoxImpLevel.Size = new System.Drawing.Size(160, 28);
            this.comboBoxImpLevel.TabIndex = 2;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(8, 34);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(86, 20);
            label14.TabIndex = 1;
            label14.Text = "Token Type:";
            // 
            // comboBoxTokenType
            // 
            this.comboBoxTokenType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTokenType.FormattingEnabled = true;
            this.comboBoxTokenType.Location = new System.Drawing.Point(156, 29);
            this.comboBoxTokenType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTokenType.Name = "comboBoxTokenType";
            this.comboBoxTokenType.Size = new System.Drawing.Size(160, 28);
            this.comboBoxTokenType.TabIndex = 0;
            this.comboBoxTokenType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTokenType_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.checkBoxUseNetLogon);
            groupBox1.Controls.Add(this.checkBoxUseWmi);
            groupBox1.Controls.Add(this.checkBoxMakeInteractive);
            groupBox1.Controls.Add(this.btnCreateProcess);
            groupBox1.Controls.Add(this.txtCommandLine);
            groupBox1.Controls.Add(label16);
            groupBox1.Location = new System.Drawing.Point(4, 198);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox1.Size = new System.Drawing.Size(608, 140);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create Process";
            // 
            // checkBoxUseNetLogon
            // 
            this.checkBoxUseNetLogon.AutoSize = true;
            this.checkBoxUseNetLogon.Location = new System.Drawing.Point(372, 91);
            this.checkBoxUseNetLogon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxUseNetLogon.Name = "checkBoxUseNetLogon";
            this.checkBoxUseNetLogon.Size = new System.Drawing.Size(129, 24);
            this.checkBoxUseNetLogon.TabIndex = 5;
            this.checkBoxUseNetLogon.Text = "Use Net Logon";
            this.checkBoxUseNetLogon.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseWmi
            // 
            this.checkBoxUseWmi.AutoSize = true;
            this.checkBoxUseWmi.Location = new System.Drawing.Point(269, 91);
            this.checkBoxUseWmi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxUseWmi.Name = "checkBoxUseWmi";
            this.checkBoxUseWmi.Size = new System.Drawing.Size(90, 24);
            this.checkBoxUseWmi.TabIndex = 4;
            this.checkBoxUseWmi.Text = "Use WMI";
            this.checkBoxUseWmi.UseVisualStyleBackColor = true;
            // 
            // checkBoxMakeInteractive
            // 
            this.checkBoxMakeInteractive.AutoSize = true;
            this.checkBoxMakeInteractive.Location = new System.Drawing.Point(120, 91);
            this.checkBoxMakeInteractive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxMakeInteractive.Name = "checkBoxMakeInteractive";
            this.checkBoxMakeInteractive.Size = new System.Drawing.Size(140, 24);
            this.checkBoxMakeInteractive.TabIndex = 3;
            this.checkBoxMakeInteractive.Text = "Make Interactive";
            this.checkBoxMakeInteractive.UseVisualStyleBackColor = true;
            // 
            // btnCreateProcess
            // 
            this.btnCreateProcess.Location = new System.Drawing.Point(12, 85);
            this.btnCreateProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateProcess.Name = "btnCreateProcess";
            this.btnCreateProcess.Size = new System.Drawing.Size(100, 35);
            this.btnCreateProcess.TabIndex = 2;
            this.btnCreateProcess.Text = "Create";
            this.btnCreateProcess.UseVisualStyleBackColor = true;
            this.btnCreateProcess.Click += new System.EventHandler(this.btnCreateProcess_Click);
            // 
            // txtCommandLine
            // 
            this.txtCommandLine.Location = new System.Drawing.Point(123, 34);
            this.txtCommandLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommandLine.Name = "txtCommandLine";
            this.txtCommandLine.Size = new System.Drawing.Size(409, 27);
            this.txtCommandLine.TabIndex = 1;
            this.txtCommandLine.Text = "cmd.exe";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(8, 39);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(112, 20);
            label16.TabIndex = 0;
            label16.Text = "Command Line:";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            groupBox2.Controls.Add(label29);
            groupBox2.Controls.Add(this.txtTokenFlags);
            groupBox2.Controls.Add(label28);
            groupBox2.Controls.Add(this.txtTrustLevel);
            groupBox2.Controls.Add(this.btnToggleVirtualizationEnabled);
            groupBox2.Controls.Add(label26);
            groupBox2.Controls.Add(this.txtHandleAccess);
            groupBox2.Controls.Add(this.btnToggleUIAccess);
            groupBox2.Controls.Add(this.treeViewSecurityAttributes);
            groupBox2.Controls.Add(this.llbSecurityAttributes);
            groupBox2.Controls.Add(label22);
            groupBox2.Controls.Add(this.txtMandatoryILPolicy);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(this.txtVirtualizationEnabled);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(this.txtVirtualizationAllowed);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(this.txtSandboxInert);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(this.txtUIAccess);
            groupBox2.Location = new System.Drawing.Point(11, 9);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox2.Size = new System.Drawing.Size(601, 676);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Additional Properties";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(8, 312);
            label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(89, 20);
            label29.TabIndex = 24;
            label29.Text = "Token Flags:";
            // 
            // txtTokenFlags
            // 
            this.txtTokenFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTokenFlags.Location = new System.Drawing.Point(161, 308);
            this.txtTokenFlags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTokenFlags.Name = "txtTokenFlags";
            this.txtTokenFlags.ReadOnly = true;
            this.txtTokenFlags.Size = new System.Drawing.Size(431, 27);
            this.txtTokenFlags.TabIndex = 25;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(8, 271);
            label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(81, 20);
            label28.TabIndex = 22;
            label28.Text = "Trust Level:";
            // 
            // txtTrustLevel
            // 
            this.txtTrustLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrustLevel.Location = new System.Drawing.Point(161, 266);
            this.txtTrustLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTrustLevel.Name = "txtTrustLevel";
            this.txtTrustLevel.ReadOnly = true;
            this.txtTrustLevel.Size = new System.Drawing.Size(431, 27);
            this.txtTrustLevel.TabIndex = 23;
            // 
            // btnToggleVirtualizationEnabled
            // 
            this.btnToggleVirtualizationEnabled.Location = new System.Drawing.Point(313, 139);
            this.btnToggleVirtualizationEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnToggleVirtualizationEnabled.Name = "btnToggleVirtualizationEnabled";
            this.btnToggleVirtualizationEnabled.Size = new System.Drawing.Size(100, 35);
            this.btnToggleVirtualizationEnabled.TabIndex = 21;
            this.btnToggleVirtualizationEnabled.Text = "Toggle";
            this.btnToggleVirtualizationEnabled.UseVisualStyleBackColor = true;
            this.btnToggleVirtualizationEnabled.Click += new System.EventHandler(this.btnToggleVirtualizationEnabled_Click);
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(8, 231);
            label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(108, 20);
            label26.TabIndex = 19;
            label26.Text = "Handle Access:";
            // 
            // txtHandleAccess
            // 
            this.txtHandleAccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHandleAccess.Location = new System.Drawing.Point(161, 226);
            this.txtHandleAccess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHandleAccess.Name = "txtHandleAccess";
            this.txtHandleAccess.ReadOnly = true;
            this.txtHandleAccess.Size = new System.Drawing.Size(431, 27);
            this.txtHandleAccess.TabIndex = 20;
            // 
            // btnToggleUIAccess
            // 
            this.btnToggleUIAccess.Location = new System.Drawing.Point(313, 18);
            this.btnToggleUIAccess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnToggleUIAccess.Name = "btnToggleUIAccess";
            this.btnToggleUIAccess.Size = new System.Drawing.Size(100, 35);
            this.btnToggleUIAccess.TabIndex = 18;
            this.btnToggleUIAccess.Text = "Toggle";
            this.btnToggleUIAccess.UseVisualStyleBackColor = true;
            this.btnToggleUIAccess.Click += new System.EventHandler(this.btnToggleUIAccess_Click);
            // 
            // treeViewSecurityAttributes
            // 
            this.treeViewSecurityAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewSecurityAttributes.Location = new System.Drawing.Point(12, 381);
            this.treeViewSecurityAttributes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeViewSecurityAttributes.Name = "treeViewSecurityAttributes";
            this.treeViewSecurityAttributes.Size = new System.Drawing.Size(580, 262);
            this.treeViewSecurityAttributes.TabIndex = 17;
            // 
            // llbSecurityAttributes
            // 
            this.llbSecurityAttributes.AutoSize = true;
            this.llbSecurityAttributes.Location = new System.Drawing.Point(8, 358);
            this.llbSecurityAttributes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llbSecurityAttributes.Name = "llbSecurityAttributes";
            this.llbSecurityAttributes.Size = new System.Drawing.Size(133, 20);
            this.llbSecurityAttributes.TabIndex = 16;
            this.llbSecurityAttributes.Text = "Security Attributes:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(8, 186);
            label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(141, 20);
            label22.TabIndex = 14;
            label22.Text = "Mandatory IL Policy:";
            // 
            // txtMandatoryILPolicy
            // 
            this.txtMandatoryILPolicy.Location = new System.Drawing.Point(161, 181);
            this.txtMandatoryILPolicy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMandatoryILPolicy.Name = "txtMandatoryILPolicy";
            this.txtMandatoryILPolicy.ReadOnly = true;
            this.txtMandatoryILPolicy.Size = new System.Drawing.Size(251, 27);
            this.txtMandatoryILPolicy.TabIndex = 15;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(8, 146);
            label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(158, 20);
            label20.TabIndex = 12;
            label20.Text = "Virtualization Enabled:";
            // 
            // txtVirtualizationEnabled
            // 
            this.txtVirtualizationEnabled.Location = new System.Drawing.Point(161, 141);
            this.txtVirtualizationEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVirtualizationEnabled.Name = "txtVirtualizationEnabled";
            this.txtVirtualizationEnabled.ReadOnly = true;
            this.txtVirtualizationEnabled.Size = new System.Drawing.Size(143, 27);
            this.txtVirtualizationEnabled.TabIndex = 13;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(8, 106);
            label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(159, 20);
            label19.TabIndex = 10;
            label19.Text = "Virtualization Allowed:";
            // 
            // txtVirtualizationAllowed
            // 
            this.txtVirtualizationAllowed.Location = new System.Drawing.Point(161, 101);
            this.txtVirtualizationAllowed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVirtualizationAllowed.Name = "txtVirtualizationAllowed";
            this.txtVirtualizationAllowed.ReadOnly = true;
            this.txtVirtualizationAllowed.Size = new System.Drawing.Size(143, 27);
            this.txtVirtualizationAllowed.TabIndex = 11;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(8, 66);
            label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(104, 20);
            label18.TabIndex = 8;
            label18.Text = "Sandbox Inert:";
            // 
            // txtSandboxInert
            // 
            this.txtSandboxInert.Location = new System.Drawing.Point(161, 60);
            this.txtSandboxInert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSandboxInert.Name = "txtSandboxInert";
            this.txtSandboxInert.ReadOnly = true;
            this.txtSandboxInert.Size = new System.Drawing.Size(143, 27);
            this.txtSandboxInert.TabIndex = 9;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(8, 25);
            label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(74, 20);
            label17.TabIndex = 6;
            label17.Text = "UI Access:";
            // 
            // txtUIAccess
            // 
            this.txtUIAccess.Location = new System.Drawing.Point(161, 20);
            this.txtUIAccess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUIAccess.Name = "txtUIAccess";
            this.txtUIAccess.ReadOnly = true;
            this.txtUIAccess.Size = new System.Drawing.Size(143, 27);
            this.txtUIAccess.TabIndex = 7;
            // 
            // groupBoxSafer
            // 
            groupBoxSafer.Controls.Add(this.btnCreateSandbox);
            groupBoxSafer.Controls.Add(label21);
            groupBoxSafer.Controls.Add(this.comboBoxSaferLevel);
            groupBoxSafer.Controls.Add(this.checkBoxSaferMakeInert);
            groupBoxSafer.Controls.Add(this.btnComputeSafer);
            groupBoxSafer.Location = new System.Drawing.Point(4, 346);
            groupBoxSafer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxSafer.Name = "groupBoxSafer";
            groupBoxSafer.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxSafer.Size = new System.Drawing.Size(611, 139);
            groupBoxSafer.TabIndex = 2;
            groupBoxSafer.TabStop = false;
            groupBoxSafer.Text = "Restricted Tokens";
            // 
            // btnCreateSandbox
            // 
            this.btnCreateSandbox.Location = new System.Drawing.Point(469, 86);
            this.btnCreateSandbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateSandbox.Name = "btnCreateSandbox";
            this.btnCreateSandbox.Size = new System.Drawing.Size(133, 35);
            this.btnCreateSandbox.TabIndex = 8;
            this.btnCreateSandbox.Text = "Create Sandbox";
            this.btnCreateSandbox.UseVisualStyleBackColor = true;
            this.btnCreateSandbox.Click += new System.EventHandler(this.btnCreateSandbox_Click);
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(11, 48);
            label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(84, 20);
            label21.TabIndex = 6;
            label21.Text = "Safer Level:";
            // 
            // comboBoxSaferLevel
            // 
            this.comboBoxSaferLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSaferLevel.FormattingEnabled = true;
            this.comboBoxSaferLevel.Location = new System.Drawing.Point(135, 42);
            this.comboBoxSaferLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxSaferLevel.Name = "comboBoxSaferLevel";
            this.comboBoxSaferLevel.Size = new System.Drawing.Size(160, 28);
            this.comboBoxSaferLevel.TabIndex = 5;
            // 
            // checkBoxSaferMakeInert
            // 
            this.checkBoxSaferMakeInert.AutoSize = true;
            this.checkBoxSaferMakeInert.Location = new System.Drawing.Point(319, 49);
            this.checkBoxSaferMakeInert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxSaferMakeInert.Name = "checkBoxSaferMakeInert";
            this.checkBoxSaferMakeInert.Size = new System.Drawing.Size(101, 24);
            this.checkBoxSaferMakeInert.TabIndex = 4;
            this.checkBoxSaferMakeInert.Text = "Make Inert";
            this.checkBoxSaferMakeInert.UseVisualStyleBackColor = true;
            // 
            // btnComputeSafer
            // 
            this.btnComputeSafer.Location = new System.Drawing.Point(12, 86);
            this.btnComputeSafer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnComputeSafer.Name = "btnComputeSafer";
            this.btnComputeSafer.Size = new System.Drawing.Size(100, 35);
            this.btnComputeSafer.TabIndex = 3;
            this.btnComputeSafer.Text = "Create Safer";
            this.btnComputeSafer.UseVisualStyleBackColor = true;
            this.btnComputeSafer.Click += new System.EventHandler(this.btnComputeSafer_Click);
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(this.btnCreate);
            groupBox4.Controls.Add(this.btnBrowse);
            groupBox4.Controls.Add(label24);
            groupBox4.Controls.Add(this.txtFileContents);
            groupBox4.Controls.Add(this.txtFilePath);
            groupBox4.Controls.Add(label23);
            groupBox4.Location = new System.Drawing.Point(4, 494);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBox4.Size = new System.Drawing.Size(608, 154);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Impersonate and Create File";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(484, 61);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 35);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(484, 22);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 35);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(11, 69);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(70, 20);
            label24.TabIndex = 3;
            label24.Text = "Contents:";
            // 
            // txtFileContents
            // 
            this.txtFileContents.Location = new System.Drawing.Point(87, 65);
            this.txtFileContents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFileContents.Multiline = true;
            this.txtFileContents.Name = "txtFileContents";
            this.txtFileContents.Size = new System.Drawing.Size(372, 78);
            this.txtFileContents.TabIndex = 2;
            this.txtFileContents.Text = "Hello World!";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(87, 25);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(372, 27);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.Text = "c:\\windows\\test.txt";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(11, 29);
            label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(67, 20);
            label23.TabIndex = 0;
            label23.Text = "File Path:";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Name";
            columnHeader5.Width = 210;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Flags";
            columnHeader6.Width = 194;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(29, 65);
            label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(93, 20);
            label27.TabIndex = 13;
            label27.Text = "Package SID:";
            // 
            // tableLayoutPanelSecurity
            // 
            tableLayoutPanelSecurity.ColumnCount = 1;
            tableLayoutPanelSecurity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSecurity.Controls.Add(this.btnEditPermissions, 0, 1);
            tableLayoutPanelSecurity.Controls.Add(this.securityDescriptorViewerControl, 0, 0);
            tableLayoutPanelSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelSecurity.Location = new System.Drawing.Point(3, 2);
            tableLayoutPanelSecurity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tableLayoutPanelSecurity.Name = "tableLayoutPanelSecurity";
            tableLayoutPanelSecurity.RowCount = 2;
            tableLayoutPanelSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelSecurity.Size = new System.Drawing.Size(619, 709);
            tableLayoutPanelSecurity.TabIndex = 1;
            // 
            // btnEditPermissions
            // 
            this.btnEditPermissions.Location = new System.Drawing.Point(4, 669);
            this.btnEditPermissions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditPermissions.Name = "btnEditPermissions";
            this.btnEditPermissions.Size = new System.Drawing.Size(100, 35);
            this.btnEditPermissions.TabIndex = 17;
            this.btnEditPermissions.Text = "Edit";
            this.btnEditPermissions.UseVisualStyleBackColor = true;
            this.btnEditPermissions.Click += new System.EventHandler(this.btnEditPermissions_Click);
            // 
            // securityDescriptorViewerControl
            // 
            this.securityDescriptorViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.securityDescriptorViewerControl.Location = new System.Drawing.Point(3, 2);
            this.securityDescriptorViewerControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.securityDescriptorViewerControl.Name = "securityDescriptorViewerControl";
            this.securityDescriptorViewerControl.Size = new System.Drawing.Size(613, 660);
            this.securityDescriptorViewerControl.TabIndex = 0;
            // 
            // lblProcessId
            // 
            lblProcessId.AutoSize = true;
            lblProcessId.Location = new System.Drawing.Point(9, 35);
            lblProcessId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblProcessId.Name = "lblProcessId";
            lblProcessId.Size = new System.Drawing.Size(80, 20);
            lblProcessId.TabIndex = 0;
            lblProcessId.Text = "Process ID:";
            // 
            // lblImagePath
            // 
            lblImagePath.AutoSize = true;
            lblImagePath.Location = new System.Drawing.Point(9, 75);
            lblImagePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblImagePath.Name = "lblImagePath";
            lblImagePath.Size = new System.Drawing.Size(86, 20);
            lblImagePath.TabIndex = 2;
            lblImagePath.Text = "Image Path:";
            // 
            // lblCommandLine
            // 
            lblCommandLine.AutoSize = true;
            lblCommandLine.Location = new System.Drawing.Point(9, 115);
            lblCommandLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCommandLine.Name = "lblCommandLine";
            lblCommandLine.Size = new System.Drawing.Size(112, 20);
            lblCommandLine.TabIndex = 4;
            lblCommandLine.Text = "Command Line:";
            // 
            // groupProcess
            // 
            groupProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            groupProcess.Controls.Add(this.txtProcessCommandLine);
            groupProcess.Controls.Add(lblProcessId);
            groupProcess.Controls.Add(lblCommandLine);
            groupProcess.Controls.Add(this.txtProcessId);
            groupProcess.Controls.Add(this.txtProcessImagePath);
            groupProcess.Controls.Add(lblImagePath);
            groupProcess.Location = new System.Drawing.Point(15, 9);
            groupProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupProcess.Name = "groupProcess";
            groupProcess.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupProcess.Size = new System.Drawing.Size(597, 162);
            groupProcess.TabIndex = 6;
            groupProcess.TabStop = false;
            groupProcess.Text = "Process Information";
            // 
            // txtProcessCommandLine
            // 
            this.txtProcessCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessCommandLine.Location = new System.Drawing.Point(124, 111);
            this.txtProcessCommandLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProcessCommandLine.Name = "txtProcessCommandLine";
            this.txtProcessCommandLine.ReadOnly = true;
            this.txtProcessCommandLine.Size = new System.Drawing.Size(464, 27);
            this.txtProcessCommandLine.TabIndex = 5;
            // 
            // txtProcessId
            // 
            this.txtProcessId.Location = new System.Drawing.Point(124, 31);
            this.txtProcessId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProcessId.Name = "txtProcessId";
            this.txtProcessId.ReadOnly = true;
            this.txtProcessId.Size = new System.Drawing.Size(132, 27);
            this.txtProcessId.TabIndex = 1;
            // 
            // txtProcessImagePath
            // 
            this.txtProcessImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcessImagePath.Location = new System.Drawing.Point(124, 71);
            this.txtProcessImagePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProcessImagePath.Name = "txtProcessImagePath";
            this.txtProcessImagePath.ReadOnly = true;
            this.txtProcessImagePath.Size = new System.Drawing.Size(464, 27);
            this.txtProcessImagePath.TabIndex = 3;
            // 
            // lblThreadId
            // 
            lblThreadId.AutoSize = true;
            lblThreadId.Location = new System.Drawing.Point(9, 35);
            lblThreadId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblThreadId.Name = "lblThreadId";
            lblThreadId.Size = new System.Drawing.Size(77, 20);
            lblThreadId.TabIndex = 0;
            lblThreadId.Text = "Thread ID:";
            // 
            // lblThreadName
            // 
            lblThreadName.AutoSize = true;
            lblThreadName.Location = new System.Drawing.Point(9, 75);
            lblThreadName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblThreadName.Name = "lblThreadName";
            lblThreadName.Size = new System.Drawing.Size(102, 20);
            lblThreadName.TabIndex = 2;
            lblThreadName.Text = "Thread Name:";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(tabPageMain);
            this.tabControlMain.Controls.Add(tabPageGroups);
            this.tabControlMain.Controls.Add(this.tabPagePrivs);
            this.tabControlMain.Controls.Add(this.tabPageRestricted);
            this.tabControlMain.Controls.Add(this.tabPageAppContainer);
            this.tabControlMain.Controls.Add(tabPageDefaultDacl);
            this.tabControlMain.Controls.Add(this.tabPageMisc);
            this.tabControlMain.Controls.Add(this.tabPageOperations);
            this.tabControlMain.Controls.Add(this.tabPageTokenSource);
            this.tabControlMain.Controls.Add(this.tabPageSecurity);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(631, 858);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPagePrivs
            // 
            this.tabPagePrivs.Controls.Add(this.listViewPrivs);
            this.tabPagePrivs.Location = new System.Drawing.Point(4, 25);
            this.tabPagePrivs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPagePrivs.Name = "tabPagePrivs";
            this.tabPagePrivs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPagePrivs.Size = new System.Drawing.Size(625, 713);
            this.tabPagePrivs.TabIndex = 7;
            this.tabPagePrivs.Text = "Privileges";
            this.tabPagePrivs.UseVisualStyleBackColor = true;
            // 
            // listViewPrivs
            // 
            this.listViewPrivs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader5, columnHeader6 });
            this.listViewPrivs.ContextMenuStrip = this.contextMenuStripPrivileges;
            this.listViewPrivs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPrivs.FullRowSelect = true;
            this.listViewPrivs.HideSelection = false;
            this.listViewPrivs.Location = new System.Drawing.Point(4, 5);
            this.listViewPrivs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewPrivs.Name = "listViewPrivs";
            this.listViewPrivs.Size = new System.Drawing.Size(617, 703);
            this.listViewPrivs.TabIndex = 1;
            this.listViewPrivs.UseCompatibleStateImageBehavior = false;
            this.listViewPrivs.View = System.Windows.Forms.View.Details;
            this.listViewPrivs.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // contextMenuStripPrivileges
            // 
            this.contextMenuStripPrivileges.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripPrivileges.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.enablePrivilegeToolStripMenuItem, this.removePrivilegeToolStripMenuItem, this.selectAllPrivsToolStripMenuItem, this.copyToolStripMenuItemPrivs });
            this.contextMenuStripPrivileges.Name = "contextMenuStripPrivileges";
            this.contextMenuStripPrivileges.Size = new System.Drawing.Size(194, 100);
            this.contextMenuStripPrivileges.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripPrivileges_Opening);
            // 
            // enablePrivilegeToolStripMenuItem
            // 
            this.enablePrivilegeToolStripMenuItem.Name = "enablePrivilegeToolStripMenuItem";
            this.enablePrivilegeToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.enablePrivilegeToolStripMenuItem.Text = "Enable Privilege";
            this.enablePrivilegeToolStripMenuItem.Click += new System.EventHandler(this.enablePrivilegeToolStripMenuItem_Click);
            // 
            // removePrivilegeToolStripMenuItem
            // 
            this.removePrivilegeToolStripMenuItem.Name = "removePrivilegeToolStripMenuItem";
            this.removePrivilegeToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.removePrivilegeToolStripMenuItem.Text = "Remove Privilege";
            this.removePrivilegeToolStripMenuItem.Click += new System.EventHandler(this.removePrivilegeToolStripMenuItem_Click);
            // 
            // selectAllPrivsToolStripMenuItem
            // 
            this.selectAllPrivsToolStripMenuItem.Name = "selectAllPrivsToolStripMenuItem";
            this.selectAllPrivsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllPrivsToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.selectAllPrivsToolStripMenuItem.Text = "Select All";
            this.selectAllPrivsToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItemPrivs
            // 
            this.copyToolStripMenuItemPrivs.Name = "copyToolStripMenuItemPrivs";
            this.copyToolStripMenuItemPrivs.Size = new System.Drawing.Size(193, 24);
            this.copyToolStripMenuItemPrivs.Text = "Copy";
            this.copyToolStripMenuItemPrivs.Click += new System.EventHandler(this.CopyListViewItems);
            // 
            // tabPageRestricted
            // 
            this.tabPageRestricted.Controls.Add(this.listViewRestrictedSids);
            this.tabPageRestricted.Location = new System.Drawing.Point(4, 25);
            this.tabPageRestricted.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageRestricted.Name = "tabPageRestricted";
            this.tabPageRestricted.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageRestricted.Size = new System.Drawing.Size(625, 713);
            this.tabPageRestricted.TabIndex = 3;
            this.tabPageRestricted.Text = "Restricted SIDs";
            this.tabPageRestricted.UseVisualStyleBackColor = true;
            // 
            // listViewRestrictedSids
            // 
            this.listViewRestrictedSids.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeader1, this.columnHeader2 });
            this.listViewRestrictedSids.ContextMenuStrip = this.contextMenuStripDefaultGroups;
            this.listViewRestrictedSids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRestrictedSids.FullRowSelect = true;
            this.listViewRestrictedSids.HideSelection = false;
            this.listViewRestrictedSids.Location = new System.Drawing.Point(4, 5);
            this.listViewRestrictedSids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewRestrictedSids.Name = "listViewRestrictedSids";
            this.listViewRestrictedSids.Size = new System.Drawing.Size(617, 703);
            this.listViewRestrictedSids.TabIndex = 1;
            this.listViewRestrictedSids.UseCompatibleStateImageBehavior = false;
            this.listViewRestrictedSids.View = System.Windows.Forms.View.Details;
            this.listViewRestrictedSids.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 210;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Flags";
            this.columnHeader2.Width = 194;
            // 
            // contextMenuStripDefaultGroups
            // 
            this.contextMenuStripDefaultGroups.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripDefaultGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.selectAllToolStripMenuItem, this.toolStripMenuItemCopyGroups, this.toolStripMenuItemCopySidsGeneric });
            this.contextMenuStripDefaultGroups.Name = "contextMenuStripDefaultGroups";
            this.contextMenuStripDefaultGroups.Size = new System.Drawing.Size(141, 76);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllListViewItems);
            // 
            // toolStripMenuItemCopyGroups
            // 
            this.toolStripMenuItemCopyGroups.Name = "toolStripMenuItemCopyGroups";
            this.toolStripMenuItemCopyGroups.Size = new System.Drawing.Size(140, 24);
            this.toolStripMenuItemCopyGroups.Text = "Copy";
            this.toolStripMenuItemCopyGroups.Click += new System.EventHandler(this.CopyListViewItems);
            // 
            // toolStripMenuItemCopySidsGeneric
            // 
            this.toolStripMenuItemCopySidsGeneric.Name = "toolStripMenuItemCopySidsGeneric";
            this.toolStripMenuItemCopySidsGeneric.Size = new System.Drawing.Size(140, 24);
            this.toolStripMenuItemCopySidsGeneric.Text = "Copy Sid";
            this.toolStripMenuItemCopySidsGeneric.Click += new System.EventHandler(this.CopySidListViewItems);
            // 
            // tabPageAppContainer
            // 
            this.tabPageAppContainer.Controls.Add(label27);
            this.tabPageAppContainer.Controls.Add(this.txtPackageSid);
            this.tabPageAppContainer.Controls.Add(label12);
            this.tabPageAppContainer.Controls.Add(this.txtACNumber);
            this.tabPageAppContainer.Controls.Add(this.listViewCapabilities);
            this.tabPageAppContainer.Controls.Add(label11);
            this.tabPageAppContainer.Controls.Add(this.txtPackageName);
            this.tabPageAppContainer.Location = new System.Drawing.Point(4, 25);
            this.tabPageAppContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageAppContainer.Name = "tabPageAppContainer";
            this.tabPageAppContainer.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageAppContainer.Size = new System.Drawing.Size(625, 713);
            this.tabPageAppContainer.TabIndex = 4;
            this.tabPageAppContainer.Text = "App Container";
            this.tabPageAppContainer.UseVisualStyleBackColor = true;
            // 
            // txtPackageSid
            // 
            this.txtPackageSid.Location = new System.Drawing.Point(189, 65);
            this.txtPackageSid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPackageSid.Name = "txtPackageSid";
            this.txtPackageSid.ReadOnly = true;
            this.txtPackageSid.Size = new System.Drawing.Size(340, 27);
            this.txtPackageSid.TabIndex = 14;
            // 
            // txtACNumber
            // 
            this.txtACNumber.Location = new System.Drawing.Point(189, 102);
            this.txtACNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtACNumber.Name = "txtACNumber";
            this.txtACNumber.ReadOnly = true;
            this.txtACNumber.Size = new System.Drawing.Size(111, 27);
            this.txtACNumber.TabIndex = 12;
            // 
            // listViewCapabilities
            // 
            this.listViewCapabilities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCapabilities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeader3, this.columnHeader4 });
            this.listViewCapabilities.ContextMenuStrip = this.contextMenuStripDefaultGroups;
            this.listViewCapabilities.FullRowSelect = true;
            this.listViewCapabilities.HideSelection = false;
            this.listViewCapabilities.Location = new System.Drawing.Point(4, 140);
            this.listViewCapabilities.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewCapabilities.Name = "listViewCapabilities";
            this.listViewCapabilities.Size = new System.Drawing.Size(613, 545);
            this.listViewCapabilities.TabIndex = 10;
            this.listViewCapabilities.UseCompatibleStateImageBehavior = false;
            this.listViewCapabilities.View = System.Windows.Forms.View.Details;
            this.listViewCapabilities.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 210;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Flags";
            this.columnHeader4.Width = 194;
            // 
            // txtPackageName
            // 
            this.txtPackageName.Location = new System.Drawing.Point(189, 21);
            this.txtPackageName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.ReadOnly = true;
            this.txtPackageName.Size = new System.Drawing.Size(340, 27);
            this.txtPackageName.TabIndex = 9;
            // 
            // tabPageMisc
            // 
            this.tabPageMisc.Controls.Add(groupBox2);
            this.tabPageMisc.Location = new System.Drawing.Point(4, 29);
            this.tabPageMisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageMisc.Name = "tabPageMisc";
            this.tabPageMisc.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageMisc.Size = new System.Drawing.Size(625, 709);
            this.tabPageMisc.TabIndex = 6;
            this.tabPageMisc.Text = "Misc";
            this.tabPageMisc.UseVisualStyleBackColor = true;
            // 
            // tabPageOperations
            // 
            this.tabPageOperations.Controls.Add(this.groupBox3);
            this.tabPageOperations.Controls.Add(groupBox4);
            this.tabPageOperations.Controls.Add(groupBoxSafer);
            this.tabPageOperations.Controls.Add(groupBox1);
            this.tabPageOperations.Controls.Add(groupBoxDuplicate);
            this.tabPageOperations.Location = new System.Drawing.Point(4, 29);
            this.tabPageOperations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageOperations.Name = "tabPageOperations";
            this.tabPageOperations.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageOperations.Size = new System.Drawing.Size(623, 825);
            this.tabPageOperations.TabIndex = 5;
            this.tabPageOperations.Text = "Operations";
            this.tabPageOperations.UseVisualStyleBackColor = true;
            // 
            // tabPageTokenSource
            // 
            this.tabPageTokenSource.Controls.Add(this.groupThread);
            this.tabPageTokenSource.Controls.Add(groupProcess);
            this.tabPageTokenSource.Location = new System.Drawing.Point(4, 25);
            this.tabPageTokenSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageTokenSource.Name = "tabPageTokenSource";
            this.tabPageTokenSource.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageTokenSource.Size = new System.Drawing.Size(625, 713);
            this.tabPageTokenSource.TabIndex = 9;
            this.tabPageTokenSource.Text = "Token Source";
            this.tabPageTokenSource.UseVisualStyleBackColor = true;
            // 
            // groupThread
            // 
            this.groupThread.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupThread.Controls.Add(lblThreadId);
            this.groupThread.Controls.Add(this.txtThreadId);
            this.groupThread.Controls.Add(this.txtThreadName);
            this.groupThread.Controls.Add(lblThreadName);
            this.groupThread.Location = new System.Drawing.Point(15, 180);
            this.groupThread.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupThread.Name = "groupThread";
            this.groupThread.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupThread.Size = new System.Drawing.Size(597, 121);
            this.groupThread.TabIndex = 7;
            this.groupThread.TabStop = false;
            this.groupThread.Text = "Thread Information";
            // 
            // txtThreadId
            // 
            this.txtThreadId.Location = new System.Drawing.Point(124, 31);
            this.txtThreadId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtThreadId.Name = "txtThreadId";
            this.txtThreadId.ReadOnly = true;
            this.txtThreadId.Size = new System.Drawing.Size(132, 27);
            this.txtThreadId.TabIndex = 1;
            // 
            // txtThreadName
            // 
            this.txtThreadName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThreadName.Location = new System.Drawing.Point(124, 71);
            this.txtThreadName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtThreadName.Name = "txtThreadName";
            this.txtThreadName.ReadOnly = true;
            this.txtThreadName.Size = new System.Drawing.Size(464, 27);
            this.txtThreadName.TabIndex = 3;
            // 
            // tabPageSecurity
            // 
            this.tabPageSecurity.Controls.Add(tableLayoutPanelSecurity);
            this.tabPageSecurity.Location = new System.Drawing.Point(4, 25);
            this.tabPageSecurity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSecurity.Name = "tabPageSecurity";
            this.tabPageSecurity.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSecurity.Size = new System.Drawing.Size(625, 713);
            this.tabPageSecurity.TabIndex = 8;
            this.tabPageSecurity.Text = "Security";
            this.tabPageSecurity.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDecrypt);
            this.groupBox3.Controls.Add(this.btnEncrypt);
            this.groupBox3.Controls.Add(label30);
            this.groupBox3.Controls.Add(this.txtDpapiContents);
            this.groupBox3.Location = new System.Drawing.Point(13, 665);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(599, 136);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Call DPAPI";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(7, 23);
            label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(70, 20);
            label30.TabIndex = 5;
            label30.Text = "Contents:";
            // 
            // txtDpapiContents
            // 
            this.txtDpapiContents.Location = new System.Drawing.Point(83, 19);
            this.txtDpapiContents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDpapiContents.Multiline = true;
            this.txtDpapiContents.Name = "txtDpapiContents";
            this.txtDpapiContents.Size = new System.Drawing.Size(372, 78);
            this.txtDpapiContents.TabIndex = 4;
            this.txtDpapiContents.Text = "Hello World!";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(475, 19);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(100, 39);
            this.btnEncrypt.TabIndex = 6;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(475, 64);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(100, 39);
            this.btnDecrypt.TabIndex = 7;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // TokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 858);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(649, 765);
            this.Name = "TokenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Token View";
            tabPageMain.ResumeLayout(false);
            this.groupBoxSource.ResumeLayout(false);
            this.groupBoxSource.PerformLayout();
            groupBoxToken.ResumeLayout(false);
            groupBoxToken.PerformLayout();
            tabPageGroups.ResumeLayout(false);
            this.contextMenuStripGroups.ResumeLayout(false);
            tabPageDefaultDacl.ResumeLayout(false);
            tabPageDefaultDacl.PerformLayout();
            this.contextMenuStripDefaultDacl.ResumeLayout(false);
            groupBoxDuplicate.ResumeLayout(false);
            groupBoxDuplicate.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBoxSafer.ResumeLayout(false);
            groupBoxSafer.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tableLayoutPanelSecurity.ResumeLayout(false);
            groupProcess.ResumeLayout(false);
            groupProcess.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPagePrivs.ResumeLayout(false);
            this.contextMenuStripPrivileges.ResumeLayout(false);
            this.tabPageRestricted.ResumeLayout(false);
            this.contextMenuStripDefaultGroups.ResumeLayout(false);
            this.tabPageAppContainer.ResumeLayout(false);
            this.tabPageAppContainer.PerformLayout();
            this.tabPageMisc.ResumeLayout(false);
            this.tabPageOperations.ResumeLayout(false);
            this.tabPageTokenSource.ResumeLayout(false);
            this.groupThread.ResumeLayout(false);
            this.groupThread.PerformLayout();
            this.tabPageSecurity.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TextBox txtUserSid;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUserSid;
        private System.Windows.Forms.TextBox txtImpLevel;
        private System.Windows.Forms.TextBox txtTokenType;
        private System.Windows.Forms.TextBox txtModifiedId;
        private System.Windows.Forms.TextBox txtAuthId;
        private System.Windows.Forms.TextBox txtTokenId;
        private System.Windows.Forms.TextBox txtSessionId;
        private System.Windows.Forms.GroupBox groupBoxSource;
        private System.Windows.Forms.TextBox txtSourceId;
        private System.Windows.Forms.TextBox txtSourceName;
        private System.Windows.Forms.TextBox txtElevationType;
        private System.Windows.Forms.Button btnLinkedToken;
        private System.Windows.Forms.ListView listViewGroups;
        private System.Windows.Forms.TextBox txtPrimaryGroup;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.ListView listViewDefDacl;
        private System.Windows.Forms.TabPage tabPageRestricted;
        private System.Windows.Forms.ListView listViewRestrictedSids;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPageAppContainer;
        private System.Windows.Forms.TextBox txtPackageName;
        private System.Windows.Forms.ListView listViewCapabilities;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtACNumber;
        private System.Windows.Forms.TabPage tabPageOperations;
        private System.Windows.Forms.TextBox txtOriginLoginId;
        private System.Windows.Forms.ComboBox comboBoxImpLevel;
        private System.Windows.Forms.ComboBox comboBoxTokenType;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.Button btnCreateProcess;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.TabPage tabPageMisc;
        private System.Windows.Forms.TextBox txtUIAccess;
        private System.Windows.Forms.TextBox txtSandboxInert;
        private System.Windows.Forms.TextBox txtVirtualizationEnabled;
        private System.Windows.Forms.TextBox txtVirtualizationAllowed;
        private System.Windows.Forms.ComboBox comboBoxSaferLevel;
        private System.Windows.Forms.CheckBox checkBoxSaferMakeInert;
        private System.Windows.Forms.Button btnComputeSafer;
        private System.Windows.Forms.TextBox txtMandatoryILPolicy;
        private System.Windows.Forms.CheckBox checkBoxMakeInteractive;
        private System.Windows.Forms.ComboBox comboBoxIL;
        private System.Windows.Forms.Button btnSetIL;
        private System.Windows.Forms.ComboBox comboBoxILForDup;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileContents;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TabPage tabPagePrivs;
        private System.Windows.Forms.ListView listViewPrivs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPrivileges;
        private System.Windows.Forms.ToolStripMenuItem enablePrivilegeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtIsElevated;
        private System.Windows.Forms.ToolStripMenuItem selectAllPrivsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGroups;
        private System.Windows.Forms.ToolStripMenuItem enableGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllGroupsToolStripMenuItem;
        private System.Windows.Forms.Button btnCreateSandbox;
        private System.Windows.Forms.Button btnImpersonate;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkBoxUseWmi;
        private System.Windows.Forms.ToolStripMenuItem removePrivilegeToolStripMenuItem;
        private System.Windows.Forms.Label llbSecurityAttributes;
        private System.Windows.Forms.TreeView treeViewSecurityAttributes;
        private System.Windows.Forms.Button btnToggleUIAccess;
        private System.Windows.Forms.TextBox txtHandleAccess;
        private System.Windows.Forms.Button btnToggleVirtualizationEnabled;
        private System.Windows.Forms.CheckBox checkBoxUseNetLogon;
        private System.Windows.Forms.TextBox txtPackageSid;
        private System.Windows.Forms.ToolStripMenuItem copySidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItemPrivs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDefaultGroups;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyGroups;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopySidsGeneric;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDefaultDacl;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItemDacl;
        private System.Windows.Forms.ToolStripMenuItem copyAsSDDLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllDaclToolStripMenuItem;
        private System.Windows.Forms.TextBox txtTrustLevel;
        private System.Windows.Forms.TabPage tabPageSecurity;
        private NtApiDotNet.Forms.SecurityDescriptorViewerControl securityDescriptorViewerControl;
        private System.Windows.Forms.Button btnEditPermissions;
        private System.Windows.Forms.TextBox txtTokenFlags;
        private System.Windows.Forms.TabPage tabPageTokenSource;
        private System.Windows.Forms.TextBox txtProcessCommandLine;
        private System.Windows.Forms.TextBox txtProcessImagePath;
        private System.Windows.Forms.TextBox txtProcessId;
        private System.Windows.Forms.GroupBox groupThread;
        private System.Windows.Forms.TextBox txtThreadId;
        private System.Windows.Forms.TextBox txtThreadName;
        private System.Windows.Forms.TextBox txtDpapiContents;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}