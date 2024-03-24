// See https://aka.ms/new-console-template for more information
using System;

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
        playCount += countToAdd;
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
        // Membuat objek SayaTubeVideo dengan judul video
        string judulVideo = "Tutorial Design By Contract – ALFAR";
        SayaTubeVideo video = new SayaTubeVideo(judulVideo);

        // Menambah jumlah playCount
        video.IncreasePlayCount(10);

        // Mencetak detail video
        video.PrintVideoDetails();
    }
}
