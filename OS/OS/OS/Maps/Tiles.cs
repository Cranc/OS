using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OS.Maps
{
    public class Tiles
    {
        private int frameRowcount;
        private int frameColumncount;
        private Texture2D myTexture;
        public int tilesize = 32;

        public void Load(ContentManager content, 
            string asset, 
            int frameRowCount, 
            int frameColumnCount)
        {
            frameRowcount = frameRowCount;
            frameColumncount = frameColumnCount;
            myTexture = content.Load<Texture2D>(asset);
        }

        public Rectangle getTileById(int id)
        {
            int FrameWidth = myTexture.Width / frameColumncount;
            int FrameHeight = myTexture.Height / frameRowcount;

            int column = id % frameRowcount;
            int row = id / frameRowcount;

            return new Rectangle(
                FrameWidth * row,
                FrameHeight * column,
                FrameWidth,
                FrameHeight);
        }

    }
}
