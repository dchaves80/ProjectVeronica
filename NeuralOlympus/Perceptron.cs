using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOlympus
{
    public class Perceptron
    {
        float _Bias;
        float _Result;
        Layer _OwnerLayer;
        Layer.LayerType NeuronType;
        Synapse InputSynapse;
        Synapse OutputSynapse;

        public void SetInputConnection(Synapse S)
        {
            InputSynapse = S;
        }
        public void SetOutputConnection(Synapse S)
        {
            OutputSynapse = S;
        }

        public Perceptron(Layer OwnerLayer)
        {
            Random R = new Random(DateTime.Now.Millisecond);
            
            _OwnerLayer = OwnerLayer;
            _Result = 0f;
            _Bias = R.Next(-100, 100) / 100; 
            NeuronType = OwnerLayer.LAYERTYPE;

        }
    }
}
