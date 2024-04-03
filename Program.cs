using System;
using System.Collections.Generic;
using System.IO;

namespace ListaDeCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Programa de Lista de Compras!");

            while (true)
            {
                Console.WriteLine("\nOpções:");
                Console.WriteLine("1. Criar nova lista de compras");
                Console.WriteLine("2. Listar itens da lista de compras");
                Console.WriteLine("3. Sair");
                Console.Write("Digite o número da opção desejada: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        CriarLista();
                        break;
                    case "2":
                        ListarLista();
                        break;
                    case "3":
                        Console.WriteLine("Obrigado por usar o Programa de Lista de Compras!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Digite 1, 2 ou 3.");
                        break;
                }
            }
        }

        static void CriarLista()
        {
            List<string> lista = new List<string>();
            while (true)
            {
                Console.Write("Digite o nome do item (ou 'sair' para encerrar): ");
                string item = Console.ReadLine();
                if (item.ToLower() == "sair")
                    break;
                lista.Add(item);
            }

            
            File.WriteAllLines("lista_de_compras.txt", lista);

            Console.WriteLine("Lista de compras criada e salva com sucesso!");
        }

        static void ListarLista()
        {
            try
            {
                string[] lista = File.ReadAllLines("lista_de_compras.txt");
                if (lista.Length == 0)
                    Console.WriteLine("A lista de compras está vazia.");
                else
                {
                    Console.WriteLine("Itens na lista de compras:");
                    foreach (string item in lista)
                        Console.WriteLine(item);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ainda não há uma lista de compras criada.");
            }
        }
    }
}
