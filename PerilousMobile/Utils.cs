using System;
namespace PerilousMobile
{

    public static class Utils
    {
        public static Random rnd = new Random();

        public static string StripForDisplay(string text)
        {
            string raw = text.Replace("=", "-");
            raw = raw.Replace("_", " ");
            return raw;
        
        }
    }

}
