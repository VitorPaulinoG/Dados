using Dados.Models;
using Dados.Repositories;

namespace Dados.View;

public class RakingView
{
    private JogadorRepository _jogadorRepository;
    public RakingView(JogadorRepository jogadorRepository)
    {
        _jogadorRepository = jogadorRepository;
    }

    public async Task MostrarRaking(int count)
    {
        Console.Clear();
        Console.WriteLine("𝗧𝗢𝗣 𝗙𝗜𝗩𝗘");
        var jogadores = await _jogadorRepository.GetTopSorted(count);
        FormarTabela(jogadores);
        Console.WriteLine("Pressione qualquer tecla para continuar!");
        Console.ReadKey();
        Console.Clear();
    }
    
    private void FormarTabela (IList<Jogador> jogadores) 
    {
        if (!jogadores.Any())
        {
            FormarTabelaVazia();
            return;
        }
        int[] widths = [
            Math.Max(jogadores.Max(x => x.Nome.Length), 20),
            Math.Max(jogadores.Max(x => x.Vitorias.ToString().Length), 8)
        ];

        string[] headers = ["Nome", "Vitorias"];
        
        Console.Write("╭");
        for (int i = 0; i < widths.Length; i++) {
            Console.Write(string.Concat(Enumerable.Repeat('─', widths[i])));
            if(i < widths.Length - 1)
                Console.Write("┬");
        }
        Console.WriteLine("╮");

        Console.Write("│");
        for (int i = 0; i < widths.Length; i++) {
            Console.Write(headers[i]);
            Console.Write(string.Concat(Enumerable.Repeat(' ', Math.Max(widths[i] - headers[i].Length, 0))));
            Console.Write("│");
        }
        Console.WriteLine();

        Console.Write("├");
        for (int i = 0; i < widths.Length; i++) {
            Console.Write(string.Concat(Enumerable.Repeat('─', widths[i])));
            if(i < widths.Length - 1)
                Console.Write("┼");
        }
        Console.WriteLine("┤");
        
        for (int i = 0; i < jogadores.Count(); i++)
        {
            string[] props = jogadores[i].ToString().Split(",\n");
            

            Console.Write("│");
            for (int j = 0; j < widths.Length; j++) {
                
                Console.Write($"{props[j]}");

                int space = widths[j] - props[j].Length;
                if(space > 0)
                    Console.Write(string.Concat(Enumerable.Repeat(' ', space)));
                Console.Write("│");
            }
            Console.WriteLine();

            if(i < jogadores.Count() - 1) {
                Console.Write("├");
                for (int j = 0; j < widths.Length; j++) {
                    Console.Write(string.Concat(Enumerable.Repeat('─', widths[j])));
                    if(j < widths.Length - 1)
                        Console.Write("┼");
                }
                Console.WriteLine("┤");
            } else {
                Console.Write("╰");
                for (int j = 0; j < widths.Length; j++) {
                    Console.Write(string.Concat(Enumerable.Repeat('─', widths[j])));
                    if(j < widths.Length - 1)
                        Console.Write("┴");
                }
                Console.WriteLine("╯");
            }

            
        }
    }

    private void FormarTabelaVazia()
    {
        int[] widths = [
            20,
            8
        ];

        string[] headers = ["Nome", "Vitorias"];
        Console.Write("╭");
        for (int i = 0; i < widths.Length; i++) {
            Console.Write(string.Concat(Enumerable.Repeat('─', widths[i])));
            if(i < widths.Length - 1)
                Console.Write("┬");
        }
        Console.WriteLine("╮");

        Console.Write("│");
        for (int i = 0; i < widths.Length; i++) {
            Console.Write(headers[i]);
            Console.Write(string.Concat(Enumerable.Repeat(' ', Math.Max(widths[i] - headers[i].Length, 0))));
            Console.Write("│");
        }
        Console.WriteLine();
        Console.Write("╰");
        for (int j = 0; j < widths.Length; j++) {
            Console.Write(string.Concat(Enumerable.Repeat('─', widths[j])));
            if(j < widths.Length - 1)
                Console.Write("┴");
        }
        Console.WriteLine("╯");

    }
}