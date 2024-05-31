// O padrão Proxy sugere em seu primeiro passo, que seja criada uma interface (ou classe abstrata) que representará o objeto real e o proxy.
// Assim garante-se que o proxy e o objeto real possuam os mesmos métodos definidos (com implementações diferentes),
// permitindo que o proxy atue como um objeto real sem medo de ser feliz.

#region Interface
// Interfaces são "contratos", pois garantem que as classes que as implementem possuam os métodos definidos na interface.

// Neste exemplo a interface IObjeto contém o método Request, que será implementado pelas classes ObjetoReal e Proxy.
// O método Request é o método que será chamado pelo cliente para interagir com o objeto real,
// e é também o método que o proxy interceptará para controlar o acesso ao objeto real.
#endregion

// Qual o benefício de fazer essa camada? Não seria mais fácil alterar a classe ObjetoReal diretamente?

#region Resposta
// Imagine que essa classe ObjetoReal seja um objeto que você não pode alterar, por exemplo, uma classe de uma biblioteca de terceiros.
// Nesse caso, você não pode alterar a classe ObjetoReal diretamente, mas pode criar um proxy para controlar o acesso a ela.
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
    private ObjetoReal _objetoReal;

    public Proxy()
    {
        _objetoReal = new ObjetoReal();
    }

    public void Request()
    {
        Console.WriteLine("Proxy: Validando credenciais...");

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