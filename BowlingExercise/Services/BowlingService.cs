using BowlingExercise.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BowlingExercise.Services
{
    public class BowlingService : IBowlingService
    {

        public BowlingService() { }

        /// <summary>Calculates</summary>
        public ObservableRangeCollection<BowlingScore> CalculateScores(ObservableRangeCollection<BowlingScore> scores)
        {
            for (int i = 0; i < 10; i++)
            {
                if (scores[i].FrameNumber != "10")
                {
                    int first = scores[i].Shot1, second = 0;

                    //Strike: A strike earns 10 points plus the sum of your next two shots.
                    if (scores[i].Shot1 == 20)
                    {
                        var nextTwo = NextTwo(scores, i);
                        first = 10;
                        second = nextTwo.Item1 + nextTwo.Item2;
                    }
                    //Spare: A spare earns 10 points plus the sum of your next one shot.
                    else if (scores[i].Shot2 == 10)
                    {
                        var nextOne = NextOne(scores, i);
                        first = 10;
                        second = nextOne;
                    }
                    //An open frame only earns the number of pins knocked down.
                    else
                        second = scores[i].Shot2;

                    //Append to end
                    int prev = (i > 0) ? Convert.ToInt32(scores[i - 1].FrameScore) : 0;
                    scores[i].FrameScore = (prev + first + second).ToString();
                }
                else
                {
                    //Your score in Frame 10 is the total number of pins knocked down
                    int num1=0, num2 = 0, num3 = 0;

                    //Spare
                    if (scores[i].Shot2 == 10)
                    {
                        num1 = 0;
                        num2 = 10;
                    }

                    //Strikes to 10s
                    if (scores[i].Shot1 == 20)
                        num1 = 10;
                    if (scores[i].Shot2 == 20)
                        num2 = 10;
                    if (scores[i].Shot3 == 20)
                        num3 = 10;

                    scores[i].FrameScore = (Convert.ToInt32(scores[i - 1].FrameScore) + num1 + num2 + num3).ToString();
                }

                
            }

            return scores;
        }

        //Only called when there's a strike in frames 1-9
        (int, int) NextTwo(ObservableRangeCollection<BowlingScore> scores, int index)
        {
            //Strike = 10, Spare = the sparing number plus itself
            int num1 = 0, num2 = 0;
            if (scores[index + 1].Shot1 == 20)
            {
                //Two strikes in a row
                num1 = 10;

                //At this point its either 3 strikes in a row, or use the first shot
                //It is impossible to get X X /
                if (index < 8)
                {
                    num2 = (scores[index + 2].Shot1 == 20) ? 10 : scores[index + 2].Shot1;
                }
                else //Use 2nd shot of 10th frame (8+1 = out of bounds)
                {
                    num2 = (scores[index + 1].Shot2 == 20) ? 10 : scores[index + 1].Shot2;
                }
            }
            else if (scores[index + 1].Shot2 == 10)
            {
                //A strike followed by a spare earns 20 points in a frame.
                num1 = 0;
                num2 = 10;
            }
            else
            {
                //Open frame
                num1 = scores[index + 1].Shot1;
                num2 = scores[index + 1].Shot2;
            }

            return (num1, num2);
        }

        int NextOne(ObservableRangeCollection<BowlingScore> scores, int index)
        {
            //A spare followed by a strike earns 20 points in a frame
            //if (scores[index + 1].Shot1 == 20)
            //    return 10;
            //else
            //    return scores[index + 1].Shot1;

            return (scores[index + 1].Shot1 == 20) ? 10 : scores[index + 1].Shot1; //Shot 1 can never be 10
        }
    }
}
