using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class AboutPage : ContentPage
    {

        async void OnCloseClickedHandler (object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
            //await Navigation.PushAsync (new AboutPage ());
        }


        public AboutPage()
        {
            InitializeComponent();
        }
    }
}
