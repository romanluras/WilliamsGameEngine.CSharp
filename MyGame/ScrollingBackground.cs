using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class ScrollingBackground : GameObject
    {
        private readonly Sprite _sprite = new Sprite(); // Creates the background.
        public ScrollingBackground()
        {
            _sprite.Texture = Game.GetTexture("../../../Resources/skybackground3.png");
            _sprite.Position = new Vector2f(0, 0);
        }
        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite.Position;

            float x = pos.X; 
            float y = pos.Y;

            x -= 10; //move the background left 10

            if (x <= -1600) //if the background is completely off the screen cycle it back to the begining
            {
                x = 1600;
            }

            _sprite.Position = new Vector2f(x, y);
        }
    }
}
