using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Threading;1

namespace MyGame
{
    class FlappyBird : GameObject
    {
        private const float Gravity = 0.3f;
        private const int JumpDelay = 200;
        private int _jumpTimer;
        private int jumpHeight = 70;
        private bool jumpCheck = false;
        private float savey = 0;

        private readonly Sprite _sprite = new Sprite(); //creates the flappy bird
        public FlappyBird()
        {
            _sprite.Texture = Game.GetTexture("../../../Resources/flappybird3.png"); 
            _sprite.Position = new Vector2f(100, 300);
            SetCollisionCheckEnabled(true);
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
            Vector2f pos = _sprite.Position; 
            float x = pos.X; 
            float y = pos.Y;
            int msElapsed = elapsed.AsMilliseconds();

            if (y <= 0 || y >= 600) //if the flappy bird exits the screen vertically -> gameover
            {
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.HandleGameOver();

                MakeDead();
            }

            //savey basically saves the current y of the flappybird and adds the jumpheight ultimately creating a point of destination after the flappy bird jumps

            if (savey > y) { jumpCheck = false; } //if the flappybird passes the point of destination stop jumping

            if (jumpCheck == true && savey <= y) //if player has pressed jump and is under the point of destination
            {
                y -= 10; //move the player up 10
            }
            else
            {
                y += Gravity * msElapsed; //if not slowly move the player down
            }

            _sprite.Position = new Vector2f(x, y);

            if (_jumpTimer > 0) { _jumpTimer -= msElapsed; } //subtract time from the jump timer as long as its greater than 0
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _jumpTimer <= 0) //if player presses space and jump timer is over
            {
                savey = y - jumpHeight; //creates destination point

                jumpCheck = true; //begins the effects of jumping

                _jumpTimer = JumpDelay; //resets jump timer
            }
        }
        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("pipe")) //if the object is a pipe
            {
                GameScene scene = (GameScene)Game.CurrentScene; //Gameover
                scene.HandleGameOver();

                MakeDead();
            }
        }
    }
}

