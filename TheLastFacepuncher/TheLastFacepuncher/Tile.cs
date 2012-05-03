using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheLastFacepuncher.Tiles;

namespace TheLastFacepuncher
{
    public abstract class Tile
    {
        public Vector2 Position;
        public Texture2D Texture;

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(Texture, new Vector2(Position.X * 20, Position.Y * 20), Color.White);
        }
    }
}