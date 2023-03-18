using System;
using LogicaInundaciones;

namespace MonitoreoInundaciones
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Programa para evaluar el riesgo de inundaciones en diferentes zonas");

            int cantidadZonas = 0;
            bool cantidadZonasCorrecta = false;

            do
            {
                try
                {
                    Console.Write("\nIngrese la cantidad de zonas: \n");
                    cantidadZonas = int.Parse(Console.ReadLine()!);

                    if (cantidadZonas <= 0)
                        Console.WriteLine("El dato ingresado debe ser entero positivo. Intenta nuevamente.");
                    else
                        cantidadZonasCorrecta = true;
                }
                catch (FormatException elError)
                {
                    Console.WriteLine("El dato ingresado no representa una cantidad. Intenta nuevamente.");
                    Console.WriteLine(elError.Message);
                }
            }
            while (cantidadZonasCorrecta == false);

            Monitoreador misTerr = new Monitoreador(cantidadZonas);
            Console.WriteLine(misTerr.ToString());
        }
    }
}