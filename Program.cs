using System;

public class SayaMusicTrack
{
    private int id;
    private string playCount;
    private string title;

    public SayaMusicTrack(string title)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = "0";
    }

    public void IncreasePlayCount(int count)
    {
        int current = int.Parse(playCount);
        current += count;
        playCount = current.ToString();
    }

    public void PrintTrackDetails()
    {
        Console.WriteLine("=== Track Details ===");
        Console.WriteLine($"ID        : {id}");
        Console.WriteLine($"Title     : {title}");
        Console.WriteLine($"Play Count: {playCount}");
        Console.WriteLine("=====================");
    }
}
class Program
{
    static void Main(string[] args)
    {
        SayaMusicTrack track = new SayaMusicTrack("Bohemian Rhapsody");

        Console.WriteLine("--- Detail Track Awal ---");
        track.PrintTrackDetails();

        track.IncreasePlayCount(150);
        Console.WriteLine("\n--- Setelah IncreasePlayCount(150) ---");
        track.PrintTrackDetails();

        track.IncreasePlayCount(75);
        Console.WriteLine("\n--- Setelah IncreasePlayCount(75) ---");
        track.PrintTrackDetails();
    }
}