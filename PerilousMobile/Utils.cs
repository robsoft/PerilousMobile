using System;
namespace PerilousMobile
{

    public static class Utils
    {
        public static Random rnd = new Random();

        public static string StripForDisplay(string text)
        {
          return text.Replace("_", "-");
        
        }
    }

}
