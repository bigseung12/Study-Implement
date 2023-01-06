using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapTool;

namespace MapTool
{
    public enum TileValue
    {
        None,
        Bush,
        River,
        Wall,
    }

    public struct Tile
    {
        public TileValue tileValue;
        public GameObject tile;

        public void ChangeTile(TileValue value)
        {
            Debug.Log("¿€µø«ÿ!");
            tileValue = value;
        }
    }
}