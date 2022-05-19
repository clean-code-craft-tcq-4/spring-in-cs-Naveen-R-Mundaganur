using System;
using System.Collections.Generic;

namespace Statistics
{
    public class StatsComputer
    {
        public double Max{get;set;}
        public double Min{get;set;}
        public double Average{get;set;}
        private int total;
        
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
                    ++total;
                }
                Average=sum/total;
            }
            return Tuple.Create(Min,Max,Average);
        }
    }
}
