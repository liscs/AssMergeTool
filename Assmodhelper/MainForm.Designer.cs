namespace AssMergeTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.AddAss1 = new System.Windows.Forms.Button();
            this.DelAss1 = new System.Windows.Forms.Button();
            this.AssList1 = new System.Windows.Forms.ListBox();
            this.Save = new System.Windows.Forms.Button();
            this.Down1 = new System.Windows.Forms.Button();
            this.Up1 = new System.Windows.Forms.Button();
            this.Up2 = new System.Windows.Forms.Button();
            this.Down2 = new System.Windows.Forms.Button();
            this.AssList2 = new System.Windows.Forms.ListBox();
            this.DelAss2 = new System.Windows.Forms.Button();
            this.AddAss2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddAss1
            // 
            this.AddAss1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddAss1.Location = new System.Drawing.Point(381, 37);
            this.AddAss1.Name = "AddAss1";
            this.AddAss1.Size = new System.Drawing.Size(43, 23);
            this.AddAss1.TabIndex = 1;
            this.AddAss1.Text = "+";
            this.AddAss1.UseVisualStyleBackColor = true;
            this.AddAss1.Click += new System.EventHandler(this.AddAss_Click);
            // 
            // DelAss1
            // 
            this.DelAss1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DelAss1.Location = new System.Drawing.Point(381, 66);
            this.DelAss1.Name = "DelAss1";
            this.DelAss1.Size = new System.Drawing.Size(43, 23);
            this.DelAss1.TabIndex = 2;
            this.DelAss1.Text = "-";
            this.DelAss1.UseVisualStyleBackColor = true;
            this.DelAss1.Click += new System.EventHandler(this.DelAss_Click);
            // 
            // AssList1
            // 
            this.AssList1.AllowDrop = true;
            this.AssList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AssList1.FormattingEnabled = true;
            this.AssList1.ItemHeight = 12;
            this.AssList1.Location = new System.Drawing.Point(12, 37);
            this.AssList1.Name = "AssList1";
            this.AssList1.Size = new System.Drawing.Size(363, 184);
            this.AssList1.TabIndex = 3;
            this.AssList1.SelectedIndexChanged += new System.EventHandler(this.AssList1_SelectedIndexChanged);
            this.AssList1.DragDrop += new System.Windows.Forms.DragEventHandler(this.AssList1_DragDrop);
            this.AssList1.DragEnter += new System.Windows.Forms.DragEventHandler(this.AssList_DragEnter);
            // 
            // Save
            // 
            this.Save.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Save.Location = new System.Drawing.Point(381, 153);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(104, 51);
            this.Save.TabIndex = 8;
            this.Save.Text = "执行合并";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Down1
            // 
            this.Down1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Down1.Enabled = false;
            this.Down1.Location = new System.Drawing.Point(381, 124);
            this.Down1.Name = "Down1";
            this.Down1.Size = new System.Drawing.Size(43, 23);
            this.Down1.TabIndex = 9;
            this.Down1.Text = "↓";
            this.Down1.UseVisualStyleBackColor = true;
            this.Down1.Click += new System.EventHandler(this.Down_Click);
            // 
            // Up1
            // 
            this.Up1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Up1.Enabled = false;
            this.Up1.Location = new System.Drawing.Point(381, 95);
            this.Up1.Name = "Up1";
            this.Up1.Size = new System.Drawing.Size(43, 23);
            this.Up1.TabIndex = 10;
            this.Up1.Text = "↑";
            this.Up1.UseVisualStyleBackColor = true;
            this.Up1.Click += new System.EventHandler(this.Up_Click);
            // 
            // Up2
            // 
            this.Up2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Up2.Enabled = false;
            this.Up2.Location = new System.Drawing.Point(442, 95);
            this.Up2.Name = "Up2";
            this.Up2.Size = new System.Drawing.Size(43, 23);
            this.Up2.TabIndex = 15;
            this.Up2.Text = "↑";
            this.Up2.UseVisualStyleBackColor = true;
            this.Up2.Click += new System.EventHandler(this.Up_Click);
            // 
            // Down2
            // 
            this.Down2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Down2.Enabled = false;
            this.Down2.Location = new System.Drawing.Point(442, 124);
            this.Down2.Name = "Down2";
            this.Down2.Size = new System.Drawing.Size(43, 23);
            this.Down2.TabIndex = 14;
            this.Down2.Text = "↓";
            this.Down2.UseVisualStyleBackColor = true;
            this.Down2.Click += new System.EventHandler(this.Down_Click);
            // 
            // AssList2
            // 
            this.AssList2.AllowDrop = true;
            this.AssList2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AssList2.FormattingEnabled = true;
            this.AssList2.ItemHeight = 12;
            this.AssList2.Location = new System.Drawing.Point(491, 37);
            this.AssList2.Name = "AssList2";
            this.AssList2.Size = new System.Drawing.Size(363, 184);
            this.AssList2.TabIndex = 13;
            this.AssList2.SelectedIndexChanged += new System.EventHandler(this.AssList2_SelectedIndexChanged);
            this.AssList2.DragDrop += new System.Windows.Forms.DragEventHandler(this.AssList2_DragDrop);
            this.AssList2.DragEnter += new System.Windows.Forms.DragEventHandler(this.AssList_DragEnter);
            // 
            // DelAss2
            // 
            this.DelAss2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DelAss2.Location = new System.Drawing.Point(442, 66);
            this.DelAss2.Name = "DelAss2";
            this.DelAss2.Size = new System.Drawing.Size(43, 23);
            this.DelAss2.TabIndex = 12;
            this.DelAss2.Text = "-";
            this.DelAss2.UseVisualStyleBackColor = true;
            this.DelAss2.Click += new System.EventHandler(this.DelAss_Click);
            // 
            // AddAss2
            // 
            this.AddAss2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddAss2.Location = new System.Drawing.Point(442, 37);
            this.AddAss2.Name = "AddAss2";
            this.AddAss2.Size = new System.Drawing.Size(43, 23);
            this.AddAss2.TabIndex = 11;
            this.AddAss2.Text = "+";
            this.AddAss2.UseVisualStyleBackColor = true;
            this.AddAss2.Click += new System.EventHandler(this.AddAss_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "被合并文件";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "并入目标文件";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 261);
            this.Controls.Add(this.AssList2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Up2);
            this.Controls.Add(this.Down2);
            this.Controls.Add(this.DelAss2);
            this.Controls.Add(this.AddAss2);
            this.Controls.Add(this.Up1);
            this.Controls.Add(this.Down1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AssList1);
            this.Controls.Add(this.DelAss1);
            this.Controls.Add(this.AddAss1);
            this.MinimumSize = new System.Drawing.Size(882, 300);
            this.Name = "MainForm";
            this.Text = "ASS对应向右合并";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddAss1;
        private System.Windows.Forms.Button DelAss1;
        private System.Windows.Forms.ListBox AssList1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Down1;
        private System.Windows.Forms.Button Up1;
        private System.Windows.Forms.Button Up2;
        private System.Windows.Forms.Button Down2;
        private System.Windows.Forms.ListBox AssList2;
        private System.Windows.Forms.Button DelAss2;
        private System.Windows.Forms.Button AddAss2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

