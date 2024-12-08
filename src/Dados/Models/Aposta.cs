namespace Dados.Models;

public class Aposta
{
    public Jogador Jogador { get; set; }
    public int Numero { get; set; }   
    
    public Aposta(Jogador jogador, int numero)
    {
        Jogador = jogador;
        Numero = numero;
    }
}