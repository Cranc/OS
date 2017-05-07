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
        private List<Tuple<Rectangle, Vector2>> _map;
        private Tiles _tiles;
        public MyMap(ContentManager c)
        {
            content = c;
            _tiles = new Tiles();
            generateMap();
        }

        private void generateMap()
        {
            _tiles.Load(content, "tiles", 1, 3);
            float x, y;
            x = y = 5;
            _map = new List<Tuple<Rectangle, Vector2>>();
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(0), new Vector2(x, y)));
            x = y += 50;
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(1), new Vector2(x, y)));
            x = y += 50;
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(2), new Vector2(x, y)));
            //_map.Add(new Tuple<Rectangle, Vector2>(content.Load<Texture2D>("chest"), new Vector2(x, y)));
        }

        public List<Tuple<Rectangle, Vector2>> Map
        {
            get { return _map; }
        }
    }
}