using System;
using System.Windows.Forms;
using InterestCalculator.Properties;
using ModernGUI;

namespace InterestCalculator
{
    public partial class FormCalculator : Form
    {
        string textBoxString;
        decimal capital;
        short percentage;

        public FormCalculator()
        {
            InitializeComponent();
            this.Icon = Resources.AppIcon;
        }

        private void txtCapital_Text_Changed(object sender, EventArgs e)
        {
            if (txtCapital.Text.Length > 0 && txtCapital.Text != "0")
            {
                txtCapital.Text = Convert.ToDouble(txtCapital.Text).ToString("n0");
                SendKeys.Send("{END}");
                textBoxString = Convert.ToString(txtCapital.Text).Replace(".", "");
                capital = Convert.ToDecimal(textBoxString);
            }
            else if (txtCapital.Text == "0")
                txtCapital.Text = string.Empty;
            Calculate_Monthly();
        }

        private void txtRate_Text_Changed(object sender, EventArgs e)
        {
            if (txtRate.Text.Length > 0)
            {
                if (Convert.ToInt16(txtRate.Text) <= 100 && Convert.ToInt16(txtRate.Text) > 0)
                {
                    percentage = Convert.ToByte(txtRate.Text);
                    SendKeys.Send("{END}");
                }
                else if (txtRate.Text == "0")
                    txtRate.Text = string.Empty;
                else
                    txtRate.Text = Convert.ToString(percentage);
            }
            Calculate_Monthly();
        }

        public void Calculate_Monthly()
        {
            if (txtCapital.Text.Length > 0 && txtRate.Text.Length > 0)
                txtMonthly.Text = (Math.Floor(((capital / 100) * percentage) / 12)).ToString("n0");
            else
                txtMonthly.Text = string.Empty;
            Calculate_Daily();
        }

        public void Calculate_Daily()
        {
            if (txtCapital.Text.Length > 0 && txtRate.Text.Length > 0)
                txtDaily.Text = (Math.Floor(((capital / 100) * percentage) / 365)).ToString("n0");
            else
                txtDaily.Text = string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBoxNew)
                    c.Text = string.Empty;
            }
        }
    }
}
