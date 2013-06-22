using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;

namespace TestGame
{
    public interface IObject
    {
        float X { get; set; }
        float Y { get; set; }
        Texture2D Texture { get; set; }
        Rectangle PicArea { get; set; }
        Game1 Game {get;set;}

        void Move();
        void Draw(SpriteBatch sb);
        void Kill();
    }
}
