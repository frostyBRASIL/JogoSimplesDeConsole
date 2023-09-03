using System;

namespace JogoSimplesDeConsole
{
    public class Atributos
    {
        public string nome;
        public bool vivo;
        public int vida;
        public int ataque;
        public bool atacar;
        public Random ForcaAtaque;
        
    }

    public class Jogador : Atributos
    {
        public bool escolhaAtaque;
        public bool EscolhaAtaqueEsp;
        public Random ForcaAtaqueEsp;
        public int QuantBrasoes;
        protected bool TemBrasoes;

        public Jogador()
        {
            vivo = true;
            vida = 150;
            Random ataque = new Random();
            escolhaAtaque = true;
            ForcaAtaque = new Random();
            EscolhaAtaqueEsp = false;
            ForcaAtaqueEsp = new Random();
            QuantBrasoes = 19;
            TemBrasoes = true;
        }
    }
        public class Boss : Atributos
        {
            public Random ForcaAtaque;
            public int Fases;
            public bool PriFase;
            protected bool SegFase;

            public Boss()
            {
                nome = "Joãozinho";
                vida = 300;
                vivo = true;
                atacar = true;
                Random ForcaAtaque = new Random();
                Fases = 2;
                PriFase = true;
            }
        }

    class Principal
    {
        static void SistemaAtaqueJ(Jogador j1, Boss boss) // Função que define o sistema de ataque do jogador
        {
            Console.Clear();
            j1.escolhaAtaque = true;
            j1.EscolhaAtaqueEsp = false;
            j1.QuantBrasoes -= 2;
    
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
    
            object atq = j1.ForcaAtaque.Next(10, 50);
    
            Console.WriteLine($"Ótimo, você causou {atq} de dano");
            Console.WriteLine($"{boss.nome} teve a vida reduzida para: {boss.vida - Convert.ToDouble(atq)}");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        }
        static void SistemaAtaqueEsp(Jogador j1, Boss boss) // Função que define o sistema de ataque especial do jogador
        {
            Console.Clear();
            j1.escolhaAtaque = false;
            j1.EscolhaAtaqueEsp = true;
            j1.QuantBrasoes -= 4;
    
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
    
            object atq = j1.ForcaAtaque.Next(60, 150);
    
            Console.WriteLine($"Ótimo, você causou {atq} de dano");
            Console.WriteLine($"Seus brasões espírituais foram para: {j1.QuantBrasoes}");
            Console.WriteLine($"{boss.nome} teve a vida reduzida para: {boss.vida - Convert.ToDouble(atq)}");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        }
        static void SistemaDefesa(Jogador j1, Boss boss) // Função qye defibe o sistema de defesa do jogador
        {
            Console.Clear();
            object atqBoss = j1.ForcaAtaque.Next(40);
            j1.vida = j1.vida - Convert.ToInt32(atqBoss);
    
            Console.WriteLine($"Você defendeu e sofreu menos do dano total. Você ainda tem {j1.vida} de vida.");
            Console.WriteLine($"Dano recebido: {atqBoss}");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
    
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
            j1.nome = Console.ReadLine();
    
            inicio:
    
            Console.Clear();
            
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine($"|\tOs atributos do {b1.nome} são:\t\t|");
            Console.WriteLine($"|\tVida................: {j1.vida}\t\t|");
            Console.WriteLine($"|\tForça do ataque.....: 40\t\t| ");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine($"|\tSeus atributos são:\t\t\t|");
            Console.WriteLine($"|\tVida......................: {b1.vida}\t\t|");
            Console.WriteLine($"|\tQuantidade de brasões.....: {j1.QuantBrasoes}\t\t|");
            Console.WriteLine($"|\tAtaque....................: 10 - 50\t|");
            Console.WriteLine($"|\tAtaque Especial...........: 60 - 150\t|");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            
            Console.WriteLine($"{j1.nome}, a batalha começou, deseja atacar {b1.nome}?");
            Console.WriteLine("(S/N)");
            string atacar = Console.ReadLine();
    
            //Definindo as possiveis opções
            if (atacar.StartsWith("s")  || atacar.StartsWith("S"))
            {
                j1.escolhaAtaque = j1.escolhaAtaque;
    
                comecoataque:
    
                Console.Clear();
                Console.WriteLine($"\nVocê possui {j1.QuantBrasoes} brasões");
                Console.WriteLine($"{j1.nome}, qual ataque você gostaria de usar?");
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
                j1.atacar = false;
                SistemaDefesa(j1, b1);
            }
            else
            {
                goto inicio; //Vá para o inicio
            }
        }
    }
}
