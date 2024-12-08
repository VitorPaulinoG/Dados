using Dados.Events;

namespace Dados.Models;
public class Dado
{
    private static readonly Random _rand = new Random();
    public int Value { get; set; }
    public static event EventHandler<DadosLancadosEventArgs> DadosLancados;
    public Dado()
    {

    }
    public void LancarDado () 
    {
        Value = _rand.Next(1, 6 + 1);
    }


    public static void OnDadosLancados (List<Dado> dados) 
    {
        DadosLancados?.Invoke(typeof(Dado), new DadosLancadosEventArgs(dados));
    }
    
    public static int LancarDados(int quantidade) 
    {
        List<Dado> dados = new List<Dado>();
        for (int i = 0; i < quantidade; i++) 
        {
            Dado dado = new Dado();
            dado.LancarDado();
            dados.Add(dado);
        }
        
        OnDadosLancados(dados);
        return dados.Sum(x => x.Value);

    }
}