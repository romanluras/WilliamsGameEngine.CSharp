using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace MyGame
{
    class GameOverMessage : GameObject
    {
        private readonly Text _text = new Text();
        public GameOverMessage(double score) //creates the message
        {
            _text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _text.Position = new Vector2f(50.0f, 50.0f);
            _text.CharacterSize = 30;
            _text.FillColor = Color.Red;
            _text.DisplayedString = "GAME OVER\n\nYOUR SCORE: " + score + "\n\nPRESS ENTER TO CONTINUE";
        }
        public override void Draw()
        {
            Game.RenderWindow.Draw(_text);
        }
        public override void Update(Time elapsed)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Enter)) //checks if the player presses enter
            {
                GameScene scene = new GameScene();
                Game.SetScene(scene);
            }
        }
    }
}
