//  O Proxy é um padrão de projeto estrutural que permite que você forneça, quando solicitado, ao invés do objeto real,
//  um substituto que manipulará o objeto real.

//  Por quê? Este substituto (proxy) controlará de acordo com suas necessidades o acesso ao objeto original, 
//  permitindo que você faça algo antes ou depois da interação com o objeto original de fato.

public class ObjetoReal
{
    public ObjetoReal() { }

    public void Request()
    {
        Console.WriteLine("Objeto Real: Processando a requisição...");
    }
}
public class Proxy
{
    ObjetoReal _objetoReal;

    public Proxy() 
    {
        _objetoReal = new ObjetoReal();
    }

    public void Request()
    {
        Console.WriteLine("Executou ações antes...");
        _objetoReal.Request();
        Console.WriteLine("Executou ações depois...");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var proxy = new Proxy();
        proxy.Request();
    }
}