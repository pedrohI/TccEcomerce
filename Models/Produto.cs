namespace TccEcomerce.Models;
public class Produto {
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public double Preco { get; set; }
    public int Estoque { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public bool Disponivel { get; set; } // Disponível ou não disponível
}