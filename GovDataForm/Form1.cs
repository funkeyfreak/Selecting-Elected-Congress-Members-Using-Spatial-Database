using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GovDataForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxRep.SelectedIndex = 0;
        }
            
        //Init class
        private GovData.ElectedRecords dClass = new GovData.ElectedRecords();

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBoxRep.SelectedIndex == 0){ //if addr/city/state/zip
                //get input
                String input = inputZ.Text;
                //outputRTB.Text = "Unimplimented";

                String[] splitInput = input.Split(',');

                if (splitInput.Length != 4)
                {
                    MessageBox.Show("Input should be formatted as 'Address, City, State, Zip'.");
                }
                else
                {
                    String address = splitInput[0];
                    String city = splitInput[1];
                    String state = splitInput[2];
                    String zip = splitInput[3];

                    List<GovData.Representative> repList = dClass.GetRepresentativesByAddress(address, city, state, zip);
                    
                    //Call getSenByZip method
                    List<GovData.Senator> senList = dClass.GetSenator(repList[0].State);

                    String output = "Senators:";
                    for (int i = 0; i < senList.Count; i++)
                    {
                        output += Environment.NewLine + "   " + (i + 1) + ": " + Environment.NewLine +
                            "       Name: " + senList[i].FirstName + " " + senList[i].LastName + Environment.NewLine +
                            "       Party: " + senList[i].Party + Environment.NewLine +
                            "       ID: " + senList[i].bioguide_id + Environment.NewLine +
                            "       State: " + senList[i].StateAbrev + Environment.NewLine +
                            "       Phone: " + senList[i].Phone + Environment.NewLine +
                            "       Class: " + senList[i].Class + Environment.NewLine;

                        if (senList[i].LeadershipPosition != "")
                        {
                            output += "       Leadership Position?: Yes: " + senList[i].LeadershipPosition + Environment.NewLine + Environment.NewLine;
                        }
                        else
                        {
                            output += "       Leadership Position?: No" + Environment.NewLine + Environment.NewLine;
                        }
                    }

                    output += "District Representative:";
                    for (int i = 0; i < repList.Count; i++)
                    {
                        output += Environment.NewLine + "   " + (i + 1) + ": " + Environment.NewLine +
                            "       Name: " + repList[i].FirstName + " " + repList[i].MiddleName + " " + repList[i].LastName + " " + repList[i].Suffix + Environment.NewLine +
                            "       Party: " + repList[i].Party + Environment.NewLine +
                            "       ID: " + repList[i].BioguideID + Environment.NewLine +
                            "       State: " + repList[i].State + Environment.NewLine +
                            "       District: " + repList[i].District + Environment.NewLine;
                    }

                    //update fields
                    outputRTB.Text = output;

                }

            }
            else if (comboBoxRep.SelectedIndex == 1)
            { //if zip
                //get input
                String zip = inputZ.Text;

                if (zip.Length != 5)
                {
                    MessageBox.Show("Zip should be formatted as '#####'.");
                }
                else
                {
                    //Call getRepByZip method
                    List<GovData.Representative> repList = dClass.GetRepresentativesByZip(zip);

                    //Call getSenByZip method
                    List<GovData.Senator> senList = dClass.GetSenator(repList[0].State);

                    String output = "Senators:";
                    for (int i = 0; i < senList.Count; i++)
                    {
                        output += Environment.NewLine + "   " + (i + 1) + ": " + Environment.NewLine +
                            "       Name: " + senList[i].FirstName + " " + senList[i].LastName + Environment.NewLine +
                            "       Party: " + senList[i].Party + Environment.NewLine +
                            "       ID: " + senList[i].bioguide_id + Environment.NewLine +
                            "       State: " + senList[i].StateAbrev + Environment.NewLine +
                            "       Phone: " + senList[i].Phone + Environment.NewLine +
                            "       Class: " + senList[i].Class + Environment.NewLine;

                        if (senList[i].LeadershipPosition != "")
                        {
                            output += "       Leadership Position?: Yes: " + senList[i].LeadershipPosition + Environment.NewLine + Environment.NewLine;
                        }
                        else
                        {
                            output += "       Leadership Position?: No" + Environment.NewLine + Environment.NewLine;
                        }
                    }

                    output += "Representatives:";
                    for (int i = 0; i < repList.Count; i++)
                    {
                        output += Environment.NewLine + "   " + (i + 1) + ": " + Environment.NewLine +
                            "       Name: " + repList[i].FirstName + " " + repList[i].MiddleName + " " + repList[i].LastName + " " + repList[i].Suffix + Environment.NewLine +
                            "       Party: " + repList[i].Party + Environment.NewLine +
                            "       ID: " + repList[i].BioguideID + Environment.NewLine +
                            "       State: " + repList[i].State + Environment.NewLine +
                            "       District: " + repList[i].District + Environment.NewLine;
                    }

                    //update fields
                    outputRTB.Text = output;
                }
            }
        }
    }
}
