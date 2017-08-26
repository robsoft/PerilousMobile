using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class TestPage : ContentPage
    {


		private void PopulateMap()
		{
            lblMap.Text = App.game.GetMapAsText();
		}

        public TestPage()
        {
            InitializeComponent();
            PopulateMap();
        }
    }
}
