using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstarAlgorithm;

namespace AstarAlgorithm
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private GameObject tile;

        private void Awake()
        {
            int tilePositionX;
            int tilePositionZ;

            for (int i = 0; i < Define.TileCountMax; ++i)
            {
                tilePositionX = i % Define.TileCountX;
                tilePositionZ = i / Define.TileCountX;

                Vector3 tilePosition = new Vector3(tilePositionX, 0f, tilePositionZ);
                Instantiate(tile, tilePosition, Quaternion.identity);
            }
        }
    }
}