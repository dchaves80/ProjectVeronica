using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOlympus
{



    public class Layer: coreclass.NetworkNucleusEntity
    {
        private bool Calculated = false;
        private int _NeuronQuantity;
        private LayerType _TypeOfLayer;
        private Network _OwnerNetwork;
        public enum LayerType { Input, Hidden, Output }
        private List<Neuron> NeuronList = new List<Neuron>();

        public LayerType LAYERTYPE { get { return _TypeOfLayer; } }
        public List<Neuron> NEURONS { get { return NeuronList; } }

        public Layer(int NeuronQuantity, LayerType TypeOfLayer,Network OwnerNetwork)
        {
            _NeuronQuantity = NeuronQuantity;
            _TypeOfLayer = TypeOfLayer;
            _OwnerNetwork = OwnerNetwork;
            Init();
        }

        private void Init()
        {
            for (int a = 0; a < _NeuronQuantity; a++)
            {
                NeuronList.Add(new Neuron(this));
            }
        }
    }
}
