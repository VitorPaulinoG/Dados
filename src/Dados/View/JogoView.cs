using Dados.Models;
using Dados.Repositories;

namespace Dados.View;
public class JogoView
{
    public event EventHandler<ApostaRealizadaEventArgs> ApostaRealizada;
    private List<Aposta> _apostas = new List<Aposta>();
    private JogadorRepository _jogadorRep;

    public JogoView(JogadorRepository jogadorRepository)
    {
        _jogadorRep = jogadorRepository;
    }
    public void OnApostaRealizada ()
    {
        ApostaRealizada?.Invoke(typeof(JogoView), new ApostaRealizadaEventArgs(_apostas));
    }

    public async Task Start () 
    {
        for (int i = 0; i < 11; i++) {
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

                    if(_apostas.Any(x => x.Numero == numero)) {
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

            _apostas.Add(aposta);




            if(i == 11 - 1)
            break; 
            Console.Write("Adicionar ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("mais ");
            Console.ResetColor();
            Console.Write("um jogador? ");
            string resp = Console.ReadLine();
            
            Console.Clear();
            OnApostaRealizada();

            if (resp != "S")
                break;


        }
        
        int numeroSorteado = Dado.LancarDados(2);
        Console.WriteLine($"Número Sorteado: {numeroSorteado}");
        Jogador? vencedor = _apostas.SingleOrDefault(x => x.Numero == numeroSorteado)?.Jogador;
        if(vencedor != null) 
        {
            Console.WriteLine($"O jogador {vencedor.Nome} venceu!");
            await _jogadorRep.Add(vencedor);

        } else 
        {
            Console.WriteLine("A máquina venceu!");
        }
    }
}