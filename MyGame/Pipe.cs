using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Reflection.Metadata.Ecma335;
namespace MyGame
{
    class Pipe : GameObject
    {
        private const float Speed = 0.5f; //speed that the pipe travels
        private readonly Sprite _sprite = new Sprite();

        public Pipe(Vector2f pos, int posPipeType)
        {
            //allows us to pick different textures when calling the same method
            if (posPipeType == 0)
                _sprite.Texture = Game.GetTexture("../../../Resources/pipe2.png");
            else if (posPipeType == 1)
                _sprite.Texture = Game.GetTexture("../../../Resources/pipe.png");
            else if (posPipeType == 2)
                _sprite.Texture = Game.GetTexture("../../../Resources/pipemid.png");


            _sprite.Position = pos; //position of the pipe
            AssignTag("pipe");
            SetCollisionCheckEnabled(true); //allows pipe to colide with other objects
        }
        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds(); 
            Vector2f pos = _sprite.Position;

            if (pos.X < _sprite.GetGlobalBounds().Width * -1) //if the pipe travels off screen get rid of the pipe
            {
                MakeDead();

                if(_sprite.Texture != Game.GetTexture("../../../Resources/pipemid.png")) //make sure not to count the filler sections
                {
                    GameScene scene = (GameScene)Game.CurrentScene; //add 1 to the score of the player 
                    scene.IncreaseScore();
                }
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y); //moves the pipe
            }
        }
    }
}
