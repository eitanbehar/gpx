using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Data;

namespace EndoCaloriesChallenge
{
    public class DataReceiver
    {
        string _strExcelFilename = String.Empty;

        public DataReceiver(string Filename)
        {
            _strExcelFilename = Filename;
        }

        internal ObservableCollection<Participant> LoadData()
        {

            ObservableCollection<Participant> participants = new ObservableCollection<Participant>();

           DataTable dt = new DataTable("Endomondo");
            OleDbConnection dbConnection = new OleDbConnection
                (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _strExcelFilename + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";");
            dbConnection.Open();
            try
            {
                OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT * FROM [Endomondo$]", dbConnection);
                dbAdapter.Fill(dt);

                int columnsCount = dt.Columns.Count;

                foreach (DataRow row in dt.Rows)
                {
                    Participant p = new Participant();
                    p.Name = row[0].ToString();

                    int outValue;
                    int.TryParse(row[columnsCount - 1].ToString(), out outValue);
                    if (outValue != 0)
                    {
                        p.CaloriesThisMonth = outValue;
                    }
                    int.TryParse(row[columnsCount - 2].ToString(), out outValue);
                    if (outValue != 0)
                    {
                        p.CaloriesLastMonth = outValue;
                    }
                    participants.Add(p);
                }

            }
            finally
            {
                dbConnection.Close();
            }

            return participants;

        }
        

    }
}
