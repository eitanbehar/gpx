using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;


namespace EndoCaloriesChallenge
{
    public class Logger
    {
        private string _logFileName = String.Empty;

        public Logger(string logFilename)
        {
            _logFileName = logFilename;
        }

        public string GetLogFileName()
        {
            return _logFileName;
        }
        
        public void WriteToLog(string sMsg)
        {
            string s = String.Format("[{0}]: {1}", DateTime.Now, sMsg);
            File.AppendAllText(_logFileName, s + "\r\n");
        }

        public void ClearLog()
        {
            if (File.Exists(_logFileName))
            {
                File.Delete(_logFileName);
            }
        }
    }
}
