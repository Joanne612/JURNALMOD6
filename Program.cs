using System;
using System.Diagnostics;

public class SayaMusicTrack
{
    private int id;
    private string playCount;
    private string title;

    public SayaMusicTrack(string title)
    {
        Debug.Assert(title != null, "[PRECONDITION FAILED] Judul track tidak boleh null.");
        Debug.Assert(title.Length <= 100, "[PRECONDITION FAILED] Judul track tidak boleh lebih dari 100 karakter.");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = "0";
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count <= 10_000_000, "[PRECONDITION FAILED] Input count tidak boleh melebihi 10.000.000.");
        Debug.Assert(count >= 0, "[PRECONDITION FAILED] Input count tidak boleh negatif.");

        int current = int.Parse(playCount);
        int result = checked(current + count); 
        playCount = result.ToString();
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
        Console.WriteLine("========================================");
        Console.WriteLine("TEST 1: Penggunaan Normal");
        Console.WriteLine("========================================");
        SayaMusicTrack track1 = new SayaMusicTrack("Bohemian Rhapsody");
        track1.PrintTrackDetails();
        track1.IncreasePlayCount(500);
        Console.WriteLine("Setelah IncreasePlayCount(500):");
        track1.PrintTrackDetails();

        Console.WriteLine("\n========================================");
        Console.WriteLine("TEST 2: Precondition - Judul null");
        Console.WriteLine("========================================");
        try
        {
            string judulNull = null;
            if (judulNull == null)
                throw new ArgumentNullException("title", "[PRECONDITION FAILED] Judul track tidak boleh null.");

            SayaMusicTrack trackNull = new SayaMusicTrack(judulNull);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Exception tertangkap: {ex.Message}");
        }

        Console.WriteLine("\n========================================");
        Console.WriteLine("TEST 3: Precondition - Judul > 100 karakter");
        Console.WriteLine("========================================");
        try
        {
            string judulPanjang = new string('A', 101); 
            if (judulPanjang.Length > 100)
                throw new ArgumentException("[PRECONDITION FAILED] Judul track tidak boleh lebih dari 100 karakter.");

            SayaMusicTrack trackPanjang = new SayaMusicTrack(judulPanjang);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Exception tertangkap: {ex.Message}");
        }

        Console.WriteLine("\n========================================");
        Console.WriteLine("TEST 4: Precondition - count > 10.000.000");
        Console.WriteLine("========================================");
        try
        {
            SayaMusicTrack track4 = new SayaMusicTrack("Shape of You");
            int inputBesar = 10_000_001;
            if (inputBesar > 10_000_000)
                throw new ArgumentOutOfRangeException("count", "[PRECONDITION FAILED] Input count tidak boleh melebihi 10.000.000.");

            track4.IncreasePlayCount(inputBesar);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Exception tertangkap: {ex.Message}");
        }

        Console.WriteLine("\n========================================");
        Console.WriteLine("TEST 5: Exception - Integer Overflow");
        Console.WriteLine("========================================");
        try
        {
            SayaMusicTrack track5 = new SayaMusicTrack("Blinding Lights");
            Console.WriteLine("Memulai loop penambahan play count hingga overflow...");

            for (int i = 0; i < 1000; i++)
            {
                track5.IncreasePlayCount(10_000_000);
                Console.WriteLine($"Iterasi {i + 1}: PlayCount berhasil ditambah.");
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("OverflowException tertangkap: Play count melebihi batas maksimum integer!");
        }

        Console.WriteLine("\n========================================");
        Console.WriteLine("Semua test selesai dijalankan.");
        Console.WriteLine("========================================");
    }
}