using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GPX_Analyst.Helpers;
using GPX_Analyst.Model;
using System.Xml.Linq;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace GPX_Analyst.ViewModel
{
    public class GPXViewModel : ObservableObject
    {
        public List<Segment> Segments { get; set; }

        public ObservableCollection<Metadata> MetadataList { get; set; }

        private string _gpxFilename = String.Empty;

        bool CanLoadGPXFile()
        {
            return true;
        }

        void LoadGPXFile()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Multiselect = false;
            openDialog.FileName = String.Empty;
            openDialog.Filter = "GPX Files (*.gpx)|*.gpx";
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

            if (openDialog.ShowDialog() != true)
                return;

            _gpxFilename = openDialog.FileName;

            Track track = GPX_Analyst.DataProvider.GPXData.Load(_gpxFilename);

            MetadataList = new ObservableCollection<Metadata>();
            MetadataList.Add(new Metadata("Name", track.Name));
            MetadataList.Add(new Metadata("Time", track.Time));

            Segments = track.Segments;

            RaisePropertyChanged("Segments");
            RaisePropertyChanged("MetadataList");
        }

        public ICommand OpenGPXFile { get { return new RelayCommand(LoadGPXFile, CanLoadGPXFile); } }

    }
}

