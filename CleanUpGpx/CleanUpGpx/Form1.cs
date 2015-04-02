using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CleanUpGpx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = @"D:\Batey\Downloads\Pura 08-nov-2014.gpx";
            string outFile = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + ".new.gpx");

            XDocument xDoc = XDocument.Load(fileName);

            XNamespace ns = xDoc.Root.Name.Namespace;

            xDoc.Descendants(ns + "extensions").Remove();

            xDoc.Save(outFile);

        }
    }
}
