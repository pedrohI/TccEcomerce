public class Pedido {
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string IdentityId { get; set; } = string.Empty;
    public Usuario? Usuario { get; set; }
    public List<ItemPedido>? Itens { get; set; }
    public decimal ValorTotal { get; set; }
}