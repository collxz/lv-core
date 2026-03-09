using System.ComponentModel.DataAnnotations.Schema;

namespace LarrainVial.Portafolios.Api.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Saldo { get; set; }
}
