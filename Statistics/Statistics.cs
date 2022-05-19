using System;
using System.Collections.Generic;

namespace Statistics
{
    public class StatsComputer
    {
        public double Max{get;set;}
        public double Min{get;set;}
        public double Average{get;set;}
        private int total_count;
        private double sum;
        
        public Tuple<double,double,double> CalculateStatistics(List<double?> numbers) 
        {
            if(numbers.Count==0)
            {
                Min=double.NaN;
                Max=double.NaN;
                Average=double.NaN;
            }
            else
            {
                numbers.Sort();
                Min=Convert.ToDouble(numbers[0]);
                Max=Convert.ToDouble(numbers[numbers.Count-1]);
                
                foreach(var count in numbers)
                {
                    sum+=count.Value;
                    ++total_count;
                }
                Average=sum/total_count;
            }
            return Tuple.Create(Min,Max,Average);
        }
    }
}
