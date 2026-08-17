using DoceCantinho.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;

public class CarrinhoController : Controller
{
    [HttpPost]
    public IActionResult FinalizarCompra(Pedido pedido)
    {
        var mensagem = new StringBuilder();

        mensagem.AppendLine("*NOVO PEDIDO*");
        mensagem.AppendLine($"Nome: {pedido.NomeCliente}");
        mensagem.AppendLine($"Telefone: {pedido.Telefone}");
        mensagem.AppendLine("");

        decimal total = 0;

        foreach (var item in pedido.Itens)
        {
            mensagem.AppendLine(
                $"- {item.Nome} x{item.Quantidade} - R$ {item.Preco:F2}"
            );

            total += item.Preco * item.Quantidade;
        }

        mensagem.AppendLine("");
        mensagem.AppendLine($"Total: R$ {total:F2}");

        string numeroWhatsApp = "5511999999999";

        string link =
            $"https://wa.me/{numeroWhatsApp}?text={Uri.EscapeDataString(mensagem.ToString())}";

        return Redirect(link);
    }
}