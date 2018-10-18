using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOlympus
{
    public class NetworkResult
    {
        private float _Error;
        private float[] _Results;
        public float[] RESULTS { get { return _Results; } }
        public float ERROR { get { return _Error; } }
        public NetworkResult(float Error, float[] Results)
        {
            _Error = Error;
            _Results = Results;
        }
    }
}
