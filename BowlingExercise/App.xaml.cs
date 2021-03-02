using BowlingExercise.IoC;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BowlingExercise
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppContainer.RegisterDependencies();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
