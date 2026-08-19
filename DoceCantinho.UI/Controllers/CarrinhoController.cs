using DoceCantinho.Application.Interfaces;
using DoceCantinho.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

public class CarrinhoController : Controller
{
    private const string CARRINHO_SESSION_KEY = "Carrinho";
    private readonly IDoceService _doceService;

    public CarrinhoController(IDoceService doceService)
    {
        _doceService = doceService;
    }

    // GET: Carrinho (exibir carrinho)
    public IActionResult Index()
    {
        var carrinho = ObterCarrinhoDaSessao();
        return View(carrinho);
    }

    // POST: Adicionar item ao carrinho
    [HttpPost]
    public async Task<IActionResult> Adicionar(int id, int quantidade = 1)
    {
        var doce = await _doceService.GetByIdAsync(id);
        if (doce == null)
            return NotFound();

        var carrinho = ObterCarrinhoDaSessao();

        // Procura se o item já existe no carrinho
        var itemExistente = carrinho.Itens.FirstOrDefault(i => i.DoceId == id);

        if (itemExistente != null)
        {
            // Se existe, aumenta a quantidade
            itemExistente.Quantidade += quantidade;
        }
        else
        {
            // Cria um novo item no carrinho
            carrinho.Itens.Add(new ItemCarrinho
            {
                DoceId = doce.Id,
                Nome = doce.Title,
                Preco = decimal.Parse(doce.Preco.ToString()),
                Quantidade = quantidade,
                CoverImageUrl = doce.CoverImageUrl
            });
        }

        SalvarCarrinhemaSessao(carrinho);

        // Redireciona para o carrinho ou volta à página anterior
        return RedirectToAction("Index");
    }

    // POST: Remover item do carrinho
    [HttpPost]
    public IActionResult Remover(int doceId)
    {
        var carrinho = ObterCarrinhoDaSessao();
        var item = carrinho.Itens.FirstOrDefault(i => i.DoceId == doceId);

        if (item != null)
        {
            carrinho.Itens.Remove(item);
            SalvarCarrinhemaSessao(carrinho);
        }

        return RedirectToAction("Index");
    }

    // POST: Atualizar quantidade
    [HttpPost]
    public IActionResult AtualizarQuantidade(int doceId, int quantidade)
    {
        if (quantidade <= 0)
            return Remover(doceId);

        var carrinho = ObterCarrinhoDaSessao();
        var item = carrinho.Itens.FirstOrDefault(i => i.DoceId == doceId);

        if (item != null)
        {
            item.Quantidade = quantidade;
            SalvarCarrinhemaSessao(carrinho);
        }

        return RedirectToAction("Index");
    }

    // POST: Limpar carrinho
    [HttpPost]
    public IActionResult Limpar()
    {
        HttpContext.Session.Remove(CARRINHO_SESSION_KEY);
        return RedirectToAction("Index");
    }

    // POST: Finalizar compra
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult FinalizarCompra(string nomeCliente, string telefone, string? endereco = null)
    {
        var carrinho = ObterCarrinhoDaSessao();

        if (!carrinho.Itens.Any())
            return RedirectToAction("Index");

        if (string.IsNullOrWhiteSpace(nomeCliente) || string.IsNullOrWhiteSpace(telefone))
            return BadRequest("Nome e telefone são obrigatórios");

        var mensagem = new StringBuilder();
        mensagem.AppendLine("🎉 *NOVO PEDIDO - Doce Cantinho* 🎉");
        mensagem.AppendLine("━━━━━━━━━━━━━━━━━━━━━━");
        mensagem.AppendLine($"📝 *Cliente:* {nomeCliente}");
        mensagem.AppendLine($"📱 *Telefone:* {telefone}");

        if (!string.IsNullOrWhiteSpace(endereco))
        {
            mensagem.AppendLine($"📍 *Endereço:* {endereco}");
        }

        mensagem.AppendLine("━━━━━━━━━━━━━━━━━━━━━━");
        mensagem.AppendLine("🛒 *Itens do Pedido:*");
        mensagem.AppendLine("");

        decimal total = 0;

        foreach (var item in carrinho.Itens)
        {
            var subtotal = item.Preco * item.Quantidade;
            mensagem.AppendLine($"✓ {item.Nome}");
            mensagem.AppendLine($"  Qtd: {item.Quantidade} x R$ {item.Preco:F2}");
            mensagem.AppendLine($"  Subtotal: R$ {subtotal:F2}");
            mensagem.AppendLine("");

            total += subtotal;
        }

        mensagem.AppendLine("━━━━━━━━━━━━━━━━━━━━━━");
        mensagem.AppendLine($"💰 *TOTAL:* R$ {total:F2}");
        mensagem.AppendLine("━━━━━━━━━━━━━━━━━━━━━━");
        mensagem.AppendLine("");
        mensagem.AppendLine("Obrigado por sua compra! 🙏");

        string numeroWhatsApp = "5511999999999"; // Seu número aqui
        string link = $"https://wa.me/{numeroWhatsApp}?text={Uri.EscapeDataString(mensagem.ToString())}";

        // Limpar após enviar
        HttpContext.Session.Remove(CARRINHO_SESSION_KEY);

        return Redirect(link);
    }

    // Métodos auxiliares
    private CarrinhoSessao ObterCarrinhoDaSessao()
    {
        var carrinhoJson = HttpContext.Session.GetString(CARRINHO_SESSION_KEY);

        if (string.IsNullOrEmpty(carrinhoJson))
        {
            return new CarrinhoSessao { Itens = new List<ItemCarrinho>() };
        }

        return JsonSerializer.Deserialize<CarrinhoSessao>(carrinhoJson) 
            ?? new CarrinhoSessao { Itens = new List<ItemCarrinho>() };
    }

    private void SalvarCarrinhemaSessao(CarrinhoSessao carrinho)
    {
        var carrinhoJson = JsonSerializer.Serialize(carrinho);
        HttpContext.Session.SetString(CARRINHO_SESSION_KEY, carrinhoJson);
    }
}

// Modelos para carrinho
public class CarrinhoSessao
{
    public List<ItemCarrinho> Itens { get; set; } = new();

    public decimal Total => Itens.Sum(i => i.Preco * i.Quantidade);
    public int QuantidadeTotal => Itens.Sum(i => i.Quantidade);
}

public class ItemCarrinho
{
    public int DoceId { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public string? CoverImageUrl { get; set; }
}
