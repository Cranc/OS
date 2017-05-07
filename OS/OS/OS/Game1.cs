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

namespace OS
{
    /// <summary>
    /// This is the main type for the game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Matrix spriteScale;
        
        Texture2D myBackgroundTexture;
        Texture2D myTileTexture;
        Tiles _tiles;
        List<Tuple<Texture2D, Vector2>> mySprites;
        List<Tuple<Rectangle, Vector2>> myTiles;

        AnimatedSprite mySprite;
        Rectangle myMainFrame;

        Viewport viewport;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            mySprite = new AnimatedSprite(Vector2.Zero, 0, 2.0f, 0.5f);
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

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1020;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();

            mySprites = new List<Tuple<Texture2D, Vector2>>();
            myTiles = new List<Tuple<Rectangle, Vector2>>();
            _tiles = new Tiles();

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

            // TODO: use this.Content to load your game content here
            float screenscale = (float)graphics.GraphicsDevice.Viewport.Width / 800f;
            spriteScale = Matrix.CreateScale(screenscale, screenscale, 1);

            myMainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height); 

            myBackgroundTexture = this.Content.Load<Texture2D>("placeholder_background");

            //load tile texture and the Tile class
            myTileTexture = this.Content.Load<Texture2D>("tiles");
            _tiles.Load(this.Content, "tiles", 1, 3);

            mySprite.Load(Content, "chest", 4, 2);
            viewport = graphics.GraphicsDevice.Viewport;

            //load test map
            myTiles = new MyMap(this.Content).Map;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
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

            // TODO: Add your update logic here
            //elapsed time
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            mySprite.UpdateFrame(elapsed);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, spriteScale);
            spriteBatch.Draw(myBackgroundTexture, myMainFrame, Color.White);
            
            //sprites
            foreach(Tuple<Texture2D,Vector2> s in mySprites)
            {
                spriteBatch.Draw(s.Item1, s.Item2, Color.White);
            }
            // draw tiles
            foreach(Tuple<Rectangle,Vector2> t in myTiles)
            {
                spriteBatch.Draw(myTileTexture, t.Item2, t.Item1, Color.White,
                0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
