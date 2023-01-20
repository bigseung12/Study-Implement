using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstarAlgorithm;

namespace AstarAlgorithm
{
    [CreateAssetMenu(fileName = "TileResources", menuName = "AstarAlgorithm/TileResources")]
    public class TileResources : ScriptableObject
    {
        public Material[] Materials { get { return materials; } }

        [SerializeField] private Material[] materials;
    }
}