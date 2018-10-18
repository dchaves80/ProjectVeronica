using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOlympus
{
    public class Neuron:coreclass.NetworkNucleusEntity
    {
        float _Bias;
        float _Result;
        Layer _OwnerLayer;
        Layer.LayerType NeuronType;
        List<Synapse> InputSynapse = new List<Synapse>();
        List<Synapse> OutputSynapse=new List<Synapse>();

        public void SetInputConnection(Synapse S)
        {
            InputSynapse.Add(S);
        }
        public void SetOutputConnection(Synapse S)
        {
            OutputSynapse.Add(S);
        }

        public Neuron(Layer OwnerLayer)
        {
            Random R = new Random(DateTime.Now.Millisecond);
            
            _OwnerLayer = OwnerLayer;
            _Result = 0f;
            _Bias = R.Next(-100, 100) / 100; 
            NeuronType = OwnerLayer.LAYERTYPE;

        }
    }
}
