using Dados.Models;

namespace Dados.Events;
public class DadosLancadosEventArgs : EventArgs
{
    public List<Dado> Dados { get; set; }
    public int Result { get; set; }

    public DadosLancadosEventArgs(List<Dado> dados)
    {
        Dados = dados;
        Result = dados.Sum(x => x.Value);
    }
}