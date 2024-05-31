// O Proxy de referência inteligente é um tipo de proxy que mantém uma referência a determinados dados
// enquanto os mesmos podem ser úteis ao sistema, porém os descarta quando deixam de ser utilizáveis.

#region Analogia
// Imagine que o serviço de buffet é o objeto real. Ele prepara e serve os alimentos e bebidas.
// No entanto, você não quer que o buffet esteja sempre funcionando, gastando recursos e dinheiro desnecessariamente.
// Agora, imagine que você contrata um “buffet proxy”. Esse proxy não é um buffet completo, mas ele gerencia o buffet completo.
// Ele disponibiliza os pratos para os clientes, porém quando não há mais clientes, ele para de servir e descarta os pratos.
#endregion

using System;

public interface IObjetoCaro
{
    void OperacaoCustosa();
}

// Implementação real do objeto
public class ObjetoCaro : IObjetoCaro
{
    public ObjetoCaro()
    {
        Thread.Sleep(3000);
        Console.WriteLine("Objeto Caro: Objeto criado.");
    }

    public void OperacaoCustosa()
    {
        Console.WriteLine("Objeto Caro: Operação realizada.");
    }
}

// Proxy de referência inteligente
public class ProxyInteligente : IObjetoCaro
{
    private IObjetoCaro? _realObject;

    public void OperacaoCustosa()
    {
        if (_realObject == null)
        {
            _realObject = new ObjetoCaro();
        }

        _realObject.OperacaoCustosa();
    }

    public void DescartarObjeto()
    {
        Console.WriteLine("Proxy Inteligente: Objeto descartado.");
        _realObject = null;
    }
}

class Program
{
    static void Main()
    {
        var proxy = new ProxyInteligente();

        for (int i = 0; i < 3; i++)
        {
            proxy.OperacaoCustosa();
        }

        Console.WriteLine();

        proxy.DescartarObjeto();

        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            proxy.OperacaoCustosa();
        }

        proxy.DescartarObjeto();
    }
}