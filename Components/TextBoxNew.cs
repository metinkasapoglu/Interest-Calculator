using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ModernGUI
{
    public enum CharControl
    {
        None,
        JustDigit,
        JustCharacterAndSpace,
        NoSpace,
        NoSpecialCharacter,
        PhoneNumber,
        PhoneNumberNoAreaCode,
        ShortTime,
        ShortDate,
        ShortTimeAndDate,
        Currency
    }

    [DefaultEvent("Text_Changed")]

    public class TextBoxNew : UserControl
    {
        #region Props

        [Category("AppearanceCustom")]
        public Color _BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public Color _BorderFocusColor
        {
            get
            {
                return borderFocusColor;
            }
            set
            {
                borderFocusColor = value;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public int _BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                if (value >= 4)
                {
                    value = 4;
                    borderSize = value;
                }
                else
                {
                    borderSize = value;
                }
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public bool _UnderlinedStyle
        {
            get
            {
                return underlinedStyle;
            }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public bool _PasswordChar
        {
            get
            {
                return isPasswordChar;
            }
            set
            {
                isPasswordChar = value;
                if (!isPlaceholder)
                    txtSub.UseSystemPasswordChar = value;
            }
        }

        [Category("AppearanceCustom")]
        public bool _Multiline
        {
            get
            {
                return txtSub.Multiline;
            }
            set
            {
                txtSub.Multiline = value;
                SetSize();
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public int _BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value <= 2)
                {
                    value = 2;
                    borderRadius = value;
                }
                else
                {
                    borderRadius = value;
                }
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public CharControl _CharacterControl
        {
            get
            {
                return characterControl;
            }
            set
            {
                characterControl = value;
                if (value == CharControl.PhoneNumber ||
                    value == CharControl.PhoneNumberNoAreaCode ||
                    value == CharControl.ShortTime ||
                    value == CharControl.ShortDate ||
                    value == CharControl.ShortTimeAndDate ||
                    value == CharControl.Currency)
                {
                    SetTextBoxMask();
                }
                else
                {
                    txtSub.Mask = string.Empty;
                }
            }
        }

        [Category("AppearanceCustom")]
        public Color _PlaceholderColor
        {
            get
            {
                return placeholderColor;
            }
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    lbl.ForeColor = value;
                this.Invalidate();
            }
        }

        [Category("AppearanceCustom")]
        public string _PlaceholderText
        {
            get
            {
                return placeholderText;
            }
            set
            {
                placeholderText = value;
                lbl.Text = "";
                SetPlaceholder();
            }
        }

        [Category("AppearanceCustom")]
        public bool _ReadOnly
        {
            get
            {
                return txtSub.ReadOnly;
            }
            set
            {
                txtSub.ReadOnly = value;
            }
        }

        [Category("AppearanceCustom")]
        public string _Text
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }

        [Category("AppearanceCustom")]
        public override string Text
        {
            get
            {
                return txtSub.Text;
            }
            set
            {
                txtSub.Text = value;
                SetPlaceholder();
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                txtSub.Font = value;
                lbl.Font = value;
                if (this.DesignMode)
                    SetSize();
            }
        }

        #endregion

        #region Fields

        CharControl characterControl;
        Color borderColor = SystemColors.ControlDark;
        Color borderFocusColor = SystemColors.HotTrack;
        Color placeholderColor = Color.DarkGray;
        int borderSize = 1;
        int borderRadius = 8;
        bool justDigit;
        bool underlinedStyle;
        bool isFocused;
        bool isPlaceholder;
        bool isPasswordChar;
        private Label lbl;
        private MaskedTextBox txtSub;
        string placeholderText = "";
        public event EventHandler Text_Changed;

        #endregion

        #region Methods

        public TextBoxNew()
        {
            InitializeComponent();
            this.Size = new Size(150, 31);
            this.MinimumSize = new Size(31, 31);
            this.Font = SystemFonts.DefaultFont;
        }

        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.txtSub = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl.Location = new System.Drawing.Point(8, 8);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(234, 15);
            this.lbl.TabIndex = 1;
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl.Visible = false;
            this.lbl.Click += new System.EventHandler(this.lbl_Click);
            // 
            // txtSub
            // 
            this.txtSub.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSub.Location = new System.Drawing.Point(8, 8);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(234, 15);
            this.txtSub.TabIndex = 2;
            this.txtSub.Click += new System.EventHandler(this.txtSub_Click);
            this.txtSub.TextChanged += new System.EventHandler(this.txtSub_TextChanged);
            this.txtSub.Enter += new System.EventHandler(this.txtSub_Enter);
            this.txtSub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSub_KeyPress);
            this.txtSub.Leave += new System.EventHandler(this.txtSub_Leave);
            this.txtSub.MouseEnter += new System.EventHandler(this.txtSub_MouseEnter);
            this.txtSub.MouseLeave += new System.EventHandler(this.txtSub_MouseLeave);
            // 
            // TextBoxNew
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtSub);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TextBoxNew";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(250, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void Clear()
        {
            txtSub.Clear();
        }

        void lbl_Click(object sender, EventArgs e)
        {
            txtSub.Focus();
        }

        void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtSub.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                lbl.Visible = true;
                lbl.Text = placeholderText;
                lbl.ForeColor = placeholderColor;
                if (isPasswordChar)
                    txtSub.UseSystemPasswordChar = false;
            }
        }

        void DeSetPlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                lbl.Visible = false;
                lbl.Text = "";
                lbl.ForeColor = this.ForeColor;
                if (isPasswordChar)
                    txtSub.UseSystemPasswordChar = true;
            }
        }

        GraphicsPath GetPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        void SetRegion()
        {
            GraphicsPath pathTxt;
            if (_Multiline)
            {
                pathTxt = GetPath(txtSub.ClientRectangle, borderRadius - borderSize);
                txtSub.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetPath(txtSub.ClientRectangle, borderSize * 2);
                txtSub.Region = new Region(pathTxt);
            }
            pathTxt.Dispose();
        }

        void SetSize()
        {
            if (txtSub.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height - 1;
                txtSub.Multiline = true;
                txtSub.MinimumSize = new Size(0, txtHeight);
                txtSub.Multiline = false;

                this.Height = txtSub.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        void txtSub_TextChanged(object sender, EventArgs e)
        {
            if (Text_Changed != null)
            {
                this.Text = txtSub.Text;
                Text_Changed.Invoke(sender, e);
            }
            if (isPasswordChar)
                txtSub.UseSystemPasswordChar = true;
            lbl.Visible = false;
        }

        void txtSub_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        void txtSub_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        void txtSub_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        void txtSub_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
            if (characterControl == CharControl.JustDigit)
            {
                e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',') && !char.IsControl(e.KeyChar);
            }
            else if (characterControl == CharControl.JustCharacterAndSpace)
            {
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
            }
            else if (characterControl == CharControl.NoSpace)
            {
                e.Handled = (int)e.KeyChar == 32;
            }
            else if (characterControl == CharControl.NoSpecialCharacter)
            {
                if (e.KeyChar == '£' || e.KeyChar == '½' ||
                    e.KeyChar == '€' || e.KeyChar == '₺' ||
                    e.KeyChar == '¨' || e.KeyChar == 'æ' ||
                    e.KeyChar == 'ß' || e.KeyChar == '´')
                {
                    e.Handled = true;
                }
                if ((int)e.KeyChar >= 33 && (int)e.KeyChar <= 47)
                {
                    e.Handled = true;
                }
                if ((int)e.KeyChar >= 58 && (int)e.KeyChar <= 64)
                {
                    e.Handled = true;
                }
                if ((int)e.KeyChar >= 91 && (int)e.KeyChar <= 96)
                {
                    e.Handled = true;
                }
                if ((int)e.KeyChar >= 123 && (int)e.KeyChar <= 127)
                {
                    e.Handled = true;
                }
            }
        }

        void SetTextBoxMask()
        {
            switch (characterControl)
            {
                case CharControl.PhoneNumber:
                    txtSub.Mask = "+90(999) 000-0000";
                    break;
                case CharControl.PhoneNumberNoAreaCode:
                    txtSub.Mask = "(999) 000-0000";
                    break;
                case CharControl.ShortTime:
                    txtSub.Mask = "00:00";
                    break;
                case CharControl.ShortDate:
                    txtSub.Mask = "00/00/0000";
                    break;
                case CharControl.ShortTimeAndDate:
                    txtSub.Mask = "00/00/0000 00:00";
                    break;
                case CharControl.Currency:
                    txtSub.Mask = "000,000,000.00";
                    break;
            }
        }

        void txtSub_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            DeSetPlaceholder();
        }

        void txtSub_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }

        #endregion

        #region Overrides

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            txtSub.Font = this.Font;
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            txtSub.BackColor = this.BackColor;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            txtSub.ForeColor = this.ForeColor;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                SetSize();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetSize();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle borderSmooth = this.ClientRectangle;
            Rectangle border = Rectangle.Inflate(borderSmooth, -borderSize, -borderSize);
            int smoothSize = borderSize > 0 ? borderSize : 1;

            using (GraphicsPath borderSmoothPath = GetPath(borderSmooth, borderRadius))
            using (GraphicsPath borderPath = GetPath(border, borderRadius - borderSize))
            using (Pen borderSmoothPen = new Pen(this.Parent.BackColor, smoothSize))
            using (Pen borderPen = new Pen(borderColor, borderSize))
            {
                this.Region = new Region(borderSmoothPath);
                if (borderRadius > 15) SetRegion();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                borderPen.Alignment = PenAlignment.Center;
                if (isFocused) borderPen.Color = borderFocusColor;

                if (!underlinedStyle)
                {
                    g.DrawPath(borderSmoothPen, borderSmoothPath);
                    g.DrawPath(borderPen, borderPath);
                }
                else
                {
                    g.DrawPath(borderSmoothPen, borderSmoothPath);
                    g.SmoothingMode = SmoothingMode.None;
                    g.DrawLine(borderPen, 0, this.Height - 1, this.Width, this.Height - 1);
                }
            }
        }

        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
            this.Font = this.Parent.Font;
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            this.BackColor = this.Parent.BackColor;
        }

        protected override void OnParentForeColorChanged(EventArgs e)
        {
            base.OnParentForeColorChanged(e);
            this.ForeColor = this.Parent.ForeColor;
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
    }
}
