// A proxy de registro é um tipo de proxy que mantém um registro de chamadas para um objeto real.
// Ele pode ser útil para monitorar e registrar chamadas de métodos, ou para implementar um sistema de log.

#region Analogia
// Imagine que você é um gerente de uma loja de roupas e tem um funcionário chamado ProxyRegistro.
// O ProxyRegistro é responsável por registrar todas as vendas que o funcionário faz.
// Ele anota o nome do cliente, o produto vendido e o valor da venda.
// Isso permite que você monitore as vendas e saiba quais produtos estão vendendo mais.
#endregion

public interface IVenda
{
    void EfetuarVenda(string nomeProduto, double valorTotal);
}

public class SistemaVenda : IVenda
{
    public void EfetuarVenda(string nomeProduto, double valorTotal)
    {
        Console.WriteLine("SistemaVenda: realizando a venda...");
    }
}

public class ProxyVenda : IVenda
{
    private SistemaVenda? _venda;

    public void EfetuarVenda(string nomeProduto, double valorTotal)
    {
        Console.WriteLine("\nProxyVenda: Validando dados venda...");

        _venda = new();

        Console.WriteLine("ProxyVenda: Chamando o sistema venda...");

        _venda.EfetuarVenda(nomeProduto, valorTotal);

        Console.WriteLine($"ProxyVenda: Criando o relatorio...\n\nRelatorio: Produto: {nomeProduto}, Valor: {valorTotal}");
    }
}

class Program
{
    static void Main()
    {
        IVenda proxy = new ProxyVenda();

        proxy.EfetuarVenda("champoo", 11.70);
        proxy.EfetuarVenda("sabolete niquido", 2.50);
        proxy.EfetuarVenda("cuiscuis", 7.50);
    }
}