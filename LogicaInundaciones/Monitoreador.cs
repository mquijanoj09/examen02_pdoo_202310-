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

        public string ObtienePocentajeZonasPorTipo()
        {
            double porcentajeUrbana = 0;
            double porcentajeRural = 0;
            int totalZonasRiesgo = 0;

            foreach (Territorios unaZona in losTerritorios)
            {
                if (unaZona.GetEstaEnRiesgo())
                {
                    totalZonasRiesgo++;
                    if (unaZona.GetTipoZona() == "Urbana")
                        porcentajeUrbana++;

                    else
                        porcentajeRural++;
                }
            }
            return $"Del total de zonas en riesgo: {totalZonasRiesgo}, hay un {((porcentajeRural / totalZonasRiesgo) * 100)}% de zonas Rurales " +
                $"y hay un {((porcentajeUrbana / totalZonasRiesgo) * 100)}% Urbanas";
        }

        public string ObtienePocentajeRiesgosPorTipo()
        {
            double porcentajeFluvial = 0;
            double porcentajeCostera = 0;
            double porcentajeUrbana = 0;
            int totalZonasRiesgo = 0;

            foreach (Territorios unaZona in losTerritorios)
            {
                if (unaZona.GetEstaEnRiesgo())
                {
                    totalZonasRiesgo++;
                    if (unaZona.GetTipoInundacion() == "Fluvial")
                        porcentajeFluvial++;
                    else if (unaZona.GetTipoInundacion() == "Costera")
                        porcentajeCostera++;
                    else
                        porcentajeUrbana++;
                }
            }
            return $"Del total de zonas en riesgo: {totalZonasRiesgo}, hay un {((porcentajeFluvial / totalZonasRiesgo) * 100)}% de riesgo por inundacion fluvial, " +
                $"un {((porcentajeCostera / totalZonasRiesgo) * 100)}% de riesgo por inundacion costera " +
                $"y hay un {((porcentajeUrbana / totalZonasRiesgo) * 100)}% de riesgo por inundacion urbana";
        }
    }
}

