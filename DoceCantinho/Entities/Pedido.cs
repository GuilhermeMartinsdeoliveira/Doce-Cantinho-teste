namespace DoceCantinho.Domain.Entities;

public class Pedido
{
    public string NomeCliente { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    public List<Carrinho> Itens { get; set; } = [];
}