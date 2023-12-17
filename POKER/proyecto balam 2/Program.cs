using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido al juego de poker.");

        // Crear una baraja y barajarla
        List<Card> deck = Deck.GenerateDeck();
        deck = Deck.Shuffle(deck);

        // Crear jugadores
        List<Player> players = new List<Player>
        {
            new Player("Jugador 1"),
            new Player("Jugador 2"),
            new Player("Jugador 3")
        };

        // Repartir cartas iniciales
        foreach (var player in players)
        {
            player.Hand = Deck.DealCards(deck, 5);
        }

        // Proceso de devolver y recibir nuevas cartas
        foreach (var player in players)
        {
            Console.WriteLine($"{player.Name}, tus cartas actuales: {player.DisplayHand()}");
            Console.Write("¿Cuáles cartas quieres devolver? (escribe los números separados por espacios): ");
            var indexesToReturn = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            player.ReturnCards(indexesToReturn, deck);
            player.ReceiveNewCards(deck, indexesToReturn.Count);
            Console.WriteLine($"{player.Name}, tus nuevas cartas: {player.DisplayHand()}");
        }

        // Mostrar las manos finales de los jugadores
        Console.WriteLine("\nManos finales:");
        foreach (var player in players)
        {
            Console.WriteLine($"{player.Name}: {player.DisplayHand()} - {HandEvaluator.EvaluateHand(player.Hand)}");
        }

        // Determinar el ganador
        var winner = players.OrderByDescending(p => HandEvaluator.EvaluateHand(p.Hand)).First();
        Console.WriteLine($"\n¡{winner.Name} gana con la mejor mano!");

        Console.ReadKey();
    }
    
}

// Clase para representar una carta
class Card
{
    public string Suit { get; set; }
    public string Rank { get; set; }

    public override string ToString()
    {
        return $"{Rank} de {Suit}";
    }
}

// Clase para representar un jugador
class Player
{
    public string Name { get; }
    public List<Card> Hand { get; set; }

    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
    }

    public void ReturnCards(List<int> indexes, List<Card> deck)
    {
        foreach (var index in indexes)
        {
            deck.Add(Hand[index]);
        }

        Hand.RemoveAll(card => indexes.Contains(Hand.IndexOf(card)));
    }

    public void ReceiveNewCards(List<Card> deck, int numCards)
    {
        Hand.AddRange(Deck.DealCards(deck, numCards));
    }

    public string DisplayHand()
    {
        return string.Join(", ", Hand.Select(card => card.ToString()));
    }
}

// Clase para manejar la baraja
class Deck
{
    public static List<Card> GenerateDeck()
    {
        var ranks = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        var suits = new[] { "Corazones", "Diamantes", "Tréboles", "Picas" };

        var deck = new List<Card>();
        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                deck.Add(new Card { Suit = suit, Rank = rank });
            }
        }

        return deck;
    }

    public static List<Card> Shuffle(List<Card> deck)
    {
        Random rand = new Random();
        return deck.OrderBy(card => rand.Next()).ToList();
    }

    public static List<Card> DealCards(List<Card> deck, int numCards)
    {
        var dealtCards = deck.Take(numCards).ToList();
        deck.RemoveRange(0, numCards);
        return dealtCards;
    }

    
}
// Clase para manejar la evaluación de manos
class HandEvaluator
{
    public static string EvaluateHand(List<Card> hand)
    {
        if (IsRoyalFlush(hand))
            return "Escalera Real";
        if (IsStraightFlush(hand))
            return "Escalera de Color";
        if (IsFourOfAKind(hand))
            return "Póker";
        if (IsFullHouse(hand))
            return "Full House";
        if (IsFlush(hand))
            return "Color";
        if (IsStraight(hand))
            return "Escalera";
        if (IsThreeOfAKind(hand))
            return "Trío";
        if (IsTwoPair(hand))
            return "Doble Pareja";
        if (IsOnePair(hand))
            return "Pareja";

        return "Carta Alta";
    }

    private static bool IsRoyalFlush(List<Card> hand)
    {
        // Verificar si es una Escalera Real (A, K, Q, J, 10 del mismo palo)
        return IsStraightFlush(hand) && hand.Any(card => card.Rank == "A");
    }

    private static bool IsStraightFlush(List<Card> hand)
    {
        // Verificar si es una Escalera de Color
        return IsFlush(hand) && IsStraight(hand);
    }

    private static bool IsFourOfAKind(List<Card> hand)
    {
        // Verificar si es un Póker (Cuatro cartas del mismo rango)
        var groupedByRank = hand.GroupBy(card => card.Rank);
        return groupedByRank.Any(group => group.Count() == 4);
    }

    private static bool IsFullHouse(List<Card> hand)
    {
        // Verificar si es un Full House (Un trío y una pareja)
        var groupedByRank = hand.GroupBy(card => card.Rank);
        return groupedByRank.Any(group => group.Count() == 3) && groupedByRank.Any(group => group.Count() == 2);
    }

    private static bool IsFlush(List<Card> hand)
    {
        // Verificar si es un Color (Todas las cartas del mismo palo)
        return hand.GroupBy(card => card.Suit).Count() == 1;
    }

    private static bool IsStraight(List<Card> hand)
    {
        // Verificar si es una Escalera (Cinco cartas consecutivas)
        var ranks = hand.Select(card => card.Rank).Distinct().OrderBy(rank => "23456789TJQKA".IndexOf(rank));
        var consecutiveCount = 0;

        foreach (var rank in ranks)
        {
            if ("23456789TJQKA".IndexOf(rank) - consecutiveCount == "23456789TJQKA".IndexOf(ranks.First()))
                consecutiveCount++;
            else
                consecutiveCount = 1;

            if (consecutiveCount == 5)
                return true;
        }

        return false;
    }

    private static bool IsThreeOfAKind(List<Card> hand)
    {
        // Verificar si es un Trío (Tres cartas del mismo rango)
        var groupedByRank = hand.GroupBy(card => card.Rank);
        return groupedByRank.Any(group => group.Count() == 3);
    }

    private static bool IsTwoPair(List<Card> hand)
    {
        // Verificar si son Dos Pares (Dos grupos de dos cartas del mismo rango)
        var groupedByRank = hand.GroupBy(card => card.Rank);
        return groupedByRank.Count(group => group.Count() == 2) == 2;
    }

    private static bool IsOnePair(List<Card> hand)
    {
        // Verificar si es una Pareja (Dos cartas del mismo rango)
        var groupedByRank = hand.GroupBy(card => card.Rank);
        return groupedByRank.Any(group => group.Count() == 2);
    }
   
}

