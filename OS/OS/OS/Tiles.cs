using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OS
{
    class Tiles
    {
        private int frameRowcount;
        private int frameColumcount;
        private Texture2D myTexture;
        public float Rotation, Scale, Depth;
        public Vector2 Origin;

        public void Load(ContentManager content, string asset,
    int frameRowCount, int frameColumCount)
        {
            frameRowcount = frameRowCount;
            frameColumcount = frameColumCount;
            myTexture = content.Load<Texture2D>(asset);
        }
    }

}
