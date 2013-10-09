using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.WPF.Framework;

namespace EndoCaloriesChallenge
{
    public class Participant : ObservableObject
    {
        public string Name { get; set; }
        public int CaloriesLastMonth { get; set; }
        public int CaloriesThisMonth { get; set; }

        public int CalculatedCalories { get; set; }
        public int NumberOfTickets { get; set; }
        public List<int> Tickets { get; set; }

        public void UpdateValues(int CaloriesIncreaseFactor, int CaloriesPerTicket)
        {
            CalculatedCalories = CaloriesThisMonth;

            if (CaloriesThisMonth > CaloriesLastMonth && CaloriesLastMonth > 0)
            {
                CalculatedCalories += (CaloriesThisMonth - CaloriesLastMonth) * CaloriesIncreaseFactor;
            }

            NumberOfTickets = (int)(CalculatedCalories / CaloriesPerTicket);
            Tickets = new List<int>();
            
            RaisePropertyChanged("CalculatedCalories");
            RaisePropertyChanged("NumberOfTickets");
        }
    }
}
