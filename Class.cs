using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ISMPrakt07
{
    public class AirPlane
    {
        public AirPlane() { }

        public AirPlane(string StartCity, string FinishCity)
        {
            this.StartCity = StartCity;
            this.FinishCity = FinishCity;
            this.StartDate = null;
            this.FinishDate = null;
            id++;
            IDFlight = id;
        }
        public AirPlane(string StartCity, string FinishCity, Date StartDate, Date FinishDate)
        {
            this.StartCity = StartCity;
            this.FinishCity = FinishCity;
            this.StartDate = StartDate;
            this.FinishDate = FinishDate;
            id++;
            IDFlight = id;
        }

        public AirPlane(AirPlane flight)
        {
            this.StartCity = flight.StartCity;
            this.FinishCity = flight.FinishCity;
            this.StartDate = flight.StartDate;
            this.FinishDate = flight.FinishDate;
            id++;
            IDFlight = id;
        }

        public static int ActivePlane = 3;
        protected static int id = 1000;
        public int IDFlight;
        public int _ActivePlane {
            get { return ActivePlane; }
            set { ActivePlane = value; }
        }
        protected string _startCity;
        public string StartCity {
            get { return _startCity; }
            set { _startCity = value; }
        }
        
        protected string _finishCity;

        public string FinishCity
        {
            get { return _finishCity; }
            set { _finishCity = value; }
        }
        protected Date _startDate = new Date();
        public Date StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        protected Date _finishDate = new Date();
        public Date FinishDate
        {
            get { return _finishDate; }
            set { _finishDate = value; }
        }


        public bool IsArrivingToday(AirPlane race)
        {
            if (race.StartDate.Day == race.FinishDate.Day) { return true; }
            else { return false; }
        }
        public Date GetTotalTime(AirPlane[] flight_list, int flight_number)
        {
            bool flag = false; //для правильності обрахунку часу
            Date Time = new Date();
            
            if (flight_list[flight_number].StartDate.Day < flight_list[flight_number].FinishDate.Day)
            {
                if (flight_list[flight_number].StartDate.Hour == flight_list[flight_number].FinishDate.Hour)
                {
                    Time.Hour = 24;
                }
                else
                {
                    Time.Hour = (24 - flight_list[flight_number].StartDate.Hour) + flight_list[flight_number].FinishDate.Hour;
                }
            }
            else
            {
                Time.Hour = flight_list[flight_number].FinishDate.Hour - flight_list[flight_number].StartDate.Hour;
            }

            if ((flight_list[flight_number].StartDate.Minute < flight_list[flight_number].FinishDate.Minute) || (flight_list[flight_number].StartDate.Minute == flight_list[flight_number].FinishDate.Minute))
            {
                
                Time.Minute = flight_list[flight_number].FinishDate.Minute - flight_list[flight_number].StartDate.Minute;
            }
            else
            {
                Time.Minute = (60 - flight_list[flight_number].StartDate.Minute) + flight_list[flight_number].FinishDate.Minute;
                Time.Hour -= 1;
            }

            return Time;
        }
    }

    public class Date
    {
        public Date() { }

        public Date(int Hour, int Minute, int Second) 
        {
            this.Hour = Hour;
            this.Minute = Minute;
            this.Second = Second;
        }
        public Date(int Year, int Month, int Day, int Hour, int Minute, int Second)
        {
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
            this.Hour = Hour;
            this.Minute = Minute;
            this.Second = Second;
        }

        public Date(Date date)
        {
            this.Year = date.Year;
            this.Month = date.Month;
            this.Day = date.Day;
            this.Hour = date.Hour;
            this.Minute = date.Minute;
            this.Second = date.Second;
        }

        protected int _year = 0;
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        protected int _month = 1;
        internal int Month
        {
            get { return _month; }
            set { if ((value >= 1) && (value <= 12)) _month = value; }
        }

        protected int _date = 1;
        internal int Day
        {
            get { return _date; }
            set
            {
                if ((_month == 2) && (_year % 4 == 0))
                {
                    if ((value >= 1) && (value <= 29)) _date = value;
                }
                else if ((_month == 2) && (_year % 4 != 0))
                {
                    if ((value >= 1) && (value <= 28)) _date = value;
                }
                else if (_month % 2 == 0)
                {
                    if ((value >= 1) && (value <= 31)) _date = value;
                }
                else
                {
                    if ((value >= 1) && (value <= 30)) _date = value;
                }
            }
        }
        protected int _hour = 0;
        internal int Hour
        {
            get { return _hour; }
            set { if ((value >= 0) && (value <= 24)) _hour = value; }
        }

        protected int _minute = 0;
        internal int Minute
        {
            get { return _minute; }
            set { if ((value >= 0) && (value <= 59)) _minute = value; }
        }

        protected int _second = 0;
        internal int Second
        {
            get { return _second; }
            set { if ((value >= 0) && (value <= 59)) _second = value; }
        }
       
        public void PrintDate(Date date)
        {
            Console.WriteLine($"{date.Year}.{date.Month}.{date.Day} {date.Hour}:{date.Minute}:{date.Second}");
        }
    }
  
}
