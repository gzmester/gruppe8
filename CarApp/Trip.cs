using System;

namespace car_app
{
    public class Trip
    {
        public string CarRegNr { get; set; }
        public double Distance { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public override string ToString()
        {
            return $"{CarRegNr};{Distance};{Date:yyyy-MM-dd};{StartTime:hh\\:mm};{EndTime:hh\\:mm}";
        }

        public static Trip FromString(string input)
        {
            var parts = input.Split(';');
            return new Trip
            {
                CarRegNr = parts[0],
                Distance = double.Parse(parts[1]),
                Date = DateTime.Parse(parts[2]),
                StartTime = TimeSpan.Parse(parts[3]),
                EndTime = TimeSpan.Parse(parts[4])
            };
        }
    }
}