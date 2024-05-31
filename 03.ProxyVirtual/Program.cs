//  O Proxy Virtual (Lazy Loading) é muito usado quando você deseja adiar a criação de um objeto até o momento em que ele é realmente necessário, por exemplo. 

// Por que utilizar?

#region Resposta
//  Isso pode ser útil quando a criação de um objeto é cara em termos de recursos ou tempo de processamento.
#endregion

#region Analogia
// Imagine que todas as fotos/vídeos são carregadas completamente e em alta qualidade assim que você abre Instagram.
// Isso consumiria muitos recursos do seu celular e poderia deixar o aplicativo lento.
// O Instagram, no entanto, carrega as imagens em baixa qualidade e só carrega a versão em alta qualidade quando você clica na imagem.
#endregion

public interface IObjeto
{
    void Request();
}

public class ObjetoReal : IObjeto
{
    public void Request()
    {
        Console.WriteLine("ObjetoReal: Processando a requisição...");
    }
}

public class Proxy : IObjeto
{
    private ObjetoReal? _objetoReal;

    public void Request()
    {
        Console.WriteLine("Proxy: Validando credenciais...");

        _objetoReal = new();

        Console.WriteLine("Proxy: Executando o objeto real...");

        _objetoReal.Request();

        Console.WriteLine("Proxy: criando relatório...");
    }
}

class Program
{
    static void Main()
    {
        IObjeto proxy = new Proxy();
        proxy.Request();
    }
}