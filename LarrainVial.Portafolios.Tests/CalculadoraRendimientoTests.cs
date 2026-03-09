using LarrainVial.Portafolios.Api.Servicios;

namespace LarrainVial.Portafolios.Tests
{
    public class CalculadoraRendimientoTests
    {
        [Fact]
        public void CalcularProyeccionAnual_DebeCalcularInteresCorrectamente()
        {
            // 1. Arrange (Preparar el escenario)
            var calculadora = new CalculadoraRendimiento();
            decimal saldoInicial = 10000m;
            decimal tasaInteres = 5m;
            decimal resultadoEsperado = 10500m;

            // 2. Act (Ejecutar la acción)
            decimal resultadoReal = calculadora.CalcularProyeccionAnual(saldoInicial, tasaInteres);

            // 3. Assert (Verificar el resultado)
            Assert.Equal(resultadoEsperado, resultadoReal);
        }

        [Fact]
        public void CalcularProyeccionAnual_SaldoNegativo_DebeRetornarCero()
        {
            // 1. Arrange
            var calculadora = new CalculadoraRendimiento();

            // 2. Act
            decimal resultadoReal = calculadora.CalcularProyeccionAnual(-500m, 10m);

            // 3. Assert
            Assert.Equal(0m, resultadoReal);
        }
    }
}