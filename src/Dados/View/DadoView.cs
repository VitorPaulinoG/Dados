using Dados.Events;

namespace Dados.View;
public class DadoView
{
    private Dictionary<int, string> _dadosASCII = new (){
        {
            1, 
                "╭─────────╮\n" +
                "│         │\n" + 
                "│    ⬤    │\n" + 
                "│         │\n" +
                "╰─────────╯"
        },
        {
            2, 
                "╭─────────╮\n" +
                "│ ⬤       │\n" +
                "│         │\n" +
                "│       ⬤ │\n" +
                "╰─────────╯"
        },
        {
            3, 
                "╭─────────╮\n" +
                "│ ⬤       │\n" +
                "│    ⬤    │\n" +
                "│       ⬤ │\n" +
                "╰─────────╯"
        },
        {
            4, 
                "╭─────────╮\n" +
                "│ ⬤     ⬤ │\n" +
                "│         │\n" + 
                "│ ⬤     ⬤ │\n" +
                "╰─────────╯"
        },
        {
            5, 
                "╭─────────╮\n" +
                "│ ⬤     ⬤ │\n" +
                "│    ⬤    │\n" +
                "│ ⬤     ⬤ │\n" +
                "╰─────────╯"
        },
        {
            6, 
                "╭─────────╮\n" +
                "│ ⬤     ⬤ │\n" +
                "│ ⬤     ⬤ │\n" +
                "│ ⬤     ⬤ │\n" +
                "╰─────────╯"
        }
    };
    public DadoView()
    {
        
    }

    public void MostrarDados (object sender, DadosLancadosEventArgs args) 
    {        
        List<string> dados = args.Dados.Select(x => _dadosASCII[x.Value]).ToList();
        List<string[]> partesDosDados = dados.Select(x => x.Split('\n')).ToList();
        
        string faces = "";
        for (int i = 0; i < 5; i++) 
        {
            foreach (var parte in partesDosDados) 
            {
                faces+= $"{parte[i]}\t";
            }
            faces += "\n";
        }
        Console.WriteLine(faces);
    } 
}