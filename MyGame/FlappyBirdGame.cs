using GameEngine; //roman luraschi period 3

namespace MyGame
{
    static class FlappyBirdGame
    {
        private const int WindowWidth = 1000;
        private const int WindowHeight = 600;

        private const string WindowTitle = "Flappy Bird";

        private static void Main(string[] args)
        {
            //initialize the game.
            Game.Initialize(WindowWidth, WindowHeight, WindowTitle);

            //create scene.
            GameScene scene = new GameScene();
            Game.SetScene(scene);

            //run the game loop.
            Game.Run();
        }
    }
}