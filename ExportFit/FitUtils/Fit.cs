using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynastream.Fit;
using System.IO; // downloaded from http://www.thisisant.com/resources/fit // also decoder code used from corresponding example

namespace FitUtils
{
    public static class Fit
    {
        public static Tcx tcx = new Tcx();

        public static Tcx ReadFitFileIntoTcxObject(string fitFile)
        {
            // Attempt to open .FIT file
            FileStream fitSource = new FileStream(fitFile, FileMode.Open);
            Console.WriteLine("Opening {0}", fitFile);

            Decode decodeDemo = new Decode();
            MesgBroadcaster mesgBroadcaster = new MesgBroadcaster();

            // Connect the Broadcaster to our event (message) source (in this case the Decoder)
            decodeDemo.MesgEvent += mesgBroadcaster.OnMesg;
            decodeDemo.MesgDefinitionEvent += mesgBroadcaster.OnMesgDefinition;

            // Subscribe to message events of interest by connecting to the Broadcaster
            mesgBroadcaster.MesgEvent += new MesgEventHandler(OnMesg);
            mesgBroadcaster.MesgDefinitionEvent += new MesgDefinitionEventHandler(OnMesgDefn);

            mesgBroadcaster.FileIdMesgEvent += new MesgEventHandler(OnFileIDMesg);
            mesgBroadcaster.UserProfileMesgEvent += new MesgEventHandler(OnUserProfileMesg);

            mesgBroadcaster.SessionMesgEvent += new MesgEventHandler(OnSessionMesgEvent); 
           
            bool status = decodeDemo.IsFIT(fitSource);
            status &= decodeDemo.CheckIntegrity(fitSource);
            // Process the file
                if (status == true)
                {
                    Console.WriteLine("Decoding...");
                    try { decodeDemo.Read(fitSource); } catch {}
                    Console.WriteLine("Decoded FIT file {0}", fitFile);
                }
                else
                {
                    Console.WriteLine("Integrity Check Failed {0}", fitFile);
                    Console.WriteLine("Attempting to decode...");
                    try { decodeDemo.Read(fitSource); }
                    catch { }
                }
            fitSource.Close();

            return tcx;
        }

        #region Message Handlers
        // Client implements their handlers of interest and subscribes to MesgBroadcaster events
        static void OnMesgDefn(object sender, MesgDefinitionEventArgs e)
        {
            Console.WriteLine("OnMesgDef: Received Defn for local message #{0}, it has {1} fields", e.mesgDef.LocalMesgNum, e.mesgDef.NumFields);
        }

        private static void OnSessionMesgEvent(object sender, MesgEventArgs e)
        {
            SessionMesg session = (SessionMesg)e.mesg;
            if (session.GetTotalCalories() < ushort.MaxValue)
            {
                tcx.Calories = (int)session.GetTotalCalories();
            }
            if (session.GetTotalDistance() < 1E6)
            {
                tcx.DistanceMeters = (double)session.GetTotalDistance();
            }
        }

        static void OnMesg(object sender, MesgEventArgs e)
        {
            string activityType = e.mesg.Name;
            Console.WriteLine("OnMesg: Received Mesg with global ID#{0}, its name is {1}", e.mesg.Num, activityType);

            Trackpoint tp = new Trackpoint();

            for (byte i = 0; i < e.mesg.GetNumFields(); i++)
            {
                foreach (var field in e.mesg.fields)
                {
                    string fieldValue = field.GetValue().ToString();
                    string fieldName = field.GetName().ToString();
                    string recordType = e.mesg.fields[i].Num.ToString();
                    Console.WriteLine("\tField{0} Index{1} (\"{2}\" Field#{4}) Value: {3}", i, 0, fieldName, fieldValue, recordType);

                    
                    if (activityType == "FileId")
                    {
                        switch (fieldName)
                        {
                            case "TimeCreated":
                                Dynastream.Fit.DateTime dt = new Dynastream.Fit.DateTime(uint.Parse(fieldValue));
                                tcx.Id = Trackpoint.ConvertDate(dt.GetDateTime());
                                tcx.StartTime = dt.GetDateTime();
                                break;
                            default:
                                break;
                        }
                    }

                    if (activityType == "Record")
                    {
                        switch (fieldName)
                        {
                            case "Timestamp":
                                Dynastream.Fit.DateTime dt = new Dynastream.Fit.DateTime(uint.Parse(fieldValue));
                                tp.Time = dt.GetDateTime();
                                break;
                            case "HeartRate":
                                tp.HeartRateBpm = int.Parse(fieldValue);
                                break;
                            case "PositionLat":
                                tp.LatitudeDegrees = double.Parse(fieldValue);
                                break;
                            case "PositionLong":
                                tp.LongitudeDegrees = double.Parse(fieldValue);
                                break;
                            case "Altitude":
                                tp.AltitudeMeters = 300;//double.Parse(fieldValue);
                                break;
                            default:
                                break;
                        }
                    }

                }

            }

            if (activityType == "Record")
            {
                tcx.TrackpointList.Add(tp);
            }
        }

        static void OnFileIDMesg(object sender, MesgEventArgs e)
        {
            Console.WriteLine("FileIdHandler: Received {1} Mesg with global ID#{0}", e.mesg.Num, e.mesg.Name);
            FileIdMesg myFileId = (FileIdMesg)e.mesg;
            try
            {
                Console.WriteLine("\tType: {0}", myFileId.GetType());
                Console.WriteLine("\tManufacturer: {0}", myFileId.GetManufacturer());
                Console.WriteLine("\tProduct: {0}", myFileId.GetProduct());
                Console.WriteLine("\tSerialNumber {0}", myFileId.GetSerialNumber());
                Console.WriteLine("\tNumber {0}", myFileId.GetNumber());
                Dynastream.Fit.DateTime dtTime = new Dynastream.Fit.DateTime(myFileId.GetTimeCreated().GetTimeStamp());

            }
            catch (FitException exception)
            {
                Console.WriteLine("\tOnFileIDMesg Error {0}", exception.Message);
                Console.WriteLine("\t{0}", exception.InnerException);
            }
        }
        static void OnUserProfileMesg(object sender, MesgEventArgs e)
        {
            Console.WriteLine("UserProfileHandler: Received {1} Mesg, it has global ID#{0}", e.mesg.Num, e.mesg.Name);
            UserProfileMesg myUserProfile = (UserProfileMesg)e.mesg;
            try
            {
                Console.WriteLine("\tType {0}", myUserProfile.GetFriendlyName());
                Console.WriteLine("\tGender {0}", myUserProfile.GetGender().ToString());
                Console.WriteLine("\tAge {0}", myUserProfile.GetAge());
                Console.WriteLine("\tWeight  {0}", myUserProfile.GetWeight());
            }
            catch (FitException exception)
            {
                Console.WriteLine("\tOnUserProfileMesg Error {0}", exception.Message);
                Console.WriteLine("\t{0}", exception.InnerException);
            }
        }
        #endregion
    }


}
