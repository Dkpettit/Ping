﻿/*
 * Project: Pinger
 * Author: Dave Pettit
 * Date: July 31, 2022
 * Description: A tool to automate the "ping"-ing of multiple IP's and URL's for IND INS ILLUSTRATIONS DR Drill. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using CsvHelper.Configuration; //CSV Configuration
using System.Globalization;
using CsvHelper; //To read in CSV File

namespace Ping
{
    /// <summary>
    /// Class to fetch and return input
    /// </summary>
    public class ReadInput
    {
        /// <summary>
        /// A Method to retrieve the URL's/IP's from a CSV file
        /// </summary>
        /// <returns>List<string> of URL's/IP's</returns>
        public List<string> getInput()
        {
            String line;
            List<string> list = new List<string>();

            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };


            try
            {
                //Select the CSV file
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //Select the CSV file from the File Picker
                    string selectedFileName = openFileDialog1.FileName;
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(selectedFileName);

                    // Instantiate the CSV Reader - Passing in the StreamReader and the CSV Config object
                    var csvReader = new CsvReader(sr, csvConfig);

                    string value;
                    //Read the input continue to read until you reach end of file
                    while (csvReader.Read())
                    {
                        //add the data to a List<string>
                        for (int i = 0; csvReader.TryGetField<string>(i, out value); i++)
                        {
                            list.Add(value);
                        }
                    }
                    //close the file
                    sr.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return list;
        }
    }
}
