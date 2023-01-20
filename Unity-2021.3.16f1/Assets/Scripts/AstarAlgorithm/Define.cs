using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstarAlgorithm;

namespace AstarAlgorithm
{
    public class Define : MonoBehaviour
    {
        public enum ETileType
        {
            None,
            Wall,
        }

        public const int TileCountX = 20;
        public const int TileCountZ = 20;
        public const int TileTotalCount = TileCountX * TileCountZ;
        public const int TileSize = 1;
        public const int WallProbability = 20;
    }
}