using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstarAlgorithm;

namespace AstarAlgorithm
{
    public class MapManager : MonoBehaviour
    {
        public List<Tile> TileList { get { return tileList; } }

        [SerializeField] private Tile tileObject;

        private List<Tile> tileList;

        private void Awake()
        {
            tileList = new List<Tile>(Define.TileTotalCount);

            SpawnMap();
        }

        private void SpawnMap()
        {
            int tilePositionX;
            int tilePositionZ;

            for (int i = 0; i < Define.TileTotalCount; ++i)
            {
                tilePositionX = i % Define.TileCountX;
                tilePositionZ = i / Define.TileCountX;

                Vector3 tilePosition = new Vector3(tilePositionX, 0f, tilePositionZ);
                Tile tile = Instantiate(tileObject, tilePosition, Quaternion.identity);
                tileList.Add(tile);
            }
        }
    }
}