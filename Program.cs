using System;
using DIO.Series.Data;
using DIO.Series.Enums;
using DIO.Series.Models;

namespace DIO.Series
{
    class Program
    {
        static readonly TVSeriesRepository repository = new TVSeriesRepository();

        static void Main(string[] args)
        {
            string userOption;

            while ((userOption = GetUserOption()) != "X")
            {
                switch (userOption)
                {
                    case "1": ListTVSeries(); break;
                    case "2": InsertTVSeries(); break;
                    case "3": UpdateTVSeries(); break;
                    case "4": DeleteTVSeries(); break;
                    case "5": GetTVSeries(); break;
                    case "C": Console.Clear(); break;
                    default: throw new ArgumentOutOfRangeException(); 
                };
            }
        }

        private static void ListTVSeries()
        {
            Console.WriteLine("Listar séries");

            var listTvSeries =  repository.List();

            if (listTvSeries.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var tvSeries in listTvSeries)
            {
                Console.WriteLine($"ID {tvSeries.Id}: {tvSeries.Title}");
            }
        }

        private static void InsertTVSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int.TryParse(Console.ReadLine(), out int genre);

            Console.Write("Digite o título da série: ");
            string title = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int.TryParse(Console.ReadLine(), out int year);

            Console.Write("Digite a descrição da série: ");
            string description = Console.ReadLine();

            TVSeries tvSeries = new TVSeries(
                id: repository.NextID(),
                genre: (Genre)genre,
                title: title,
                year: year,
                description: description
            );

            repository.Insert(tvSeries);
        }
        
        private static void  UpdateTVSeries()
        {
            Console.Write("Digite o id da série: ");
            int.TryParse(Console.ReadLine(), out int id);

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }
            
            Console.Write("Digite o gênero entre as opções acima: ");
            int.TryParse(Console.ReadLine(), out int genre);

            Console.Write("Digite o título da série: ");
            string title = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int.TryParse(Console.ReadLine(), out int year);

            Console.Write("Digite a descrição da série: ");
            string description = Console.ReadLine();
            
            TVSeries updatedTvSeries = new TVSeries(
                id: id,
                genre: (Genre)genre,
                title: title,
                year: year,
                description: description
            );

            repository.Update(id, updatedTvSeries);
        }

        private static void DeleteTVSeries()
        {
            Console.Write("Digite o id da série: ");
            bool converted = int.TryParse(Console.ReadLine(), out int id);

            if (!converted) return;

            repository.Delete(id);
        }

        private static void GetTVSeries()
        {
            Console.Write("Digite o id da série: ");
            int.TryParse(Console.ReadLine(), out int id);

            var tvSeries = repository.GetById(id);

            Console.WriteLine(tvSeries);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        } 
    }
}
