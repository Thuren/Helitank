using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TestGame
{
    
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Plane plane1;
        static Texture2D Texture;
        public List<IObject> Objects = new List<IObject>();
        Random Rnd = new Random(100);
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            plane1 = new Plane(this) { X = 100, Y = 100, Texture = Texture, PicArea = new Rectangle(370, 247, 61, 55) };


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture = Content.Load<Texture2D>("1945");
            plane1.Texture = Texture;
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Handle old objects
            //plane1.Control(GamePad.GetState(PlayerIndex.One));
            plane1.Control(Keyboard.GetState());        
            Objects.ForEach(s => s.Move());
            
            // Maybe create new ones
            if (Rnd.Next(0, 100) > 95)
                Objects.Add(new EnemyPlane(this, Texture,new Rectangle(4,137,29,29),Rnd.Next(50,1230),-20));


            // Check collisions
            var toRemove = new List<IObject>();
            for (int i = 0; i < Objects.Count; i++)
            {
                var obj1 = Objects.ElementAt(i);
                for (int j = i + 1; j < Objects.Count; j++)
                { 
                    var obj2 = Objects.ElementAt(j);
                    if (new Rectangle((int)obj1.X, (int)obj1.Y, obj1.PicArea.Width, obj1.PicArea.Height).Intersects(new Rectangle((int)obj2.X, (int)obj2.Y, obj2.PicArea.Width, obj2.PicArea.Height)))
                    {
                        toRemove.Add(obj1);
                        toRemove.Add(obj2);
                    }


                }
                if (!new Rectangle(0, 0, 1280, 720).Intersects(new Rectangle((int)obj1.X, (int)obj1.Y, obj1.PicArea.Width, obj1.PicArea.Height)))
                    toRemove.Add(obj1);
            }

            foreach (var rem in toRemove)
                Objects.Remove(rem);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //spriteBatch.Draw(texture, new Rectangle((int)x, (int)y, 61, 55), new Rectangle(370, 247, 61, 55), new Color(255,255,255));
            plane1.Draw(spriteBatch);
            Objects.ForEach(s => s.Draw(spriteBatch));
            // TODO: Add your drawing code here
            spriteBatch.End();
            
            
            base.Draw(gameTime);

            
        }
    }
}
