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
    public partial class uxThresholdDialog : Form
    {
        public decimal Threshold { get => uxThresholdCounter.Value; }

        
        public uxThresholdDialog()
        {
            InitializeComponent();
        }

        private void uxButton_Click(object sender, EventArgs e)
        {
            
            uxButton.DialogResult = DialogResult.OK;

        }

        private void uxThresholdDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
