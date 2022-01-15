using System;

namespace ISMPrakt07
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("_AIRPLANE CONSOLE_");
            Menu();
            int point = Convert.ToInt32(Console.ReadLine());
            AirPlane[] flight_list = new AirPlane[AirPlane.ActivePlane];
            Date LongestFlight = new Date();
            Date ShortestFlight = new Date();
            Date StartDate = new Date(2021, 1, 12, 15, 10, 0);
            Date FinishDate = new Date(2021, 1, 12, 23, 0, 0);
            //change this


            flight_list[0] = new AirPlane("Kyiv", "Warcshawa", StartDate, FinishDate);
            flight_list[1] = new AirPlane("New York", "Warcshawa", new Date(2021,1,11,10,0,0), new Date(2021, 1, 12, 10, 0, 0));
            flight_list[2] = new AirPlane("Mexico", "Warcshawa", new Date(2021, 1, 12, 19, 0, 0), new Date(2021, 1, 12, 21, 0, 0));

            do
            {
                switch (point)
                {
                    case 1:
                        ReadAirplaneArray(ref flight_list); Menu(); break;
                    case 2:
                        PrintAirplanes(flight_list); Menu(); break;
                    case 3:
                        GetAirplaneInfo(flight_list, out LongestFlight, out ShortestFlight);
                        Console.WriteLine($"Longest: {LongestFlight.Hour} Hours, {LongestFlight.Minute} Minutes, {LongestFlight.Second} Seconds");
                        Console.WriteLine($"Shortest: {ShortestFlight.Hour} Hours, {ShortestFlight.Minute} Minutes, {ShortestFlight.Second} Seconds");
                        Menu();
                        break;
                    case 4:
                        SortAirplanesByDate(flight_list); Menu(); break;
                    case 5:
                        SortAirplanesByTotalTime(flight_list); Menu();
                        break;
                    default:
                        Menu(); break;
                }
                point = Convert.ToInt32(Console.ReadLine());
            } while (point != 0);

            
            bool today = flight_list[0].IsArrivingToday(flight_list[0]);
   

            static void Menu()
            {
                Console.WriteLine("1-Add flight\n2-See all flight\n3-The longest and the shortest time of flight" +
                    "\n4-Sort airplanes by date\n5-Sort airplanes by total time\n0-Stop");

            }

            static void ReadAirplaneArray(ref AirPlane[] arr)
            {
                Console.Write("New flight\nStart city: ");
                string StartCity = Console.ReadLine();
                Console.Write("Finish city: ");
                string FinishCity = Console.ReadLine();

                Console.Write("Year of departure: ");
                int Year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Month of departure(1-12): ");
                int Month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Date of departure: ");
                int Date = Convert.ToInt32(Console.ReadLine());
                Console.Write("Hour of departure(0-24): ");
                int Hour = Convert.ToInt32(Console.ReadLine());
                Console.Write("Minute of departure(0-60): ");
                int Minute = Convert.ToInt32(Console.ReadLine());
                Console.Write("Second of departure(0-60): ");
                int Second = Convert.ToInt32(Console.ReadLine());
                Date StartDate = new Date(Year, Month, Date, Hour, Minute, Second);

                Console.Write("Year of arrival: ");
                int FYear = Convert.ToInt32(Console.ReadLine());
                Console.Write("Month of arrival(1-12): ");
                int FMonth = Convert.ToInt32(Console.ReadLine());
                Console.Write("Date of arrival: ");
                int FDate = Convert.ToInt32(Console.ReadLine());
                Console.Write("Hour of arrival(0-24): ");
                int FHour = Convert.ToInt32(Console.ReadLine());
                Console.Write("Minute of arrival(0-60): ");
                int FMinute = Convert.ToInt32(Console.ReadLine());
                Console.Write("Second of arrival(0-60): ");
                int FSecond = Convert.ToInt32(Console.ReadLine());
                Date FinishDate = new Date(FYear, FMonth, FDate, FHour, FMinute, FSecond);

                AirPlane.ActivePlane++; 
                Array.Resize<AirPlane>(ref arr, AirPlane.ActivePlane);
                arr[AirPlane.ActivePlane - 1] = new AirPlane(StartCity, FinishCity, StartDate, FinishDate);   
                Console.WriteLine("\nComplete!");
                
            }

            static void PrintAirplane(AirPlane[] flight_list, int flight_number)
            {
                
                Console.WriteLine($" № Start city:\t   Finish city:\t    Start date:\t\t    Finish date:");
                Console.Write($"{flight_number+1,2}{flight_list[flight_number].StartCity,11}{flight_list[flight_number].FinishCity,17}");
                PrintDate(flight_list[flight_number].StartDate);
                PrintDate(flight_list[flight_number].FinishDate);
                Console.WriteLine("\n");
            }

            static void PrintAirplanes(AirPlane[] flight_list)
            {
                int ActivePlane = AirPlane.ActivePlane;
                for (int i = 0; i < ActivePlane; i++)
                {
                    Console.WriteLine($" № Start city:\t   Finish city:\t    Start date:\t\t    Finish date:");
                    Console.Write($"{i+1,2}{flight_list[i].StartCity,11}{flight_list[i].FinishCity,17}");
                    PrintDate(flight_list[i].StartDate);
                    PrintDate(flight_list[i].FinishDate);
                    Console.WriteLine("\n");
                }
            }

            static void PrintDate(Date date)
            {
                string _date = Convert.ToString(date.Year) + "." + Convert.ToString(date.Month) + "." + Convert.ToString(date.Day) + " " + Convert.ToString(date.Hour) + ":" + Convert.ToString(date.Minute) + ":" + Convert.ToString(date.Second);
                Console.Write($"{_date,23}");
                
            }

            static void GetAirplaneInfo(AirPlane[] flight_list, out Date Longest, out Date Shortest)
            {
                Longest = flight_list[0].GetTotalTime(flight_list, 1);
                Shortest = flight_list[0].GetTotalTime(flight_list, 1);
                for (int i = 0; i < AirPlane.ActivePlane; i++)
                {
                    if (flight_list[i].GetTotalTime(flight_list, i).Hour > Longest.Hour)
                    {
                        Longest = flight_list[i].GetTotalTime(flight_list, i);
                    }
                    else if (flight_list[i].GetTotalTime(flight_list, i).Hour == Longest.Hour)
                    {
                        if (flight_list[i].GetTotalTime(flight_list, i).Minute > Longest.Minute)
                        {
                            Longest = flight_list[i].GetTotalTime(flight_list, i);
                        }
                    }
                }

                for (int i = 0; i < AirPlane.ActivePlane; i++)
                {
                    if (flight_list[i].GetTotalTime(flight_list, i).Hour < Shortest.Hour)
                    {
                        Shortest = flight_list[i].GetTotalTime(flight_list, i);
                    }
                    else if (flight_list[i].GetTotalTime(flight_list, i).Hour == Shortest.Hour)
                    {
                        if (flight_list[i].GetTotalTime(flight_list, i).Minute < Shortest.Minute)
                        {
                            Shortest = flight_list[i].GetTotalTime(flight_list, i);
                        }
                    }
                }
            }
            static void SortAirplanesByDate(AirPlane[] flight_list)
            {
                int[] arr_date = new int[AirPlane.ActivePlane];
                int[] arr_id = new int[AirPlane.ActivePlane];
                for (int i = 0; i < AirPlane.ActivePlane; i++)
                {
                    arr_date[i] = flight_list[i].StartDate.Day;
                    arr_id[i] = flight_list[i].IDFlight;
                }
                Array.Sort(arr_date, arr_id);
                Array.Reverse(arr_date);
                Array.Reverse(arr_id);

                for (int i = 0; i < AirPlane.ActivePlane; i++)
                {
                    for (int j = 0; j < AirPlane.ActivePlane; j++)
                    {
                        if (arr_id[i] == flight_list[j].IDFlight) PrintAirplane(flight_list, j);
                    }
                }
            }

            static void SortAirplanesByTotalTime(AirPlane[] flight_list)
            {
                int[] arr_ttime = new int[AirPlane.ActivePlane];
                int[] arr_id = new int[AirPlane.ActivePlane];
                Date Time = new Date();
                for (int i = 0; i < AirPlane.ActivePlane; i++)
                {
                    Time = flight_list[i].GetTotalTime(flight_list, i);
                    arr_ttime[i] = Time.Hour;
                    arr_id[i] = flight_list[i].IDFlight;
                }

                Array.Sort(arr_ttime, arr_id);

                for (int i = 0; i < AirPlane.ActivePlane; i++)
                {
                    for (int j = 0; j < AirPlane.ActivePlane; j++)
                    {
                        if (arr_id[i] == flight_list[j].IDFlight) PrintAirplane(flight_list, j);
                  
                    }
                }
            }
        }
    }
    
}

