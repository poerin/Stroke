namespace Stroke.Configure
{
    partial class Configure
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configure));
            this.panel = new System.Windows.Forms.Panel();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.buttonSpy = new System.Windows.Forms.Button();
            this.comboBoxGesture = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.treeViewAction = new System.Windows.Forms.TreeView();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxMouse = new System.Windows.Forms.ComboBox();
            this.buttonGesture = new System.Windows.Forms.Button();
            this.buttonPen = new System.Windows.Forms.Button();
            this.ContextMenuStripActionPackage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddActionPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRemoveActionPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStripAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemAddAction = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemRemoveAction = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCompile = new System.Windows.Forms.Button();
            this.buttonFiltration = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.ContextMenuStripActionPackage.SuspendLayout();
            this.ContextMenuStripAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.AliceBlue;
            this.panel.Controls.Add(this.textBoxCode);
            this.panel.Controls.Add(this.buttonSpy);
            this.panel.Controls.Add(this.comboBoxGesture);
            this.panel.Controls.Add(this.textBoxName);
            this.panel.Controls.Add(this.treeViewAction);
            this.panel.Location = new System.Drawing.Point(12, 40);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(920, 510);
            this.panel.TabIndex = 7;
            // 
            // textBoxCode
            // 
            this.textBoxCode.AcceptsReturn = true;
            this.textBoxCode.AcceptsTab = true;
            this.textBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCode.Font = new System.Drawing.Font("Consolas", 12F);
            this.textBoxCode.Location = new System.Drawing.Point(230, 45);
            this.textBoxCode.MaxLength = 2147483647;
            this.textBoxCode.Multiline = true;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCode.Size = new System.Drawing.Size(685, 462);
            this.textBoxCode.TabIndex = 4;
            this.textBoxCode.WordWrap = false;
            this.textBoxCode.TextChanged += new System.EventHandler(this.textBoxCode_TextChanged);
            // 
            // buttonSpy
            // 
            this.buttonSpy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSpy.Location = new System.Drawing.Point(850, 11);
            this.buttonSpy.Name = "buttonSpy";
            this.buttonSpy.Size = new System.Drawing.Size(65, 25);
            this.buttonSpy.TabIndex = 3;
            this.buttonSpy.Text = "添加路径";
            this.buttonSpy.UseVisualStyleBackColor = true;
            this.buttonSpy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonSpy_MouseDown);
            // 
            // comboBoxGesture
            // 
            this.comboBoxGesture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxGesture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGesture.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxGesture.FormattingEnabled = true;
            this.comboBoxGesture.Location = new System.Drawing.Point(636, 11);
            this.comboBoxGesture.Name = "comboBoxGesture";
            this.comboBoxGesture.Size = new System.Drawing.Size(195, 25);
            this.comboBoxGesture.TabIndex = 2;
            this.comboBoxGesture.SelectedIndexChanged += new System.EventHandler(this.comboBoxGesture_SelectedIndexChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxName.Location = new System.Drawing.Point(230, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(400, 23);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // treeViewAction
            // 
            this.treeViewAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewAction.HideSelection = false;
            this.treeViewAction.Location = new System.Drawing.Point(3, 3);
            this.treeViewAction.Name = "treeViewAction";
            this.treeViewAction.Size = new System.Drawing.Size(221, 504);
            this.treeViewAction.TabIndex = 0;
            this.treeViewAction.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAction_AfterSelect);
            this.treeViewAction.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewAction_MouseClick);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(806, 8);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(60, 25);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(872, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(60, 25);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxMouse
            // 
            this.comboBoxMouse.AllowDrop = true;
            this.comboBoxMouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMouse.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxMouse.FormattingEnabled = true;
            this.comboBoxMouse.Items.AddRange(new object[] {
            "中键",
            "左键",
            "右键",
            "X1",
            "X2"});
            this.comboBoxMouse.Location = new System.Drawing.Point(15, 8);
            this.comboBoxMouse.Name = "comboBoxMouse";
            this.comboBoxMouse.Size = new System.Drawing.Size(62, 25);
            this.comboBoxMouse.TabIndex = 0;
            this.comboBoxMouse.SelectedIndexChanged += new System.EventHandler(this.comboBoxMouse_SelectedIndexChanged);
            // 
            // buttonGesture
            // 
            this.buttonGesture.Location = new System.Drawing.Point(189, 8);
            this.buttonGesture.Name = "buttonGesture";
            this.buttonGesture.Size = new System.Drawing.Size(100, 25);
            this.buttonGesture.TabIndex = 2;
            this.buttonGesture.Text = "手势设置";
            this.buttonGesture.UseVisualStyleBackColor = true;
            this.buttonGesture.Click += new System.EventHandler(this.buttonGesture_Click);
            // 
            // buttonPen
            // 
            this.buttonPen.Location = new System.Drawing.Point(83, 8);
            this.buttonPen.Name = "buttonPen";
            this.buttonPen.Size = new System.Drawing.Size(100, 25);
            this.buttonPen.TabIndex = 1;
            this.buttonPen.Text = "画笔设置";
            this.buttonPen.UseVisualStyleBackColor = true;
            this.buttonPen.Click += new System.EventHandler(this.buttonPen_Click);
            // 
            // ContextMenuStripActionPackage
            // 
            this.ContextMenuStripActionPackage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddActionPackage,
            this.ToolStripMenuItemRemoveActionPackage});
            this.ContextMenuStripActionPackage.Name = "ContextMenuStripActionPackage";
            this.ContextMenuStripActionPackage.Size = new System.Drawing.Size(149, 48);
            // 
            // ToolStripMenuItemAddActionPackage
            // 
            this.ToolStripMenuItemAddActionPackage.Name = "ToolStripMenuItemAddActionPackage";
            this.ToolStripMenuItemAddActionPackage.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItemAddActionPackage.Text = "添加 [动作包]";
            // 
            // ToolStripMenuItemRemoveActionPackage
            // 
            this.ToolStripMenuItemRemoveActionPackage.Name = "ToolStripMenuItemRemoveActionPackage";
            this.ToolStripMenuItemRemoveActionPackage.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItemRemoveActionPackage.Text = "删除 [动作包]";
            // 
            // ContextMenuStripAction
            // 
            this.ContextMenuStripAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAddAction,
            this.ToolStripMenuItemRemoveAction});
            this.ContextMenuStripAction.Name = "ContextMenuStripAction";
            this.ContextMenuStripAction.Size = new System.Drawing.Size(137, 48);
            // 
            // ToolStripMenuItemAddAction
            // 
            this.ToolStripMenuItemAddAction.Name = "ToolStripMenuItemAddAction";
            this.ToolStripMenuItemAddAction.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItemAddAction.Text = "添加 [动作]";
            // 
            // ToolStripMenuItemRemoveAction
            // 
            this.ToolStripMenuItemRemoveAction.Name = "ToolStripMenuItemRemoveAction";
            this.ToolStripMenuItemRemoveAction.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItemRemoveAction.Text = "删除 [动作]";
            // 
            // buttonCompile
            // 
            this.buttonCompile.Location = new System.Drawing.Point(295, 8);
            this.buttonCompile.Name = "buttonCompile";
            this.buttonCompile.Size = new System.Drawing.Size(100, 25);
            this.buttonCompile.TabIndex = 3;
            this.buttonCompile.Text = "编译设置";
            this.buttonCompile.UseVisualStyleBackColor = true;
            this.buttonCompile.Click += new System.EventHandler(this.buttonCompile_Click);
            // 
            // buttonFiltration
            // 
            this.buttonFiltration.Location = new System.Drawing.Point(401, 8);
            this.buttonFiltration.Name = "buttonFiltration";
            this.buttonFiltration.Size = new System.Drawing.Size(100, 25);
            this.buttonFiltration.TabIndex = 4;
            this.buttonFiltration.Text = "过滤设置";
            this.buttonFiltration.UseVisualStyleBackColor = true;
            this.buttonFiltration.Click += new System.EventHandler(this.buttonFiltration_Click);
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.ControlBox = false;
            this.Controls.Add(this.buttonFiltration);
            this.Controls.Add(this.buttonCompile);
            this.Controls.Add(this.buttonPen);
            this.Controls.Add(this.buttonGesture);
            this.Controls.Add(this.comboBoxMouse);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(960, 600);
            this.Name = "Configure";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置";
            this.Load += new System.EventHandler(this.Configure_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ContextMenuStripActionPackage.ResumeLayout(false);
            this.ContextMenuStripAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TreeView treeViewAction;
        private System.Windows.Forms.ComboBox comboBoxMouse;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxGesture;
        private System.Windows.Forms.Button buttonGesture;
        private System.Windows.Forms.Button buttonPen;

        private PenConfigure PenConfigure;
        private GestureConfigure GestureConfigure;
        private CompileConfigure CompileConfigure;
        private FiltrationConfigure FiltrationConfigure;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripActionPackage;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripAction;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddActionPackage;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRemoveActionPackage;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAddAction;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRemoveAction;
        private System.Windows.Forms.Button buttonSpy;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Button buttonCompile;
        private System.Windows.Forms.Button buttonFiltration;
    }
}

