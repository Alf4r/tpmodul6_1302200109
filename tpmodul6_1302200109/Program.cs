// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics.Contracts;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    // Konstruktor
    public SayaTubeVideo(string title)
    {
        this.id = GenerateRandomId();
        this.title = title;
        this.playCount = 0;
    }

    // Method untuk menambah jumlah playCount
    public void IncreasePlayCount(int countToAdd)
    {
        // Prekondisi: Input penambahan play count maksimal 10.000.000 per panggilan method
        Contract.Requires(countToAdd <= 10000000, "Input penambahan play count melebihi batas maksimal.");

        // Exception Handling: Pastikan tidak terjadi overflow
        try
        {
            checked
            {
                playCount += countToAdd;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Terjadi overflow saat menambah jumlah play count.");
        }
    }

    // Method untuk mencetak detail video
    public void PrintVideoDetails()
    {
        Console.WriteLine($"Video Details:");
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }

    // Method untuk menghasilkan ID acak
    private int GenerateRandomId()
    {
        Random random = new Random();
        return random.Next(10000, 99999); // 5 digit random number
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Uji prekondisi dan exception handling
        TestPreconditionsAndExceptions();
    }

    static void TestPreconditionsAndExceptions()
    {
        // Uji prekondisi
        string judulVideo = "Tutorial Design By Contract – ALFAR ";
        SayaTubeVideo video = new SayaTubeVideo(judulVideo);
        video.IncreasePlayCount(100000000); // Ini akan memicu prekondisi

        // Uji exception handling dengan loop
        for (int i = 0; i < 5; i++)
        {
            video.IncreasePlayCount(int.MaxValue / 2); // Ini akan memicu overflow
        }

        // Mencetak detail video setelah pengujian
        video.PrintVideoDetails();
    }
}

