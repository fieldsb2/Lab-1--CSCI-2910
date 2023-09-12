//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Lab 1 - Video Games
// File Name: Program.cs
// Description: A class that implements a video game list and manipulates it, while also taking in user commands.
// Course: CSCI 2910-001 – Server Side Web Programming
// Author: Braydon Fields, fieldsb2@etsu.edu, East Tennessee State University
// Created: Thursday, September 1, 2023
// Copyright: Braydon Fields, 2023
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


/// <summary>
/// a class for a video game that implements IComparable
/// </summary>
public class VideoGame : IComparable<VideoGame>
{
    public string Name;// the video game name
    public string Platform;// the video game platform
    public int Year;// the video game year
    public string Genre; // the video game genre
    public string Publisher;// the video game publisher
    public double NA_Sales;// north american sales
    public double EU_Sales;// european sales
    public double JP_Sales;// japanese sales
    public double O_Sales;// other sales
    public double G_Sales;// global sales

    /// <summary>
    /// a video game class that takes no parameters
    /// </summary>
    public VideoGame()
    {
        Name = "";
        Platform = "";
        Year = 0;
        Genre = "";
        Publisher = "";
    }

    /// <summary>
    /// a class that takes in all parameters for a video game object
    /// </summary>
    /// <param name="name">name of video game</param>
    /// <param name="platform">platform of video game</param>
    /// <param name="year">year video game was made</param>
    /// <param name="genre">genre of video game</param>
    /// <param name="publisher">publisher of video game</param>
    /// <param name="na_Sales">north american sales</param>
    /// <param name="eu_Sales">european sales</param>
    /// <param name="jp_Sales">japanese sales</param>
    /// <param name="o_Sales">other sales</param>
    /// <param name="g_Sales">global sales</param>
    public VideoGame(string name, string platform, int year, string genre, string publisher, double na_Sales, double eu_Sales, double jp_Sales, double o_Sales, double g_Sales)
    {
        Name = name;
        Platform = platform;
        Year = year;
        Genre = genre;
        Publisher = publisher;
        NA_Sales = na_Sales;
        EU_Sales = eu_Sales;
        JP_Sales = jp_Sales;
        O_Sales = o_Sales;
        G_Sales = g_Sales;
    }

    /// <summary>
    /// an implemented method from IComparable that allows lists to be sorted
    /// </summary>
    /// <param name="game1">the game it takes in to sort by name</param>
    /// <returns>an int that determines which name came first</returns>
    public int CompareTo(VideoGame? game1)
    {
        int CName = Name.CompareTo(game1.Name);
        return CName;

    }

    /// <summary>
    /// a method that returns the publisher of the video game
    /// </summary>
    /// <returns>publisher of video game</returns>
    public string GetPublisher()
    {
        return Publisher;
    }

    /// <summary>
    /// a method that returns the genre of the video game
    /// </summary>
    /// <returns>genre of video game</returns>
    public string GetGenre()
    {
        return Genre;
    }

    /// <summary>
    /// a method that takes in what publisher the user enters and returns it
    /// </summary>
    /// <returns>a string containing user input</returns>
    public string PublisherData()
    {
        string userInput = "";
        userInput = Console.ReadLine();
        return userInput;
    }

    /// <summary>
    /// a method that takes in what genre the user enters and returns it
    /// </summary>
    /// <returns>string containing user input</returns>
    public string GenreData()
    {
        string userInput = "";
        userInput = Console.ReadLine();
        return userInput;
    }

    /// <summary>
    /// a method that returns a string of the video game name, publisher, and genre
    /// </summary>
    /// <returns>a string containing name, publisher, and genre</returns>
    public override string ToString()
    {
        string returnValue = "";
        returnValue += "Name: " + Name + "\nPublisher: " + Publisher + "\nGenre: " + Genre;
        return returnValue;
    }
}