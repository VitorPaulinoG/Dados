using Dados.Models;
using Dados.Repositories;
using Dados.View;

List<Aposta> apostas = new List<Aposta>();

JogadorRepository jogadorRep = new JogadorRepository("../../../../../data/table.txt");

DadoView dadoView = new DadoView();
ApostaView apostaView = new ApostaView();

Dado.DadosLancados += dadoView.MostrarDados;

JogoView jogoView = new JogoView(jogadorRep);
jogoView.ApostaRealizada += apostaView.MostrarApostas;

jogoView.Start();
