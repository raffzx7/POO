using System;

namespace POO
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Uso da classe Animal
            Animal animalGenerico = new Animal("Animal Genérico");
            animalGenerico.EmitirSom(); // Exibe "Som genérico de animal"
            Console.WriteLine($"Nome do animal: {animalGenerico.Nome}");

            // Uso da classe Cachorro
            Cachorro meuCao = new Cachorro("Rex");
            meuCao.EmitirSom();  // Herdado da classe base (Animal)
            meuCao.Latir();      // Método específico da classe Cachorro
            Console.WriteLine($"Nome do cachorro: {meuCao.Nome}");

            // Testando a propriedade Idade
            meuCao.Idade = 5; // Atribui idade válida
            Console.WriteLine($"Idade do cachorro: {meuCao.Idade} anos");

            meuCao.Idade = -3; // Tenta atribuir idade inválida
            Console.WriteLine($"Idade do cachorro após tentativa inválida: {meuCao.Idade} anos");

            // Testando o encapsulamento do peso
            meuCao.DefinirPeso(15.5); // Define o peso
            Console.WriteLine($"Peso do cachorro: {meuCao.ObterPeso()} kg");

            meuCao.DefinirPeso(-10); // Tenta definir peso inválido
            Console.WriteLine($"Peso do cachorro após tentativa inválida: {meuCao.ObterPeso()} kg");

            // Uso da classe Gato
            Animal animal = new Gato("Mimi");
            animal.EmitirSom(); // "Miau!" - Polimorfismo em ação
            Console.WriteLine($"Nome do gato: {animal.Nome}");

            // Uso da classe Humano
            Humano humano = new Humano("João");
            humano.EmitirSom(); // Herdado da classe base (Animal)
            humano.Amamentar();  // Método específico da classe Humano
            Console.WriteLine($"Nome do humano: {humano.Nome}");

            // Uso da interface INadador
            INadador nadador = new Cachorro("Bob");
            nadador.Nadar(); // Exibe "Bob está nadando!"

            Console.Write("Pressione qualquer tecla para continuar...");
            Console.ReadKey(true);
        }

        public class Animal
        {
            private int _idade; // Campo privado encapsulado
            public int Idade
            {
                get => _idade;
                set => _idade = value >= 0 ? value : 0; // Validação: idade não pode ser negativa
            }
            public string Nome { get; set; }

            // Construtor da classe Animal
            public Animal(string nome)
            {
                Nome = nome;
            }

            // Método para emitir som genérico (marcado como virtual para permitir sobrescrita)
            public virtual void EmitirSom()
            {
                Console.WriteLine("Som genérico de animal");
            }
        }

        public class Cachorro : Animal, INadador
        {
            private double _peso; // Campo privado encapsulado

            // Construtor da classe Cachorro
            public Cachorro(string nome) : base(nome) { }

            // Método específico da classe Cachorro
            public void Latir()
            {
                Console.WriteLine("Au Au!");
            }

            // Implementação da interface INadador
            public void Nadar()
            {
                Console.WriteLine($"{Nome} está nadando!");
            }

            // Método público para definir o peso (com validação)
            public void DefinirPeso(double peso)
            {
                if (peso > 0)
                {
                    _peso = peso;
                }
                else
                {
                    Console.WriteLine("Peso inválido! O peso deve ser maior que zero.");
                }
            }

            // Método público para obter o peso
            public double ObterPeso()
            {
                return _peso;
            }
        }

        public class Gato : Animal
        {
            // Construtor da classe Gato
            public Gato(string nome) : base(nome) { }

            // Sobrescreve o método EmitirSom da classe base
            public override void EmitirSom()
            {
                Console.WriteLine("Miau!");
            }
        }

        public abstract class Mamifero : Animal
        {
            // Construtor da classe Mamifero
            public Mamifero(string nome) : base(nome) { }

            // Método abstrato que deve ser implementado pelas classes derivadas
            public abstract void Amamentar();
        }

        public class Humano : Mamifero
        {
            // Construtor da classe Humano
            public Humano(string nome) : base(nome) { }

            // Implementação do método abstrato Amamentar
            public override void Amamentar()
            {
                Console.WriteLine("Amamentando bebê");
            }
        }

        // Interface para animais que podem nadar
        public interface INadador
        {
            void Nadar();
        }
    }
}
