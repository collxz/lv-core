namespace LarrainVial.Portafolios.Api.Servicios
{
    public class CalculadoraRendimiento
    {
        // Calcula el saldo proyectado a 1 año con una tasa de interés simple
        public decimal CalcularProyeccionAnual(decimal saldoActual, decimal tasaInteresPorcentaje)
        {
            if (saldoActual < 0) return 0;

            decimal multiplicador = 1 + (tasaInteresPorcentaje / 100);
            return saldoActual * multiplicador;
        }
    }
}
