using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class HelpPage : ContentPage
    {
        async void HandleDoneClicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();

        }
        public HelpPage()
        {
            InitializeComponent();
        }
    }
}
