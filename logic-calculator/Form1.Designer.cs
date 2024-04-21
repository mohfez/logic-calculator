namespace logic_calculator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabsControl = new System.Windows.Forms.TabControl();
            this.calcPage = new System.Windows.Forms.TabPage();
            this.disclaimer = new System.Windows.Forms.Label();
            this.dropboxHeader = new System.Windows.Forms.Label();
            this.xorBtn = new System.Windows.Forms.Button();
            this.equivBtn = new System.Windows.Forms.Button();
            this.impliesLBtn = new System.Windows.Forms.Button();
            this.impliesRbtn = new System.Windows.Forms.Button();
            this.andBtn = new System.Windows.Forms.Button();
            this.orBtn = new System.Windows.Forms.Button();
            this.notBtn = new System.Windows.Forms.Button();
            this.clrBtn = new System.Windows.Forms.Button();
            this.execBtn = new System.Windows.Forms.Button();
            this.taskDropdown = new System.Windows.Forms.ComboBox();
            this.expressionTxtBox = new System.Windows.Forms.RichTextBox();
            this.resPage = new System.Windows.Forms.TabPage();
            this.resListBox = new System.Windows.Forms.ListBox();
            this.graphPage = new System.Windows.Forms.TabPage();
            this.locateBtn = new System.Windows.Forms.Button();
            this.resListBoxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphViewer = new GraphViewer.GraphView();
            this.tabsControl.SuspendLayout();
            this.calcPage.SuspendLayout();
            this.resPage.SuspendLayout();
            this.graphPage.SuspendLayout();
            this.resListBoxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsControl
            // 
            this.tabsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsControl.Controls.Add(this.calcPage);
            this.tabsControl.Controls.Add(this.resPage);
            this.tabsControl.Controls.Add(this.graphPage);
            this.tabsControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabsControl.Location = new System.Drawing.Point(-4, -1);
            this.tabsControl.Name = "tabsControl";
            this.tabsControl.SelectedIndex = 0;
            this.tabsControl.Size = new System.Drawing.Size(616, 391);
            this.tabsControl.TabIndex = 0;
            // 
            // calcPage
            // 
            this.calcPage.Controls.Add(this.disclaimer);
            this.calcPage.Controls.Add(this.dropboxHeader);
            this.calcPage.Controls.Add(this.xorBtn);
            this.calcPage.Controls.Add(this.equivBtn);
            this.calcPage.Controls.Add(this.impliesLBtn);
            this.calcPage.Controls.Add(this.impliesRbtn);
            this.calcPage.Controls.Add(this.andBtn);
            this.calcPage.Controls.Add(this.orBtn);
            this.calcPage.Controls.Add(this.notBtn);
            this.calcPage.Controls.Add(this.clrBtn);
            this.calcPage.Controls.Add(this.execBtn);
            this.calcPage.Controls.Add(this.taskDropdown);
            this.calcPage.Controls.Add(this.expressionTxtBox);
            this.calcPage.Location = new System.Drawing.Point(4, 25);
            this.calcPage.Name = "calcPage";
            this.calcPage.Padding = new System.Windows.Forms.Padding(3);
            this.calcPage.Size = new System.Drawing.Size(608, 362);
            this.calcPage.TabIndex = 0;
            this.calcPage.Text = "Calculator";
            this.calcPage.UseVisualStyleBackColor = true;
            // 
            // disclaimer
            // 
            this.disclaimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.disclaimer.Location = new System.Drawing.Point(16, 3);
            this.disclaimer.MaximumSize = new System.Drawing.Size(985, 64);
            this.disclaimer.Name = "disclaimer";
            this.disclaimer.Size = new System.Drawing.Size(582, 60);
            this.disclaimer.TabIndex = 12;
            this.disclaimer.Text = resources.GetString("disclaimer.Text");
            // 
            // dropboxHeader
            // 
            this.dropboxHeader.AutoSize = true;
            this.dropboxHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropboxHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dropboxHeader.Location = new System.Drawing.Point(16, 223);
            this.dropboxHeader.Name = "dropboxHeader";
            this.dropboxHeader.Size = new System.Drawing.Size(38, 16);
            this.dropboxHeader.TabIndex = 11;
            this.dropboxHeader.Text = "Task";
            this.dropboxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xorBtn
            // 
            this.xorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xorBtn.Location = new System.Drawing.Point(397, 151);
            this.xorBtn.Name = "xorBtn";
            this.xorBtn.Size = new System.Drawing.Size(49, 49);
            this.xorBtn.TabIndex = 10;
            this.xorBtn.Text = "⊕";
            this.xorBtn.UseVisualStyleBackColor = true;
            this.xorBtn.Click += new System.EventHandler(this.xorBtn_Click);
            // 
            // equivBtn
            // 
            this.equivBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equivBtn.Location = new System.Drawing.Point(334, 151);
            this.equivBtn.Name = "equivBtn";
            this.equivBtn.Size = new System.Drawing.Size(49, 49);
            this.equivBtn.TabIndex = 9;
            this.equivBtn.Text = "↔";
            this.equivBtn.UseVisualStyleBackColor = true;
            this.equivBtn.Click += new System.EventHandler(this.equivBtn_Click);
            // 
            // impliesLBtn
            // 
            this.impliesLBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.impliesLBtn.Location = new System.Drawing.Point(271, 151);
            this.impliesLBtn.Name = "impliesLBtn";
            this.impliesLBtn.Size = new System.Drawing.Size(49, 49);
            this.impliesLBtn.TabIndex = 8;
            this.impliesLBtn.Text = "←";
            this.impliesLBtn.UseVisualStyleBackColor = true;
            this.impliesLBtn.Click += new System.EventHandler(this.impliesLBtn_Click);
            // 
            // impliesRbtn
            // 
            this.impliesRbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.impliesRbtn.Location = new System.Drawing.Point(208, 151);
            this.impliesRbtn.Name = "impliesRbtn";
            this.impliesRbtn.Size = new System.Drawing.Size(49, 49);
            this.impliesRbtn.TabIndex = 7;
            this.impliesRbtn.Text = "→";
            this.impliesRbtn.UseVisualStyleBackColor = true;
            this.impliesRbtn.Click += new System.EventHandler(this.impliesRbtn_Click);
            // 
            // andBtn
            // 
            this.andBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.andBtn.Location = new System.Drawing.Point(145, 151);
            this.andBtn.Name = "andBtn";
            this.andBtn.Size = new System.Drawing.Size(49, 49);
            this.andBtn.TabIndex = 6;
            this.andBtn.Text = "∧";
            this.andBtn.UseVisualStyleBackColor = true;
            this.andBtn.Click += new System.EventHandler(this.andBtn_Click);
            // 
            // orBtn
            // 
            this.orBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orBtn.Location = new System.Drawing.Point(82, 151);
            this.orBtn.Name = "orBtn";
            this.orBtn.Size = new System.Drawing.Size(49, 49);
            this.orBtn.TabIndex = 5;
            this.orBtn.Text = "∨";
            this.orBtn.UseVisualStyleBackColor = true;
            this.orBtn.Click += new System.EventHandler(this.orBtn_Click);
            // 
            // notBtn
            // 
            this.notBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notBtn.Location = new System.Drawing.Point(19, 151);
            this.notBtn.Name = "notBtn";
            this.notBtn.Size = new System.Drawing.Size(49, 49);
            this.notBtn.TabIndex = 4;
            this.notBtn.Text = "¬";
            this.notBtn.UseVisualStyleBackColor = true;
            this.notBtn.Click += new System.EventHandler(this.notBtn_Click);
            // 
            // clrBtn
            // 
            this.clrBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clrBtn.Location = new System.Drawing.Point(149, 283);
            this.clrBtn.Name = "clrBtn";
            this.clrBtn.Size = new System.Drawing.Size(112, 60);
            this.clrBtn.TabIndex = 3;
            this.clrBtn.Text = "Clear";
            this.clrBtn.UseVisualStyleBackColor = true;
            this.clrBtn.Click += new System.EventHandler(this.clrBtn_Click);
            // 
            // execBtn
            // 
            this.execBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.execBtn.Location = new System.Drawing.Point(19, 283);
            this.execBtn.Name = "execBtn";
            this.execBtn.Size = new System.Drawing.Size(112, 60);
            this.execBtn.TabIndex = 2;
            this.execBtn.Text = "Execute";
            this.execBtn.UseVisualStyleBackColor = true;
            this.execBtn.Click += new System.EventHandler(this.execBtn_Click);
            // 
            // taskDropdown
            // 
            this.taskDropdown.FormattingEnabled = true;
            this.taskDropdown.Items.AddRange(new object[] {
            "To CNF",
            "To DNF",
            "Show Truth Table",
            "Show Tree Graph"});
            this.taskDropdown.Location = new System.Drawing.Point(19, 242);
            this.taskDropdown.Name = "taskDropdown";
            this.taskDropdown.Size = new System.Drawing.Size(286, 24);
            this.taskDropdown.TabIndex = 1;
            // 
            // expressionTxtBox
            // 
            this.expressionTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionTxtBox.Location = new System.Drawing.Point(19, 66);
            this.expressionTxtBox.Name = "expressionTxtBox";
            this.expressionTxtBox.Size = new System.Drawing.Size(542, 64);
            this.expressionTxtBox.TabIndex = 0;
            this.expressionTxtBox.Text = "Enter an expression here.";
            // 
            // resPage
            // 
            this.resPage.Controls.Add(this.resListBox);
            this.resPage.Location = new System.Drawing.Point(4, 25);
            this.resPage.Name = "resPage";
            this.resPage.Padding = new System.Windows.Forms.Padding(3);
            this.resPage.Size = new System.Drawing.Size(608, 362);
            this.resPage.TabIndex = 1;
            this.resPage.Text = "Result";
            this.resPage.UseVisualStyleBackColor = true;
            // 
            // resListBox
            // 
            this.resListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resListBox.FormattingEnabled = true;
            this.resListBox.HorizontalScrollbar = true;
            this.resListBox.ItemHeight = 16;
            this.resListBox.Location = new System.Drawing.Point(3, 3);
            this.resListBox.Name = "resListBox";
            this.resListBox.Size = new System.Drawing.Size(602, 356);
            this.resListBox.TabIndex = 0;
            this.resListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resListBox_MouseDown);
            // 
            // graphPage
            // 
            this.graphPage.Controls.Add(this.locateBtn);
            this.graphPage.Controls.Add(this.graphViewer);
            this.graphPage.Location = new System.Drawing.Point(4, 25);
            this.graphPage.Name = "graphPage";
            this.graphPage.Size = new System.Drawing.Size(608, 362);
            this.graphPage.TabIndex = 2;
            this.graphPage.Text = "Graph View";
            this.graphPage.UseVisualStyleBackColor = true;
            // 
            // locateBtn
            // 
            this.locateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locateBtn.Location = new System.Drawing.Point(0, 0);
            this.locateBtn.Name = "locateBtn";
            this.locateBtn.Size = new System.Drawing.Size(608, 23);
            this.locateBtn.TabIndex = 1;
            this.locateBtn.Text = "Locate";
            this.locateBtn.UseVisualStyleBackColor = true;
            this.locateBtn.Click += new System.EventHandler(this.locatebtn_Click);
            // 
            // resListBoxMenu
            // 
            this.resListBoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.resListBoxMenu.Name = "resListBoxMenu";
            this.resListBoxMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // graphViewer
            // 
            this.graphViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphViewer.Location = new System.Drawing.Point(0, 21);
            this.graphViewer.Name = "graphViewer";
            this.graphViewer.Size = new System.Drawing.Size(608, 341);
            this.graphViewer.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 388);
            this.Controls.Add(this.tabsControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Logic Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabsControl.ResumeLayout(false);
            this.calcPage.ResumeLayout(false);
            this.calcPage.PerformLayout();
            this.resPage.ResumeLayout(false);
            this.graphPage.ResumeLayout(false);
            this.resListBoxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsControl;
        private System.Windows.Forms.TabPage calcPage;
        private System.Windows.Forms.TabPage resPage;
        private System.Windows.Forms.Label disclaimer;
        private System.Windows.Forms.Label dropboxHeader;
        private System.Windows.Forms.Button xorBtn;
        private System.Windows.Forms.Button equivBtn;
        private System.Windows.Forms.Button impliesLBtn;
        private System.Windows.Forms.Button impliesRbtn;
        private System.Windows.Forms.Button andBtn;
        private System.Windows.Forms.Button orBtn;
        private System.Windows.Forms.Button notBtn;
        private System.Windows.Forms.Button clrBtn;
        private System.Windows.Forms.Button execBtn;
        private System.Windows.Forms.ComboBox taskDropdown;
        private System.Windows.Forms.RichTextBox expressionTxtBox;
        private System.Windows.Forms.ListBox resListBox;
        private System.Windows.Forms.TabPage graphPage;
        private GraphViewer.GraphView graphViewer;
        private System.Windows.Forms.Button locateBtn;
        private System.Windows.Forms.ContextMenuStrip resListBoxMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    }
}

