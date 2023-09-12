//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Project: Lab 1 - Video Games
// File Name: VGDriver.cs
// Description: A class that implements a video game list and manipulates it, while also taking in user commands.
// Course: CSCI 2910-001 – Server Side Web Programming
// Author: Braydon Fields, fieldsb2@etsu.edu, East Tennessee State University
// Created: Thursday, September 1, 2023
// Copyright: Braydon Fields, 2023
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace Lab_1___CSCI_2910
{
    /// <summary>
    /// the driver class that holds the main method and runs the program
    /// </summary>
    internal class VGDriver
    {
        /// <summary>
        /// a class that implements a list and manipulates it and then takes in user input to manipulate the list as well
        /// </summary>
        /// <param name="args"></param>
        static public void Main(string[] args) 
        {

            VideoGame game = new VideoGame();// an object instantiation of the video game class
            List<VideoGame> videoGames = new List<VideoGame>();// a list that will hold all video games from a csv file
            string FilePath = "../../../../../videogames.csv";// the file path of the csv file
            StreamReader str = new StreamReader(FilePath);//the stream reader which reads lines from the file
            str.ReadLine();
            string LineInfo = "";//the line pulled from the streamreader
            string name = "";//the name of the video game
            string plat = "";// the platform of the video game
            int year = 0;//the year the video game was made
            string pub = "";// the publisher of the video games
            string genre = "";// the genre of the video games
            double nsale = 0.0;// north american sales of the video games
            double esale = 0.0;// european sales of the video games
            double jsale = 0.0;// japanese sales of the video games
            double osale = 0.0;// other sales of the video games
            double gsale = 0.0;// global sales of hte video games
            

            int position = 0;//a variable to track the position of the list
            int count = File.ReadAllLines(FilePath).Length;//a variable to track the length of the array
            count--;

            while (count !=0)
             {
                 LineInfo = str.ReadLine();
                 string[] games = LineInfo.Split(new string[] { "," }, StringSplitOptions.None);// an array to hold each line of the csv
                 name = games[position];
                 position++;
                 plat = games[position];
                 position++;
                 year = int.Parse(games[position]);
                 position++;
                 pub = games[position];
                 position++;
                 genre = games[position];
                 position++;
                 nsale = double.Parse(games[position]);
                 position++;
                 esale = double.Parse(games[position]);
                 position++;
                 jsale = double.Parse(games[position]);
                 position++;
                 osale = double.Parse(games[position]);
                 position++;
                 gsale = double.Parse(games[position]);
                 position++;

                 count--;
                VideoGame game1 = new VideoGame(name, plat, year, pub, genre, nsale, esale, jsale, osale, gsale);// an object that will be 
                                                                                                               //added to the beginning list
                videoGames.Add(game1);
                 position = 0;
            }

            videoGames.Sort();

            for (int i = 0; i < videoGames.Count; i++)
             {
                Console.WriteLine(videoGames[i].ToString());
             }

            List<VideoGame> PublisherList = new List<VideoGame>();// a list that contains all of the games that the program sorts by publisher

            string pubFound;//a string to hold what the searched for publisher is
            
            for (int i = 0; i < videoGames.Count; i++)
            {
                pubFound = videoGames[i].GetPublisher();

                if (pubFound == "Nintendo")
                {
                    PublisherList.Add(videoGames[i]);
                }
            }

            PublisherList.Sort();

            for (int i = 0; i < PublisherList.Count; i++)
            {
                Console.WriteLine(PublisherList[i].ToString());
            }

            int pubLength = PublisherList.Count;//an int to hold the length of the publisher list
            int gameLength = videoGames.Count;// an int to hold the original list length
            decimal rounded;// a decimal value to hold the divison before it is rounded
            rounded = decimal.Divide(pubLength, gameLength);
            rounded = rounded * 100;
            decimal fullRound = Math.Round(rounded, 2);//a decimal to hold the finished number after being rounded
            Console.WriteLine("Out of " + gameLength +" games, " + pubLength +" of them were Nintendo. This calculates to " + fullRound + "%");



            List<VideoGame> GenreList = new List<VideoGame>();// a list to hold the video games from the selected genre
            for (int i = 0; i < videoGames.Count; i++)
            {
                string genreFound = videoGames[i].GetGenre();//a string to hold the genre pulled from the video game
                if (genreFound == "Platform")
                {
                    GenreList.Add(videoGames[i]);
                }
            }

            GenreList.Sort();

            for (int i = 0; i < GenreList.Count; i++)
            {
                Console.WriteLine(GenreList[i].ToString());
            }

            int genLength = GenreList.Count;// an int to hold the genre list length

            rounded = decimal.Divide(genLength, gameLength);
            rounded = rounded * 100;
            fullRound = Math.Round(rounded, 2);
            Console.WriteLine("Out of " + gameLength + " games, " + genLength + " of them were Platform. This calculates to " + fullRound + "%");

            List<VideoGame> userPub = new List<VideoGame>();// a list to hold the video games from the user specified publisher

            string userPubFound;// a string to hold the publisher from the user entry

            Console.WriteLine("Please enter a publisher to sort by: ");
            userPubFound = game.PublisherData();
            for (int i = 0; i < videoGames.Count; i++)
                if (userPubFound == videoGames[i].GetPublisher())
                {
                    userPub.Add(videoGames[i]);
                }
            userPub.Sort();
            int userPubLength = userPub.Count;// an int to hold the list length for the user publisher list

            rounded = decimal.Divide(userPubLength, gameLength);
            rounded = rounded * 100;
            fullRound = Math.Round(rounded, 2);
            Console.WriteLine("Out of " + gameLength + " games, " + userPubLength + " of them were " + userPubFound + ". This calculates to " + fullRound + "%");



            List<VideoGame> userGen = new List<VideoGame>();// a list to hold video games from the user specified genre

            string userGenFound;// a string to hold what genre the user enters

            Console.WriteLine("Please enter a genre to sort by: ");
            userGenFound = game.GenreData();
            for (int i = 0; i < videoGames.Count; i++)
                if (userGenFound == videoGames[i].GetGenre())
                {
                    userGen.Add(videoGames[i]);
                }
            userPub.Sort();
            int userGenLength = userGen.Count;// an int to hold the length of the user genre list

            rounded = decimal.Divide(userGenLength, gameLength);
            rounded = rounded * 100;
            fullRound = Math.Round(rounded, 2);
            Console.WriteLine("Out of " + gameLength + " games, " + userGenLength + " of them were " + userGenFound + ". This calculates to " + fullRound + "%");
        }
    }
}
