using System;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private String color1 = "Y"; //Yellow Color
        private String color2 = "R"; //Red Color
        private String colorOff = "O"; //Off Color

        public string convertTime(string aTime)
        {
            try { 
                var time = Time.convertFromString(aTime);
                return getSeconds(time.getSeconds()) + Environment.NewLine + getHours(time.getHours()) + Environment.NewLine + getMinutes(time.getMinutes());
            }
            catch( InvalidFormatException inEx)
            {
                return inEx.Message;
            }
        }

        public string getOutput(Time time)
        {
            return getSeconds(time.getSeconds()) + Environment.NewLine + getHours(time.getHours()) + Environment.NewLine + getMinutes(time.getMinutes());
        }

        private string getHours(int hours)
        {
            return getLampState(4, (hours - (hours % 5)) / 5) + Environment.NewLine + getLampState(4, hours % 5);
        }
                
        private string getMinutes(int minutes)
        {
            return Regex.Replace(getLampState(11, (minutes - (minutes % 5)) / 5, color1), color1 + color1 + color1, color1 + color1 + color2) + Environment.NewLine +
                getLampState(4, minutes % 5, color1);
        }

        private string getSeconds(int seconds)
        {
            if (seconds % 2 == 0)
                return color1;
            else
                return colorOff;
        }

        private string getLampState(int lamps, int onLight)
        {
            return getLampState(lamps, onLight, color2);
        }

        private string getLampState(int lamps, int onLights, String onLight)
        {
            String output = "";
            for (int i = 0; i < onLights; i++)
            {
                output += onLight;
            }
            for (int i = 0; i < (lamps - onLights); i++)
            {
                output += colorOff;
            }
            return output;
        }
    }
}
