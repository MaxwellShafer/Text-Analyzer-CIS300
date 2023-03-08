/* uxThresholdDialog.cs
 * By: Max Shafer
 */

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.TextAnalysis
{
    /// <summary>
    /// threshold form
    /// </summary>
    public partial class uxThresholdDialog : Form
    {
        /// <summary>
        /// public property for the threshold
        /// </summary>
        public decimal Threshold { get => uxThresholdCounter.Value; }

        /// <summary>
        /// initiazes the form
        /// </summary>
        public uxThresholdDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// event handler for when button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxButton_Click(object sender, EventArgs e)
        {
            
            uxButton.DialogResult = DialogResult.OK;

        }
        /// <summary>
        /// ignore accedental double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxThresholdDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
