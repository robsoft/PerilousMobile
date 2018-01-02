using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PerilousMobile

{
    public partial class SelectionPage : ContentPage
    {
        private MaleKinds maleKindOpt;
        private MaleDescriptions maleDescOpt;
        private FemaleKinds femaleKindOpt;
        private FemaleDescriptions femaleDescOpt;
        private FrogKinds frogKindOpt;
        private FrogDescriptions frogDescOpt;

        private MaleKinds maleKindQuest;
        private MaleDescriptions maleDescQuest;
        private FemaleKinds femaleKindQuest;
        private FemaleDescriptions femaleDescQuest;
        private FrogKinds frogKindQuest;
        private FrogDescriptions frogDescQuest;

        public SelectionPage()
        {
            InitializeComponent();
            CreateQuest();
            UpdateGameDetails();
        }
        void HandleOptClicked(object sender, System.EventArgs e)
        {
            imgOpt1.IsVisible = false;
            imgOpt2.IsVisible = false;
            imgOpt3.IsVisible = false;

            if (sender == lblOpt1) { imgOpt1.IsVisible = true; }
            else
                if (sender == lblOpt2) { imgOpt2.IsVisible = true; }
            else
                if (sender == lblOpt3) { imgOpt3.IsVisible = true; }

        }


        void HandleQuestClicked(object sender, System.EventArgs e)
        {
            imgQuest1.IsVisible = false;
            imgQuest2.IsVisible = false;
            imgQuest3.IsVisible = false;
            imgQuest4.IsVisible = false;
            imgQuest5.IsVisible = false;
            if (sender == lblQuest1) { imgQuest1.IsVisible = true; }
            else
                if (sender == lblQuest2) { imgQuest2.IsVisible = true; }
            else
                if (sender == lblQuest3) { imgQuest3.IsVisible = true; }
            else
                if (sender == lblQuest4) { imgQuest4.IsVisible = true; }
            else
                if (sender == lblQuest5) { imgQuest5.IsVisible = true; }

        }


        async void HandleStartClicked(object sender, System.EventArgs e)
        {
            App.game.Reset();
            // put in our choices here
            App.game.PrepareToStart();
            App.game.currentState = GameState.isReadyToStart;
            await Navigation.PopModalAsync();

        }
        async void HandleCancelClicked(object sender, System.EventArgs e)
        {
            App.game.currentState = GameState.isOver;
            await Navigation.PopModalAsync();
        }

        void HandleRegenerateClicked(object sender, System.EventArgs e)
        {
            //App.game.Reset();
            CreateQuest();
            UpdateGameDetails();
        }

        void UpdateGameDetails()
        {
            // fill in the on-screen labels etc

            lblOpt1.Text = Utils.StripForDisplay(maleDescOpt.ToString() + " " + maleKindOpt.ToString());
            lblOpt2.Text = Utils.StripForDisplay(femaleDescOpt.ToString() + " " + femaleKindOpt.ToString());
            lblOpt3.Text = Utils.StripForDisplay(frogDescOpt.ToString() + " " + frogKindOpt.ToString());

            lblQuest1.Text = Utils.StripForDisplay(femaleDescQuest.ToString() + " " + femaleKindQuest.ToString());
            lblQuest2.Text = Utils.StripForDisplay(maleDescQuest.ToString() + " " + maleKindQuest.ToString());
            lblQuest3.Text = Utils.StripForDisplay(frogDescQuest.ToString() + " " + frogKindQuest.ToString());

            HandleOptClicked(lblOpt1, null);
            HandleQuestClicked(lblQuest1, null);
        }

        void CreateQuest()
        {
            Array values = Enum.GetValues(typeof(MaleKinds));
            maleKindOpt = (MaleKinds)values.GetValue(Utils.rnd.Next(values.Length));
            maleKindQuest = (MaleKinds)values.GetValue(Utils.rnd.Next(values.Length));

            values = Enum.GetValues(typeof(MaleDescriptions));
            maleDescOpt = (MaleDescriptions)values.GetValue(Utils.rnd.Next(values.Length));
            maleDescQuest = (MaleDescriptions)values.GetValue(Utils.rnd.Next(values.Length));

            values = Enum.GetValues(typeof(FemaleKinds));
            femaleKindOpt = (FemaleKinds)values.GetValue(Utils.rnd.Next(values.Length));
            femaleKindQuest = (FemaleKinds)values.GetValue(Utils.rnd.Next(values.Length));

            values = Enum.GetValues(typeof(FemaleDescriptions));
            femaleDescOpt = (FemaleDescriptions)values.GetValue(Utils.rnd.Next(values.Length));
            femaleDescQuest = (FemaleDescriptions)values.GetValue(Utils.rnd.Next(values.Length));

            values = Enum.GetValues(typeof(FrogKinds));
            frogKindOpt = (FrogKinds)values.GetValue(Utils.rnd.Next(values.Length));
            frogKindQuest = (FrogKinds)values.GetValue(Utils.rnd.Next(values.Length));

            values = Enum.GetValues(typeof(FrogDescriptions));
            frogDescOpt = (FrogDescriptions)values.GetValue(Utils.rnd.Next(values.Length));
            frogDescQuest = (FrogDescriptions)values.GetValue(Utils.rnd.Next(values.Length));


        }

    }
}
