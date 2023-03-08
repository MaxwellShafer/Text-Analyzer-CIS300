/* uxTextAnalyer.cs
 * By: Max Shafer
 */

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
    /// <summary>
    /// a form for analying texts
    /// </summary>
    public partial class uxTextAnalyzer : Form
    {
        /// <summary>
        /// a feld to keep track of the threshold counter
        /// </summary>
        public uxThresholdDialog thresholdData = new uxThresholdDialog();

        /// <summary>
        /// a format string
        /// </summary>
        private const string _formatString = "N5";

        /// <summary>
        /// an array to store the files read in
        /// </summary>
        private static FileInfo[] files;

        /// <summary>
        /// stores the freqency tables 
        /// </summary>
        private static Dictionary<string, double>[] freqTables;


        /// <summary>
        /// initilizes the form and sets the text for threshold
        /// </summary>
        public uxTextAnalyzer()
        {
            InitializeComponent();
            uxThresholdText.Text = thresholdData.Threshold.ToString("N3");
        }

        /// <summary>
        /// event handler for opening a folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenFolder_Click(object sender, EventArgs e)
        {

            if(uxFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                

                DirectoryInfo directory = new DirectoryInfo(uxFolderBrowserDialog.SelectedPath);

                files = directory.GetFiles();
                

                if (CheckForFiles(files))
                {
                    uxListView.Items.Clear();
                    freqTables = TextAnalyzer.BuildFrequencyTables(files);
                    SetupListView(files, freqTables, 0);  
                }
                else
                {
                    Exception ex = new IOException("The selected folder contains no files");
                    MessageBox.Show(ex.ToString());
                }  
            }
            
        }
        /// <summary>
        /// sets up the list view
        /// </summary>
        /// <param name="files">the files</param>
        /// <param name="freqTables">the freqencys corrisoponding</param>
        /// <param name="selectedIndex"></param>
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
        
        /// <summary>
        /// updates the last two columns
        /// </summary>
        /// <param name="freqTables">requency table array</param>
        /// <param name="selectedIndex">the current selected index</param>
        private void UpdateDiffrences(Dictionary<string, double>[] freqTables, int selectedIndex)
        {
            int i = 0;
            
            foreach (ListViewItem item in uxListView.Items)
            {
               
                int wordsCompared;
                double diffrence = TextAnalyzer.CompareDiffrences(freqTables[selectedIndex], freqTables[i], Convert.ToDouble(uxThresholdText.Text), out wordsCompared);

                item.SubItems[2].Text = diffrence.ToString(_formatString);
                item.SubItems[3].Text = wordsCompared.ToString();

                
                i++;

                
            }
        }

        /// <summary>
        /// checks if there are files in a directory
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
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
                uxThresholdText.Text =  thresholdData.Threshold.ToString("N3");

                if(uxListView.SelectedIndices.Count > 0)
                {
                    UpdateDiffrences(freqTables, uxListView.SelectedIndices[0]);
                }
            }
        }

        /// <summary>
        /// event handler when the index changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;

            if(uxListView.SelectedIndices.Count > 0)
            {
                UpdateDiffrences(freqTables, uxListView.SelectedIndices[0]);
            }
            
            
        }
        /// <summary>
        /// ignore accedential double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxThresholdText_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
