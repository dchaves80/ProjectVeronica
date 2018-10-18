using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOlympus
{



    public class Layer
    {
        private bool Calculated = false;
        private int _PerceptronQuantity;
        private LayerType _TypeOfLayer;
        private Network _OwnerNetwork;
        public enum LayerType { Input, Hidden, Output }
        private List<Perceptron> PerceptronList = new List<Perceptron>();

        public LayerType LAYERTYPE { get { return _TypeOfLayer; } }

        public Layer(int PerceptronQuantity, LayerType TypeOfLayer,Network OwnerNetwork)
        {
            _PerceptronQuantity = PerceptronQuantity;
            _TypeOfLayer = TypeOfLayer;
            _OwnerNetwork = OwnerNetwork;
            Init();
        }

        private void Init()
        {
            for (int a = 0; a < _PerceptronQuantity; a++)
            {
                PerceptronList.Add(new Perceptron(this));
            }
        }
    }
}
