using GameEngine;
using SFML.System;
namespace MyGame
{
    class GameScene : Scene
    {
        private double _score;
        public GameScene()
        {
            ScrollingBackground scrollingbackground = new ScrollingBackground();
            AddGameObject(scrollingbackground);

            ScrollingBackgroundTwo scrollingbackgroundtwo = new ScrollingBackgroundTwo();
            AddGameObject(scrollingbackgroundtwo);

            FlappyBird flappybird = new FlappyBird();
            AddGameObject(flappybird);

            // a couple lines to test the pipes
            PipeSpawner pipeSpawner = new PipeSpawner();
            AddGameObject(pipeSpawner);

            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);
        }

        public double GetScore()
        {
            return _score;
        }
        public void IncreaseScore() //increases by 0.5 because it acounts for top and bottom pipe
        {
            _score = _score + 0.5;
        }

        public void HandleGameOver()
        {
            GameOverScene gameOverScene = new GameOverScene(_score);
            Game.SetScene(gameOverScene);
        }
    }
}
