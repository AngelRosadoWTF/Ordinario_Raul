using ProyectoOrdinario.Enumeradores;
using ProyectoOrdinario.Interfaces;

namespace ProyectoOrdinario
{
    class Program
    {
        static void Main()
        {
            DeckDeCartas deckDeCartas = new DeckDeCartas();
            #region Crear 7 Jugadores
            Jugador jugador1 = new Jugador();
            Jugador jugador2 = new Jugador();
            Jugador jugador3 = new Jugador();
            Jugador jugador4 = new Jugador();
            Jugador jugador5 = new Jugador();
            Jugador jugador6 = new Jugador();
            Jugador jugador7 = new Jugador();
            #endregion


            SeleccionJuego();
        }
        public static void SeleccionJuego()
        {
            var Juego = new Juego();
            Console.WriteLine("Bienvenido! que le gustaria jugar hoy? [ 1) Poker  2) Blackjack  3) Salir ]");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine("poker aun no implementado.");
                        SeleccionJuego();
                        break;
                    }
                case "2":
                    {
                        Juego.ObtenerJugadoresYNombres();
                        Juego.MostrarPuntuaje();
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Hasta la proxima.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Seleccion invalida.");
                        Console.WriteLine("---\n");
                        SeleccionJuego();
                        break;
                    }
            }
        }

        #region "parte comentada que no se para que es xd"
        /*while (true)
        {
            try
            {
                deckDeCartas.LeerCartas();
                string? seleccionInicial = Console.ReadLine();

                if (seleccionInicial == "rand")
                {
                    deckDeCartas.BarajearDeck();
                    Console.WriteLine("El deck a sido barajeado.");
                }
                else
                {
                    int seleccionInicialNum = Convert.ToInt32(seleccionInicial) - 1;
                    Console.WriteLine(deckDeCartas.VerCarta(Convert.ToInt32(seleccionInicialNum)));
                    Console.WriteLine();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Numero fuera del rango. El numero tiene que ser entre 1 y 51.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"El numero es demasiado grande. El numero tiene que estar entre 1 y 51.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Inserte unicamente numeros.");
            }
        }*/
        #endregion
    }
}

//Propiedades basicas del juego
public class Juego
{
    // Variables básicas del juego
    int NumJugadores;
    string[] NombresJugadores = new string[7];
    IDealer Dealer { get; }
    bool JuegoTerminado { get; }

    // Acciones que pueden pasar en el juego
    void AgregarJugador(IJugador jugador)
    {

    }
    void IniciarJuego()
    {

    }
    void JugarRonda()
    {

    }
    void MostrarGanador()
    {

        Console.WriteLine("El ganador es : " + NombresJugadores);
    }

    //Iniciador del juego
    public void ObtenerJugadoresYNombres()
    {
        Console.WriteLine("Cuantos jugadores?");
        try
        {
            NumJugadores = Convert.ToInt32(Console.ReadLine());
            if (NumJugadores > 7 || NumJugadores < 1)
            {
                Console.WriteLine("El numero tiene que ser entre 1 y 7.");
                Console.WriteLine("---\n");
                ObtenerJugadoresYNombres();
            }
            else
            {
                for (int i = 0; i < NumJugadores; i++)
                {
                    Console.WriteLine("Ingrese el nombre del jugador #" + (i + 1));
                    NombresJugadores[i] = Console.ReadLine();
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Inserte solamente numeros.");
            Console.WriteLine("---\n");
            ObtenerJugadoresYNombres();
        }
    }

    // Imprime el puntaje de cada jugador
    public void MostrarPuntuaje()
    {
        Console.WriteLine("\n-= Puntuaje actual =-");
        for (int i = 0; i < NumJugadores; i++)
        {
            Console.WriteLine($"{NombresJugadores[i]} - Puntos");
        }
        Console.WriteLine("-=   Ronda : #1    =-\n");
    }
}

// Objeto jugador
public class Jugador
{
    // Región que crea una lista que contiene las cartas por cada jugador
    #region Crear Manos Jugadores 1-7
    public List<Carta> ManoJugador1 = new List<Carta>();
    public List<Carta> ManoJugador2 = new List<Carta>();
    public List<Carta> ManoJugador3 = new List<Carta>();
    public List<Carta> ManoJugador4 = new List<Carta>();
    public List<Carta> ManoJugador5 = new List<Carta>();
    public List<Carta> ManoJugador6 = new List<Carta>();
    public List<Carta> ManoJugador7 = new List<Carta>();
    #endregion
    string JugadorName;
    int PuntajeDeLasCartas;
    public Jugador()
    {
        
    }

    // Acciones que puede realizar el jugador
    void RealizarJugada()
    {

    }
    void ObtenerCartas(List<ICarta> cartas)
    {

    }
    /* ICarta DevolverCarta(int indiceCarta)
     {

     }
     List<ICarta> DevolverTodasLasCartas()
     {

     }
     List<ICarta> MostrarCartas()
     {

     }
     ICarta MostrarCarta(int indiceCarta)
     {

     }*/
}

//Objeto dealer
public class Dealer
{
    // esta lista guarda las cartas que posee el dealer
    List<ICarta> RepartirCartas(int numeroDeCartas)
    {
        return new List<ICarta>();
    }

    //acciones que puede realizar el dealer
    void RecogerCartas(List<ICarta> cartas)
    {

    }
    void BarajearDeck()
    {

    }
}

//Objeto Baraja de Cartas
public class DeckDeCartas : IDeckDeCartas
{
    //sistema para crear la baraja asignando valoras y simbolos
    public DeckDeCartas()
    {
        for (int i = 0; i <= 3; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                DeckLista.Add(new Carta(j, i));
            }
        }
    }

    // la baraja esta guardada en esta lista
    public List<Carta> DeckLista = new List<Carta>();
    
    //escribe la carta en la consola
    public void LeerCartas()
    {
        foreach (Carta carta in DeckLista)
        {
            Console.WriteLine(carta.ToString());
        }
    }

    //Acciones que puede realizar la baraja
    public void BarajearDeck()
    {
        var random = new Random();
        int n = DeckLista.Count;
        while (n > 1)
        {
            n--;
        }
    }

    public ICarta VerCarta(int indiceCarta)
    {
        return DeckLista[indiceCarta];
    }

    public ICarta SacarCarta(int indiceCarta)
    {
        var carta = DeckLista.ElementAt(indiceCarta);
        DeckLista.RemoveAt(indiceCarta);
        return carta;
    }
    public void MeterCarta(ICarta carta)
    {
        DeckLista.Add((Carta)carta);
    }
    public void MeterCarta(List<ICarta> cartas)
    {

    }
}

// Objeto Carta
public class Carta : ICarta
{
    private ValoresCartasEnum _valor;

    // tira exepcion en caso de que el valor de la carta no sea valido
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

    // tira exepcion en caso de que el simbolo de la carta no se valido
    public FigurasCartasEnum Figura
    {
        get { return _figura; }
        set
        {
            if ((int)value < 0 || (int)value > 3) throw new Exception("El valor de la figura debe ser entre 0 y 3.");
            _figura = value;
        }
    }

    // Constructores del objeto carta
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