using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class PrincessPage : ContentPage
    {
        async void HandleDoneClicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();

        }

        public PrincessPage()
        {
            InitializeComponent();
        }
    }
}
