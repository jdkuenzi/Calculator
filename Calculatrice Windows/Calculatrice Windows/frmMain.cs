using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculatrice_Windows
{
    public partial class frmMain : Form
    {
        String calcul = ""; 
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            tbxVisual.Text = null;
            tbxVisual.ReadOnly = true;
            lblCalcul.Text = calcul;
        }

        private void btn_click(object sender, EventArgs e)
        {
            if ((tbxVisual.Text == "0") || (isOperationPerformed))
                tbxVisual.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!tbxVisual.Text.Contains("."))
                    tbxVisual.Text = tbxVisual.Text + button.Text;
            }
            else
                tbxVisual.Text = tbxVisual.Text + button.Text;
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            tbxVisual.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxVisual.Text = "0";
            resultValue = 0;
            calcul = null;
            lblCalcul.Text = calcul;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    resultValue = (resultValue + Double.Parse(tbxVisual.Text));
                    break;
                case "-":
                    resultValue = (resultValue - Double.Parse(tbxVisual.Text));
                    break;
                case "x":
                    resultValue = (resultValue * Double.Parse(tbxVisual.Text));
                    break;
                case "/":
                    resultValue = (resultValue / Double.Parse(tbxVisual.Text));
                    break;
                default:
                    break;
            }
            if (isOperationPerformed == true)
            {
                calcul += operationPerformed + " " + tbxVisual.Text + " ";
                lblCalcul.Text = calcul;
                tbxVisual.Text = resultValue.ToString();
            }
            else
            {
                calcul += operationPerformed + " " + tbxVisual.Text;
                tbxHistory.Text += calcul + " =" + Environment.NewLine;
                tbxHistory.Text += resultValue + Environment.NewLine;
                tbxHistory.Text += Environment.NewLine;
                calcul = null;
                lblCalcul.Text = calcul;
                tbxVisual.Text = resultValue.ToString();
            }
        }

        private void btnOperator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                isOperationPerformed = true;
                btnEqual.PerformClick();
                operationPerformed = button.Text;
            }
            else
            {
                isOperationPerformed = true;
                operationPerformed = button.Text;
                calcul = tbxVisual.Text + " ";
                lblCalcul.Text = calcul;
                resultValue = Double.Parse(tbxVisual.Text);
            }
        }
    }
}
