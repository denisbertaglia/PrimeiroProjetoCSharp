// Screen Sound

string mensagemDeBoasVindas = "Boas Vindas ao Screen Sound";

Dictionary<string,List<int>> bandasCadastradas = new Dictionary<string, List<int>> { 
    { "Ira", new List<int>{ 1, 2, 4, 8 } } 
};
bandasCadastradas.Add("U2", new List<int> { 10, 5, 6});
bandasCadastradas.Add("Calypso", new List<int>());

void ExbirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");

    Console.WriteLine("\n"+mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExbirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string? opcaoEscolhida = Console.ReadLine();

    if(opcaoEscolhida == null)
    {
        opcaoEscolhida = "-1";
    }

    int opcaoEscolhidaNumérica = int.Parse(opcaoEscolhida);
    
    switch(opcaoEscolhidaNumérica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: ExbirListaBandas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: ExibirMediaBanda();
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            Thread.Sleep(2000);
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Regisitro de Bandas");
    Console.Write("Informe o nome da banda a ser cadastrado: ");
    string nomeBanda = Console.ReadLine()!;
    bandasCadastradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"A Banda \"{nomeBanda}\" foi cadastrado com sucesso!");
    Thread.Sleep( 2000 );
    Console.Clear();
    ExibirOpcoesDoMenu();
}
void ExbirListaBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Lista de Bandas");
    foreach (string banda in bandasCadastradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    RetornoAoMenu();
}

void AvaliarBanda(){
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeBanda = Console.ReadLine()!;
    if(bandasCadastradas.ContainsKey(nomeBanda))
    {
        Console.Write($"\n Qual a nota para a banda {nomeBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasCadastradas[nomeBanda].Add(nota);
        Console.WriteLine($"\n Nota {nota} registrada para a banda {nomeBanda} com sucesso!");
        Thread.Sleep(2000);
    }
    else
    {
       Console.WriteLine($"\n Banda {nomeBanda} não encontrada!");
    }
    RetornoAoMenu();
}

void ExibirMediaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Média das notas");
    Console.Write("Digite o nome da banda que deseja ver a média: ");
    string nomeBanda = Console.ReadLine()!;
    if(bandasCadastradas.ContainsKey(nomeBanda))
    {
        List<int> notas = bandasCadastradas[nomeBanda];
        double media = 0;
        if (notas.Count > 0)
        {
            media = bandasCadastradas[nomeBanda].Average();
        }
        
        Console.WriteLine($" A média de notas da banda {nomeBanda} é {media}.");
    }
    else
    {
        Console.WriteLine($"\n Banda {nomeBanda} não encontrada!");
    }
    RetornoAoMenu();
}
void RetornoAoMenu()
{
    Console.WriteLine("\nPressione alguma tecla para voltar para o menu.");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}
void ExibirTituloDaOpcao(string titulo = "")
{
    int quantidadeDeCaracteres = titulo.Length;
    string astericos = string.Empty.PadLeft(quantidadeDeCaracteres,'*');

    Console.WriteLine(astericos);
    Console.WriteLine(titulo);
    Console.WriteLine(astericos + "\n");
}


ExibirOpcoesDoMenu();
