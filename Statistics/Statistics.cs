using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistics
{
    public class StatsComputer
    {
        public double Max{get;set;}
        public double Min{get;set;}
        public double Average{get;set;}
        
        public Tuple<double,double,double> CalculateStatistics(List<double> numbers) 
        {
            Tuple<double,double,double> stats_data;
            if(numbers.Count==0)
            {
                Min=double.NaN;
                Max=double.NaN;
                Average=double.NaN;
            }
            else
            {                
                Min=numbers.Min();
                Max=numbers.Max();                                
                Average=Convert.ToDouble(numbers.Average());
            }
            stats_data= new Tuple<double,double,double>(Min,Max,Average);
            return stats_data;
        }
    }
    public interface IAlerter
    {
        bool EmailSent{get;set;}
        bool LEDGlows{get;set;}
    }
    public class EmailAlert:IAlerter
    {
        bool emailSent;
        public bool EmailSent
        {
            get =>emailSent;
            set => emailSent=value;
        }
        public bool LEDGlows
        {
            get;
            set;
        }        
    }
    public class LEDAlert:IAlerter
    {
        bool ledGlows;
        public bool EmailSent
        {
            get;
            set;
        }
        public bool LEDGlows
        {
             get =>ledGlows;
            set => ledGlows=value;   
        }
    }
    public class StatsAlerter
    {
        readonly float max_threshold;
        float max_output;
        EmailAlert ealt;
        LEDAlert ledalt;
        
        public StatsAlerter(float max_data, IAlerter[] ialt)
        {
            max_threshold=max_data;
            ealt=(EmailAlert)ialt[0];
            ledalt=(LEDAlert)ialt[1];
        }
        public void checkAndAlert(List<float> data)
        {
           
            max_output=data.Max();
            if(max_output>max_threshold)
            {
                ealt.EmailSent=true;
                ledalt.LEDGlows=true;
            }
            else
            {
                ealt.EmailSent=false;
                ledalt.LEDGlows=false;
            }                        
        }
        
    }
}
