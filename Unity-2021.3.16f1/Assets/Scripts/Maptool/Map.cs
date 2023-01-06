using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapTool;
using System.IO;

namespace MapTool
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] int mapSizeX;
        [SerializeField] int mapSizeY;
        [SerializeField] Material white;
        [SerializeField] Material green;
        [SerializeField] Material blue;
        [SerializeField] Material black;

        private Dictionary<int, Tile> tilesInfo;
        private RaycastHit hitInfo;

        private void Awake()
        {
            tilesInfo = new Dictionary<int, Tile>();
            hitInfo = new RaycastHit();

            int repeatNumber = mapSizeX * mapSizeY;
            Transform[] tiles = GetComponentsInChildren<Transform>();
            Tile tileInfo = new Tile();
            for (int i = 1; i <= repeatNumber; i++)
            {
                tileInfo.tileValue = TileValue.None;
                tileInfo.tile = tiles[i].gameObject;
                tilesInfo[i] = tileInfo;
            }
        }

        public void SetTile(TileValue tileValue)
        {
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                RectTransform rectTransform = (RectTransform)hitInfo.transform;
                int posX = (int)rectTransform.anchoredPosition.x + 1;
                int posY = ((int)rectTransform.anchoredPosition.y * -1);
                int tileSequence = (posY * mapSizeX) + posX;

                MeshRenderer mesh = tilesInfo[tileSequence].tile.GetComponent<MeshRenderer>();
                switch (tileValue)
                {
                    case TileValue.None:
                        mesh.material = white;
                        break;

                    case TileValue.Bush:
                        mesh.material = green;
                        break;

                    case TileValue.River:
                        mesh.material = blue ;
                        break;

                    case TileValue.Wall:
                        mesh.material = black;
                        break;
                }

                TileValue newValue = tileValue;
                Tile newTile = new Tile();
                newTile.tileValue = newValue;
                newTile.tile = tilesInfo[tileSequence].tile;
                tilesInfo[tileSequence] = newTile;
            }
        }

        public void SaveMap()
        {
            FileStream file = File.Create(Application.dataPath + "/Data/MapData.csv");
            StreamWriter writter = new StreamWriter(file);

            int repeatNumber = mapSizeX * mapSizeY;
            for (int i = 1; i <= repeatNumber; ++i)
            {
                writter.WriteLine(tilesInfo[i].tileValue);
            }

            writter.Close();
            file.Close();
        }

        public void LoadMap()
        {
            FileStream file = new FileStream(Application.dataPath + "/Data/MapData.csv", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            int repeatNumber = mapSizeX * mapSizeY;
            for (int i = 1; i <= repeatNumber; ++i)
            {
                string data = reader.ReadLine();

                TileValue tileValue = TileValue.None;
                if (data == "None")
                {
                    tileValue = TileValue.None;
                }
                else if (data == "Bush")
                {
                    tileValue = TileValue.Bush;
                }
                else if (data == "River")
                {
                    tileValue = TileValue.River;
                }
                else if (data == "Wall")
                {
                    tileValue = TileValue.Wall;
                }

                Tile newTile = new Tile();
                newTile.tileValue = tileValue;
                newTile.tile = tilesInfo[i].tile;
                tilesInfo[i] = newTile;

                MeshRenderer mesh = tilesInfo[i].tile.GetComponent<MeshRenderer>();
                switch (tileValue)
                {
                    case TileValue.None:
                        mesh.material = white;
                        break;

                    case TileValue.Bush:
                        mesh.material = green;
                        break;

                    case TileValue.River:
                        mesh.material = blue;
                        break;

                    case TileValue.Wall:
                        mesh.material = black;
                        break;
                }
            }

            reader.Close();
            file.Close();
        }
    }
}