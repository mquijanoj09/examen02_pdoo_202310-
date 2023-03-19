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

        public string GetTipoZona()
        {
            return tipoZona;
        }

        public void SetTipoZona(string tipoZona)
        {
            this.tipoZona = tipoZona;
        }

        public bool GetEstaEnRiesgo()
        {
            return estaEnRiesgo;
        }

        public void SetEstaEnRiesgo(bool estaEnRiesgo)
        {
            this.estaEnRiesgo = estaEnRiesgo;
        }

        public string GetTipoInundacion()
        {
            return tipoInundacion;
        }

        public void SetTipoInundacion(string tipoInundacion)
        {
            this.tipoInundacion = tipoInundacion;
        }

        public void ObtieneTipoZona(int totalHabitantes)
        {
            if (totalHabitantes > 500000)
                 tipoZona = "Urbana";
            else
                 tipoZona = "Rural";
        }

        public void ObtieneTipoUbicacion(int nivelDelMar)
        {
            if (nivelDelMar > 500)
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

        public override string ToString()
        {
            string resultado = $"Zona: {tipoZona}, ubicacion: {tipoUbicacion}, area: {areas}, " +
                $"densidad poblacional: {(totalHabitantes / areas)}, ";
            if (estaEnRiesgo)
                resultado += $"esta en riesgo, inundacion: {tipoInundacion}";
            else
                resultado += "No esta en riesgo";
            return resultado;
        }
    }
}