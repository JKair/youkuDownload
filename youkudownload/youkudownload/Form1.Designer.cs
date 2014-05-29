namespace youkudownload
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.downloadButton = new System.Windows.Forms.Button();
            this.downloadUrlTextBox = new System.Windows.Forms.TextBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.brows = new System.Windows.Forms.Button();
            this.downloadProcess = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folderPath = new System.Windows.Forms.FolderBrowserDialog();
            this.downloadInfo = new System.Windows.Forms.Label();
            this.about = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(333, 225);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "下载";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.download_Click);
            // 
            // downloadUrlTextBox
            // 
            this.downloadUrlTextBox.Location = new System.Drawing.Point(25, 54);
            this.downloadUrlTextBox.Name = "downloadUrlTextBox";
            this.downloadUrlTextBox.Size = new System.Drawing.Size(383, 21);
            this.downloadUrlTextBox.TabIndex = 2;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(25, 112);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(305, 21);
            this.pathTextBox.TabIndex = 3;
            // 
            // brows
            // 
            this.brows.Location = new System.Drawing.Point(349, 112);
            this.brows.Name = "brows";
            this.brows.Size = new System.Drawing.Size(59, 23);
            this.brows.TabIndex = 4;
            this.brows.Text = "浏览";
            this.brows.UseVisualStyleBackColor = true;
            this.brows.Click += new System.EventHandler(this.brows_Click);
            // 
            // downloadProcess
            // 
            this.downloadProcess.Location = new System.Drawing.Point(25, 171);
            this.downloadProcess.Name = "downloadProcess";
            this.downloadProcess.Size = new System.Drawing.Size(383, 23);
            this.downloadProcess.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "选择下载链接：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "保存地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "下载进度：";
            // 
            // downloadInfo
            // 
            this.downloadInfo.AutoSize = true;
            this.downloadInfo.Location = new System.Drawing.Point(212, 215);
            this.downloadInfo.Name = "downloadInfo";
            this.downloadInfo.Size = new System.Drawing.Size(0, 12);
            this.downloadInfo.TabIndex = 9;
            this.downloadInfo.Click += new System.EventHandler(this.label4_Click);
            // 
            // about
            // 
            this.about.AutoSize = true;
            this.about.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.about.Location = new System.Drawing.Point(23, 230);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(35, 14);
            this.about.TabIndex = 10;
            this.about.Text = "关于";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(440, 260);
            this.Controls.Add(this.about);
            this.Controls.Add(this.downloadInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downloadProcess);
            this.Controls.Add(this.brows);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.downloadUrlTextBox);
            this.Controls.Add(this.downloadButton);
            this.Name = "Form1";
            this.Text = "优酷电影下载";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.TextBox downloadUrlTextBox;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button brows;
        private System.Windows.Forms.ProgressBar downloadProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderPath;
        private System.Windows.Forms.Label downloadInfo;
        private System.Windows.Forms.Label about;
    }
}

