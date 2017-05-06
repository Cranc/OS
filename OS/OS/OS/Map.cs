using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace OS
{
    public class MyMap
    {
        private ContentManager content;
        private List<Tuple<Texture2D, Vector2>> _map;
        public MyMap(ContentManager c)
        {
            content = c;
            generateMap();
        }

        private void generateMap()
        {
            float x, y;
            x = y = 5;
            _map = new List<Tuple<Texture2D, Vector2>>();
            _map.Add(new Tuple<Texture2D, Vector2>(content.Load<Texture2D>("chest"), new Vector2(x, y)));
        }

        public List<Tuple<Texture2D, Vector2>> Map
        {
            get { return _map; }
        }
    }
}