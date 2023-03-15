// See https://aka.ms/new-console-template for more information
using System.Linq;

class Programm
{
    public static int playersCount = 0;
    public static int cardsCount = 0;
    private static string command = "";
    private static List<string> cards = new List<string>();
    private static string[,] players = new string[playersCount, cardsCount];
    // для удобства сделал эти переменые глобальными💩
    public static void Main(string[] args)
    {
        CardsGenerated();
        while (true)
        {

            ControllerCommads(command);
        }
    }
    public static void ControllerCommads(string command)
    {
        //цент управления командами 👷‍♂️👷‍♂️👷‍♂️
        string[] numbers = Console.ReadLine().Split();
        command = Convert.ToString(numbers[0]);

        if (command == "start")
        {
            playersCount = Convert.ToInt32(numbers[1]);
            cardsCount = Convert.ToInt32(numbers[2]);
            DistributionOfСards(playersCount, cardsCount, cards);

        }
        else if (command == "")
        {

            Console.WriteLine("Введите комманду");
        }
        else if (command == "get-card")
        {
            
            playersCount = Convert.ToInt32(numbers[1]);
            Console.WriteLine("игрок под номером " + playersCount);
            for (int i = 0; i < cardsCount; i++)
            {

                Console.Write(players[i, (playersCount - 1)] + " ");
            }
        }
    }
    // генерация каллоды 🃏🃏🃏
    static List<string> CardsGenerated()
    {
        
        for (int i = 0; i < 10; i++)
        {
            cards.Add("R" + i);
            cards.Add("G" + i);
            cards.Add("B" + i);
            cards.Add("W" + i);
        }
        
        return cards;
    }
    // раздача карт на игроков ♠️♣️♥️♦️
    static void DistributionOfСards(int playersCount, int cardsCount, List<string> cards)
    {
        players = new string[playersCount, cardsCount];
        Random randomCards = new Random();
        for (int y = 0; y < players.GetLength(0); y++)
        {
            for (int x = 0; x < players.GetLength(1); x++)

            {
                int cardIndex = randomCards.Next(0, cards.Count());
                players[x,y] = cards[cardIndex];
                //убираем карты которые уже раздали🚫🚫🚫
                cards.RemoveAt(cardIndex);
                Console.Write(players[x,y] + " ");
            }

            Console.WriteLine();
        }

       Console.WriteLine("раздача карт завершена");
       command = "";//обнулил команду что бы предотвротить бесконечный цикл💀💀💀
        ControllerCommads(command);
    }
    
}