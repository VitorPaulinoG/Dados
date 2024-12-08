using System.Text;


using Dados.Models;

namespace Dados.Repositories;
public class JogadorRepository
{
    public string Path { get; set; }
    public JogadorRepository(string path)
    {
        Path = path;
    }
    public async Task<Jogador?> GetByName (string nome)
    {
        using (StreamReader reader = new StreamReader(Path)) 
        {
            string nomeJogador;
            int vitorias;
            do 
            {
                var jogador = (await reader.ReadLineAsync()).Split(';');
                nomeJogador = jogador[0];
                vitorias = int.Parse(jogador[1]);

            } while (nomeJogador != nome && !reader.EndOfStream); 
            if(nomeJogador == nome) {
                return new Jogador(nomeJogador) {
                    Vitorias = vitorias
                };
            }
            return null;
        }
    }

    public async Task<int> GetIndexByName (string nome)
    {
        int index = -1;
        using (StreamReader reader = new StreamReader(Path)) 
        {
            string nomeJogador;
            try {
                do 
                {
                    index++;
                    var jogador = (await reader.ReadLineAsync()).Split(';');
                    nomeJogador = jogador[0];
                } while (nomeJogador != nome && !reader.EndOfStream); 


                if(nomeJogador == nome) {
                    return index;
                }
                return -1;
            } catch (Exception) {
                return -1;
            }

        }
    }

    public async Task<IList<Jogador>> Get ()
    {
        IList<Jogador> jogadores = new List<Jogador>();
        using (StreamReader reader = new StreamReader(Path)) 
        {
            string[] jogador;
            while ((jogador = (await reader.ReadLineAsync()).Split(';')) != null)
            {
                jogadores.Add(new Jogador(jogador[0]) { Vitorias = int.Parse(jogador[1])});
            }
        }
        return jogadores;
    }

    public async Task Add (Jogador jogador) 
    {
        try {
            int index = await GetIndexByName(jogador.Nome);
            List<string> jogadores = (await File.ReadAllTextAsync(Path)).Split('\r').ToList();
            // Console.WriteLine("CHEGOU"); 
            if(index >= 0) {
                int vitoriasIndex = jogadores[index].IndexOf(';') + 1;

                int vitoriasAnteriores = int.Parse(jogadores[index].Substring(vitoriasIndex, 
                    jogadores[index].Length - vitoriasIndex));
                
                jogadores[index] = jogadores[index].Replace(vitoriasAnteriores.ToString(), (vitoriasAnteriores+1).ToString());
            } else {
                jogadores.Add($"{jogador.Nome};{jogador.Vitorias}");
            }

            await File.WriteAllTextAsync(Path, string.Join('\r', jogadores));

        } catch (Exception ex) {
            Console.WriteLine(ex);
        }

    }
}