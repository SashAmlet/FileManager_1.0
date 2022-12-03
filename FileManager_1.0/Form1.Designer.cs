namespace FileManager_1._0
{
    partial class FileManagerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManagerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRightDown = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewRight = new System.Windows.Forms.TreeView();
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.listViewRight = new System.Windows.Forms.ListView();
            this.tableLayoutPanelRightUp = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRightUpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRightLeft = new System.Windows.Forms.Button();
            this.buttonRightRight = new System.Windows.Forms.Button();
            this.tableLayoutPanelRightUpRight = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRightUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanelRightUpCenter = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxRightLink = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeftDown = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewLeft = new System.Windows.Forms.TreeView();
            this.listViewLeft = new System.Windows.Forms.ListView();
            this.tableLayoutPanelLeftUp = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeftUpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLeftLeft = new System.Windows.Forms.Button();
            this.buttonLeftRight = new System.Windows.Forms.Button();
            this.tableLayoutPanelLeftUpCenter = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLeftLink = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelLeftUpRight = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLeftUpdate = new System.Windows.Forms.Button();
            this.listViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.tableLayoutPanelRightDown.SuspendLayout();
            this.tableLayoutPanelRightUp.SuspendLayout();
            this.tableLayoutPanelRightUpLeft.SuspendLayout();
            this.tableLayoutPanelRightUpRight.SuspendLayout();
            this.tableLayoutPanelRightUpCenter.SuspendLayout();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.tableLayoutPanelLeftDown.SuspendLayout();
            this.tableLayoutPanelLeftUp.SuspendLayout();
            this.tableLayoutPanelLeftUpLeft.SuspendLayout();
            this.tableLayoutPanelLeftUpCenter.SuspendLayout();
            this.tableLayoutPanelLeftUpRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1474, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializeToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(124, 38);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // initializeToolStripMenuItem
            // 
            this.initializeToolStripMenuItem.Name = "initializeToolStripMenuItem";
            this.initializeToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.initializeToolStripMenuItem.Text = "Initialize disks";
            this.initializeToolStripMenuItem.Click += new System.EventHandler(this.initializeToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 38);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(233, 44);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(233, 44);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(233, 44);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(233, 44);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelRight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelLeft, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1474, 787);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.Controls.Add(this.tableLayoutPanelRightDown, 0, 1);
            this.tableLayoutPanelRight.Controls.Add(this.tableLayoutPanelRightUp, 0, 0);
            this.tableLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(740, 3);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 2;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(731, 781);
            this.tableLayoutPanelRight.TabIndex = 1;
            // 
            // tableLayoutPanelRightDown
            // 
            this.tableLayoutPanelRightDown.ColumnCount = 2;
            this.tableLayoutPanelRightDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.34336F));
            this.tableLayoutPanelRightDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.65664F));
            this.tableLayoutPanelRightDown.Controls.Add(this.treeViewRight, 0, 0);
            this.tableLayoutPanelRightDown.Controls.Add(this.listViewRight, 1, 0);
            this.tableLayoutPanelRightDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRightDown.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanelRightDown.Name = "tableLayoutPanelRightDown";
            this.tableLayoutPanelRightDown.RowCount = 1;
            this.tableLayoutPanelRightDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRightDown.Size = new System.Drawing.Size(725, 715);
            this.tableLayoutPanelRightDown.TabIndex = 2;
            // 
            // treeViewRight
            // 
            this.treeViewRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewRight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeViewRight.ImageIndex = 0;
            this.treeViewRight.ImageList = this.treeViewImageList;
            this.treeViewRight.Location = new System.Drawing.Point(3, 3);
            this.treeViewRight.Name = "treeViewRight";
            this.treeViewRight.SelectedImageIndex = 0;
            this.treeViewRight.ShowPlusMinus = false;
            this.treeViewRight.ShowRootLines = false;
            this.treeViewRight.Size = new System.Drawing.Size(264, 709);
            this.treeViewRight.TabIndex = 0;
            this.treeViewRight.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewRight_BeforeCollapse);
            this.treeViewRight.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewRight_BeforeExpand);
            this.treeViewRight.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRight_AfterSelect);
            this.treeViewRight.Click += new System.EventHandler(this.treeViewRight_Click);
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeViewImageList.Images.SetKeyName(0, "closed-file-folder-google.png");
            this.treeViewImageList.Images.SetKeyName(1, "open-file-folder-google.png");
            // 
            // listViewRight
            // 
            this.listViewRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRight.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewRight.Location = new System.Drawing.Point(273, 3);
            this.listViewRight.Name = "listViewRight";
            this.listViewRight.Size = new System.Drawing.Size(449, 709);
            this.listViewRight.TabIndex = 1;
            this.listViewRight.UseCompatibleStateImageBehavior = false;
            this.listViewRight.View = System.Windows.Forms.View.List;
            this.listViewRight.Enter += new System.EventHandler(this.listViewRight_Enter);
            this.listViewRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewRight_MouseClick);
            this.listViewRight.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewRight_MouseDoubleClick);
            // 
            // tableLayoutPanelRightUp
            // 
            this.tableLayoutPanelRightUp.ColumnCount = 3;
            this.tableLayoutPanelRightUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelRightUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRightUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelRightUp.Controls.Add(this.tableLayoutPanelRightUpLeft, 0, 0);
            this.tableLayoutPanelRightUp.Controls.Add(this.tableLayoutPanelRightUpRight, 2, 0);
            this.tableLayoutPanelRightUp.Controls.Add(this.tableLayoutPanelRightUpCenter, 1, 0);
            this.tableLayoutPanelRightUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRightUp.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelRightUp.Name = "tableLayoutPanelRightUp";
            this.tableLayoutPanelRightUp.RowCount = 1;
            this.tableLayoutPanelRightUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRightUp.Size = new System.Drawing.Size(725, 54);
            this.tableLayoutPanelRightUp.TabIndex = 3;
            // 
            // tableLayoutPanelRightUpLeft
            // 
            this.tableLayoutPanelRightUpLeft.ColumnCount = 2;
            this.tableLayoutPanelRightUpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRightUpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRightUpLeft.Controls.Add(this.buttonRightLeft, 0, 0);
            this.tableLayoutPanelRightUpLeft.Controls.Add(this.buttonRightRight, 1, 0);
            this.tableLayoutPanelRightUpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRightUpLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelRightUpLeft.Name = "tableLayoutPanelRightUpLeft";
            this.tableLayoutPanelRightUpLeft.RowCount = 1;
            this.tableLayoutPanelRightUpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRightUpLeft.Size = new System.Drawing.Size(114, 48);
            this.tableLayoutPanelRightUpLeft.TabIndex = 1;
            // 
            // buttonRightLeft
            // 
            this.buttonRightLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRightLeft.Location = new System.Drawing.Point(3, 3);
            this.buttonRightLeft.Name = "buttonRightLeft";
            this.buttonRightLeft.Size = new System.Drawing.Size(51, 42);
            this.buttonRightLeft.TabIndex = 0;
            this.buttonRightLeft.Text = "L";
            this.buttonRightLeft.UseVisualStyleBackColor = true;
            // 
            // buttonRightRight
            // 
            this.buttonRightRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRightRight.Location = new System.Drawing.Point(60, 3);
            this.buttonRightRight.Name = "buttonRightRight";
            this.buttonRightRight.Size = new System.Drawing.Size(51, 42);
            this.buttonRightRight.TabIndex = 1;
            this.buttonRightRight.Text = "R";
            this.buttonRightRight.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelRightUpRight
            // 
            this.tableLayoutPanelRightUpRight.ColumnCount = 1;
            this.tableLayoutPanelRightUpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRightUpRight.Controls.Add(this.buttonRightUpdate, 0, 0);
            this.tableLayoutPanelRightUpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRightUpRight.Location = new System.Drawing.Point(668, 3);
            this.tableLayoutPanelRightUpRight.Name = "tableLayoutPanelRightUpRight";
            this.tableLayoutPanelRightUpRight.RowCount = 1;
            this.tableLayoutPanelRightUpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRightUpRight.Size = new System.Drawing.Size(54, 48);
            this.tableLayoutPanelRightUpRight.TabIndex = 2;
            // 
            // buttonRightUpdate
            // 
            this.buttonRightUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRightUpdate.Location = new System.Drawing.Point(3, 3);
            this.buttonRightUpdate.Name = "buttonRightUpdate";
            this.buttonRightUpdate.Size = new System.Drawing.Size(48, 42);
            this.buttonRightUpdate.TabIndex = 0;
            this.buttonRightUpdate.Text = "U";
            this.buttonRightUpdate.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelRightUpCenter
            // 
            this.tableLayoutPanelRightUpCenter.ColumnCount = 1;
            this.tableLayoutPanelRightUpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRightUpCenter.Controls.Add(this.comboBoxRightLink, 0, 0);
            this.tableLayoutPanelRightUpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRightUpCenter.Location = new System.Drawing.Point(123, 3);
            this.tableLayoutPanelRightUpCenter.Name = "tableLayoutPanelRightUpCenter";
            this.tableLayoutPanelRightUpCenter.RowCount = 1;
            this.tableLayoutPanelRightUpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelRightUpCenter.Size = new System.Drawing.Size(539, 48);
            this.tableLayoutPanelRightUpCenter.TabIndex = 3;
            // 
            // comboBoxRightLink
            // 
            this.comboBoxRightLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxRightLink.FormattingEnabled = true;
            this.comboBoxRightLink.Location = new System.Drawing.Point(3, 3);
            this.comboBoxRightLink.Name = "comboBoxRightLink";
            this.comboBoxRightLink.Size = new System.Drawing.Size(533, 40);
            this.comboBoxRightLink.TabIndex = 1;
            this.comboBoxRightLink.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxRightLink_KeyPress);
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.tableLayoutPanelLeftDown, 0, 1);
            this.tableLayoutPanelLeft.Controls.Add(this.tableLayoutPanelLeftUp, 0, 0);
            this.tableLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 2;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(731, 781);
            this.tableLayoutPanelLeft.TabIndex = 2;
            // 
            // tableLayoutPanelLeftDown
            // 
            this.tableLayoutPanelLeftDown.ColumnCount = 2;
            this.tableLayoutPanelLeftDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.34336F));
            this.tableLayoutPanelLeftDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.65664F));
            this.tableLayoutPanelLeftDown.Controls.Add(this.treeViewLeft, 0, 0);
            this.tableLayoutPanelLeftDown.Controls.Add(this.listViewLeft, 1, 0);
            this.tableLayoutPanelLeftDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeftDown.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanelLeftDown.Name = "tableLayoutPanelLeftDown";
            this.tableLayoutPanelLeftDown.RowCount = 1;
            this.tableLayoutPanelLeftDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeftDown.Size = new System.Drawing.Size(725, 717);
            this.tableLayoutPanelLeftDown.TabIndex = 1;
            // 
            // treeViewLeft
            // 
            this.treeViewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewLeft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeViewLeft.ImageIndex = 0;
            this.treeViewLeft.ImageList = this.treeViewImageList;
            this.treeViewLeft.Location = new System.Drawing.Point(3, 3);
            this.treeViewLeft.Name = "treeViewLeft";
            this.treeViewLeft.SelectedImageIndex = 0;
            this.treeViewLeft.ShowPlusMinus = false;
            this.treeViewLeft.ShowRootLines = false;
            this.treeViewLeft.Size = new System.Drawing.Size(264, 711);
            this.treeViewLeft.TabIndex = 0;
            this.treeViewLeft.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewLeft_BeforeCollapse);
            this.treeViewLeft.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewLeft_BeforeExpand);
            this.treeViewLeft.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewLeft_AfterSelect);
            this.treeViewLeft.Click += new System.EventHandler(this.treeViewLeft_Click);
            // 
            // listViewLeft
            // 
            this.listViewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLeft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewLeft.Location = new System.Drawing.Point(273, 3);
            this.listViewLeft.Name = "listViewLeft";
            this.listViewLeft.Size = new System.Drawing.Size(449, 711);
            this.listViewLeft.TabIndex = 1;
            this.listViewLeft.UseCompatibleStateImageBehavior = false;
            this.listViewLeft.View = System.Windows.Forms.View.List;
            this.listViewLeft.Enter += new System.EventHandler(this.listViewLeft_Enter);
            this.listViewLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewLeft_MouseClick);
            this.listViewLeft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewLeft_MouseDoubleClick_1);
            // 
            // tableLayoutPanelLeftUp
            // 
            this.tableLayoutPanelLeftUp.ColumnCount = 3;
            this.tableLayoutPanelLeftUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelLeftUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeftUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelLeftUp.Controls.Add(this.tableLayoutPanelLeftUpLeft, 0, 0);
            this.tableLayoutPanelLeftUp.Controls.Add(this.tableLayoutPanelLeftUpCenter, 1, 0);
            this.tableLayoutPanelLeftUp.Controls.Add(this.tableLayoutPanelLeftUpRight, 2, 0);
            this.tableLayoutPanelLeftUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeftUp.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLeftUp.Name = "tableLayoutPanelLeftUp";
            this.tableLayoutPanelLeftUp.RowCount = 1;
            this.tableLayoutPanelLeftUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeftUp.Size = new System.Drawing.Size(725, 54);
            this.tableLayoutPanelLeftUp.TabIndex = 2;
            // 
            // tableLayoutPanelLeftUpLeft
            // 
            this.tableLayoutPanelLeftUpLeft.ColumnCount = 2;
            this.tableLayoutPanelLeftUpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLeftUpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLeftUpLeft.Controls.Add(this.buttonLeftLeft, 0, 0);
            this.tableLayoutPanelLeftUpLeft.Controls.Add(this.buttonLeftRight, 1, 0);
            this.tableLayoutPanelLeftUpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeftUpLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLeftUpLeft.Name = "tableLayoutPanelLeftUpLeft";
            this.tableLayoutPanelLeftUpLeft.RowCount = 1;
            this.tableLayoutPanelLeftUpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLeftUpLeft.Size = new System.Drawing.Size(114, 48);
            this.tableLayoutPanelLeftUpLeft.TabIndex = 0;
            // 
            // buttonLeftLeft
            // 
            this.buttonLeftLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLeftLeft.Location = new System.Drawing.Point(3, 3);
            this.buttonLeftLeft.Name = "buttonLeftLeft";
            this.buttonLeftLeft.Size = new System.Drawing.Size(51, 42);
            this.buttonLeftLeft.TabIndex = 0;
            this.buttonLeftLeft.Text = "L";
            this.buttonLeftLeft.UseVisualStyleBackColor = true;
            // 
            // buttonLeftRight
            // 
            this.buttonLeftRight.Location = new System.Drawing.Point(60, 3);
            this.buttonLeftRight.Name = "buttonLeftRight";
            this.buttonLeftRight.Size = new System.Drawing.Size(51, 42);
            this.buttonLeftRight.TabIndex = 1;
            this.buttonLeftRight.Text = "R";
            this.buttonLeftRight.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelLeftUpCenter
            // 
            this.tableLayoutPanelLeftUpCenter.ColumnCount = 1;
            this.tableLayoutPanelLeftUpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLeftUpCenter.Controls.Add(this.comboBoxLeftLink, 0, 0);
            this.tableLayoutPanelLeftUpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeftUpCenter.Location = new System.Drawing.Point(123, 3);
            this.tableLayoutPanelLeftUpCenter.Name = "tableLayoutPanelLeftUpCenter";
            this.tableLayoutPanelLeftUpCenter.RowCount = 1;
            this.tableLayoutPanelLeftUpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLeftUpCenter.Size = new System.Drawing.Size(539, 48);
            this.tableLayoutPanelLeftUpCenter.TabIndex = 1;
            // 
            // comboBoxLeftLink
            // 
            this.comboBoxLeftLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxLeftLink.FormattingEnabled = true;
            this.comboBoxLeftLink.Location = new System.Drawing.Point(3, 3);
            this.comboBoxLeftLink.Name = "comboBoxLeftLink";
            this.comboBoxLeftLink.Size = new System.Drawing.Size(533, 40);
            this.comboBoxLeftLink.TabIndex = 1;
            this.comboBoxLeftLink.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxLeftLink_KeyPress);
            // 
            // tableLayoutPanelLeftUpRight
            // 
            this.tableLayoutPanelLeftUpRight.ColumnCount = 1;
            this.tableLayoutPanelLeftUpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLeftUpRight.Controls.Add(this.buttonLeftUpdate, 0, 0);
            this.tableLayoutPanelLeftUpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeftUpRight.Location = new System.Drawing.Point(668, 3);
            this.tableLayoutPanelLeftUpRight.Name = "tableLayoutPanelLeftUpRight";
            this.tableLayoutPanelLeftUpRight.RowCount = 1;
            this.tableLayoutPanelLeftUpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLeftUpRight.Size = new System.Drawing.Size(54, 48);
            this.tableLayoutPanelLeftUpRight.TabIndex = 2;
            // 
            // buttonLeftUpdate
            // 
            this.buttonLeftUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLeftUpdate.Location = new System.Drawing.Point(3, 3);
            this.buttonLeftUpdate.Name = "buttonLeftUpdate";
            this.buttonLeftUpdate.Size = new System.Drawing.Size(48, 42);
            this.buttonLeftUpdate.TabIndex = 0;
            this.buttonLeftUpdate.Text = "U";
            this.buttonLeftUpdate.UseVisualStyleBackColor = true;
            // 
            // listViewImageList
            // 
            this.listViewImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.listViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listViewImageList.ImageStream")));
            this.listViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.listViewImageList.Images.SetKeyName(0, "file-document.png");
            // 
            // FileManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 829);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FileManagerForm";
            this.Text = "File Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.tableLayoutPanelRightDown.ResumeLayout(false);
            this.tableLayoutPanelRightUp.ResumeLayout(false);
            this.tableLayoutPanelRightUpLeft.ResumeLayout(false);
            this.tableLayoutPanelRightUpRight.ResumeLayout(false);
            this.tableLayoutPanelRightUpCenter.ResumeLayout(false);
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.tableLayoutPanelLeftDown.ResumeLayout(false);
            this.tableLayoutPanelLeftUp.ResumeLayout(false);
            this.tableLayoutPanelLeftUpLeft.ResumeLayout(false);
            this.tableLayoutPanelLeftUpCenter.ResumeLayout(false);
            this.tableLayoutPanelLeftUpRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem programToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanelRight;
        private TableLayoutPanel tableLayoutPanelRightDown;
        private TableLayoutPanel tableLayoutPanelLeft;
        private TableLayoutPanel tableLayoutPanelLeftDown;
        private TreeView treeViewRight;
        private ListView listViewRight;
        private TreeView treeViewLeft;
        private ListView listViewLeft;
        private TableLayoutPanel tableLayoutPanelRightUp;
        private TableLayoutPanel tableLayoutPanelLeftUp;
        private TableLayoutPanel tableLayoutPanelRightUpLeft;
        private TableLayoutPanel tableLayoutPanelRightUpRight;
        private Button buttonRightUpdate;
        private TableLayoutPanel tableLayoutPanelRightUpCenter;
        private ComboBox comboBoxRightLink;
        private Button buttonRightLeft;
        private Button buttonRightRight;
        private TableLayoutPanel tableLayoutPanelLeftUpLeft;
        private TableLayoutPanel tableLayoutPanelLeftUpCenter;
        private ComboBox comboBoxLeftLink;
        private TableLayoutPanel tableLayoutPanelLeftUpRight;
        private Button buttonLeftLeft;
        private Button buttonLeftRight;
        private Button buttonLeftUpdate;
        private ImageList treeViewImageList;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ImageList listViewImageList;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem initializeToolStripMenuItem;
    }
}