using System;
using System.Collections.Generic;
using System.Linq;
using GeeUI;
using GeeUI.Views;
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
        Texture2D testLevelr1;
        Texture2D testLevelr2;
        public static Texture2D wallTexture;
        Level testLevel;
        public static Texture2D playerTexture;
        Player player = new Player(new Vector2(50, 50));

        public TLFPGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window.Title = "Iunno";
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
            /*List<FPThread> threads = fpAPI.GetThreads(240);
            foreach (FPThread thread in threads)
            {
                Console.WriteLine("http://www.facepunch.com/avatar/" + thread.AuthorID + ".png");
            }*/
            //Commented out so it doesn't load on each Run.
            GeeUI.GeeUI.Initialize(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            wallTexture = Content.Load<Texture2D>("Textures/wallTexture");
            testLevelr1 = Content.Load<Texture2D>("testlevelr1");
            testLevelr2 = Content.Load<Texture2D>("testlevelr2");
            testLevel = new Level(new List<Room> { new Room(LoadRoom(testLevelr1)), new Room(LoadRoom(testLevelr2)) });
            playerTexture = Content.Load<Texture2D>("Sprites/PlayerSprite");
            player.LoadTexture();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            GeeUI.GeeUI.Update(gameTime);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            testLevel.Draw(spriteBatch);
            GeeUI.GeeUI.Draw(spriteBatch);
            spriteBatch.End();
            //GraphicsDevice.Clear(Color.BurlyWood); Cornflower Blue >:(
            base.Draw(gameTime);
        }
    }
}