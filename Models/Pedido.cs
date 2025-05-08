public class Pedido {
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public int ApplicationUserId { get; set; }
    public ApplicationUser? Usuario { get; set; }
    public List<ItemPedido>? Itens { get; set; }
    public decimal ValorTotal { get; set; }
}