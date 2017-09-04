using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile
{
    public partial class AboutPage : ContentPage
    {

        public AboutPage()
        {
            InitializeComponent();

            lblVersion.Text = "Version 0.2";
        }
    }
}
