using FitUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExportFit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog fileDialog = new OpenFileDialog();

            Button bt = (Button)sender;
            GroupBox currentGroupBox = (GroupBox)bt.Parent;
            TextBox txtB = (TextBox)currentGroupBox.Controls[bt.Name.Replace("buttonBrowse", "textBox")];
            fileDialog.CheckPathExists = true;
            fileDialog.Filter = "(Fit Files *.fit) | *.fit";
            fileDialog.InitialDirectory = txtB.Text;
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtB.Text = fileDialog.FileName;
        }

        private void checkBoxVirtualRoute_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxVirtualRoute.Enabled = checkBoxVirtualRoute.Checked;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string fitFile = textBoxFitFilename.Text;
            string tcxFile = textBoxTcxFilename.Text;

            Tcx tcx = Fit.ReadFitFileIntoTcxObject(fitFile);

            if (checkBoxDistance.Checked)
            {
                tcx.DistanceMeters = double.Parse(textBoxDistance.Text);
            }

            tcx.AdjustPoints();

            if (checkBoxVirtualRoute.Checked)
            {
                tcx.CreateVirtualRoute(double.Parse(textBoxLatitude.Text), double.Parse(textBoxLongitude.Text),
                    (Tcx.RouteType)Enum.Parse(typeof(Tcx.RouteType), comboBoxRouteType.SelectedItem.ToString()));
            }

            tcx.Save(tcxFile);

            Clipboard.Clear();
            Clipboard.SetText(tcxFile);

            MessageBox.Show("Completed");
        }

        private void buttonBrowseTcxFilename_Click(object sender, EventArgs e)
        {

            SaveFileDialog fileDialog = new SaveFileDialog();

            Button bt = (Button)sender;
            GroupBox currentGroupBox = (GroupBox)bt.Parent;
            TextBox txtB = (TextBox)currentGroupBox.Controls[bt.Name.Replace("buttonBrowse", "textBox")];
            fileDialog.InitialDirectory = txtB.Text;
            fileDialog.Filter = "(Tcx Files *.tcx) | *.tcx";
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            txtB.Text = fileDialog.FileName;
        }

        private void textBoxFitFilename_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(textBoxTcxFilename.Text))
                    return;

                string fitFileName = textBoxFitFilename.Text;

                if (String.IsNullOrEmpty(fitFileName))
                    return;

                string fileName = Path.GetFileNameWithoutExtension(fitFileName);

                textBoxTcxFilename.Text = Path.Combine(@"C:\temp", fileName + "_" + comboBoxRouteType.Text  + ".tcx");

            }
            catch
            {
                // do nothing
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBoxRouteType.SelectedIndex = 0;
        }

        
        private void comboBoxRouteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxTcxFilename.Text = String.Empty;
            textBoxFitFilename_TextChanged(sender, e);
        }

        
    }
}
