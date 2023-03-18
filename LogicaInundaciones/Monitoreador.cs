using System;

namespace LogicaInundaciones
{
    public class Monitoreador
    {
        private Territorios[] losTerritorios;
        private int cantidadZonas;

        public Monitoreador(int cantidadZonas)
        {
            this.cantidadZonas = cantidadZonas;
            losTerritorios = new Territorios[cantidadZonas];

            //Aqui se inicializa el arreglo de las Zonas
            InicializaLasZonas();
        }

        private void InicializaLasZonas()
        {
            Random aleatorio = new Random();
            int nivelDelMar, areas, totalHabitantes, distanciaRiosPrinciles;

            for (int i = 0; i < losTerritorios.Length; i++)
            {
                nivelDelMar = aleatorio.Next(0, 3000);
                areas = aleatorio.Next(1, 50);
                totalHabitantes = aleatorio.Next(1000, 1000000);
                distanciaRiosPrinciles = aleatorio.Next(0, 2000);
                losTerritorios[i] = new Territorios(nivelDelMar, areas, totalHabitantes, distanciaRiosPrinciles);
            }
        }

        public string VisualizaContenidoZonas()
        {
            string resultado = "";

            foreach (Territorios Zona in losTerritorios)
                resultado = resultado+Zona.ToString()+ "\n";

            return resultado;
        }
    }
}

