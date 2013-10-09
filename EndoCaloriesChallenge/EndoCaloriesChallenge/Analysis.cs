using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using Infrastructure.WPF.Framework;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows.Input;
using System.IO;

namespace EndoCaloriesChallenge
{
    public class Analysis : ObservableObject
    {
        public ObservableCollection<Participant> Participants { get; set; }
        public int CaloriesPerTicket { get; set; }
        public int CaloriesIncreaseFactor { get; set; }
        public int TicketsToDraw { get; set; }

        public ObservableCollection<Winner> Winners { get; set; }

        private bool ticketsAreReady = false;

        Logger logger = null;

        public Analysis()
        {
            CaloriesPerTicket = 1000;
            CaloriesIncreaseFactor = 2;
            TicketsToDraw = 1;
        }

        void loadData()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Multiselect = false;
            openDialog.FileName = String.Empty;
            openDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Endomondo";

            if (openDialog.ShowDialog() != true)
                return;

            string fileName = openDialog.FileName;

            DataReceiver dataReceiver = new DataReceiver(fileName);
            Participants = dataReceiver.LoadData();

            RaisePropertyChanged("Participants");

            Winners = new ObservableCollection<Winner>();
            RaisePropertyChanged("Winners");

            logger = new Logger(Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + ".log"));

            ticketsAreReady = false;

        }

        bool CanDoIt()
        {
            return true;
        }

        bool CanDraw()
        {
            return ticketsAreReady; 
        }

        bool CanCalculate()
        {
            return (Participants != null);
        }

        void calculateTickets()
        {

            Winners = new ObservableCollection<Winner>();
            RaisePropertyChanged("Winners");
            
            int ticketsCount = 0;

            foreach (Participant p in Participants)
            {
                p.UpdateValues(CaloriesIncreaseFactor, CaloriesPerTicket);
                ticketsCount += p.NumberOfTickets;
            }

            List<int> ticketList = new List<int>();
            for (int i = 0; i < ticketsCount; i++)
            {
                ticketList.Add(i + 1); // tickets are 1 based
            }

            Randomizer r = new Randomizer();

            logger.ClearLog();
            logger.WriteToLog("Assigning Tickets");

            // assign tickets
            do
            {
                foreach (Participant p in Participants)
                {
                    if (p.Tickets.Count < p.NumberOfTickets)
                    {
                        // get ticket
                        bool isTicketFound = false;
                        do
                        {
                            int ticket = r.GetRandomTicket(ticketList.Min(), ticketList.Max());
                            if (ticketList.Contains(ticket))
                            {
                                p.Tickets.Add(ticket);

                                logger.WriteToLog(String.Format("{0} got ticket number: {1}", p.Name, ticket));

                                ticketList.Remove(ticket);
                                isTicketFound = true;
                            }

                        } while (!isTicketFound);
                    }

                    if (ticketList.Count == 0)
                        break;

                }
            }
            while (ticketList.Count != 0);

            logger.WriteToLog("----");

            RaisePropertyChanged("Participants");
            ticketsAreReady = true;
            
        }

        void selectLuckyWinners()
        {

            int ticketsCount = 0;
            foreach (Participant p in Participants)
            {
                ticketsCount += p.NumberOfTickets;
            }

            Winners = new ObservableCollection<Winner>();

            Randomizer r = new Randomizer();

            List<Participant> finalists = Participants.ToList<Participant>();

            logger.WriteToLog("Choosing winner ticket(s)");

            string excludeParticipant = String.Empty;

#if DEBUG
            excludeParticipant = "EitanB" ;
#endif


            // choose winners
            for (int i = 0; i < TicketsToDraw; i++)
            {

                bool isWinnerFound = false;
                do
                {
                    int winnerTicket = r.GetRandomTicket(1, ticketsCount);

                    // find winner
                    List<Participant> q = (from f in finalists
                                           where f.Tickets.Contains(winnerTicket) && f.Name != excludeParticipant
                                           select f).ToList<Participant>();

                    if (q.Count > 0)
                    {
                        Participant theOne = q[0];
                        Winners.Add(new Winner() { Name = theOne.Name, LuckyTicket = winnerTicket });

                        logger.WriteToLog(String.Format("Winner ticket: {1}. Lucky Winner: {0}", theOne.Name, winnerTicket));

                        finalists.Remove(theOne);
                        break;
                    }

                    if (finalists.Count == 0)
                        break;

                }
                while (!isWinnerFound);
            }

            RaisePropertyChanged("Winners");

        }


        public ICommand OpenEndomondoExcelFile { get { return new RelayCommand(loadData, CanDoIt); } }
        public ICommand SelectLuckyWinners { get { return new RelayCommand(selectLuckyWinners, CanDraw); } }
        public ICommand CalculateTickets { get { return new RelayCommand(calculateTickets, CanCalculate); } }
    }
}
