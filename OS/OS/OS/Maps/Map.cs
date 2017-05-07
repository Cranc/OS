using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace OS.Maps
{
    public class MyMap
    {
        private ContentManager content;
        private List<Tuple<Rectangle, Vector2>> _map;
        private Tiles _tiles;
        private TileMap t;
        public MyMap(ContentManager c, Tiles t, TileMap tm)
        {
            content = c;
            _tiles = t;
            this.t = tm;
            generateMap();
        }

        private void generateMap()
        {
            _tiles.Load(content, "tiles", 1, 3);
            float x, y;
            _map = new List<Tuple<Rectangle, Vector2>>();
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(0), t.GetPositionOf(0, 0)));
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(1), t.GetPositionOf(0, 1)));
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(2), t.GetPositionOf(0, 2)));
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(2), t.GetPositionOf(1, 2)));
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(2), t.GetPositionOf(2, 2)));
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(2), t.GetPositionOf(3, 2)));
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(2), t.GetPositionOf(4, 2)));
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(2), t.GetPositionOf(5, 2)));
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(2), t.GetPositionOf(8, 2)));
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(2), t.GetPositionOf(9, 2)));
            _map.Add(new Tuple<Rectangle, Vector2>(_tiles.getTileById(2), t.GetPositionOf(10, 2)));
            //_map.Add(new Tuple<Rectangle, Vector2>(content.Load<Texture2D>("chest"), new Vector2(x, y)));
        }

        public List<Tuple<Rectangle, Vector2>> Map
        {
            get { return _map; }
        }
    }
}