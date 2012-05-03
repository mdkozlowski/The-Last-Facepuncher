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
using TheLastFacepuncher.FacepunchApi;
using TheLastFacepuncher.Tiles;

namespace TheLastFacepuncher
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TLFPGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static FpAPI fpAPI = new FpAPI("TLFacepuncher", "a73f6ed15af9f91d4a05855a4a38b5ba");
        Texture2D _testLevel;
        Level testLevel;

        public TLFPGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window.Title = "The Last Facepuncher";
        }

        public Color[,] LoadRoom(Texture2D levelTexture)
        {
            //The levels are going to be procedurally generated, but for testing purposes they will be loaded from images

            //Loading the image into a 2D array for ease of use
            Color[] colors1D = new Color[levelTexture.Width * levelTexture.Height];
            levelTexture.GetData(colors1D);
            Color[,] colors2D = new Color[levelTexture.Width, levelTexture.Height];
            for (int x = 0; x < levelTexture.Width; x++)
                for (int y = 0; y < levelTexture.Height; y++)
                    colors2D[x, y] = colors1D[x + y * levelTexture.Width];
            return colors2D;
        }

        protected override void Initialize()
        {
            List<FPThread> threads = fpAPI.GetThreads(240);
            foreach (FPThread thread in threads)
            {
                Console.WriteLine("http://www.facepunch.com/avatar/" + thread.AuthorID + ".png");
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _testLevel = Content.Load<Texture2D>("testlevel");
            testLevel = new Level(new List<Room> { new Room(LoadRoom(_testLevel)) });
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.BurlyWood); Cornflower Blue >:(
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}