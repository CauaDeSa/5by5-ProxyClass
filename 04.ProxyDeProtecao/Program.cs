// O Proxy de proteção é uma variação do padrão Proxy que controla o acesso ao objeto real.
// È útil quando você deseja controlar quem pode acessar o objeto real e como ele pode ser acessado.

#region Analogia
// Neste exemplo, o ProxyUsuario controla o acesso ao objeto Usuario, exigindo que o usuário seja autenticado antes de acessar os dados pessoais.
// Fazendo uma analogia com o mundo real, poderíamos dizer que um cartão de crédito é um proxy de proteção para o dinheiro em sua conta bancária.
// Você precisa autenticar-se (com uma senha, ou realizar aproximação do chip do cartão) antes de poder acessar o dinheiro.
#endregion

using System;
using System.Threading;

public interface IUsuario
{
    String GetDadosPessoais();
}


public class Usuario : IUsuario
{
    public String GetDadosPessoais()
    {
        return "Usuario: Retornando dados pessoais do pestana...";
    }
}

public class ProxyUsuario : IUsuario
{
    Usuario? usuario;

    String senha = "AmoJava";

    public String GetDadosPessoais()
    {
        String situacao = "Proxy: Usuário não autenticado";

        if (this.usuario != null)
            situacao = usuario.GetDadosPessoais();

        return situacao;
    }


    public String Autenticar(String senha)
    {
        String situacao = "Proxy: Erro ao autenticar";

        if (senha == this.senha)
        {
            this.usuario = new Usuario();
            situacao = "Proxy: Usuário autenticado";
        }

        return situacao;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ProxyUsuario proxy = new ProxyUsuario();

        Console.WriteLine("\nTentando consultar sem autenticar");
        Console.WriteLine(proxy.GetDadosPessoais());

        Console.WriteLine("\nAutenticando com senha incorreta");
        Console.WriteLine(proxy.Autenticar("senhaErrada"));
        Console.WriteLine(proxy.GetDadosPessoais());
        Console.WriteLine();

        Console.WriteLine("\nAutenticando com senha correta");
        Console.WriteLine(proxy.Autenticar("AmoJava"));
        Console.WriteLine(proxy.GetDadosPessoais());
    }
}