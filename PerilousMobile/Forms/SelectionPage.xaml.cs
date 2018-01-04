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
        private GeneralQuests generalQuest;
        private RandomQuests randomQuest;

        private int quest = 0;
        private int opt = 0;

        public SelectionPage()
        {
            InitializeComponent();
            CreateQuest();
            UpdateGameDetails();

            imgOpt1.GestureRecognizers.Add(new TapGestureRecognizer { 
                Command = new Command(() => HandleOptClicked(imgOpt1, null)), });
            imgOpt2.GestureRecognizers.Add(new TapGestureRecognizer { 
                Command = new Command(() => HandleOptClicked(imgOpt2, null)), });
            imgOpt3.GestureRecognizers.Add(new TapGestureRecognizer { 
                Command = new Command(() => HandleOptClicked(imgOpt3, null)), });

            imgQuest1.GestureRecognizers.Add(new TapGestureRecognizer { 
                Command = new Command(() => HandleQuestClicked(imgQuest1, null)), });
            imgQuest2.GestureRecognizers.Add(new TapGestureRecognizer { 
                Command = new Command(() => HandleQuestClicked(imgQuest2, null)), });
            imgQuest3.GestureRecognizers.Add(new TapGestureRecognizer { 
                Command = new Command(() => HandleQuestClicked(imgQuest3, null)), });
            imgQuest4.GestureRecognizers.Add(new TapGestureRecognizer { 
                Command = new Command(() => HandleQuestClicked(imgQuest4, null)), });
            imgQuest5.GestureRecognizers.Add(new TapGestureRecognizer { 
                Command = new Command(() => HandleQuestClicked(imgQuest5, null)), });

        }
        void HandleOptClicked(object sender, System.EventArgs e)
        {
            
            imgOpt1.Text = UserControls.Icon.FASquare;
            imgOpt2.Text = UserControls.Icon.FASquare;
            imgOpt3.Text = UserControls.Icon.FASquare;

            if ((sender == lblOpt1) || (sender == imgOpt1))
            { 
                imgOpt1.Text = UserControls.Icon.FACheckSquare; 
                opt = 1; 
            }
            else if ((sender == lblOpt2) || (sender == imgOpt2))
            { 
                imgOpt2.Text = UserControls.Icon.FACheckSquare; 
                opt = 2; 
            }
            else if ((sender == lblOpt3) || (sender == imgOpt3))
            {
                imgOpt3.Text = UserControls.Icon.FACheckSquare; 
                opt = 3; 
            }
        }


        void HandleQuestClicked(object sender, System.EventArgs e)
        {
            imgQuest1.Text = UserControls.Icon.FASquare;
            imgQuest2.Text = UserControls.Icon.FASquare;
            imgQuest3.Text = UserControls.Icon.FASquare;
            imgQuest4.Text = UserControls.Icon.FASquare;
            imgQuest5.Text = UserControls.Icon.FASquare;

            if ((sender == lblQuest1) || (sender == imgQuest1))
            {
                imgQuest1.Text = UserControls.Icon.FACheckSquare;
                quest = 1;
            }
            else if ((sender == lblQuest2) || (sender == imgQuest2))
            {
                imgQuest2.Text = UserControls.Icon.FACheckSquare;
                quest = 2;
            }
            else if ((sender == lblQuest3) || (sender == imgQuest3))
            {
                imgQuest3.Text = UserControls.Icon.FACheckSquare;
                quest = 3;
            }
            else if ((sender == lblQuest4) || (sender == imgQuest4))
            {
                imgQuest4.Text = UserControls.Icon.FACheckSquare;
                quest = 4;
            }
            else if ((sender == lblQuest5) || (sender == imgQuest5))
            {
                imgQuest5.Text = UserControls.Icon.FACheckSquare;
                quest = 5;
            }

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

            lblQuest4.Text = Utils.StripForDisplay(generalQuest.ToString());
            lblQuest5.Text = Utils.StripForDisplay(randomQuest.ToString());

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

            values = Enum.GetValues(typeof(GeneralQuests));
            generalQuest = (GeneralQuests)values.GetValue(Utils.rnd.Next(values.Length));
            values = Enum.GetValues(typeof(RandomQuests));
            randomQuest = (RandomQuests)values.GetValue(Utils.rnd.Next(values.Length));
        }

    }
}
