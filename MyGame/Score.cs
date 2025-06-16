﻿using GameEngine;
using SFML.Graphics;
using SFML.System;
namespace MyGame
{
    class Score : GameObject
    {
        private readonly Text _text = new Text(); 
        public Score(Vector2f pos) //creates score text
        {
            _text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _text.Position = pos;
            _text.CharacterSize = 24;
            _text.FillColor = Color.Black;
            AssignTag("score");
        }
        public override void Draw()
        {
            Game.RenderWindow.Draw(_text);
        }
        public override void Update(Time elapsed)
        {
            GameScene scene = (GameScene)Game.CurrentScene;
            _text.DisplayedString = "Score: " + scene.GetScore();
        }
    }
}
