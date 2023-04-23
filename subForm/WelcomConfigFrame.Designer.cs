namespace DouYinFetch.subForm
{
    partial class WelcomConfigFrame
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
            this.configTabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.payLevelLab = new System.Windows.Forms.Label();
            this.payLevelText = new System.Windows.Forms.TextBox();
            this.payLevelLab1 = new System.Windows.Forms.Label();
            this.welcomeLab = new System.Windows.Forms.Label();
            this.welcomeText = new System.Windows.Forms.TextBox();
            this.configTabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // configTabControl
            // 
            this.configTabControl.Controls.Add(this.tabPage2);
            this.configTabControl.Controls.Add(this.tabPage1);
            this.configTabControl.Location = new System.Drawing.Point(2, 4);
            this.configTabControl.Name = "configTabControl";
            this.configTabControl.SelectedIndex = 0;
            this.configTabControl.Size = new System.Drawing.Size(556, 332);
            this.configTabControl.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.welcomeText);
            this.tabPage2.Controls.Add(this.welcomeLab);
            this.tabPage2.Controls.Add(this.payLevelLab1);
            this.tabPage2.Controls.Add(this.payLevelText);
            this.tabPage2.Controls.Add(this.payLevelLab);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(548, 306);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "用户进入";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(548, 306);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "用户发言";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // payLevelLab
            // 
            this.payLevelLab.AutoSize = true;
            this.payLevelLab.Location = new System.Drawing.Point(16, 26);
            this.payLevelLab.Name = "payLevelLab";
            this.payLevelLab.Size = new System.Drawing.Size(119, 12);
            this.payLevelLab.TabIndex = 0;
            this.payLevelLab.Text = "消费等级大于或等于:";
            // 
            // payLevelText
            // 
            this.payLevelText.Location = new System.Drawing.Point(134, 22);
            this.payLevelText.Name = "payLevelText";
            this.payLevelText.Size = new System.Drawing.Size(37, 21);
            this.payLevelText.TabIndex = 1;
            this.payLevelText.Text = "0";
            this.payLevelText.TextChanged += new System.EventHandler(this.payLevelText_TextChanged);
            // 
            // payLevelLab1
            // 
            this.payLevelLab1.AutoSize = true;
            this.payLevelLab1.Location = new System.Drawing.Point(178, 26);
            this.payLevelLab1.Name = "payLevelLab1";
            this.payLevelLab1.Size = new System.Drawing.Size(53, 12);
            this.payLevelLab1.TabIndex = 2;
            this.payLevelLab1.Text = "进行欢迎";
            // 
            // welcomeLab
            // 
            this.welcomeLab.AutoSize = true;
            this.welcomeLab.Location = new System.Drawing.Point(19, 55);
            this.welcomeLab.Name = "welcomeLab";
            this.welcomeLab.Size = new System.Drawing.Size(59, 12);
            this.welcomeLab.TabIndex = 3;
            this.welcomeLab.Text = "欢迎语句:";
            // 
            // welcomeText
            // 
            this.welcomeText.Location = new System.Drawing.Point(79, 49);
            this.welcomeText.Name = "welcomeText";
            this.welcomeText.Size = new System.Drawing.Size(146, 21);
            this.welcomeText.TabIndex = 4;
            this.welcomeText.Text = "欢迎{user}进入直播间";
            this.welcomeText.TextChanged += new System.EventHandler(this.welcomeText_TextChanged);
            // 
            // WelcomConfigFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 338);
            this.Controls.Add(this.configTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "WelcomConfigFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信息配置";
            this.configTabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl configTabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label payLevelLab1;
        private System.Windows.Forms.TextBox payLevelText;
        private System.Windows.Forms.Label payLevelLab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox welcomeText;
        private System.Windows.Forms.Label welcomeLab;
    }
}