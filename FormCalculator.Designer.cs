namespace InterestCalculator
{
    partial class FormCalculator
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
            this.btnClear = new ModernGUI.ButtonNew();
            this.txtDaily = new ModernGUI.TextBoxNew();
            this.txtMonthly = new ModernGUI.TextBoxNew();
            this.txtRate = new ModernGUI.TextBoxNew();
            this.txtCapital = new ModernGUI.TextBoxNew();
            this.titleBarNew1 = new ModernGUI.TitleBarNew();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear._BorderRadius = 8;
            this.btnClear.AutoSize = true;
            this.btnClear.BackColor = System.Drawing.Color.DarkGreen;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClear.Location = new System.Drawing.Point(199, 221);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtDaily
            // 
            this.txtDaily._BorderColor = System.Drawing.Color.DarkGreen;
            this.txtDaily._BorderFocusColor = System.Drawing.Color.DarkOliveGreen;
            this.txtDaily._BorderRadius = 8;
            this.txtDaily._BorderSize = 2;
            this.txtDaily._CharacterControl = ModernGUI.CharControl.JustDigit;
            this.txtDaily._Multiline = false;
            this.txtDaily._PasswordChar = false;
            this.txtDaily._PlaceholderColor = System.Drawing.Color.DarkOliveGreen;
            this.txtDaily._PlaceholderText = "Daily Income";
            this.txtDaily._ReadOnly = true;
            this.txtDaily._Text = "";
            this.txtDaily._UnderlinedStyle = false;
            this.txtDaily.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtDaily.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDaily.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDaily.Location = new System.Drawing.Point(13, 179);
            this.txtDaily.Margin = new System.Windows.Forms.Padding(4);
            this.txtDaily.MinimumSize = new System.Drawing.Size(31, 31);
            this.txtDaily.Name = "txtDaily";
            this.txtDaily.Padding = new System.Windows.Forms.Padding(8);
            this.txtDaily.Size = new System.Drawing.Size(236, 35);
            this.txtDaily.TabIndex = 4;
            // 
            // txtMonthly
            // 
            this.txtMonthly._BorderColor = System.Drawing.Color.DarkGreen;
            this.txtMonthly._BorderFocusColor = System.Drawing.Color.DarkOliveGreen;
            this.txtMonthly._BorderRadius = 8;
            this.txtMonthly._BorderSize = 2;
            this.txtMonthly._CharacterControl = ModernGUI.CharControl.JustDigit;
            this.txtMonthly._Multiline = false;
            this.txtMonthly._PasswordChar = false;
            this.txtMonthly._PlaceholderColor = System.Drawing.Color.DarkOliveGreen;
            this.txtMonthly._PlaceholderText = "Monthly Income";
            this.txtMonthly._ReadOnly = true;
            this.txtMonthly._Text = "";
            this.txtMonthly._UnderlinedStyle = false;
            this.txtMonthly.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtMonthly.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMonthly.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMonthly.Location = new System.Drawing.Point(13, 136);
            this.txtMonthly.Margin = new System.Windows.Forms.Padding(4);
            this.txtMonthly.MinimumSize = new System.Drawing.Size(31, 31);
            this.txtMonthly.Name = "txtMonthly";
            this.txtMonthly.Padding = new System.Windows.Forms.Padding(8);
            this.txtMonthly.Size = new System.Drawing.Size(236, 35);
            this.txtMonthly.TabIndex = 3;
            // 
            // txtRate
            // 
            this.txtRate._BorderColor = System.Drawing.Color.DarkGreen;
            this.txtRate._BorderFocusColor = System.Drawing.Color.DarkOliveGreen;
            this.txtRate._BorderRadius = 8;
            this.txtRate._BorderSize = 2;
            this.txtRate._CharacterControl = ModernGUI.CharControl.JustDigit;
            this.txtRate._Multiline = false;
            this.txtRate._PasswordChar = false;
            this.txtRate._PlaceholderColor = System.Drawing.Color.DarkOliveGreen;
            this.txtRate._PlaceholderText = "Interest Rate %";
            this.txtRate._ReadOnly = false;
            this.txtRate._Text = "";
            this.txtRate._UnderlinedStyle = false;
            this.txtRate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRate.Location = new System.Drawing.Point(13, 93);
            this.txtRate.Margin = new System.Windows.Forms.Padding(4);
            this.txtRate.MinimumSize = new System.Drawing.Size(31, 31);
            this.txtRate.Name = "txtRate";
            this.txtRate.Padding = new System.Windows.Forms.Padding(8);
            this.txtRate.Size = new System.Drawing.Size(236, 35);
            this.txtRate.TabIndex = 2;
            this.txtRate.Text_Changed += new System.EventHandler(this.txtRate_Text_Changed);
            // 
            // txtCapital
            // 
            this.txtCapital._BorderColor = System.Drawing.Color.DarkGreen;
            this.txtCapital._BorderFocusColor = System.Drawing.Color.DarkOliveGreen;
            this.txtCapital._BorderRadius = 8;
            this.txtCapital._BorderSize = 2;
            this.txtCapital._CharacterControl = ModernGUI.CharControl.JustDigit;
            this.txtCapital._Multiline = false;
            this.txtCapital._PasswordChar = false;
            this.txtCapital._PlaceholderColor = System.Drawing.Color.DarkOliveGreen;
            this.txtCapital._PlaceholderText = "Your Capital";
            this.txtCapital._ReadOnly = false;
            this.txtCapital._Text = "";
            this.txtCapital._UnderlinedStyle = false;
            this.txtCapital.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtCapital.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCapital.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCapital.Location = new System.Drawing.Point(13, 50);
            this.txtCapital.Margin = new System.Windows.Forms.Padding(4);
            this.txtCapital.MinimumSize = new System.Drawing.Size(31, 31);
            this.txtCapital.Name = "txtCapital";
            this.txtCapital.Padding = new System.Windows.Forms.Padding(8);
            this.txtCapital.Size = new System.Drawing.Size(236, 35);
            this.txtCapital.TabIndex = 1;
            this.txtCapital.Text_Changed += new System.EventHandler(this.txtCapital_Text_Changed);
            // 
            // titleBarNew1
            // 
            this.titleBarNew1._ButtonExitEnable = true;
            this.titleBarNew1._ButtonMaximizeEnable = false;
            this.titleBarNew1._ButtonMinimizeEnable = true;
            this.titleBarNew1._ButtonsBackgroundColor = System.Drawing.Color.Transparent;
            this.titleBarNew1._ButtonsClickColor = System.Drawing.SystemColors.ControlDarkDark;
            this.titleBarNew1._ForeColor = System.Drawing.SystemColors.Control;
            this.titleBarNew1._Icon = global::InterestCalculator.Properties.Resources.AppIconUSD;
            this.titleBarNew1._MagnetThreshold = 25;
            this.titleBarNew1._NotifyIcon = false;
            this.titleBarNew1._RoundedBorderRadius = 10;
            this.titleBarNew1.BackColor = System.Drawing.Color.DarkGreen;
            this.titleBarNew1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBarNew1.ForeColor = System.Drawing.SystemColors.Control;
            this.titleBarNew1.Location = new System.Drawing.Point(0, 0);
            this.titleBarNew1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.titleBarNew1.Name = "titleBarNew1";
            this.titleBarNew1.Size = new System.Drawing.Size(265, 32);
            this.titleBarNew1.TabIndex = 5;
            // 
            // FormCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(265, 255);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtDaily);
            this.Controls.Add(this.txtMonthly);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.txtCapital);
            this.Controls.Add(this.titleBarNew1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormCalculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interest Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ModernGUI.TitleBarNew titleBarNew1;
        private ModernGUI.TextBoxNew txtCapital;
        private ModernGUI.TextBoxNew txtRate;
        private ModernGUI.TextBoxNew txtMonthly;
        private ModernGUI.TextBoxNew txtDaily;
        private ModernGUI.ButtonNew btnClear;
    }
}

