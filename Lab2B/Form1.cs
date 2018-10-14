using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//This program contains the consept of GUI. This is a hair cut application which include some hairdressers, 
//client types, services,and other things. User can select any services, any hairdresser, any client type 
//and number of visitors so user know how much cost they will get

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
            this.Close();   //close the application
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            int hairdresser = 0;            
            double clientType = 0;
            int services = 0;
            double numberOfClientVisit = 0;

            //prices of hairdressers
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

            //prices of services
            if (service1.Checked == true)
                services += 30;
            if (service2.Checked == true)
                services += 40;
            if (service3.Checked == true)
                services += 50;
            if (service4.Checked == true)
                services += 200;

            //which client get how much discount
            if (client1.Checked == true)
                clientType = 0.00;
            else if (client2.Checked == true)
                clientType = 0.10;
            else if (client3.Checked == true)
                clientType = 0.05;
            else if (client4.Checked == true)
                clientType = 0.15;

            /**
             * convert the specified string
             * into bool value
             * It shows the final value and
             * the tell  us the conversion is sucessful or not
             */
            bool output = Int32.TryParse(clientVisitsTextBox.Text, out int clientVisitsInt);

            /**
             * check if any service is not selected than shows the error message
             * check if textbox is empty than show the error message
             * check if there is a string than it shows the error message
             * input is less than zero, it shoes the error message
             */
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

            /**
             * first int convert into the string 
             * if input is between 1 and 3 than it gives the specific discount to that number of people
             * the same method applies to a discount system which is provided to some specific number of people
             */
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

                /**
                 * store the amount of hairdresser and services by doing addition
                 * store the client type and number of client visits in a variable by doing addition
                 * store the above calculated values by doing multiplication 
                 * store the first calculated value and 3rd calculated value by doing subtraction
                 */
                int clientSum = hairdresser + services;
                double sumOfDiscount = clientType + numberOfClientVisit;
                double countTotalVisiters = clientSum * sumOfDiscount;
                double totalAmountShow = clientSum - countTotalVisiters;

                //shows the final value in the label
                totalPriceLabel.Text = totalAmountShow.ToString("C");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /**
             * clear button do the following actions
             * 1st hairdresser checked
             * 1st client type checked
             * all services are unchecked
             * total price label " "
             * client visitis input is clear
             */
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
