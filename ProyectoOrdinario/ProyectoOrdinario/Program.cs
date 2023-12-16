using ProyectoOrdinario.Enumeradores;
using ProyectoOrdinario.Interfaces;
using System;
using System.Collections.Generic;

namespace ProyectoOrdinario
{
    class Program
    {

        static void Main(string[] args)
        {

            List<Carta> DeckLista = new List<Carta>();

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    DeckLista.Add(new Carta(j, i));
                }
            }

            foreach (Carta c in DeckLista)
            {
                Console.WriteLine(c);
            }
        }
    }
    public class DeckDeCartas : IDeckDeCartas
    {
        public void BarajearDeck()
        {
            Console.WriteLine("aa");
        }

        public ICarta VerCarta(int indiceCarta)
        {
            return new Carta(1,2);
        }

        public ICarta SacarCarta(int indiceCarta)
        {
            return new Carta(1,2);
        }
        public void MeterCarta(ICarta carta)
        {

        }
        public void MeterCarta(List<Carta> DeckLista)
        {
            Console.WriteLine("");
        }
        public void MeterCarta(List<ICarta> cartas)
        {

        }

    }
    public class Carta : ICarta
    {
        private ValoresCartasEnum _valor;
        public ValoresCartasEnum Valor
        {
            get { return _valor; }
            set
            {
                if ((int)value < 1 || (int)value > 13) throw new Exception("El valor de la carta debe ser entre 1 y 13.");
                _valor = value;
            }
        }

        private FigurasCartasEnum _figura;
        public FigurasCartasEnum Figura
        {
            get { return _figura; }
            set
            {
                if ((int)value < 0 || (int)value > 3) throw new Exception("El valor de la figura debe ser entre 0 y 3.");
                _figura = value;
            }
        }

        public Carta(ValoresCartasEnum valor, FigurasCartasEnum figura)
        {
            this.Valor = valor;
            this.Figura = figura;
        }
        public Carta(int valor, int figura)
        {
            this.Valor = (ValoresCartasEnum)valor;
            this.Figura = (FigurasCartasEnum)figura;
        }
        public override string ToString()
        {
            return $"{this.Valor} de {this.Figura}";
        }
    }
}