using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BowlingExercise.Models
{
    public static class BowlingScoreSamples
    {
        public static BowlingScore GetDefaultBowlingScore(int i) => new BowlingScore()
        {
            FrameNumber = (i + 1).ToString(),
            FrameScore = "0",
            HasShot3 = (i == 9),
            Shot1Text = lstPerfectScores[i].Item1,
            Shot2Text = lstPerfectScores[i].Item2,
            Shot3Text = lstPerfectScores[i].Item3
        };

        public static List<(string, string, string)> lstSampleScores = new List<(string, string, string)>()
        {
            ("8","/","-"),
            ("5","4","-"),
            ("9","-","-"),
            ("X","-","-"),
            ("X","-","-"),
            ("5","/","-"),
            ("5","3","-"),
            ("6","3","-"),
            ("9","/","-"),
            ("9","/","X"),
        };

        public static List<(string, string, string)> lstPerfectScores = new List<(string, string, string)>()
        {
            ("X","-","-"),
            ("X","-","-"),
            ("X","-","-"),
            ("X","-","-"),
            ("X","-","-"),
            ("X","-","-"),
            ("X","-","-"),
            ("X","-","-"),
            ("X","-","-"),
            ("X","X","X")
        };
    }
}
