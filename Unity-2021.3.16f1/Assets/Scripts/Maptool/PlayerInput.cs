using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapTool;

namespace MapTool
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Map map;

        public TileValue InstallTileValue { get { return installTileValue; } }

        private TileValue installTileValue;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                installTileValue = TileValue.None;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                installTileValue = TileValue.Bush;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                installTileValue = TileValue.River;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                installTileValue = TileValue.Wall;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                map.SetTile(installTileValue);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                map.SaveMap();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                map.LoadMap();
            }
        }
    }
}