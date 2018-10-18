using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOlympus
{
    public class Synapse
    {
        private Neuron _BeginningNeuron;
        private Neuron _FinalNeuron;
        private float Weight;

        public float WEIGHT { get { return Weight; } }
        public Neuron BEGINNING_NEURON{ get { return _BeginningNeuron; } }
        public Neuron FINAL_NEURON { get { return _FinalNeuron; } }

        public Synapse(Network OwnerNetwork, Neuron BeginningNeuron, Neuron FinalNeuron)
        {
            _BeginningNeuron = BeginningNeuron;
            _FinalNeuron = FinalNeuron;
            Init();
        }
        private void Init()
        {
            Random R = new Random(DateTime.Now.Millisecond);
            Weight = R.Next(-100,100) / 100f;
           _BeginningNeuron.SetOutputConnection(this);
            _FinalNeuron.SetInputConnection(this);
        }
    }
}
