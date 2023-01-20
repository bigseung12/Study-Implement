using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstarAlgorithm;

namespace AstarAlgorithm
{
    public class Tile : MonoBehaviour
    {
        public Define.ETileType Type { get { return type; } }
        
        [SerializeField] private TileResources resource;

        private Define.ETileType type;

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
            Renderer myRenderer = GetComponent<Renderer>();
            myRenderer.material = resource.Materials[(int)tileType];
        }
    }
}