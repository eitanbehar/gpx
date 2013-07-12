using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GPX_Analyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButtonOpenGPX_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "GPX Files (*.gpx)|*.gpx";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.FileName = String.Empty;
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            OpenGPXFile(openFileDialog1.FileName);
        }

        private void OpenGPXFile(string Filename)
        {
            GPX gpx = new GPX(Filename);
            ShowGPX(gpx);
            dataGridViewGPX.Tag = gpx;
            textBoxName.Text = gpx.Name;
            textBoxDate.Text = DateTime.Parse(gpx.Time).ToLocalTime().ToString();
            splitContainer1.Visible = true;

            buttonAnalyze_Click(null, null);

        }

        private void ShowGPX(GPX gpx)
        {
            dataGridViewGPX.DataSource = null;
            Application.DoEvents();

            DataTable dt = TrackPoint.GetDatatable();

            foreach (TrackPoint trackPoint in gpx.TrackPoints)
            {
                dt.Rows.Add(trackPoint.GetDataRow(dt));
            }

            dataGridViewGPX.DataSource = dt;

            AdjustColumns(dataGridViewGPX.Columns);

        }

        private void AdjustColumns(DataGridViewColumnCollection dataGridViewColumnCollection)
        {
            dataGridViewColumnCollection["Lat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewColumnCollection["Lon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewColumnCollection["Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            toolStrip1.Focus();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            splitContainer1.Visible = false;
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            GPX gpx = (GPX)dataGridViewGPX.Tag;
            GPXAnalysisInfo gpxInfo = gpx.Analyze(double.Parse(textBoxMinSpeed.Text));
            textBoxDistance.Text = String.Format("{0,10:N2}", gpxInfo.Distance);
            textBoxMaxSpeed.Text = String.Format("{0,10:N2}", gpxInfo.Speed);
        }

    }
}
