using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Ksu.Cis300.TextAnalysis
{
    public partial class uxTextAnalyzer : Form
    {
        public uxThresholdDialog thresholdData = new uxThresholdDialog();



        private const string _formatString = "N5";

        private const int _nameLoc = 0;
        private const int _vocabLoc = 1;
        private const int _wordsLoc = 2;
        private const int _diffrenceLoc = 3;

        private static FileInfo[] files;

        private static Dictionary<string, double>[] freqTables;



        public uxTextAnalyzer()
        {
            InitializeComponent();
            uxThresholdText.Text = thresholdData.Threshold.ToString(_formatString);
        }

        
        private void uxOpenFolder_Click(object sender, EventArgs e)
        {
            if(uxFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                uxListView.Items.Clear();

                DirectoryInfo directory = new DirectoryInfo(uxFolderBrowserDialog.SelectedPath);

                files = directory.GetFiles();
                

                if (CheckForFiles(files))
                {
                        freqTables = TextAnalyzer.BuildFrequencyTables(files);
                        SetupListView(files, freqTables, 0);  
                }


                  
            }
            
        }

        private void SetupListView(FileInfo[] files, Dictionary<string, double>[] freqTables, int selectedIndex)
        {
            
            for(int i = 0; i < files.Count(); i++)
            {
                string name = files[i].Name;
                int vocab = freqTables[i].Count();
                
               
              
                

                ListViewItem item = new ListViewItem(name);
                item.SubItems.Add(vocab.ToString());
                item.SubItems.Add("");
                item.SubItems.Add("");
                
                uxListView.Items.Add(item);

            }

            uxListView.Items[0].Selected = true;

           

            
            
        }
        
        private void UpdateDiffrences(Dictionary<string, double>[] freqTables, int selectedIndex)
        {
            int i = 0;
            foreach (ListViewItem item in uxListView.Items)
            {
               
                int wordsCompared;
                double diffrence = TextAnalyzer.CompareDiffrences(freqTables[selectedIndex], freqTables[i], Convert.ToDouble(uxThresholdText.Text), 1, out wordsCompared);

                item.SubItems[2].Text = diffrence.ToString(_formatString);
                item.SubItems[3].Text = wordsCompared.ToString();

                
                i++;

                //
            }
        }

        private bool CheckForFiles(FileInfo[] files)
        {
            foreach(FileInfo file in files)
            {
                if (file.Exists)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks a directory to see if there is a text file
        /// </summary>
        /// <param name="FileName">the path of the file</param>
        /// <returns>A bool if it has a txt file</returns>
        

        public void uxThresholdButton_Click(object sender, EventArgs e)
        {
            if(thresholdData.ShowDialog() == DialogResult.OK)
            {
                uxThresholdText.Text =  thresholdData.Threshold.ToString(_formatString);

                if(uxListView.SelectedIndices.Count > 0)
                {
                    UpdateDiffrences(freqTables, uxListView.SelectedIndices[0]);
                }
            }
        }

        private void uxListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;

            if(uxListView.SelectedIndices.Count > 0)
            {
                UpdateDiffrences(freqTables, uxListView.SelectedIndices[0]);
            }
            
            
        }

        private void uxThresholdText_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
