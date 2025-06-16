using GameEngine;
namespace MyGame
{
    class GameOverScene : Scene
    {
        public GameOverScene(double score)
        {
            GameOverMessage gameOverMessage = new GameOverMessage(score);
            AddGameObject(gameOverMessage);
        }
    }
}
