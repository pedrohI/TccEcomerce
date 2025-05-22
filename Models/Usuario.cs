using TccEcomerce.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario : IdentityUser
{
    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;
    public string IdentityId { get; set; } = Guid.NewGuid().ToString();
    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    public PerfilEnum Perfil { get; set; } = PerfilEnum.Cliente;
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    public DateTime? DataAtualizacao { get; set; }
    public bool IsAdmin { get; set; } = false;
    
}