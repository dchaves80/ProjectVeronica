using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOlympus
{
    public static class RandomClass
    {
        public static Random R = new Random(DateTime.Now.Millisecond);
        public static int GetLastMillisecond()
        {
            string millsstr = DateTime.Now.Millisecond.ToString();
            string lastchar = millsstr[millsstr.Length - 1].ToString();
            return int.Parse(lastchar);
        }
    }
}
