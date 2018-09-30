using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2B
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            int hairdresser = 0;
            double clientType = 0;
            int services = 0;
            double numberOfClientVisit = 0;

            if (hairdresser1.Checked == true)
                hairdresser = 30;
            else if (hairdresser2.Checked == true)
                hairdresser = 45;
            else if (hairdresser3.Checked == true)
                hairdresser = 40;
            else if (hairdresser4.Checked == true)
                hairdresser = 50;
            else if (hairdresser5.Checked == true)
                hairdresser = 55;           

            if (service1.Checked == true)
                services += 30;
            if (service2.Checked == true)
                services += 40;
            if (service3.Checked == true)
                services += 50;
            if (service4.Checked == true)
                services += 200;

            if (client1.Checked == true)
                clientType = 0.00;
            else if (client2.Checked == true)
                clientType = 0.10;
            else if (client3.Checked == true)
                clientType = 0.05;
            else if (client4.Checked == true)
                clientType = 0.15;

            bool output = Int32.TryParse(clientVisitsTextBox.Text, out int clientVisitsInt);

            if (service1.Checked != true && service2.Checked != true && service3.Checked != true && service4.Checked != true)
                MessageBox.Show("Please Select any Service");

            else if (clientVisitsTextBox.Text == "")
                MessageBox.Show("Please enter Number of Visitors!!!");

            else if (output == false)
            {
                MessageBox.Show("Please Enter a Number!!!");
                clientVisitsTextBox.Clear();
            }

            else if (Convert.ToInt32(clientVisitsTextBox.Text) <= 0)
            {
                MessageBox.Show("Number is must be equal or grater than 0");
                clientVisitsTextBox.Clear();
            }
            else
            {
                if (Convert.ToInt32(clientVisitsTextBox.Text) >= 1 && Convert.ToInt32(clientVisitsTextBox.Text) <= 3)
                    numberOfClientVisit = 0.00;

                else if (Convert.ToInt32(clientVisitsTextBox.Text) >= 4 && Convert.ToInt32(clientVisitsTextBox.Text) <= 8)
                    numberOfClientVisit = 0.05;

                else if (Convert.ToInt32(clientVisitsTextBox.Text) >= 9 && Convert.ToInt32(clientVisitsTextBox.Text) <= 13)
                    numberOfClientVisit = 0.10;

                else if (Convert.ToInt32(clientVisitsTextBox.Text) >= 14)
                    numberOfClientVisit = 0.15;

                int clientSum = hairdresser + services;
                double sumOfDiscount = clientType + numberOfClientVisit;
                double countTotalVisiters = clientSum * sumOfDiscount;
                double totalAmountShow = clientSum - countTotalVisiters;

                totalPriceLabel.Text = totalAmountShow.ToString("C");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clientVisitsTextBox.Clear();
            hairdresser1.Checked = true;
            client1.Checked = true;
            service1.Checked = false;
            service2.Checked = false;
            service3.Checked = false;
            service4.Checked = false;
            totalPriceLabel.Text = "";
        }
    }
}
