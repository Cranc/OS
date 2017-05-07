using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OS.Maps
{
    /// <summary>
    /// TileMap class stores a tileMap for the Game which includes ID's of the tiles on the map.
    /// </summary>
    public class TileMap
    {
        private int[,] tileMap;
        private int boundingBoxWidth = 32;
        private int boundingBoxHeight = 32;

        public TileMap(uint tileCountWidth,
            uint screenWidth, 
            uint screenHeight)
        {

            boundingBoxHeight = boundingBoxWidth = (int)Math.Ceiling((double)screenWidth / tileCountWidth);
            int tileCountHeight = (int)Math.Ceiling((double)screenHeight / boundingBoxHeight);

            tileMap = new int[tileCountWidth, tileCountHeight];

        }
        /// <summary>
        /// returns the position of a given tile in screen coordinates.
        /// </summary>
        /// <param name="x">column</param>
        /// <param name="y">row</param>
        /// <returns>Screen position inside a Vector</returns>
        public Vector2 GetPositionOf(int x, int y)
        {
            return new Vector2(x * boundingBoxWidth, y * boundingBoxHeight);
        }
        /// <summary>
        /// returns the number of columns in the map.
        /// </summary>
        /// <returns>number of columns</returns>
        public int GetTileCountWidth()
        {
            return tileMap.GetLength(0);
        }
        /// <summary>
        /// returns the number of rows in the map.
        /// </summary>
        /// <returns>number of rows</returns>
        public int GetTileCountHeight()
        {
            return tileMap.GetLength(1);
        }
        /// <summary>
        /// gets or sets the value of the given tile.
        /// </summary>
        /// <param name="x">Column</param>
        /// <param name="y">Row</param>
        /// <returns></returns>
        public int this[int x, int y]
        {
            get { return tileMap[x, y]; }
            set { tileMap[x, y] = value; }
        }
        /// <summary>
        /// gets the pixel size of the current tile size
        /// </summary>
        /// <returns>tile size</returns>
        public int GetTileSize()
        {
            return boundingBoxWidth;
        }
    }
}
