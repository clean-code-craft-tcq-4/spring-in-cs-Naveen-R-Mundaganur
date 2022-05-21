using System;
using Xunit;
using Statistics;
using System.Collections.Generic;

namespace Statistics.Test
{
    public class StatsUnitTest
    {
        [Fact]
        public void ReportsAverageMinMax()
        {
            float epsilon = 0.001F;
            StatsComputer statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(
                new List<double>{1.5, 8.9, 3.2, 4.5});
            
            Assert.True(Math.Abs(statsComputer.Average - 4.525) <= epsilon);
            Assert.True(Math.Abs(statsComputer.Max - 8.9) <= epsilon);
            Assert.True(Math.Abs(statsComputer.Min - 1.5) <= epsilon);
        }
        [Fact]
        public void ReportsNaNForEmptyInput()
        {
            StatsComputer statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(
                new List<double>{});
            Assert.True(Double.IsNaN(statsComputer.Max));
            Assert.True(Double.IsNaN(statsComputer.Min));
            Assert.True(Double.IsNaN(statsComputer.Average));
            //All fields of computedStats (average, max, min) must be
            //Double.NaN (not-a-number), as described in
            //https://docs.microsoft.com/en-us/dotnet/api/system.double.nan?view=netcore-3.1
        }
        [Fact]
        public void RaisesAlertsIfMaxIsMoreThanThreshold()
        {
            const float maxThreshold = 10.2f;
            EmailAlert emailAlert = new EmailAlert();
            LEDAlert ledAlert = new LEDAlert();
            IAlerter[] alerters = {emailAlert, ledAlert};
            
            StatsAlerter statsAlerter = new StatsAlerter(maxThreshold, alerters);
            statsAlerter.checkAndAlert(new List<float>{0.2f, 11.9f, 4.3f, 8.5f});

            Assert.True(emailAlert.EmailSent);
            Assert.True(ledAlert.LEDGlows);
        }
    }
}
