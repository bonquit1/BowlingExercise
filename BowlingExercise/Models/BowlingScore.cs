using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BowlingExercise.Models
{
    public class BowlingScore : ObservableObject
    {
        private string _shot1Text;
        private string _shot2Text;
        private string _shot3Text;

        public string FrameNumber { get; set; }

        public int Shot1 { get; set; }
        public int Shot2 { get; set; }
        public int Shot3 { get; set; }

        public bool HasShot3 { get; set; }

        public string Shot1Text
        {
            get => _shot1Text;
            set 
            {
                SetProperty(ref _shot1Text, value);

                int num = 0;
                if (int.TryParse(value, out num))
                    Shot1 = Convert.ToInt32(value);
                else if (value == "/")
                    Shot1 = 10;
                else if (value.ToLower() == "x")
                    Shot1 = 20;
                else
                    Shot2 = 0; // i.e. "-"
            }
        }

        public string Shot2Text
        {
            get => _shot2Text;
            set
            {
                SetProperty(ref _shot2Text, value);

                int num = 0;
                if (int.TryParse(value, out num))
                    Shot2 = Convert.ToInt32(value);
                else if (value == "/")
                    Shot2 = 10;
                else if (value.ToLower() == "x")
                    Shot2 = 20;
                else
                    Shot2 = 0; // i.e. "-"
            }
        }

        public string Shot3Text
        {
            get => _shot3Text;
            set
            {
                SetProperty(ref _shot3Text, value);

                int num = 0;
                if (int.TryParse(value, out num))
                    Shot3 = Convert.ToInt32(value);
                else if (value == "/")
                    Shot3 = 10;
                else if (value.ToLower() == "x")
                    Shot3 = 20;
                else
                    Shot3 = 0; // i.e. "-"
            }
        }

        private string _frameScore;
        public string FrameScore { get => _frameScore; set { SetProperty(ref _frameScore, value); } }
    }
}
