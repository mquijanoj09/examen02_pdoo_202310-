namespace LogicaInundaciones
{
    public class Territorios
    {
        protected int nivelDelMar, areas, totalHabitantes, distanciaRiosPrinciles;
        protected String tipoRiesgo, tipoZona, tipoUbicacion, tipoInundacion;
        protected bool estaEnRiesgo;

        public Territorios()
        {
            nivelDelMar = 0;
            areas = 0;
            totalHabitantes = 0;
            distanciaRiosPrinciles = 0;
            tipoZona = string.Empty;
            tipoUbicacion = string.Empty;
            tipoRiesgo = string.Empty;
            estaEnRiesgo = false;
            tipoInundacion = string.Empty;
        }

        public Territorios(int nivelDelMar, int areas, int totalHabitantes, int distanciaRiosPrinciles)
        {
            this.nivelDelMar = nivelDelMar;
            this.areas = areas;
            this.totalHabitantes = totalHabitantes;
            this.distanciaRiosPrinciles = distanciaRiosPrinciles;
            ObtieneTipoZona(totalHabitantes);
            ObtieneTipoUbicacion(nivelDelMar);
            ObtieneEstaEnRiesgo();
            ObtieneTipoInundacion();
        }

        public void ObtieneTipoZona(int totalHabitantes)
        {
            if (totalHabitantes > 200000)
                tipoZona = "Urbana";
            else
                tipoZona = "Rural";
        }

        public void ObtieneTipoUbicacion(int nivelDelMar)
        {
            if (nivelDelMar > 1000)
                tipoUbicacion = "Montañosa";
            else
                tipoUbicacion = "Costera";
        }

        public void ObtieneEstaEnRiesgo()
        {
            if ((tipoUbicacion == "Costera" && nivelDelMar > 10) ||
                (tipoZona == "Urbana" && (totalHabitantes / areas) > 100) ||
                (tipoUbicacion == "Montañosa" && distanciaRiosPrinciles < 50))
                estaEnRiesgo = true;
            else
                estaEnRiesgo = false;
        }

        public void ObtieneTipoInundacion()
        {
            Random aleatorio = new Random();
            string[] tiposInundaciones = { "Fluvial", "Urbana", "Costera" };
            if (tipoUbicacion == "Costera")
                tipoInundacion = tiposInundaciones[aleatorio.Next(0, 3)];
            else if (tipoUbicacion == "Montañosa")
                tipoInundacion = tiposInundaciones[aleatorio.Next(0, 2)];

        }

        public int GetNivelDelMar()
        {
            return nivelDelMar;
        }

        public void SetNivelDelMar(int nivelDelMar)
        {
            this.nivelDelMar = nivelDelMar;
        }

        public int GetAreas()
        {
            return areas;
        }

        public void SetAreas(int areas)
        {
            this.areas = areas;
        }

        public int GetTotalHabitantes()
        {
            return totalHabitantes;
        }

        public void SetTotalHabitantes(int totalHabitantes)
        {
            this.totalHabitantes = totalHabitantes;
        }

        public int GetDistanciaRiosPrinciles()
        {
            return distanciaRiosPrinciles;
        }

        public void SetDistanciaRiosPrinciles(int distanciaRiosPrinciles)
        {
            this.distanciaRiosPrinciles = distanciaRiosPrinciles;
        }

        public override string ToString()
        {
            string resultado = $"Zona {tipoZona}, ubicacion: {tipoUbicacion}, area: {areas}, " +
                $"densidad poblacional {(totalHabitantes / areas)}, esta en riesgo: {estaEnRiesgo}, ";

            if (estaEnRiesgo)
                resultado += $"Inundacion: {tipoInundacion}";
            else
                resultado += "No esta en riesgo";
            return resultado;
        }
    }
}