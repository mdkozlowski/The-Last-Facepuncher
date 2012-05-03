using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheLastFacepuncher.Tiles
{
    public class BlankTile : Tile
    {
        public Vector2 Position;

        public BlankTile(Vector2 vec)
        {
            Position = vec;
        }

        public override void Draw(SpriteBatch sb)
        {
        }
    }
}