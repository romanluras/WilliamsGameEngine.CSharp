using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace MyGame
{
    class PipeSpawner : GameObject
    { 
        private const int SpawnDelay = 1000; //How long it takes for another pipe to spawn.
        private int _timer;
        private int spaceInbetweenPipe = 240; //Has to be divisable by 80

        private int SaveLastPipePos; //Saves the last pipe position
        private int GeneratePipePosition; //Generates the current pipe position
        public override void Update(Time elapsed)
        {
            Random rnd = new Random();

            //determine how much time has passed and adjust our timer.
            int msElapsed = elapsed.AsMilliseconds(); 
            _timer -= msElapsed;
            //if the timer has elapsed reset it and spawn a pipe. 
            if (_timer <= 0)
            {
                do //Generate a pipe position untill the pipe position does now meat the requirement (high pipe -> low pipe) or vice versa
                {
                    GeneratePipePosition = rnd.Next(0, 5); //0 = low placement, 4 = high placement
                } while ((GeneratePipePosition == 0 && SaveLastPipePos == 4) || (GeneratePipePosition == 4 && SaveLastPipePos == 0));

                SaveLastPipePos = GeneratePipePosition; //save the last pipe position 

                _timer = SpawnDelay;
                Vector2u size = Game.RenderWindow.Size;
                //spawn the pipe off the right side of the screen. 
                float pipeX = size.X + 100;

                int bottomPipeHeight = 520 - (80 * GeneratePipePosition);
                int topPipeBottom = bottomPipeHeight - spaceInbetweenPipe;

                // Generates the top pipe that faces down
                Pipe pipe = new Pipe(new Vector2f(pipeX, topPipeBottom), 0);
                Game.CurrentScene.AddGameObject(pipe);


                //fills in the rest of the space with filler pipe textures
                for (int i = 0; i < (topPipeBottom + 80) / 80; i++)
                {
                    Pipe pipe3 = new Pipe(new Vector2f(pipeX, 0 + (80 * i)), 2);
                    Game.CurrentScene.AddGameObject(pipe3);
                }

                // Generates the bottom pipe that faces up
                Pipe pipe2 = new Pipe(new Vector2f(pipeX, bottomPipeHeight), 1);
                Game.CurrentScene.AddGameObject(pipe2);

                //fills in the rest of the space with filler pipe textures
                for (int i = 0; i < GeneratePipePosition; i++)
                {
                    Pipe pipe3 = new Pipe(new Vector2f(pipeX, 520 - (80 * i)), 2);
                    Game.CurrentScene.AddGameObject(pipe3);
                }
            }
        }
    }
}

