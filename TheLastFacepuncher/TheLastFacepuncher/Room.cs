using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheLastFacepuncher.Tiles;

namespace TheLastFacepuncher
{
    public class Room
    {
        public Tile[,] Tiles = new Tile[40, 24];

        public Room(Color[,] TextureData)
        {
            Tiles = ParseImage(TextureData);
        }

        public Tile[,] ParseImage(Color[,] colorData)
        {
            Tile[,] Tiles = new Tile[40, 24];
            for (int x = 0; x < 40; x++)
                for (int y = 0; y < 24; y++)
                {
                    //Assign blank tiles for initialisation
                    Tiles[x, y] = new BlankTile(new Vector2(x, y));
                }

            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    if (colorData[x, y] == Color.Black)
                    {
                        Tiles[x, y] = new Wall(new Vector2(x, y));
                    }
                }
            }
            return Tiles;
        }

        public void Update(GameTime gT)
        {
        }

        public void Draw(SpriteBatch sb)
        {
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    Tiles[x, y].Draw(sb);
                }
            }
        }
    }
}