using System;
using System.Threading.Tasks;

// Software para ajudar a aprender inglês com ajuda de IA
namespace DuoCraft
{
    internal class Program
    {
        // A sua chave de API gerada no Google AI Studio
        private static readonly string apiKey = "Insira sua chave API";

        static async Task Main(string[] args)
        {
            double option = 0;

            while (option != 2)
            {
                option = DuoMain();

                switch (option)
                {
                    case 1:
                        await GeminiSuport(); // Inicia o Suporte de linguagem
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Saindo da aplicação"); // Aviso de saída da aplicação
                        break;
                }
            }

            Console.ReadLine();
        }

        static double DuoMain() // Menu inicial
        {
            Console.Clear();

            Console.WriteLine("Ensino de inglês por IA");
            Console.WriteLine();
            Console.WriteLine("Selecione uma opção: ");

            Console.WriteLine("01 - Aprenda inglês através do suporte por IA (Google Gemini)");
            Console.WriteLine("02 - Saia da aplicação");
            Console.WriteLine();
            Console.Write("Selecione sua opção: ");
            double.TryParse(Console.ReadLine(), out double escolha);
            return escolha;
        }

        static async Task GeminiSuport() // Método responsável pelo ensino de inglês através do Gemini
        {
            Console.Clear();

            Console.WriteLine("=== SUPORTE DE INGLÊS COM GOOGLE GEMINI ===");
            Console.WriteLine("Digite a frase ou dúvida em português:");
            Console.WriteLine("(Digite 'voltar' para retornar ao menu inicial)\n");

            Console.Write("> ");
            string entradaAluno = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entradaAluno) || entradaAluno.ToLower() == "voltar")
            {
                return;
            }

            Console.WriteLine("\n[Consultando o Gemini IA... Aguarde um instante]\n");

            string prompt = $"Você é um professor e tutor de inglês especializado em ajudar alunos brasileiros. " +
                           $"O aluno enviou a seguinte dúvida ou texto em português: '{entradaAluno}'. " +
                           $"Explique o conceito em inglês correspondente, dê exemplos práticos de uso e tire a dúvida de forma clara e didática.";

            try
            {
                // Chamada oficial utilizando o SDK Google.GenAI instalado
                var client = new Google.GenAI.Client(apiKey: apiKey);
                var response = await client.Models.GenerateContentAsync(
                    model: "gemini-3.8-flash",
                    contents: prompt
                );

                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("RESPOSTA DO PROFESSOR IA:");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine(response.Text);
                Console.WriteLine("--------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na consulta: {ex.Message}");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}