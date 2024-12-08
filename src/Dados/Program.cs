using Dados.Models;
using Dados.Repositories;
using Dados.View;

List<Aposta> apostas = new List<Aposta>();

JogadorRepository jogadorRep = new JogadorRepository("../../data/table.txt");

DadoView dadoView = new DadoView();

Dado.DadosLancados += dadoView.MostrarDados;

Jogo ();
async void Jogo () 
{
    for (int i = 0; i < 11; i++) {
        MostrarNumerosApostados();
        Console.WriteLine("Insira o nome do jogador: ");
        string nome = Console.ReadLine();
        int numero = 0;

        do
        {
            try 
            {
                Console.WriteLine("Insira o número no qual você deseja apostar: ");
                numero = int.Parse(Console.ReadLine());
                if(numero < 1 || numero > 12)
                    Console.WriteLine("A aposta deve ser entre os números 1 e 12!");

                if(apostas.Any(x => x.Numero == numero)) {
                    Console.WriteLine("Outro jogador já apostou nesse número! Escolha outro.");
                    numero = 0;
                }
            } catch (FormatException) 
            {
                Console.WriteLine("A aposta deve ser um número inteiro!");
            }
        } while (numero < 1 || numero > 12);

        Jogador jogador = new Jogador(nome);

        Aposta aposta = new Aposta(jogador, numero);

        apostas.Add(aposta);




        if(i == 11 - 1)
           break; 
        Console.Write("Adicionar ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("mais ");
        Console.ResetColor();
        Console.Write("um jogador? ");
        string resp = Console.ReadLine();
        
        if (resp != "S")
            break;

        Console.Clear();
    }
    MostrarNumerosApostados();
    
    int numeroSorteado = Dado.LancarDados(2);
    Console.WriteLine($"Número Sorteado: {numeroSorteado}");
    Jogador? vencedor = apostas.SingleOrDefault(x => x.Numero == numeroSorteado)?.Jogador;
    if(vencedor != null) 
    {
        Console.WriteLine($"O jogador {vencedor.Nome} venceu!");
        await jogadorRep.Add(vencedor);

    } else 
    {
        Console.WriteLine("A máquina venceu!");
    }

}

void MostrarNumerosApostados () 
{
    if(!apostas.Any())
        return;
    string result = string.Empty;
    List<string[]> numbers = new List<string[]>();
    
    apostas.ForEach(aposta => numbers.Add(
        (
            $"╭────╮\n" + 
            $"│ {aposta.Numero:00} │\n" + 
            $"╰────╯"
        ).Split('\n')
    ));


    for(int i = 0; i < 3; i++) 
    { 
        for(int j = 0; j < numbers.Count(); j++) 
        {

            result += numbers[j][i];
        }
        result += "\n";
    }

    Console.WriteLine("Números Já Apostados");
    Console.Write(result);

}

// int LancarDados () 
// {
//     Random rand = new Random();
    
//     int num1 = rand.Next(1, 6 + 1);
//     int num2 = rand.Next(1, 6 + 1);

//     MostrarDados(num1, num2);
//     int soma = num1 + num2;
//     Console.WriteLine($"Número Sorteado: {soma}");
//     return soma;
// }


// void MostrarDados (int num1, int num2) 
// {
//     string[] dado1 = dados[num1].Split('\n');
//     string[] dado2 = dados[num2].Split('\n');
//     string faces = "";
//     for (int i = 0; i < 5; i++) 
//     {
//         faces += $"{dado1[i]}\t{dado2[i]}\n";
//     }
//     Console.WriteLine(faces);
// }


