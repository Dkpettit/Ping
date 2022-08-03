/*
 * Project: Pinger
 * Author: Dave Pettit
 * Date: July 31, 2022
 * Description: A tool to automate the "ping"-ing of multiple IP's and URL's for IND INS ILLUSTRATIONS DR Drill. 
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ping
{
    /// <summary>
    /// A class to Ping the URL's/IP's from the input data and output to GUI
    /// </summary>
    internal class OutputToList
    {
        /// <summary>
        /// A method to receive and read the data from the input file as a List<string>, ping the addresses, 
        /// and display the results in the GUI
        /// </summary>
        /// <param name="list">List<string></param>
        /// <param name="myList1">ListBox</param>
        /// <param name="myList2">ListBox</param>
        public void PopulateListBox(List<string> list, ListBox myList1, ListBox myList2, string urlInput = "")
        {
            //Declare the Ping Object
            System.Net.NetworkInformation.Ping myPing = new System.Net.NetworkInformation.Ping();

            //Global variables
            ListBox l1 = myList1;
            ListBox l2 = myList2;
            string url = "";
            string status = "";
            string time = "";
            string address = "";
            bool log = false;
            StreamWriter SW = new StreamWriter(@"d:\\pingOutput.log");

            DialogResult dialogResult = MessageBox.Show("Would you like the input written to a log file?", "Log File", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Written to pingOutput.log");
                log = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }

                if (list.Count > 0)
                {
                    //Loop through the contents of the List
                    foreach (string s in list)
                    {
                        url = s;
                        try
                        {
                            //Instatiate a Pingreply using the Ping object
                            PingReply reply = myPing.Send(s, 1000);
                            if (reply != null)
                            {
                                status = reply.Status.ToString();
                                time = reply.RoundtripTime.ToString();
                                address = reply.Address.ToString();

                            
                                

                            //If a response is received, display in l1 if not the catch block displays in l2
                            if (reply.Status.ToString() == "Success")
                                {
                                    l1.ForeColor = Color.Green;

                                    l1.Items.Add($"URL: {url} Status: {status} Time: {time} Address: {address}");
                                }

                            }
                        }
                        catch
                        {
                            l2.ForeColor = Color.Red;
                            l2.Items.Add($"ERROR: {url} Failed to respond");
                        }
                    if (log)
                    {
                        SW.WriteLine($"{url} : Status: {status}, Response Time: {time}, IP Address: {address}");
                    }
                    }
                    SW.Close();
                }
                else if (urlInput.Length > 0)
                {

                    try
                    {
                        //Instatiate a Pingreply using the Ping object
                        PingReply reply = myPing.Send(urlInput, 1000);
                        if (reply != null)
                        {
                            
                            status = reply.Status.ToString();
                            time = reply.RoundtripTime.ToString();
                            address = reply.Address.ToString();
                        if (log)
                        {
                            SW.WriteLine($"{urlInput} : Status: {status}, Response Time: {time}, IP Address: {address}");
                        }

                        

                            //If a response is received, display in l1 if not the catch block displays in l2
                            if (reply.Status.ToString() == "Success")
                            {
                                l1.ForeColor = Color.Green;

                                l1.Items.Add($"URL: {url} Status: {status} Time: {time} Address: {address}");
                            }

                        SW.Close();

                        }
                    }
                    catch
                    {
                        l2.ForeColor = Color.Red;
                        l2.Items.Add($"ERROR: {url} Failed to respond");
                    }

                }
        }
    }
}
