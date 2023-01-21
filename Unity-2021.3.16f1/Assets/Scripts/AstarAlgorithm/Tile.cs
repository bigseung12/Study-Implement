using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstarAlgorithm;

namespace AstarAlgorithm
{
    public class Tile : MonoBehaviour
    {
        public Define.ETileType Type { get { return type; } }
        public int Heuristics { get { return heuristics; } set { heuristics = value; } }
        
        [SerializeField] private TileResources resource;

        private Define.ETileType type;
        private int heuristics = 0;

        private void Start()
        {
            int randomValue = Random.Range(1, 101);

            if (randomValue <= Define.WallProbability)
            {
                ChangeTile(Define.ETileType.Wall);
            }
        }

        private void ChangeTile(Define.ETileType tileType)
        {
            type = tileType;

            Renderer myRenderer = GetComponent<Renderer>();
            myRenderer.material = resource.Materials[(int)tileType];
        }
    }
}