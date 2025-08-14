using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeCadastro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ListaAlunos = new List<string>();
            ListaAlunos.Add("João, 20 anos");
            ListaAlunos.Add("Maria, 22 anos");
            ListaAlunos.Add("José, 19 anos");

            int opcao = 0;
            string caminhoArquivo = "alunos.txt";
            if (File.Exists(caminhoArquivo))
            {
                ListaAlunos = new List<string>(File.ReadAllLines(caminhoArquivo)).ToList();
            }
            do
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Cadastro de Alunos ===\n");
                Console.WriteLine("1 - Listar Alunos");
                Console.WriteLine("2 - Cadastrar Aluno");
                Console.WriteLine("3 - Editar Aluno");
                Console.WriteLine("4 - Excluir Aluno");
                Console.WriteLine("5 - Sair");
                Console.Write("\nEscolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();

                if (opcao == 1)
                {
                    Console.WriteLine("=== Lista de Alunos ===");
                    for (int i = 0; i < ListaAlunos.Count; i++)
                    {
                        Console.WriteLine($"Id {i + 1} - {ListaAlunos[i]}");
                    }
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                }
                else if (opcao == 2)
                {
                    Console.Write("Digite o nome do aluno: ");
                    string NomeAluno = Console.ReadLine();
                    Console.Write("Digite a idade do aluno: ");
                    int IdadeAluno = int.Parse(Console.ReadLine());
                    ListaAlunos.Add($"{NomeAluno}, {IdadeAluno} anos");
                    File.WriteAllLines(caminhoArquivo, ListaAlunos);
                    Console.WriteLine($"\nAluno {NomeAluno} cadastrado com sucesso!");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("=== Lista de Alunos ===");
                    for (int i = 0; i < ListaAlunos.Count; i++)
                    {
                        Console.WriteLine($"Id {i + 1} - {ListaAlunos[i]}");
                    }
                    Console.Write("\nDigite o ID do aluno que deseja editar: ");
                    int IdAluno = int.Parse(Console.ReadLine());
                    int Id = IdAluno - 1;

                    if (IdAluno <= 0 || Id >= ListaAlunos.Count)
                    {
                        Console.WriteLine("\nID inválido.");
                    }
                    else
                    {
                        Console.Write("Digite o novo nome do aluno: ");
                        string NovoNomeAluno = Console.ReadLine();
                        Console.Write("Digite a nova idade do aluno: ");
                        int NovaIdadeAluno = int.Parse(Console.ReadLine());
                        ListaAlunos[Id] = $"{NovoNomeAluno}, {NovaIdadeAluno} anos";
                        File.WriteAllLines(caminhoArquivo, ListaAlunos);
                        Console.WriteLine($"\nAluno atualizado com sucesso!");
                    }
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
                else if (opcao == 4)
                {
                    Console.WriteLine("=== Lista de Alunos ===");
                    for (int i = 0; i < ListaAlunos.Count; i++)
                    {
                        Console.WriteLine($"Id {i + 1} - {ListaAlunos[i]}");
                    }
                    Console.Write("\nDigite o ID do aluno que deseja excluir: ");
                    int IdAlunoExcluir = int.Parse(Console.ReadLine());
                    int IdExcluir = IdAlunoExcluir - 1;

                    if (IdExcluir >= 0 && IdExcluir < ListaAlunos.Count)
                    {
                        string alunoExcluido = ListaAlunos[IdExcluir];
                        ListaAlunos.RemoveAt(IdExcluir);
                        File.WriteAllLines(caminhoArquivo, ListaAlunos);
                        Console.WriteLine($"\nAluno {alunoExcluido} excluído com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\nID inválido.");
                    }
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
                else if (opcao == 5)
                {
                    Console.WriteLine("Saindo do sistema...");
                }
                else
                {
                    Console.WriteLine("Opção inválida, tente novamente.");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcao != 5);
        }
    }
}
