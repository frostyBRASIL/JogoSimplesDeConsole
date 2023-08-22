using System;

namespace JogoSimplesDeConsole
{
    public class Jogador
        {
            public string Nome;
            public bool Vivo;
            public int Vida;
            public bool Atacar;
            public bool EscolhaAtaque;
            public Random ForcaAtaque;
            public bool EscolhaAtaqueEsp;
            public Random ForcaAtaqueEsp;
            public int QuantBrasoes;
            public bool TemBrasoes;

            public Jogador()
            {
                Vivo = true;
                Vida = 150;
                
                Atacar = true;
    
                EscolhaAtaque = true;
                ForcaAtaque = new Random();
    
                EscolhaAtaqueEsp = false;
                ForcaAtaqueEsp = new Random();
    
                QuantBrasoes = 19;
                TemBrasoes = true;
            }
    
        }
    
        public class Boss
        {
            public string Nome;
            public double Vida;
            public bool Vivo;
            public bool Atacar;
            public Random ForcaAtaque;
            public int Fases;
            public bool PriFase;
            public bool SegFase;

            public Boss()
            {
                Nome = "Inimigo";
    
                Vida = 300;
                Vivo = true;
    
                Atacar = true;
                Random ForcaAtaque = new Random();
    
                Fases = 2;
                PriFase = true;
                SegFase = false;
            }
        }
    
    
    class Principal
    {
        static void SistemaAtaqueJ(Jogador j1, Boss boss) // Função que define o sistema de ataque do jogador
        {
            Console.Clear();
            j1.EscolhaAtaque = true;
            j1.EscolhaAtaqueEsp = false;
            j1.QuantBrasoes -= 2;
    
            Console.WriteLine("-----------------------------------------");
    
            object atq = j1.ForcaAtaque.Next(0, 50);
    
            Console.WriteLine($"Ótimo, você causou {atq} de dano");
            Console.WriteLine($"{boss.Nome} teve a vida reduzida para: {boss.Vida - Convert.ToDouble(atq)}");
            Console.WriteLine("|-----------------------------------------|");
        }
        static void SistemaAtaqueEsp(Jogador j1, Boss boss) // Função que define o sistema de ataque especial do jogador
        {
            Console.Clear();
            j1.EscolhaAtaque = false;
            j1.EscolhaAtaqueEsp = true;
            j1.QuantBrasoes -= 4;
    
            Console.WriteLine("-----------------------------------------");
    
            object atq = j1.ForcaAtaque.Next(60, 150);
    
            Console.WriteLine($"Ótimo, você causou {atq} de dano");
            Console.WriteLine($"Seus brasões espírituais foram para: {j1.QuantBrasoes}");
            Console.WriteLine($"{boss.Nome} teve a vida reduzida para: {boss.Vida - Convert.ToDouble(atq)}");
            Console.WriteLine("|-----------------------------------------|");
        }
        static void SistemaDefesa(Jogador j1, Boss boss) // Função qye defibe o sistema de defesa do jogador
        {
            Console.Clear();
            object atqBoss = j1.ForcaAtaque.Next(40);
            j1.Vida = j1.Vida - Convert.ToInt32(atqBoss);
    
            Console.WriteLine($"Você defendeu e sofreu menos do dano total. Você ainda tem {j1.Vida} de vida.");
            Console.WriteLine($"Dano recebido: {atqBoss}");
            Console.WriteLine("-----------------------------------------");
    
        }
    
        static void Main()
        {
            // new reserva a memória e retorna o endereço da memória alocado para determinado obj
            Jogador j1 = new Jogador();
            Boss b1 = new Boss();
    
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("|  Olá, bem vindo ao Jogo de Console de turnos!\t\t|");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
    
            Console.Write("Escolha seu nome: ");
            j1.Nome = Console.ReadLine();
    
            inicio:
    
            Console.Clear();
            
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine($"|\tOs atributos do {b1.Nome} são:\t\t|");
            Console.WriteLine($"|\tVida.....: {j1.Vida}\t\t\t\t|");
            Console.WriteLine($"|\tForça do ataque.....: 40\t\t| ");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine($"|\tSeus atributos são:\t\t\t|");
            Console.WriteLine($"|\tVida.....: {b1.Vida}\t\t\t\t|");
            Console.WriteLine($"|\tQuantidade de brasões.....: {j1.QuantBrasoes}\t\t|");
            Console.WriteLine($"|\tAtaque.....: 0 - 50\t\t\t|");
            Console.WriteLine($"|\tAtaque Especial.....: 60 - 150\t\t|");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            
            Console.WriteLine($"{j1.Nome}, a batalha começou, deseja atacar {b1.Nome}?");
            Console.WriteLine("(S/N)");
            string atacar = Console.ReadLine();
    
            //Definindo as possiveis opções
            if (atacar.StartsWith("s")  || atacar.StartsWith("S"))
            {
                j1.EscolhaAtaque = j1.EscolhaAtaque;
    
                comecoataque:
    
                Console.Clear();
                Console.WriteLine($"\nVocê possui {j1.QuantBrasoes} brasões");
                Console.WriteLine($"{j1.Nome}, qual ataque você gostaria de usar?");
                Console.WriteLine("(1) Ataque (Custo de brasões: 2) | (2) Ataque Especial (Custo de brasões: 4)");
                string tipoAtaque = Console.ReadLine();
    
                if (tipoAtaque.StartsWith("1"))
                {
                    SistemaAtaqueJ(j1, b1);
                }
                else if (tipoAtaque.StartsWith("2"))
                {
                    SistemaAtaqueEsp(j1, b1);
                }
                else
                {
                    goto comecoataque; // Vá para o começo das opções de ataque
                }
    
            }
            else if (atacar.StartsWith("n") || atacar.StartsWith("N"))
            {
                j1.Atacar = false;
                SistemaDefesa(j1, b1);
            }
            else
            {
                goto inicio; //Vá para o inicio
            }
        }
    }
}