using NeuralOlympus;
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
            NeuralOlympus.Network N = new NeuralOlympus.Network(3,5,6,1,true,false,NeuralOlympus.Network.Activator.TAN,NeuralOlympus.Network.EjecutionMode.SYNC);
            float error = 100f;
            while (error>0.1f || error <0.1f)
            {
                Random R = new Random(DateTime.Now.Millisecond);
                int product1 = R.Next(-3, 3);
                int product2 = R.Next(-3, 3);
                if (product1 == 0) product1 = 1;
                if (product2 == 0) product2 = 1;
                int expected = product1 * product2;
                float[] inputs = { product1,product2, error };
                N.SetInputs(inputs);
                NetworkResult NR =  N.Calculate(new float[] { expected });
                error = NR.ERROR;
                N.AdjustNetwork((int)error);
                Console.WriteLine("Operacion:" + product1 + "*"  + product2 + "=" + expected +  " Resultado: " + NR.RESULTS[0] +  " Error:" + NR.ERROR);
            }
            Console.ReadKey();
        }
    }
}
