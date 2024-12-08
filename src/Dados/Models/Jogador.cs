namespace Dados.Models;
public class Jogador
{
    public string Nome { get; set; }
    public int Vitorias { get; set; }
    public Jogador(string nome)
    {
        Nome = nome;
    }
    public Jogador(string nome, int vitorias)
    {
        Nome = nome;
        Vitorias = vitorias;
    }
}