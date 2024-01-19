using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ModernGUI
{
    public class TitleBarNew : UserControl
    {
        #region Props

        [Category("AppearanceCustom")]
        public int _RoundedBorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                borderRadius = value;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public bool _ButtonMinimizeEnable
        {
            get
            {
                return buttonMinimizeEnable;
            }
            set
            {
                buttonMinimizeEnable = value;
                btnMin.Visible = buttonMinimizeEnable;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public bool _ButtonMaximizeEnable
        {
            get
            {
                return buttonMaximizeEnable;
            }
            set
            {
                buttonMaximizeEnable = value;
                btnMax.Visible = buttonMaximizeEnable;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public bool _ButtonExitEnable
        {
            get
            {
                return buttonExitEnable;
            }
            set
            {
                buttonExitEnable = value;
                btnExit.Visible = buttonExitEnable;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public Image _Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                pbTitle.BackgroundImage = icon;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public Color _ButtonsBackgroundColor
        {
            get
            {
                return buttonBackColor;
            }
            set
            {
                buttonBackColor = value;
                btnExit.BackColor = buttonBackColor;
                btnMax.BackColor = buttonBackColor;
                btnMin.BackColor = buttonBackColor;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public Color _ButtonsClickColor
        {
            get
            {
                return buttonClickBackColor;
            }
            set
            {
                buttonClickBackColor = value;
                btnExit.FlatAppearance.MouseDownBackColor = buttonClickBackColor;
                btnMax.FlatAppearance.MouseDownBackColor = buttonClickBackColor;
                btnMin.FlatAppearance.MouseDownBackColor = buttonClickBackColor;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public int _MagnetThreshold
        {
            get
            {
                return magnetThreshold;
            }
            set
            {
                magnetThreshold = value;
            }
        }

        [Category("AppearanceCustom")]
        public Color _ForeColor
        {
            get
            {
                return foreColor;
            }
            set
            {
                foreColor = value;
                lblTitle.ForeColor = value;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public bool _NotifyIcon
        {
            get
            {
                return notifyIcon;
            }
            set
            {
                notifyIcon = value;
            }
        }

        [Category("AppearanceCustom")]
        public override Font Font
        {
            get
            {
                return textSize;
            }
            set
            {
                textSize = value;
                lblTitle.Font = textSize;
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
            }
        }

        #endregion

        #region Fields

        public Button btnExit;
        public Button btnMax;
        public Button btnMin;
        public Label lblTitle;
        public PictureBox pbTitle;
        Form f;
        Color foreColor = SystemColors.Control;
        Color buttonBackColor = Color.Transparent;
        Color buttonClickBackColor = SystemColors.ControlDarkDark;
        Font textSize = new Font("Microsoft Sans Serif", 12F);
        bool notifyIcon;
        bool mouseDown;
        bool buttonMinimizeEnable = true;
        bool buttonMaximizeEnable = true;
        bool buttonExitEnable = true;
        int magnetThreshold = 25;
        int borderRadius = 10;
        Image icon;
        Point lastLocation;

        #endregion

        #region Methods

        public TitleBarNew()
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            SetButtonMouseEnterBackColor();
            btnMin.Click += BtnMin_Click;
            btnMax.Click += BtnMax_Click;
            btnExit.Click += BtnExit_Click;
            SetButtonImages(btnMinBase64String, btnMin);
            SetButtonImages(btnMaxBase64String, btnMax);
            SetButtonImages(btnExitBase64String, btnExit);
        }

        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.Location = new System.Drawing.Point(268, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 32);
            this.btnExit.TabIndex = 56;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnMax
            // 
            this.btnMax.BackColor = System.Drawing.Color.Transparent;
            this.btnMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMax.Location = new System.Drawing.Point(236, 0);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(32, 32);
            this.btnMax.TabIndex = 57;
            this.btnMax.UseVisualStyleBackColor = false;
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMin.Location = new System.Drawing.Point(204, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(32, 32);
            this.btnMin.TabIndex = 59;
            this.btnMin.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.Location = new System.Drawing.Point(28, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(46, 20);
            this.lblTitle.TabIndex = 61;
            this.lblTitle.Text = "Form";
            this.lblTitle.DoubleClick += new System.EventHandler(this.TitleBar_DoubleClick);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
            // 
            // pbTitle
            // 
            this.pbTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTitle.Location = new System.Drawing.Point(4, 4);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(24, 24);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTitle.TabIndex = 60;
            this.pbTitle.TabStop = false;
            this.pbTitle.DoubleClick += new System.EventHandler(this.TitleBar_DoubleClick);
            this.pbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            this.pbTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            this.pbTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
            // 
            // mTitleBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbTitle);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnMax);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "mTitleBar";
            this.Size = new System.Drawing.Size(300, 32);
            this.DoubleClick += new System.EventHandler(this.TitleBar_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void Form_Move(object sender, EventArgs e)
        {
            if (f.WindowState == FormWindowState.Normal)
            {
                if (Math.Abs(f.Top - Screen.FromControl(f).WorkingArea.Top) < magnetThreshold)
                {
                    f.Location = new Point(f.Location.X, Screen.FromControl(f).WorkingArea.Top);
                }
                if (Math.Abs(f.Left - Screen.FromControl(f).WorkingArea.Left) < magnetThreshold && Math.Abs(f.Top - Screen.FromControl(f).WorkingArea.Top) < magnetThreshold)
                {
                    f.Location = new Point(Screen.FromControl(f).WorkingArea.Left, Screen.FromControl(f).WorkingArea.Top);
                }
                if (Math.Abs(f.Left - Screen.FromControl(f).WorkingArea.Left) < magnetThreshold)
                {
                    f.Location = new Point(Screen.FromControl(f).WorkingArea.Left, f.Location.Y);
                }
                if (Math.Abs(f.Right - Screen.FromControl(f).WorkingArea.Right) < magnetThreshold && Math.Abs(f.Top - Screen.FromControl(f).WorkingArea.Top) < magnetThreshold)
                {
                    f.Location = new Point(Screen.FromControl(f).WorkingArea.Right - f.Width, Screen.FromControl(f).WorkingArea.Top);
                }
                if (Math.Abs(f.Right - Screen.FromControl(f).WorkingArea.Right) < magnetThreshold)
                {
                    f.Location = new Point(Screen.FromControl(f).WorkingArea.Right - f.Width, f.Location.Y);
                }
            }
        }

        void Form_Resize(object sender, EventArgs e)
        {
            if (f.WindowState == FormWindowState.Normal)
            {
                GraphicsPath path = new GraphicsPath();
                Rectangle rect = new Rectangle(0, 0, f.Width, f.Height);
                path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
                path.AddArc(rect.Right - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
                path.AddArc(rect.Right - borderRadius, rect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();
                f.Region = new Region(path);
            }
            else if (f.WindowState == FormWindowState.Minimized && notifyIcon && f != null)
            {
                f.ShowInTaskbar = false;
                f.Visible = false;
            }
            else
            {
                f.Region = null;
            }
        }


        void SetButtonMouseEnterBackColor()
        {
            int newRed = Math.Min(this.BackColor.R + 10, 255);
            int newGreen = Math.Min(this.BackColor.G + 10, 255);
            int newBlue = Math.Min(this.BackColor.B + 10, 255);
            btnMin.FlatAppearance.MouseOverBackColor = Color.FromArgb(newRed, newGreen, newBlue);
            btnMax.FlatAppearance.MouseOverBackColor = Color.FromArgb(newRed, newGreen, newBlue);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(newRed, newGreen, newBlue);
        }

        void TitleBar_DoubleClick(object sender, EventArgs e)
        {
            f.WindowState = f.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        void BtnMin_Click(object sender, EventArgs e)
        {
            f.WindowState = FormWindowState.Minimized;
        }

        void BtnMax_Click(object sender, EventArgs e)
        {
            f.WindowState = f.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        void BtnExit_Click(object sender, EventArgs e)
        {
            f.Close();
        }

        void F_TextChanged(object sender, EventArgs e)
        {
            lblTitle.Text = f.Text;
            this.Invalidate();
            if (notifyIcon)
                SetNotifyIcon();
        }

        private void F_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && f != null)
            {
                f.WindowState = f.WindowState == FormWindowState.Normal ? FormWindowState.Minimized : FormWindowState.Normal;
            }
        }

        #endregion

        #region Overrides

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.ParentForm != null)
            {
                f = this.ParentForm;
                f.KeyPreview = true;
                f.FormBorderStyle = FormBorderStyle.None;
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Resize += Form_Resize;
                f.Move += Form_Move;
                f.TextChanged += F_TextChanged;
                f.KeyDown += F_KeyDown;
                lblTitle.Text = f.Text;
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            SetButtonMouseEnterBackColor();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Height = 32;
        }

        #endregion

        #region Dispose

        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Button Icons

        void SetButtonImages(string Base64String, Button b)
        {
            byte[] byteImg = Convert.FromBase64String(Base64String);
            MemoryStream ms = new MemoryStream(byteImg);
            Image image = Image.FromStream(ms);
            b.BackgroundImage = image;
        }

        string btnMinBase64String = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAACXBIWXMAAAsTAAALEwEAmpwYAAAFyGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDggNzkuMTY0MDM2LCAyMDE5LzA4LzEzLTAxOjA2OjU3ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdEV2dD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlRXZlbnQjIiB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iIHhtbG5zOnBob3Rvc2hvcD0iaHR0cDovL25zLmFkb2JlLmNvbS9waG90b3Nob3AvMS4wLyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgMjEuMCAoV2luZG93cykiIHhtcDpDcmVhdGVEYXRlPSIyMDI0LTAxLTE2VDIzOjEyOjAzKzAzOjAwIiB4bXA6TWV0YWRhdGFEYXRlPSIyMDI0LTAxLTE2VDIzOjEyOjAzKzAzOjAwIiB4bXA6TW9kaWZ5RGF0ZT0iMjAyNC0wMS0xNlQyMzoxMjowMyswMzowMCIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo1MmVjY2E4Yi0yOTAwLTc4NDMtOWU3My04MzA5NGNlZjQ5Y2IiIHhtcE1NOkRvY3VtZW50SUQ9ImFkb2JlOmRvY2lkOnBob3Rvc2hvcDowMzdmOGM0NC0yNmM5LWFjNDAtODk4ZC1iYjk2YTdmYTkxNmUiIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDo5MmE3ODNhZS01OWQ0LWU2NGQtYTNlYy05ODY3Y2E5M2JkMTEiIGRjOmZvcm1hdD0iaW1hZ2UvcG5nIiBwaG90b3Nob3A6Q29sb3JNb2RlPSIzIj4gPHhtcE1NOkhpc3Rvcnk+IDxyZGY6U2VxPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0iY3JlYXRlZCIgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDo5MmE3ODNhZS01OWQ0LWU2NGQtYTNlYy05ODY3Y2E5M2JkMTEiIHN0RXZ0OndoZW49IjIwMjQtMDEtMTZUMjM6MTI6MDMrMDM6MDAiIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCAyMS4wIChXaW5kb3dzKSIvPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0ic2F2ZWQiIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6NTJlY2NhOGItMjkwMC03ODQzLTllNzMtODMwOTRjZWY0OWNiIiBzdEV2dDp3aGVuPSIyMDI0LTAxLTE2VDIzOjEyOjAzKzAzOjAwIiBzdEV2dDpzb2Z0d2FyZUFnZW50PSJBZG9iZSBQaG90b3Nob3AgMjEuMCAoV2luZG93cykiIHN0RXZ0OmNoYW5nZWQ9Ii8iLz4gPC9yZGY6U2VxPiA8L3htcE1NOkhpc3Rvcnk+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+fY4mRwAAAEFJREFUWIXt1bENACAIBEAx7r8yrgCFweK+JvwlFERmrsns0XYAAAAAAIAfAKc5X/3d8QpQXlzN+AkAAAAAAAAALssmBELLb8XBAAAAAElFTkSuQmCC";

        string btnMaxBase64String = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAACXBIWXMAAAsTAAALEwEAmpwYAAAFyGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDggNzkuMTY0MDM2LCAyMDE5LzA4LzEzLTAxOjA2OjU3ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdEV2dD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlRXZlbnQjIiB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iIHhtbG5zOnBob3Rvc2hvcD0iaHR0cDovL25zLmFkb2JlLmNvbS9waG90b3Nob3AvMS4wLyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgMjEuMCAoV2luZG93cykiIHhtcDpDcmVhdGVEYXRlPSIyMDI0LTAxLTE2VDIzOjExOjM1KzAzOjAwIiB4bXA6TWV0YWRhdGFEYXRlPSIyMDI0LTAxLTE2VDIzOjExOjM1KzAzOjAwIiB4bXA6TW9kaWZ5RGF0ZT0iMjAyNC0wMS0xNlQyMzoxMTozNSswMzowMCIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDowZTBjYmZiZC0xZjExLTYyNDItYTczOS0wNDU3MzU0Y2JiZWYiIHhtcE1NOkRvY3VtZW50SUQ9ImFkb2JlOmRvY2lkOnBob3Rvc2hvcDo1ZDMyYTlkMy1kNTJmLWMxNDItYWNmNi1lMWFhMTdlYTViMmQiIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDpjZDNmMDI1OC1jN2M4LTkxNDItYjRhYi03ZDlkMjFkZGZhNWUiIGRjOmZvcm1hdD0iaW1hZ2UvcG5nIiBwaG90b3Nob3A6Q29sb3JNb2RlPSIzIj4gPHhtcE1NOkhpc3Rvcnk+IDxyZGY6U2VxPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0iY3JlYXRlZCIgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDpjZDNmMDI1OC1jN2M4LTkxNDItYjRhYi03ZDlkMjFkZGZhNWUiIHN0RXZ0OndoZW49IjIwMjQtMDEtMTZUMjM6MTE6MzUrMDM6MDAiIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCAyMS4wIChXaW5kb3dzKSIvPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0ic2F2ZWQiIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6MGUwY2JmYmQtMWYxMS02MjQyLWE3MzktMDQ1NzM1NGNiYmVmIiBzdEV2dDp3aGVuPSIyMDI0LTAxLTE2VDIzOjExOjM1KzAzOjAwIiBzdEV2dDpzb2Z0d2FyZUFnZW50PSJBZG9iZSBQaG90b3Nob3AgMjEuMCAoV2luZG93cykiIHN0RXZ0OmNoYW5nZWQ9Ii8iLz4gPC9yZGY6U2VxPiA8L3htcE1NOkhpc3Rvcnk+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+8ivyNgAAAGRJREFUWIXt1bEOwCAIRdHS+P+/TKcmHWrDIyqNuSxOhoMBNHc/KuMszQ4AAAAAfwC05L2v/W0rAG9J/HGGESpg+M+VeYFedXflErK8CQFsCZi+B4aOogqQqovElj0AAAAAAFJcSpgKSTg+HTsAAAAASUVORK5CYII=";

        string btnExitBase64String = "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAACXBIWXMAAAsTAAALEwEAmpwYAAAFyGlUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4gPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDggNzkuMTY0MDM2LCAyMDE5LzA4LzEzLTAxOjA2OjU3ICAgICAgICAiPiA8cmRmOlJERiB4bWxuczpyZGY9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkvMDIvMjItcmRmLXN5bnRheC1ucyMiPiA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdEV2dD0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlRXZlbnQjIiB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iIHhtbG5zOnBob3Rvc2hvcD0iaHR0cDovL25zLmFkb2JlLmNvbS9waG90b3Nob3AvMS4wLyIgeG1wOkNyZWF0b3JUb29sPSJBZG9iZSBQaG90b3Nob3AgMjEuMCAoV2luZG93cykiIHhtcDpDcmVhdGVEYXRlPSIyMDI0LTAxLTE2VDIzOjMyOjA0KzAzOjAwIiB4bXA6TWV0YWRhdGFEYXRlPSIyMDI0LTAxLTE2VDIzOjMyOjA0KzAzOjAwIiB4bXA6TW9kaWZ5RGF0ZT0iMjAyNC0wMS0xNlQyMzozMjowNCswMzowMCIgeG1wTU06SW5zdGFuY2VJRD0ieG1wLmlpZDo0NWQxZWI2MS1mYTgyLTNjNGItYTg5YS1lNzIyN2U4YTg3ZTQiIHhtcE1NOkRvY3VtZW50SUQ9ImFkb2JlOmRvY2lkOnBob3Rvc2hvcDo2OWU5M2Q1OC1hMjk3LTk4NGMtOGZkMS0wZmI2ZGY3MzYxYjgiIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDoyZjRlM2U5My1kNmM0LTIzNGMtYjNkNi03ZTg5MjExOGNhYzkiIGRjOmZvcm1hdD0iaW1hZ2UvcG5nIiBwaG90b3Nob3A6Q29sb3JNb2RlPSIzIj4gPHhtcE1NOkhpc3Rvcnk+IDxyZGY6U2VxPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0iY3JlYXRlZCIgc3RFdnQ6aW5zdGFuY2VJRD0ieG1wLmlpZDoyZjRlM2U5My1kNmM0LTIzNGMtYjNkNi03ZTg5MjExOGNhYzkiIHN0RXZ0OndoZW49IjIwMjQtMDEtMTZUMjM6MzI6MDQrMDM6MDAiIHN0RXZ0OnNvZnR3YXJlQWdlbnQ9IkFkb2JlIFBob3Rvc2hvcCAyMS4wIChXaW5kb3dzKSIvPiA8cmRmOmxpIHN0RXZ0OmFjdGlvbj0ic2F2ZWQiIHN0RXZ0Omluc3RhbmNlSUQ9InhtcC5paWQ6NDVkMWViNjEtZmE4Mi0zYzRiLWE4OWEtZTcyMjdlOGE4N2U0IiBzdEV2dDp3aGVuPSIyMDI0LTAxLTE2VDIzOjMyOjA0KzAzOjAwIiBzdEV2dDpzb2Z0d2FyZUFnZW50PSJBZG9iZSBQaG90b3Nob3AgMjEuMCAoV2luZG93cykiIHN0RXZ0OmNoYW5nZWQ9Ii8iLz4gPC9yZGY6U2VxPiA8L3htcE1NOkhpc3Rvcnk+IDwvcmRmOkRlc2NyaXB0aW9uPiA8L3JkZjpSREY+IDwveDp4bXBtZXRhPiA8P3hwYWNrZXQgZW5kPSJyIj8+gyDF4wAAAN1JREFUWIXtlU0LAVEUhp+xUVI2UorQJEVKs6bY+utYKgtKysbCVj5fC7OYxST3mmmaum+dzTn1nud+nI4niSxVyLS7A3AADsAB5BFAQP1LPQDuaQKUgS3QjqkNgBVQM3KUZBpFfTSJ5EqSzpJ6pn6e5TZsAfvwtFVgDXSBnamRLQBh8yXQBBrA0cbknym4ARXgEYaVbAGawAnw+Vz9AuhYOVl8wpGkq6QgkptJukiam/qZNvclPSUNY2rTcDrGaU7BC+gDmy9PcwC8Xw3/mYJElLtd4AAcgANwAInrDcP3R7RmDEuWAAAAAElFTkSuQmCC";

        #endregion

        #region Drag & Move

        void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (f != null)
                {
                    f.Location = new Point(
                        (f.Location.X - lastLocation.X) + e.X, (f.Location.Y - lastLocation.Y) + e.Y);
                    f.Update();
                }
            }
        }

        void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        #endregion

        #region Notify Icon

        void SetNotifyIcon()
        {
            NotifyIcon n = new NotifyIcon();
            n.Visible = true;
            n.Icon = f.Icon;
            n.Text = f.Text;
            n.Click += NotifyIcon_Click;
        }

        void NotifyIcon_Click(object sender, EventArgs e)
        {
            f.WindowState = f.WindowState == FormWindowState.Normal ? FormWindowState.Minimized : FormWindowState.Normal;
            f.ShowInTaskbar = f.WindowState == FormWindowState.Normal ? true : false;
            f.Visible = f.WindowState == FormWindowState.Normal ? true : false;
            f.Activate();
        }

        #endregion
    }
}
