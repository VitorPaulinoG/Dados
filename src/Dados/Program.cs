using Dados.Models;
using Dados.Repositories;
using Dados.View;

JogadorRepository jogadorRep = new JogadorRepository("../../../../../data/table.txt");
DadoView dadoView = new DadoView();
ApostaView apostaView = new ApostaView();
RakingView rakingView = new RakingView(jogadorRep);
JogoView jogoView = new JogoView(jogadorRep);


Dado.DadosLancados += dadoView.MostrarDados;
jogoView.ApostaRealizada += apostaView.MostrarApostas;

string opcao;

do
{
    await rakingView.MostrarRaking(5);
    jogoView.Start();
    Console.WriteLine("Jogar novamente? ");
    opcao = Console.ReadLine();
} while (opcao.ToUpper() is "S" or "SIM" or "");
