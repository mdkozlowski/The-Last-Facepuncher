using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TheLastFacepuncher.Tiles;

namespace TheLastFacepuncher
{
    public class Level
    {
        public List<Room> Rooms = new List<Room>();
        public Room currentRoom;

        public Level()
        {
        }

        public Level(List<Room> Rooms)
        {
            this.Rooms = Rooms;
            currentRoom = Rooms[0];
        }

        public void Update(GameTime gT)
        {
            currentRoom.Update(gT);
        }

        public void Draw(SpriteBatch sb)
        {
            currentRoom.Draw(sb);
        }
    }
}