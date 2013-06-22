using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace TestGame
{
    class Shot : IObject
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float DY { get; set; }
        public float DX { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle PicArea { get; set; }
        public Game1 Game { get; set; }

        public Shot(Game1 game, Texture2D texture, Rectangle picArea, float x, float y, float dx, float dy)
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

        public void Kill()
        {
            Game.Objects.Remove(this);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, new Rectangle((int)X, (int)Y, PicArea.Width, PicArea.Height), PicArea, new Color(255, 255, 255));
        }
    }
}
