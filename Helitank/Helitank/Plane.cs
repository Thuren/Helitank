using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace TestGame
{
    class Plane
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Texture2D Texture {get;set;}
        public Rectangle PicArea {get;set;}
        public DateTime LastShot = new DateTime(1997, 1, 1);
        public Game1 Game;
        public Plane(Game1 game)
        {
            Game = game;
        }

        public Shot Shoot(int x=0)
        {


            return new Shot(Game, Texture, new Rectangle(9, 176, 10, 16), X+3+x, Y-3, 0,-12);
        }

        public void Control(GamePadState state)
        {
            X += state.ThumbSticks.Left.X * 10;
            Y -= state.ThumbSticks.Left.Y * 10;

            if (state.Buttons.A == ButtonState.Pressed)
            {
                if (DateTime.Now.Ticks - LastShot.Ticks > 1200000)
                {
                    LastShot = DateTime.Now;
                    Game.Objects.Add(Shoot());
                    Game.Objects.Add(Shoot(45));
                }

            }
        }

        public void Control(KeyboardState state)
        {
            var left = state.IsKeyDown(Keys.Left);
            var up = state.IsKeyDown(Keys.Up);
            var right = state.IsKeyDown(Keys.Right);
            var down = state.IsKeyDown(Keys.Down);
            var ctrl = state.IsKeyDown(Keys.LeftControl);

            if (left)
                X -= 8;
            if (right)
                X += 8;
            if (up)
                Y -= 8;
            if (down)
                Y += 8;
            if (ctrl)
            {
                if (DateTime.Now.Ticks - LastShot.Ticks > 1200000)
                {
                    LastShot = DateTime.Now;
                    Game.Objects.Add(Shoot());
                    Game.Objects.Add(Shoot(45));
                }

            }
        }

        public void Draw(SpriteBatch sb)
        {
            if(Texture != null)
            sb.Draw(Texture, new Rectangle((int)X, (int)Y, PicArea.Width, PicArea.Height), PicArea, new Color(255, 255, 255));
        }
    }
}
