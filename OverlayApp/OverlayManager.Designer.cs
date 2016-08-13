namespace OverlayApp
{
    partial class OverlayManager
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
            this.itemListFetcher = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.itemsFetched = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addItemToProject = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.projectNameField = new System.Windows.Forms.TextBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.addItemStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.addItemProject = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.itemDetails = new System.Windows.Forms.Panel();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.itemCountTotal = new System.Windows.Forms.TextBox();
            this.itemCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.itemList = new System.Windows.Forms.TreeView();
            this.itemCraftListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedSubNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.AddItemWorker = new System.ComponentModel.BackgroundWorker();
            this.itemNameList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fetchMissingItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemProjectList = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.itemProjectMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedProject = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllProjects = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.itemDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemCount)).BeginInit();
            this.itemCraftListMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemNameList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInfoBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.itemProjectMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemListFetcher
            // 
            this.itemListFetcher.WorkerReportsProgress = true;
            this.itemListFetcher.WorkerSupportsCancellation = true;
            this.itemListFetcher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.itemListFetcher_DoWork);
            this.itemListFetcher.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.itemListFetcher_ProgressChanged);
            this.itemListFetcher.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.itemListFetcher_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsFetched});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1010, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // itemsFetched
            // 
            this.itemsFetched.Name = "itemsFetched";
            this.itemsFetched.Size = new System.Drawing.Size(25, 17);
            this.itemsFetched.Text = "      ";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(11, 40);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(209, 20);
            this.searchBox.TabIndex = 3;
            this.searchBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search Items";
            // 
            // addItemToProject
            // 
            this.addItemToProject.Location = new System.Drawing.Point(98, 398);
            this.addItemToProject.Name = "addItemToProject";
            this.addItemToProject.Size = new System.Drawing.Size(122, 23);
            this.addItemToProject.TabIndex = 6;
            this.addItemToProject.Text = "Add Item To Prject";
            this.addItemToProject.UseVisualStyleBackColor = true;
            this.addItemToProject.Click += new System.EventHandler(this.addItemToProject_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.projectNameField);
            this.panel1.Controls.Add(this.statusStrip2);
            this.panel1.Controls.Add(this.addItemProject);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.itemDetails);
            this.panel1.Controls.Add(this.itemList);
            this.panel1.Location = new System.Drawing.Point(434, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 381);
            this.panel1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Project Name";
            // 
            // projectNameField
            // 
            this.projectNameField.Location = new System.Drawing.Point(6, 18);
            this.projectNameField.Name = "projectNameField";
            this.projectNameField.Size = new System.Drawing.Size(199, 20);
            this.projectNameField.TabIndex = 10;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemStatusLabel});
            this.statusStrip2.Location = new System.Drawing.Point(6, 340);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(133, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.Stretch = false;
            this.statusStrip2.TabIndex = 14;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // addItemStatusLabel
            // 
            this.addItemStatusLabel.Name = "addItemStatusLabel";
            this.addItemStatusLabel.Size = new System.Drawing.Size(116, 17);
            this.addItemStatusLabel.Text = "Adding Item To List: ";
            // 
            // addItemProject
            // 
            this.addItemProject.Location = new System.Drawing.Point(480, 340);
            this.addItemProject.Name = "addItemProject";
            this.addItemProject.Size = new System.Drawing.Size(75, 23);
            this.addItemProject.TabIndex = 13;
            this.addItemProject.Text = "Create Project";
            this.addItemProject.UseVisualStyleBackColor = true;
            this.addItemProject.Click += new System.EventHandler(this.addItemProject_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Item Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Items To Craft";
            // 
            // itemDetails
            // 
            this.itemDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemDetails.Controls.Add(this.textBox8);
            this.itemDetails.Controls.Add(this.label16);
            this.itemDetails.Controls.Add(this.numericUpDown2);
            this.itemDetails.Controls.Add(this.label15);
            this.itemDetails.Controls.Add(this.label14);
            this.itemDetails.Controls.Add(this.textBox7);
            this.itemDetails.Controls.Add(this.listView1);
            this.itemDetails.Controls.Add(this.label13);
            this.itemDetails.Controls.Add(this.label11);
            this.itemDetails.Controls.Add(this.textBox4);
            this.itemDetails.Controls.Add(this.label12);
            this.itemDetails.Controls.Add(this.textBox6);
            this.itemDetails.Controls.Add(this.label10);
            this.itemDetails.Controls.Add(this.textBox5);
            this.itemDetails.Controls.Add(this.label9);
            this.itemDetails.Controls.Add(this.label8);
            this.itemDetails.Controls.Add(this.textBox3);
            this.itemDetails.Controls.Add(this.label7);
            this.itemDetails.Controls.Add(this.itemCountTotal);
            this.itemDetails.Controls.Add(this.itemCount);
            this.itemDetails.Controls.Add(this.label6);
            this.itemDetails.Location = new System.Drawing.Point(211, 18);
            this.itemDetails.Name = "itemDetails";
            this.itemDetails.Size = new System.Drawing.Size(344, 316);
            this.itemDetails.TabIndex = 1;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(226, 252);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(101, 20);
            this.textBox8.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(223, 236);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "TotalCost";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(139, 253);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(81, 20);
            this.numericUpDown2.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(136, 237);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Cost Per Item";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Currency";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(9, 253);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(124, 20);
            this.textBox7.TabIndex = 19;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Location = new System.Drawing.Point(9, 161);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(318, 74);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Currency";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cost Per item";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Total";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Special Currency Cost";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(177, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "All Required Items";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(180, 122);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(124, 20);
            this.textBox4.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(177, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Single Item";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(180, 82);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(124, 20);
            this.textBox6.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "All Required Items";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 122);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(124, 20);
            this.textBox5.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Single Item";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(177, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Cost: Trading Post - Place Order";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 82);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(124, 20);
            this.textBox3.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Cost: Trading Post - Buy Now";
            // 
            // itemCountTotal
            // 
            this.itemCountTotal.Location = new System.Drawing.Point(75, 21);
            this.itemCountTotal.Name = "itemCountTotal";
            this.itemCountTotal.ReadOnly = true;
            this.itemCountTotal.Size = new System.Drawing.Size(55, 20);
            this.itemCountTotal.TabIndex = 2;
            // 
            // itemCount
            // 
            this.itemCount.Location = new System.Drawing.Point(6, 22);
            this.itemCount.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.itemCount.Name = "itemCount";
            this.itemCount.Size = new System.Drawing.Size(62, 20);
            this.itemCount.TabIndex = 1;
            this.itemCount.ValueChanged += new System.EventHandler(this.itemCount_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Count";
            // 
            // itemList
            // 
            this.itemList.ContextMenuStrip = this.itemCraftListMenuStrip;
            this.itemList.Location = new System.Drawing.Point(6, 59);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(199, 275);
            this.itemList.TabIndex = 0;
            this.itemList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.itemList_AfterSelect);
            // 
            // itemCraftListMenuStrip
            // 
            this.itemCraftListMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedToolStripMenuItem,
            this.removeSelectedSubNodeToolStripMenuItem});
            this.itemCraftListMenuStrip.Name = "contextMenuStrip1";
            this.itemCraftListMenuStrip.Size = new System.Drawing.Size(220, 48);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected Node";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
            // 
            // removeSelectedSubNodeToolStripMenuItem
            // 
            this.removeSelectedSubNodeToolStripMenuItem.Name = "removeSelectedSubNodeToolStripMenuItem";
            this.removeSelectedSubNodeToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.removeSelectedSubNodeToolStripMenuItem.Text = "Remove Selected Sub Node";
            this.removeSelectedSubNodeToolStripMenuItem.Click += new System.EventHandler(this.removeSubTreeToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Item Project";
            // 
            // AddItemWorker
            // 
            this.AddItemWorker.WorkerReportsProgress = true;
            this.AddItemWorker.WorkerSupportsCancellation = true;
            this.AddItemWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AddItemWorker_DoWork);
            this.AddItemWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.itemListFetcher_ProgressChanged);
            this.AddItemWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.itemListFetcher_RunWorkerCompleted);
            // 
            // itemNameList
            // 
            this.itemNameList.AllowUserToAddRows = false;
            this.itemNameList.AllowUserToDeleteRows = false;
            this.itemNameList.AutoGenerateColumns = false;
            this.itemNameList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemNameList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.iDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn});
            this.itemNameList.DataSource = this.dataGridInfoBindingSource;
            this.itemNameList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.itemNameList.Location = new System.Drawing.Point(11, 66);
            this.itemNameList.MultiSelect = false;
            this.itemNameList.Name = "itemNameList";
            this.itemNameList.ReadOnly = true;
            this.itemNameList.RowHeadersWidth = 20;
            this.itemNameList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemNameList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemNameList.Size = new System.Drawing.Size(209, 326);
            this.itemNameList.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ID";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ItemName";
            this.Column2.HeaderText = "Item Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridInfoBindingSource
            // 
            this.dataGridInfoBindingSource.DataSource = typeof(OverlayApp.OverlayManager.DataGridInfo);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fetchMissingItemsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1010, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fetchMissingItemsToolStripMenuItem
            // 
            this.fetchMissingItemsToolStripMenuItem.Name = "fetchMissingItemsToolStripMenuItem";
            this.fetchMissingItemsToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.fetchMissingItemsToolStripMenuItem.Text = "Fetch Missing Items";
            this.fetchMissingItemsToolStripMenuItem.Click += new System.EventHandler(this.fetchMissingItemsToolStripMenuItem_Click);
            // 
            // itemProjectList
            // 
            this.itemProjectList.ContextMenuStrip = this.itemProjectMenuStrip;
            this.itemProjectList.FormattingEnabled = true;
            this.itemProjectList.Items.AddRange(new object[] {
            "<New Project>"});
            this.itemProjectList.Location = new System.Drawing.Point(229, 40);
            this.itemProjectList.Name = "itemProjectList";
            this.itemProjectList.Size = new System.Drawing.Size(199, 381);
            this.itemProjectList.TabIndex = 15;
            this.itemProjectList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(226, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Item Projects";
            // 
            // itemProjectMenuStrip
            // 
            this.itemProjectMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedProject,
            this.clearAllProjects});
            this.itemProjectMenuStrip.Name = "contextMenuStrip1";
            this.itemProjectMenuStrip.Size = new System.Drawing.Size(205, 70);
            // 
            // removeSelectedProject
            // 
            this.removeSelectedProject.Name = "removeSelectedProject";
            this.removeSelectedProject.Size = new System.Drawing.Size(204, 22);
            this.removeSelectedProject.Text = "Remove Selected Project";
            this.removeSelectedProject.Click += new System.EventHandler(this.removeSelectedProject_Click);
            // 
            // clearAllProjects
            // 
            this.clearAllProjects.Name = "clearAllProjects";
            this.clearAllProjects.Size = new System.Drawing.Size(204, 22);
            this.clearAllProjects.Text = "Clear All Projects";
            this.clearAllProjects.Click += new System.EventHandler(this.clearAllProjects_Click);
            // 
            // OverlayManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 453);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.itemNameList);
            this.Controls.Add(this.itemProjectList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addItemToProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OverlayManager";
            this.Text = "Overlay Manager - Crafting Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Overlay_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.itemDetails.ResumeLayout(false);
            this.itemDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemCount)).EndInit();
            this.itemCraftListMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemNameList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInfoBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.itemProjectMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker itemListFetcher;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel itemsFetched;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addItemToProject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView itemList;
        private System.Windows.Forms.Panel itemDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addItemProject;
        private System.Windows.Forms.TextBox itemCountTotal;
        private System.Windows.Forms.NumericUpDown itemCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ContextMenuStrip itemCraftListMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedSubNodeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel addItemStatusLabel;
        private System.ComponentModel.BackgroundWorker AddItemWorker;
        private System.Windows.Forms.DataGridView itemNameList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.BindingSource dataGridInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fetchMissingItemsToolStripMenuItem;
        private System.Windows.Forms.ListBox itemProjectList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox projectNameField;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ContextMenuStrip itemProjectMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedProject;
        private System.Windows.Forms.ToolStripMenuItem clearAllProjects;
    }
}