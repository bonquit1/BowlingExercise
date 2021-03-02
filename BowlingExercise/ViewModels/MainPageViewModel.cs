
using BowlingExercise.Models;
using BowlingExercise.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BowlingExercise.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Members and Properties
        private int _totalScore;
        public int TotalScore { get => _totalScore; set { SetProperty(ref _totalScore, value); } }

        public ObservableRangeCollection<BowlingScore> BowlingScores { get; set; } = new ObservableRangeCollection<BowlingScore>();
        #endregion

        #region Services
        private readonly IBowlingService _bowlingService;
        #endregion

        #region Commands
        public ICommand CalculateScoresCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        #endregion

        #region Constructors
        public MainPageViewModel(Page page, IBowlingService bowlingService) : base(page)
        {
            _bowlingService = bowlingService;

            BowlingScores = new ObservableRangeCollection<BowlingScore>();
            for (int i = 0; i < 10; i++)
            {
                BowlingScores.Add(BowlingScoreSamples.GetDefaultBowlingScore(i));
            }

            CalculateScoresCommand = new Command(CalculateScores);
            LoadCommand = new Command(OnLoad);

        }
        #endregion

        #region Methods and Functions
        private async void OnLoad()
        {
            //IsBusy = false;
            //if (IsBusy) return; // If currently busy

            IsBusy = true;
            try
            {
                BowlingScores.Clear();

                for (int i = 0; i < 10; i++)
                {
                    BowlingScores.Add(BowlingScoreSamples.GetDefaultBowlingScore(i));
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void CalculateScores()
        {
            BowlingScores = _bowlingService.CalculateScores(BowlingScores);
            TotalScore = Convert.ToInt32(BowlingScores.Select(x => x.FrameScore).Where(x => x != "-").LastOrDefault());
        }

        
        #endregion
    }
}
