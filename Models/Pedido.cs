public class Pedido {
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public List<ItemPedido>? Itens { get; set; }
    public decimal ValorTotal { get; set; }
}