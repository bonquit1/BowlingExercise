using BowlingExercise.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BowlingExercise.Services
{
    public interface IBowlingService
    {
        ObservableRangeCollection<BowlingScore> CalculateScores(ObservableRangeCollection<BowlingScore> scores);
    }
}
