namespace AzzyAIConfig
{
    partial class PvpTactControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.SplitContainer splitContainer1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label2;
            this.listBoxTactics = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.comboBoxBasic = new System.Windows.Forms.ComboBox();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.comboBoxKite = new System.Windows.Forms.ComboBox();
            this.comboBoxSkill = new System.Windows.Forms.ComboBox();
            this.numericUpDownSkill = new System.Windows.Forms.NumericUpDown();
            this.comboBoxDebuff = new System.Windows.Forms.ComboBox();
            this.comboBoxPushback = new System.Windows.Forms.ComboBox();
            this.comboBoxRescue = new System.Windows.Forms.ComboBox();
            this.comboBoxDebuff2 = new System.Windows.Forms.ComboBox();
            this.comboBoxReact = new System.Windows.Forms.ComboBox();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            label3 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkill)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel2);
            splitContainer1.Size = new System.Drawing.Size(394, 254);
            splitContainer1.SplitterDistance = 131;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(this.listBoxTactics, 0, 0);
            tableLayoutPanel1.Controls.Add(this.buttonAdd, 0, 1);
            tableLayoutPanel1.Controls.Add(this.buttonRemove, 1, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(131, 254);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // listBoxTactics
            // 
            tableLayoutPanel1.SetColumnSpan(this.listBoxTactics, 2);
            this.listBoxTactics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxTactics.FormattingEnabled = true;
            this.listBoxTactics.Location = new System.Drawing.Point(3, 3);
            this.listBoxTactics.Name = "listBoxTactics";
            this.listBoxTactics.Size = new System.Drawing.Size(125, 219);
            this.listBoxTactics.TabIndex = 0;
            this.listBoxTactics.SelectedIndexChanged += new System.EventHandler(this.listBoxTactics_SelectedIndexChanged);
            this.listBoxTactics.DoubleClick += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(3, 228);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(59, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(68, 228);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(60, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(this.textBoxID, 1, 0);
            tableLayoutPanel2.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(259, 254);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(122, 13);
            label1.TabIndex = 0;
            label1.Text = "Player ID or Friend Class";
            // 
            // textBoxID
            // 
            this.textBoxID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxID.Location = new System.Drawing.Point(131, 3);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(125, 20);
            this.textBoxID.TabIndex = 1;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxID.Validated += new System.EventHandler(this.textBoxID_Validated);
            // 
            // groupBox1
            // 
            tableLayoutPanel2.SetColumnSpan(groupBox1, 2);
            groupBox1.Controls.Add(tableLayoutPanel3);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(3, 29);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(253, 222);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Overall Tactics";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.Controls.Add(label3, 0, 0);
            tableLayoutPanel3.Controls.Add(this.comboBoxBasic, 1, 0);
            tableLayoutPanel3.Controls.Add(label7, 0, 7);
            tableLayoutPanel3.Controls.Add(label6, 0, 6);
            tableLayoutPanel3.Controls.Add(this.comboBoxSize, 1, 6);
            tableLayoutPanel3.Controls.Add(label5, 0, 5);
            tableLayoutPanel3.Controls.Add(this.comboBoxKite, 1, 5);
            tableLayoutPanel3.Controls.Add(label4, 0, 3);
            tableLayoutPanel3.Controls.Add(this.comboBoxSkill, 1, 3);
            tableLayoutPanel3.Controls.Add(this.numericUpDownSkill, 2, 3);
            tableLayoutPanel3.Controls.Add(label9, 0, 2);
            tableLayoutPanel3.Controls.Add(this.comboBoxDebuff, 1, 2);
            tableLayoutPanel3.Controls.Add(label10, 0, 4);
            tableLayoutPanel3.Controls.Add(this.comboBoxPushback, 1, 4);
            tableLayoutPanel3.Controls.Add(this.comboBoxRescue, 1, 7);
            tableLayoutPanel3.Controls.Add(this.comboBoxDebuff2, 2, 2);
            tableLayoutPanel3.Controls.Add(label2, 0, 1);
            tableLayoutPanel3.Controls.Add(this.comboBoxReact, 1, 1);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(3);
            tableLayoutPanel3.RowCount = 8;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            tableLayoutPanel3.Size = new System.Drawing.Size(247, 203);
            tableLayoutPanel3.TabIndex = 0;
            tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(15, 8);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(78, 13);
            label3.TabIndex = 0;
            label3.Text = "Basic Behavior";
            // 
            // comboBoxBasic
            // 
            this.comboBoxBasic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBasic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBasic.FormattingEnabled = true;
            this.comboBoxBasic.Items.AddRange(new object[] {
            "Tank",
            "Ignore",
            "Attack (low)",
            "Attack (medium)",
            "Attack (high)",
            "React (low)",
            "React (medium)",
            "React (high)",
            "React (self)",
            "Snipe (low)",
            "Snipe (medium)",
            "Snipe (high)",
            "Attack (low) React (med)",
            "Attack (last)",
            "Attack (top)"});
            this.comboBoxBasic.Location = new System.Drawing.Point(99, 6);
            this.comboBoxBasic.Name = "comboBoxBasic";
            this.comboBoxBasic.Size = new System.Drawing.Size(86, 21);
            this.comboBoxBasic.TabIndex = 1;
            this.comboBoxBasic.SelectedIndexChanged += new System.EventHandler(this.comboBoxBasic_SelectedIndexChanged);
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(49, 179);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(44, 13);
            label7.TabIndex = 8;
            label7.Text = "Rescue";
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(39, 152);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(54, 13);
            label6.TabIndex = 6;
            label6.Text = "Skill Class";
            label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Items.AddRange(new object[] {
            "Any Attack",
            "Old Homun",
            "Homun S",
            "Combo (once)",
            "Combo (full)",
            "Summon Minions",
            "Grapple (Tinder Breaker)",
            "Grapple (CBC)",
            "Grapple (EQC)",
            "Minion+PreS Skills",
            "Minion+Homun S Skills"});
            this.comboBoxSize.Location = new System.Drawing.Point(99, 150);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(86, 21);
            this.comboBoxSize.TabIndex = 7;
            this.comboBoxSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxSize_SelectedIndexChanged);
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(60, 128);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(33, 13);
            label5.TabIndex = 4;
            label5.Text = "Kiting";
            // 
            // comboBoxKite
            // 
            this.comboBoxKite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxKite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKite.FormattingEnabled = true;
            this.comboBoxKite.Items.AddRange(new object[] {
            "Never",
            "React",
            "Always"});
            this.comboBoxKite.Location = new System.Drawing.Point(99, 126);
            this.comboBoxKite.Name = "comboBoxKite";
            this.comboBoxKite.Size = new System.Drawing.Size(86, 21);
            this.comboBoxKite.TabIndex = 5;
            this.comboBoxKite.SelectedIndexChanged += new System.EventHandler(this.comboBoxKite_SelectedIndexChanged);
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 80);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(87, 13);
            label4.TabIndex = 2;
            label4.Text = "Use Attack Skills";
            // 
            // comboBoxSkill
            // 
            this.comboBoxSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSkill.FormattingEnabled = true;
            this.comboBoxSkill.Items.AddRange(new object[] {
            "Always",
            "Never",
            "This many times:",
            "Once; level:"});
            this.comboBoxSkill.Location = new System.Drawing.Point(99, 78);
            this.comboBoxSkill.Name = "comboBoxSkill";
            this.comboBoxSkill.Size = new System.Drawing.Size(86, 21);
            this.comboBoxSkill.TabIndex = 3;
            this.comboBoxSkill.SelectedIndexChanged += new System.EventHandler(this.comboBoxSkill_SelectedIndexChanged);
            // 
            // numericUpDownSkill
            // 
            this.numericUpDownSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownSkill.Enabled = false;
            this.numericUpDownSkill.Location = new System.Drawing.Point(191, 78);
            this.numericUpDownSkill.Name = "numericUpDownSkill";
            this.numericUpDownSkill.Size = new System.Drawing.Size(50, 20);
            this.numericUpDownSkill.TabIndex = 11;
            this.numericUpDownSkill.ValueChanged += new System.EventHandler(this.numericUpDownSkill_ValueChanged);
            this.numericUpDownSkill.EnabledChanged += new System.EventHandler(this.numericUpDownSkill_EnabledChanged);
            // 
            // label9
            // 
            label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(27, 56);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(66, 13);
            label9.TabIndex = 12;
            label9.Text = "Use Debuffs";
            // 
            // comboBoxDebuff
            // 
            this.comboBoxDebuff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDebuff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDebuff.FormattingEnabled = true;
            this.comboBoxDebuff.Items.AddRange(new object[] {
            "Never",
            "Any",
            "Silent Breeze",
            "Volcanic Ash"});
            this.comboBoxDebuff.Location = new System.Drawing.Point(99, 54);
            this.comboBoxDebuff.Name = "comboBoxDebuff";
            this.comboBoxDebuff.Size = new System.Drawing.Size(86, 21);
            this.comboBoxDebuff.TabIndex = 13;
            this.comboBoxDebuff.SelectedIndexChanged += new System.EventHandler(this.comboBoxDebuff_SelectedIndexChanged);
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(16, 104);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(77, 13);
            label10.TabIndex = 14;
            label10.Text = "Use Pushback";
            label10.Visible = false;
            // 
            // comboBoxPushback
            // 
            this.comboBoxPushback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPushback.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPushback.FormattingEnabled = true;
            this.comboBoxPushback.Items.AddRange(new object[] {
            "Never",
            "Off self",
            "Off self + friend"});
            this.comboBoxPushback.Location = new System.Drawing.Point(99, 102);
            this.comboBoxPushback.Name = "comboBoxPushback";
            this.comboBoxPushback.Size = new System.Drawing.Size(86, 21);
            this.comboBoxPushback.TabIndex = 15;
            this.comboBoxPushback.Visible = false;
            this.comboBoxPushback.SelectedIndexChanged += new System.EventHandler(this.comboBoxPushback_SelectedIndexChanged);
            // 
            // comboBoxRescue
            // 
            this.comboBoxRescue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRescue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRescue.FormattingEnabled = true;
            this.comboBoxRescue.Items.AddRange(new object[] {
            "Never",
            "Rescue All",
            "Rescue Retainer"});
            this.comboBoxRescue.Location = new System.Drawing.Point(99, 175);
            this.comboBoxRescue.Name = "comboBoxRescue";
            this.comboBoxRescue.Size = new System.Drawing.Size(86, 21);
            this.comboBoxRescue.TabIndex = 9;
            this.comboBoxRescue.SelectedIndexChanged += new System.EventHandler(this.comboBoxRescue_SelectedIndexChanged);
            // 
            // comboBoxDebuff2
            // 
            this.comboBoxDebuff2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDebuff2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDebuff2.FormattingEnabled = true;
            this.comboBoxDebuff2.Items.AddRange(new object[] {
            "Chasing",
            "Attacking"});
            this.comboBoxDebuff2.Location = new System.Drawing.Point(191, 54);
            this.comboBoxDebuff2.Name = "comboBoxDebuff2";
            this.comboBoxDebuff2.Size = new System.Drawing.Size(50, 21);
            this.comboBoxDebuff2.TabIndex = 22;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(57, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(36, 13);
            label2.TabIndex = 23;
            label2.Text = "React";
            label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBoxReact
            // 
            this.comboBoxReact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxReact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReact.FormattingEnabled = true;
            this.comboBoxReact.Items.AddRange(new object[] {
            "No",
            "React to casts",
            "React w/Any",
            "React w/Breeze",
            "React w/Old",
            "React w/S",
            "React w/Mob",
            "React w/Debuff",
            "React w/Minions"});
            this.comboBoxReact.Location = new System.Drawing.Point(99, 30);
            this.comboBoxReact.Name = "comboBoxReact";
            this.comboBoxReact.Size = new System.Drawing.Size(86, 21);
            this.comboBoxReact.TabIndex = 24;
            // 
            // PvpTactControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(splitContainer1);
            this.MinimumSize = new System.Drawing.Size(400, 260);
            this.Name = "PvpTactControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(400, 260);
            this.Load += new System.EventHandler(this.PvpTactControl_Load);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSkill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTactics;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.ComboBox comboBoxBasic;
        private System.Windows.Forms.ComboBox comboBoxRescue;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.ComboBox comboBoxKite;
        private System.Windows.Forms.ComboBox comboBoxSkill;
        private System.Windows.Forms.NumericUpDown numericUpDownSkill;
        private System.Windows.Forms.ComboBox comboBoxDebuff;
        private System.Windows.Forms.ComboBox comboBoxPushback;
        private System.Windows.Forms.ComboBox comboBoxDebuff2;
        private System.Windows.Forms.ComboBox comboBoxReact;

    }
}
