using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstarAlgorithm;

namespace AstarAlgorithm
{
    public class PathfindingTool : MonoBehaviour
    {
        // 우선순위 큐를 이용하여 휴리스틱이 높은 노드부터 탐색하게끔
        // 우선순위 큐를 이용하지 못하면? 다 탐색해서 진행?
        public static void AstarPathfinding(Vector3 startPoint, Vector3 destination)
        {
            bool[] isVisited = new bool[Define.TileTotalCount];
        }
    }
}