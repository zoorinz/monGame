using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonGame.Monster.Stats
{
    public struct StatValues
    {
        public int minVal;
        public int maxVal;
        public double baseRatio;

        public StatValues(int minVal, int maxVal, double baseRatio)
        {
            this.minVal = minVal;
            this.maxVal = maxVal;
            this.baseRatio = baseRatio;
        }
    }

    public class Stat : IStat
    {
        private StatValues _attack;
        private StatValues _defence;
        private StatValues _speed;
        private static Random RND;

        public Stat(StatValues attack, StatValues defence, StatValues speed, int seed)
        {
            this._attack = attack;
            this._defence = defence;
            this._speed = speed;

            if (RND == null)
                RND = new Random(seed);

            InitStats(seed);
        }

        private void InitStats(int seed)
        {

            //Random rnd = new Random(seed);
            this.Attack = RandomStatBetweenTwoNumber(this._attack.minVal, this._attack.maxVal);
            this.Defence = RandomStatBetweenTwoNumber(this._defence.minVal, this._defence.maxVal);
            this.Speed = RandomStatBetweenTwoNumber(this._speed.minVal, this._speed.maxVal);
        }

        private int RandomStatBetweenTwoNumber(int min, int max)
        {
            int rndValue = RND.Next(0, 100);
            Console.WriteLine(rndValue);
            List<int> valueInterVal = Enumerable.Range(min, max - min + 1).ToList(); ;

            int start = -20, end = -30;
            
            if (rndValue >= 90) // 10%
            { 
                //80-100 stat distribution
                start = 80;
                end = 100;
            }
            else if (rndValue >= 70)  // 20%
            {
                //50-79 stat distribution
                start = 50;
                end = 79;
            }
            else if (rndValue >= 25) // 45%
            {
                //25-49% stat distribution
                start = 25;
                end = 49;
            }
            else // remaining 25%
            {
                //0-24% stat distribution
                start = 0;
                end = 24;
            }
            return GetProbabilityRandomVal(start, end, min, max, valueInterVal);
        }

        private int GetProbabilityRandomVal(int start, int end, int min, int max, List<int> valueList)
        {
            double fracVal = (max - min + 1) / 100.0;
            int maxVal = ((int)Math.Floor(fracVal * end));
            int minVal = ((int)Math.Floor(fracVal * start));

            minVal = minVal < 1 ? min : valueList[minVal - 1];
            maxVal = maxVal > valueList.Count ? max : valueList[maxVal - 1];

            return RND.Next(minVal, maxVal);
        }

        public double Attack { get; private set; }

        public double Defence { get; private set; }

        public double Speed { get; private set; }

        public void LvlUp()
        {
            this.Attack += this._attack.baseRatio;
            this.Defence += this._defence.baseRatio;
            this.Speed += this._speed.baseRatio;
        }
    }
}
