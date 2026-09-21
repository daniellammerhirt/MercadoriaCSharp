using System.ComponentModel.DataAnnotations;

namespace MercadoriaCSharp.Models;

public class Mercadoria
{
    [Key]
    public string CodBarras { get; set; } = "";
    public string Descricao { get; set; } = "";
    public double EstoqueMinimo { get; set; } = 0;
    public string Marca { get; set; } = "";
    public double Quantidade { get; set; } = 0;
}