using TccEcomerce.Enums;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser {
    public new int Id { get; set; }
    public string? Nome { get; set; }
    public new string? Email { get; set; }
    public string? Senha { get; set; }
    public string? Telefone { get; set; }
    public PerfilEnum Perfil { get; set; }
    public List<Pedido>? Pedidos { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    
}