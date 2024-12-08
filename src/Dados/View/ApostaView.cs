using Dados.Models;
namespace Dados.View;
public class ApostaView
{
    public ApostaView()
    {   

    }
    public void MostrarApostas (object sender, ApostaRealizadaEventArgs args)
    {
        if(!args.Apostas.Any())
            return;
        string result = string.Empty;
        List<string[]> numbers = new List<string[]>();
        
        args.Apostas.ForEach(aposta => numbers.Add(
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
}