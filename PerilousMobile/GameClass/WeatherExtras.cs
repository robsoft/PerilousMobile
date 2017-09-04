using System;
namespace PerilousMobile
{
    public partial class Game
    {


		//private const int weatherInitialCount = 2;
		//private const int weatherUpdateFrequency = 2;
		//private WeatherContent[,] weather = new WeatherContent[xDim, yDim];
		//private int windXDirection = 0;
		//private int windYDirection = 0;


		/*
		public string WeatherDecodeText(WeatherContent content)
		{
			switch (content)
			{
				case WeatherContent.Fog: return "%";
				default:
					{
						return " ";
					}
			}
		}
        */

		/*
        public string GetWindText()
        {
            string wind = "";
            if (windYDirection < 0) { wind = wind + "N"; }
            else
                if (windYDirection > 0) { wind = wind + "S"; }

            if (windXDirection < 0) { wind = wind + "W"; }
            else
                if (windXDirection > 0) { wind = wind + "E"; }
            if (wind == "")
            { return "Calm"; }
            else
                return wind;
        }
        */

		/*
 #region Weather Stuff

 public void PopulateWeather()
 {
	 // clear skies everywhere to begin with
	 for (int i = 0; i < xDim; i++)
	 {
		 for (int j = 0; j < yDim; j++)
		 {
			 weather[i, j] = WeatherContent.ClearSky;
		 }
	 }

	 // fog
	 for (int i = 1; i < weatherInitialCount; i++)
	 {
		 int x = rnd.Next(0, xDim);
		 int y = rnd.Next(0, yDim);
		 int height = rnd.Next(3, 7);    //todo magic numbers!
		 int width = rnd.Next(3, 7);
		 for (int wx = x - width; wx < x + width; wx++)
		 {
			 for (int wy = y - height; wy < y + height; wy++)
			 {
				 // if this position is legal, make it foggy
				 if (CoordInRange(wx, wy))
				 {
					 // 1 in 8 chance of undoing it around edges
					 if (rnd.Next(1, 9) != 8) //todo more magic numbers!
						 weather[wx, wy] = WeatherContent.Fog;
				 }
			 }
		 }

	 }

	 ResetWind();

 }

 public void ResetWind()
 {
	 windXDirection = rnd.Next(-1, 2);
	 windYDirection = rnd.Next(-1, 2);
 }


 public void UpdateWeather()
 {
	 if (moveCount % weatherUpdateFrequency != 0)
	 {
		 return;
	 }

	 int weatherInView = 0;
	 for (int x = 0; x < xDim; x++)
	 {
		 for (int y = 0; y < yDim; y++)
		 {
			 int wx = x + windXDirection;
			 int wy = y + windYDirection;

			 // if this position is legal, move it
			 if (CoordInRange(wx, wy))
			 {
				 // 1 in 8 chance of undoing it around edges
				 //if (rnd.Next(1, 9) != 8) //todo more magic numbers!
				 {
					 weather[wx, wy] = weather[x, y];
					 if (weather[x, y] != WeatherContent.ClearSky)
						 weatherInView++;
					 weather[x, y] = WeatherContent.ClearSky;
				 }
			 }
		 }
	 }

	 // small chance wind directions might change
	 if (rnd.Next(1, 7) == 8)// todo magic numbers again!
		 ResetWind();

	 // crude for now, if we have too little weather in view, add some
	 if (weatherInView < ((int)(xDim * yDim) / 25))
		 PopulateWeather(); // need to bring it in from opposite direction of winds etc


 }
 #endregion
 */

	}
}
