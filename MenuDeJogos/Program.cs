using System;
using System.Threading;

namespace Jogo2Players
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(48, 0);
                Console.Write("► Menu De Jogos ◄");
                Console.SetCursorPosition(0, 1);
                Console.Write(new string('_', 120));
                Console.SetCursorPosition(45, 3);
                Console.Write("→ 1. | Jogo Um Player |");
                Console.SetCursorPosition(45, 4);
                Console.Write("→ 2. | Jogo Dois Players |");
                Console.SetCursorPosition(45, 5);

                Console.SetCursorPosition(0, 6);
                Console.Write(new string('=', 120));
                Console.SetCursorPosition(0, 8);
                Console.Write(new string('=', 120));
                Console.SetCursorPosition(47, 7);
                Console.Write("Digite sua opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:

                        UmPlayer();
                        break;

                    case 2:

                        DoisPlayers();
                        break;

                    default:

                        Console.SetCursorPosition(46, 20);
                        Console.Write("[*OPÇÃO INVALIDA*]");
                        Console.ReadKey(); //pausa
                        break;


                }


            } while (opcao != 5);

        }

        static void UmPlayer()
        {

            Random sorteio = new Random();
            int numsorteado, numdeazar;
            string resp;

            do
            {
                Console.Clear();

                Thread.Sleep(1000);
                Console.WriteLine("Olá! Sejá bem vindo(a) ao jogo de adivinhação.\n");
                Thread.Sleep(1000);
                Console.WriteLine("No jogo há apenas uma regra, utilizar números de 1 a 10.");
                Thread.Sleep(1000);
                Console.WriteLine("\nBom... Vamos começar!");
                Thread.Sleep(1000);
                Console.WriteLine(new string('_', 120));
                Console.Write("\nInsira aqui a sua aposta e boa sorte: ");
                Thread.Sleep(1000);

                numdeazar = int.Parse(Console.ReadLine());
                numsorteado = sorteio.Next(1, 10);

                do
                {

                    if (numdeazar == numsorteado)
                    {
                        Console.WriteLine(new string('_', 120));
                        Console.WriteLine("\nParabéns! Você acertou.");
                        Thread.Sleep(1000);
                        Console.WriteLine(new string('_', 120));
                        Console.WriteLine("\nVocê deseja jogar novamente?");
                        resp = Console.ReadLine();
                        Console.Clear();
                    }

                    if (numdeazar > 10 || numdeazar < 1)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("\nErro!");
                    }

                    else
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("\nPoxa, não foi dessa vez.\n");

                        if (numsorteado > numdeazar)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("O número sorteado é maior que " + numdeazar);
                            Thread.Sleep(1000);
                        }

                        else
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("o número sorteado é menor que " + numdeazar);
                            Thread.Sleep(1000);
                        }

                    }

                    Console.WriteLine(new string('_', 120));
                    Console.Write("\nDigite outro número: ");
                    numdeazar = int.Parse(Console.ReadLine());

                } while (numsorteado != numdeazar);

                if (numdeazar == numsorteado)
                {

                    Console.WriteLine("\nParabéns! Você acertou.");
                    Thread.Sleep(1000);

                }

                Thread.Sleep(1000);
                Console.WriteLine(new string('_', 120));
                Console.Write("\nVocê deseja jogar novamente? ");
                resp = Console.ReadLine();
                Console.Clear();

            } while (resp == "Sim" || resp == "sim" || resp == "S" || resp == "s");

        }

        static void DoisPlayers()
        {
            int numS = 0, numA, rodadaPUm = 0, rodadaPDois = 0, atual = 2;
            string resp;

            do
            {
                Console.Clear();
                Random sorteio = new Random();

                Thread.Sleep(1000);
                Console.WriteLine("Olá! Bem vindos ao jogo de adivinhação.");
                Thread.Sleep(1000);
                Console.WriteLine("\nO jogo tem apenas uma regra, você só pode digitar números de 1 a 10.");
                Thread.Sleep(1000);
                Console.WriteLine("\nBom... Vamos começar!");
                numS = sorteio.Next(1, 10);

                do
                {
                    Thread.Sleep(1000);

                    if (atual == 2)
                    {
                        rodadaPUm += 1;
                        Console.WriteLine(new string('_', 120));
                        Console.Write("\r\nJogador Um, digite o número adivinhado: ");
                        numA = int.Parse(Console.ReadLine());
                        atual = 1;
                    }

                    else
                    {
                        rodadaPDois += 1;
                        Console.WriteLine(new string('_', 120));
                        Console.Write("\r\nJogador Dois, digite o número adivinhado: ");
                        numA = int.Parse(Console.ReadLine());
                        atual = 2;
                    }

                    if (numA > 10 || numA < 1)
                    {
                        Console.WriteLine("\nErro!");
                    }

                    else
                    {

                        if (numS > numA)
                        {
                            Console.WriteLine("\nPoxa, não foi dessa vez!\n");
                            Thread.Sleep(1000);
                            Console.WriteLine("O número sorteado é maior que " + numA);
                        }

                        else if (numS < numA)
                        {
                            Console.WriteLine("\nPoxa, não foi dessa vez!\n");
                            Thread.Sleep(1000);
                            Console.WriteLine("O número sorteado é menor que " + numA);
                        }
                    }
                } while (numS != numA);



                if (atual == 1)
                {
                    Console.WriteLine(new string('_', 120));
                    Console.WriteLine("\r\nParabéns Player Um! Você acertou na sua " + rodadaPUm + "ª tentativa!");
                    Thread.Sleep(1000);
                    Console.WriteLine(new string('_', 120));
                    Console.Write("\nVocê deseja jogar novamente? ");

                }
                else if (atual == 2)
                {
                    Console.WriteLine("\r\nParabéns Player Dois! Você acertou na sua " + rodadaPDois + "ª tentativa!");
                    Thread.Sleep(1000);
                    Console.WriteLine(new string('_', 120));
                    Console.Write("\nVocê deseja jogar novamente? ");

                }
                resp = Console.ReadLine();

            } while (resp == "Sim" || resp == "sim" || resp == "S" || resp == "s");
        }
    }

}