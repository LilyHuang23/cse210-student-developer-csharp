﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04.Game.Casting;
using Unit04.Game.Directing;
using Unit04.Game.Services;


namespace Unit04
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Greed";
        private static string DATA_PATH = "Data/messages.txt";
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_ARTIFACTS = 40;

        private static int GEM_PERCENTAGE = 50;
        private static int[] VELOCITIES = { 1, 3, 5 };

        private static int DEFAULT_VALUE = 1;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the banner
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the player
            Actor player = new Actor();
            player.SetText("#");
            player.SetFontSize(FONT_SIZE);
            player.SetColor(WHITE);
            player.SetPosition(new Point(MAX_X/ 2, MAX_Y - CELL_SIZE));
            cast.AddActor("player", player);

            // load the messages
            List<string> messages = File.ReadAllLines(DATA_PATH).ToList<string>();

            // create the artifacts
            Random random = new Random();
            for (int i = 0; i < DEFAULT_ARTIFACTS; i++)
            {
                // create gems and rocks
                string text = Convert.ToBoolean(random.Next(0, 100 + 1) <= GEM_PERCENTAGE) ? "*" : "o";
                
                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);
                Point velocity = new Point(0, VELOCITIES[random.Next(0, VELOCITIES.Count())]);


                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);


                while (r + g +b < 255)
                {
                    r = random.Next(0, 256);
                    g = random.Next(0, 256);
                    b = random.Next(0, 256);
                }
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(text);
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetVelocity(velocity);
                artifact.SetValue((text == "*")? DEFAULT_VALUE : -DEFAULT_VALUE);
                cast.AddActor("artifacts", artifact);
            }

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);

            // test comment
        }
    }
}