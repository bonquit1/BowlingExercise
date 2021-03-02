using BowlingExercise.IoC;
using BowlingExercise.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BowlingExercise
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var viewModel = AppContainer.Resolve<MainPageViewModel>(new Autofac.NamedParameter("page", this));
            BindingContext = viewModel;
        }
    }
}
