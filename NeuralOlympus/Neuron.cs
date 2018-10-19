using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOlympus
{
    public class Neuron:coreclass.NetworkNucleusEntity
    {
        private float _Bias;
        private float _Result;
        private Layer _OwnerLayer;
        Layer.LayerType NeuronType;
        List<Synapse> InputSynapse = new List<Synapse>();
        List<Synapse> OutputSynapse= new List<Synapse>();

        public float RESULT { get { return _Result; } }

        public void SetInputConnection(Synapse S)
        {
            InputSynapse.Add(S);
        }
        public void SetOutputConnection(Synapse S)
        {
            OutputSynapse.Add(S);
        }



        public void AdjustBias(float Error)
        {
            
            
            int Thershold = 0;
            if (Error < 0)
            {
                Thershold = RandomClass.R.Next((int)Error, (int)Error * -1);
            }
            else
            {
                Thershold = RandomClass.R.Next((int)Error * -1, (int)Error);
            }
            _Bias = _Bias + Thershold*10;
            if (_Bias > 1) _Bias = -1;
            if (_Bias < -1) _Bias = 1;
        }

        public void setInput(float inp)
        {
            if (_OwnerLayer.LAYERTYPE == Layer.LayerType.Input)
            {
                _Result = inp;
            }
        }

        public void CalculateLastLayer()
        {
            float tResult = 0f;
            foreach (Synapse S in InputSynapse)
            {
                tResult += (tResult * S.BEGINNING_NEURON.RESULT)+_Bias;
            }
            _Result = tResult;
        }

        public void Calculate()
        {
            _Result = 0f;
            float tResult = 0f;
            foreach (Synapse S in InputSynapse)
            {
                tResult += S.BEGINNING_NEURON.RESULT * S.WEIGHT;
            }
            tResult += this._Bias;
            float tResultNoActivation = tResult;
            if (_OwnerLayer.NETWORK.ACTIVATION_FUNCTION == Network.Activator.RELU)
            {
                tResult = Math.Max(0, tResult);
            }
            if (_OwnerLayer.NETWORK.ACTIVATION_FUNCTION == Network.Activator.SIG)
            {
                tResult = (2f / (1f + (float)Math.Exp(-2f * tResult))) - 1f;
            }
            if (_OwnerLayer.NETWORK.ACTIVATION_FUNCTION == Network.Activator.TAN)
            {
                tResult = (float)Math.Tanh(tResult);
            }
            if (tResult > 0f) tResult = 1;
            if (tResult < -0f) tResult = -1;
            if (tResult == 1f || tResult==-1f)
            {
                _Result = tResultNoActivation;
            }
            else
            {
                _Result = 0f;
            }
            
            
           

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
