using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOlympus
{
    public class Synapse
    {
        private Perceptron _BeginningPerceptron;
        private Perceptron _FinalPerceptron;
        
        private float Weight;

        public float WEIGHT { get { return Weight; } }

        public Synapse(Network OwnerNetwork, Perceptron BeginningPerceptron, Perceptron FinalPerceptron)
        {
            _BeginningPerceptron = BeginningPerceptron;
            _FinalPerceptron = FinalPerceptron;
        }
        private void Init()
        {
            Random R = new Random(DateTime.Now.Millisecond);
            Weight = R.Next(-100,100) / 100f;
        }
    }
}
