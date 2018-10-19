using NeuralOlympus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando Red Neuronal");
            NeuralOlympus.Network N = new NeuralOlympus.Network(2,20,20,1,true,false,NeuralOlympus.Network.Activator.TAN,NeuralOlympus.Network.EjecutionMode.SYNC);
            float error = 100f;
            ConsoleKeyInfo Salir = new ConsoleKeyInfo('C', ConsoleKey.C, false, false, false);
            ConsoleKeyInfo ActualKey=new ConsoleKeyInfo();
            while (ActualKey.Key != ConsoleKey.C) {
                while (true)
                {
                    float product1 = 0;
                    float product2 = 0;
                    while (product1 * product2 == 0) {
                        try {
                            product1 = RandomClass.R.Next(-DateTime.Now.Second + RandomClass.GetLastMillisecond(), DateTime.Now.Second + RandomClass.GetLastMillisecond());
                            product2 = RandomClass.R.Next(-DateTime.Now.Second + RandomClass.GetLastMillisecond(), DateTime.Now.Second + RandomClass.GetLastMillisecond());
                            if (product1 == 0 || product2 == 0)
                            {
                                product1 = RandomClass.R.Next(1, 20);
                                product2 = RandomClass.R.Next(1, 20);
                            }
                        }
                        catch (Exception E)
                        {
                            product1 = 2f;
                            product2 = 3f;
                        }
                    }

                    


                    float expected = product1 * product2;
                    float[] inputs = { product1, product2 };
                    N.SetInputs(inputs);
                    NetworkResult NR = N.Calculate(new float[] { expected });
                    error = NR.ERROR;
                    Console.WriteLine("Operacion:" + product1 + "*" + product2 + "=" + expected + " Resultado: " + NR.RESULTS[0] + " Error:" + NR.ERROR);
                    if (error > -0.01f && error < 0.01f)
                    {
                        break;
                    }
                    N.AdjustNetwork(((int)error * (int)error)/2f);



                }
                float[] inputs2 = { 2, 2 };
                N.SetInputs(inputs2);
                NetworkResult NR2 = N.Calculate(new float[] { 4 });
                Console.WriteLine("Se espera 4:" + " Resultado: " + NR2.RESULTS[0] + " Error:" + NR2.ERROR);
                float[] inputs3 = { 9, 9 };
                N.SetInputs(inputs3);
                NR2 = N.Calculate(new float[] { 81 });
                Console.WriteLine("Se espera 81:" + " Resultado: " + NR2.RESULTS[0] + " Error:" + NR2.ERROR);
                Thread.Sleep(2000);
                if (NR2.ERROR == 0.1f) { 
                ActualKey = Console.ReadKey();
                }
            }
            
            
        }
    }
}
