using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TestGame
{
    class EnemyPlane : IObject
    {
        public float X { get; set; }
        public float Y { get; set; }
        float DX { get; set; }
        float DY { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle PicArea { get; set; }
        public Game1 Game { get; set; }

        public EnemyPlane(Game1 game, Texture2D texture, Rectangle picArea, float x, float y, float dx = 0, float dy = 3)
        {
            Texture = texture;
            PicArea = picArea;
            X = x;
            Y = y;
            DX = dx;
            DY = dy;
            Game = game;
        }

        public void Move()
        {
            X += DX;
            Y += DY;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, new Rectangle((int)X, (int)Y, PicArea.Width, PicArea.Height), PicArea, new Color(255, 255, 255));
        }

        public void Kill()
        {
            Game.Objects.Remove(this);
        }

    }
}
