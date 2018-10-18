using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando Red Neuronal");
            NeuralOlympus.Network N = new NeuralOlympus.Network(3,3,4,2,true,false,NeuralOlympus.Network.Activator.RELU,NeuralOlympus.Network.EjecutionMode.SYNC);
            Console.WriteLine(N.GUID);
            Console.ReadKey();
        }
    }
}
