using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace solrac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkTextBoxes())
            {
                int knosp = int.Parse(textBox1.Text);
                double or_knosp = calculaORKnosp(knosp);

                double diamSupraselar = double.Parse(textBox2.Text);
                double diamDiafragma = double.Parse(textBox3.Text);
                double div = diamSupraselar / diamDiafragma;

                int csd = calculaCSD(div);
                double or_csd = calculaORCSD(csd);
                double or_total = or_knosp + or_csd;
                double posibResec = calculaPosibResec(or_total);

                labelORKnosp.Text = or_knosp.ToString();
                labelDiv.Text = (Math.Truncate(div * 100) / 100).ToString();
                labelCSD.Text = csd.ToString();
                labelORCSD.Text = or_csd.ToString();
                labelORSuma.Text = or_total.ToString();
                if (posibResec == -1.0)
                    labelPR.Text = "ERROR PR";
                else
                    labelPR.Text = posibResec.ToString();
            }
            else
            {
                labelPR.Text = "ERROR";
            }
        }

        private bool checkTextBoxes()
        {
            return checkKnosp() && checkDiam();
        }

        private bool checkDiam()
        {
            // sustituye punto por coma decimal
            string str = textBox2.Text;
            textBox2.Text = str.Replace('.', ',');
            str = textBox3.Text;
            textBox3.Text = str.Replace('.', ',');
            // comprueba que es un double
            double diam1, diam2 = 0.0;
            bool ok = double.TryParse(textBox2.Text, out diam1) && double.TryParse(textBox3.Text, out diam2);
            if (diam1 < 0 || diam2 <= 0)
                ok = false;

            labelErrorDiam.Visible = !ok;
            return ok;
        }

        private bool checkKnosp()
        {
            // comprueba que es un entero
            int knosp;
            bool ok = int.TryParse(textBox1.Text, out knosp);            
            // comprueba que es un valor correcto
            if (knosp < 0 || knosp > 4)
                ok = false;

            labelErrorKnosp.Visible = !ok;
            return ok;
        }

        private double calculaPosibResec(double n)
        {
            double pr;
            Console.WriteLine("¿n == 54.6? ¿" + n + " == " + 54.6 + "? " + (n == 54.6));
            if (n == 54.6)
                return 85.4;
            switch (n)
            {
                case 2:
                    pr = 58.4;
                    break;
                case 3.3:
                    pr = 60.0;
                    break;
                case 6.1:
                case 6.2:
                    pr = 60.8;
                    break;
                case 7.4:
                    pr = 68.2;
                    break;
                case 10.3:
                    pr = 73.3;
                    break;
                case 36.5:
                    pr = 78.2;
                    break;
                case 40.6:
                    pr = 79.6;
                    break;
                case 53.3:
                    pr = 80.9;
                    break;
                case 54.6:
                    pr = 85.4;
                    break;
                case 57.5:
                    pr = 91.2;
                    break;
                case 87.8:
                    pr = 95.8;
                    break;
                case 166.5:
                    pr = 94.4;
                    break;
                case 170.6:
                    pr = 94.1;
                    break;
                case 217.8:
                    pr = 92.3;
                    break;
                default:
                    pr = -1.0;
                    break;
            }
            return pr;
        }

        private double calculaORCSD(int csd)
        {
            double or;
            switch (csd) {
                case 1:
                    or = 165.5;
                    break;
                case 2:
                    or = 35.5;
                    break;
                case 3:
                    or = 5.2;
                    break;
                case 4:
                    or = 2.3;
                    break;
                default:
                    or = 1;
                    break;
            }
            return or;
        }

        private int calculaCSD(double div)
        {
            int csd;
            if (div >= 0 && div <= 0.23)
                csd = 1;
            else if (div <= 0.65)
                csd = 2;
            else if (div <= 0.83)
                csd = 3;
            else if (div <= 1.1)
                csd = 4;
            else
                csd = 5;
            return csd;
        }

        private double calculaORKnosp(int knosp)
        {
            double or;

            if (knosp == 4)
                or = 1;
            else if (knosp == 3)
                or = 5.1;
            else if (knosp >= 0 && knosp <= 2)
                or = 52.3;
            else
                or = -1.0;
            return or;
        }
    }
}
