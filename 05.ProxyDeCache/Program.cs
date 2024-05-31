// O Proxy de Cache é um tipo de proxy que mantém um cache para armazenar os resultados de operações caras ou frequentemente usadas,
// para que possam ser retornados sem recalcular os resultados.

using System;
using System.Collections.Generic;

public interface IService
{
    string GetDataFromSQL(int key);
}

public class Service : IService
{
    public string GetDataFromSQL(int key)
    {
        Console.WriteLine("Service: Buscando dados para a chave: " + key);

        Thread.Sleep(3000);

        return "Dados recuperados do SQL";
    }
}

public class ProxyService : IService
{
    private IService? _service;
    private readonly Dictionary<int, string> _cache = new Dictionary<int, string>();

    public string GetDataFromSQL(int key)
    {
        if (_cache.ContainsKey(key))
        {
            Console.WriteLine("Proxy: Retornando dados em cache para a chave: " + key);
            return _cache[key];
        }

        if(_service == null)
            _service = new Service();
        
        Console.WriteLine("Proxy: Buscando dados para a chave: " + key);

        string result = _service.GetDataFromSQL(key);

        Console.WriteLine("Proxy: Adicionando dados à cache local");
        _cache[key] = result;

        return result;
    }
}

public class Program
{
    public static void Main()
    {
        IService service = new ProxyService();

        Console.WriteLine(service.GetDataFromSQL(1) + "\n");
        Console.WriteLine(service.GetDataFromSQL(1) + "\n");
        Console.WriteLine(service.GetDataFromSQL(2));
    }
}