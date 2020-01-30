using System;

namespace BerlinClock
{
    public class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public int getHours()
        {
            return hours;
        }

        private void setHours(int hours)
        {
            this.hours = hours;
        }

        public int getMinutes()
        {
            return minutes;
        }

        private void setMinutes(int minutes)
        {
            this.minutes = minutes;
        }

        public int getSeconds()
        {
            return seconds;
        }

        private void setSeconds(int seconds)
        {
            this.seconds = seconds;
        }
        public static Time convertFromString(string aTime)
        {
            try
            {
                var time = new Time();
                var splittedTime = aTime.Split(':');
                time.setSeconds(int.Parse(splittedTime[2]));
                time.setMinutes(int.Parse(splittedTime[1]));
                time.setHours(int.Parse(splittedTime[0]));
                return time;
            }
            catch(Exception ex)
            {
                throw new InvalidFormatException(String.Format("Please enter a valid time. Exception: {0}", ex.Message));
            }
        }
    }
}