using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOlympus.coreclass
{
    public class NetworkNucleusEntity
    {
        private string _GUID = Guid.NewGuid().ToString();
        public string GUID { get { return _GUID; } }
    }
}
