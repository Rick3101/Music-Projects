using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Threading;

public class Track
{
    private static int _counter = 0;

    public int Id { get; private set; }
    public string Name { get; set; }

    public Track()
    {
        Id = ++_counter;
    }
}


class Program
{
    static List<string> ListaDeTracks = new List<string> { "Mystic River", "Soul Shard", "Tribute to GoaGil," };

    static void Main()
    {
        ExibirOpcoesDoMenu();
        LerCSV();
    }

    static void LerCSV()
    {
        using (var reader = new StreamReader("C:\\Users\\User\\Desktop\\teste 1.CSV"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<Track>();
        }

    }
    static string EditarCSV(Track track,string filename)
    {
        var tracks = ExibirCSV(filename);

        tracks.Add(track);

        using (var writer = new StreamWriter("C:\\Users\\Rick\\Desktop\\"+filename+".csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(tracks);
        }

        return "funcionou";
    }

    static List<Track> ExibirCSV(string filename)
    {
        var records = new List<Track>();
        using (var reader = new StreamReader("C:\\Users\\Rick\\Desktop\\"+filename+".csv"))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            records = csv.GetRecords<Track>().ToList();
            var flow = true;

        }
        return records;

    }

    static void ExibirMensagemDeboasvindas()
    {
        string boasVindas = "\nBoas vindas ao Trance Screen Sound!";
        Console.WriteLine("\r\n████████╗██████╗░░█████╗░███╗░░██╗░█████╗░███████╗  ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗\r\n╚══██╔══╝██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔════╝  ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║\r\n░░░██║░░░██████╔╝███████║██╔██╗██║██║░░╚═╝█████╗░░  ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║\r\n░░░██║░░░██╔══██╗██╔══██║██║╚████║██║░░██╗██╔══╝░░  ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║\r\n░░░██║░░░██║░░██║██║░░██║██║░╚███║╚█████╔╝███████╗  ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║\r\n░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝░╚════╝░╚══════╝  ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝\r\n\r\n░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░\r\n██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗\r\n╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║\r\n░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║\r\n██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝\r\n╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
        Console.WriteLine(boasVindas);
    }

    static void ExibirOpcoesDoMenu()
    {
        while (true)
        {
            Console.Clear(); // Limpa a tela antes de exibir o logo e as opções
            ExibirMensagemDeboasvindas(); // Exibe o logo no topo

            Console.WriteLine("\nDigite 1 para registrar uma Track");
            Console.WriteLine("Digite 2 para mostrar todas as Tracks");
            Console.WriteLine("Digite 3 para avaliar uma Track");
            Console.WriteLine("Digite 4 para exibir a avaliação de uma Track");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica;

            if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica))
            {
                switch (opcaoEscolhidaNumerica)
                {
                    case 1:
                        RegistrarTrack();
                        break;
                    case 2:
                        MostrarTracksRegistradas();
                        break;
                    case 3:
                        Console.WriteLine("Você escolheu a opção " + opcaoEscolhida);
                        break;
                    case 4:
                        Console.WriteLine("Você escolheu a opção " + opcaoEscolhida);
                        break;
                    case -1:
                        Console.WriteLine("Saindo do programa...");
                        return; // Sai do método, encerrando o loop e o programa
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número.");
            }
        }
    }

    static void RegistrarTrack()
    {

        Console.Clear(); // Limpa a tela antes de exibir o registro de projeto
        ExibirMensagemDeboasvindas(); // Exibe o logo no topo

        Console.WriteLine("Registro de Track");
        Console.Write("Digite o nome da Track que deseja registrar: ");
        var track = new Track() { Name = "terste" };
        var filename = "novo";

        var teste = EditarCSV(track, "fodase");
        Console.WriteLine($"A Track {track} foi registrada com sucesso ");
        Thread.Sleep(1000);
    }

    static void MostrarTracksRegistradas()
    {
        string nomedocsv = Console.ReadLine()!;

        var Tracks = ExibirCSV(nomedocsv);
        Console.Clear();
        Console.WriteLine("************\n");
        Console.WriteLine("Exibindo as Tracks registradas:");
        Console.WriteLine("************\n");

        foreach (var item in Tracks)
        {
            Console.WriteLine(item.Id + " - " + item.Name);
        }

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu inicial.");
        Console.ReadKey();
    }
}