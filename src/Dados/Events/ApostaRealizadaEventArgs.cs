using Dados.Models;

public class ApostaRealizadaEventArgs : EventArgs
{
    public List<Aposta> Apostas { get; set; }
    public ApostaRealizadaEventArgs(List<Aposta> apostas)
    {
        Apostas = apostas;
    }
}