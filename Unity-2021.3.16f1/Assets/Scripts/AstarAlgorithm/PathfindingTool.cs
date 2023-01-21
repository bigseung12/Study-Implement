using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AstarAlgorithm;

namespace AstarAlgorithm
{
    public class PathfindingTool : MonoBehaviour
    {
        // 우선순위 큐를 이용하여 휴리스틱이 높은 노드부터 탐색하게끔
        // 우선순위 큐를 이용하지 못하면? 다 탐색해서 진행?
        // 그럼 한 번 탐색을 진행할 때마다 리스트를 전부 조회하면서 먼저 탐색할 리스트를 골라낸다?
        [SerializeField] private static MapManager mapManager;

        public static void AstarPathfinding(Vector3 startPoint, Vector3 destination)
        {
            List<int> visitIndexList = new List<int>(Define.TileTotalCount);
            bool[] isVisited = Enumerable.Repeat(false, Define.TileTotalCount).ToArray();

            int startIndex = ((int)startPoint.y * Define.TileCountX) + (int)startPoint.x;
            isVisited[startIndex] = true;
            visitIndexList.Add(startIndex);

            int[] aroundNodeIndex = new int[4] { Define.TileCountX, -(Define.TileCountZ), -1, 1 };

            while (visitIndexList.Count != 0)
            {
                int minHeuristics = int.MaxValue;
                foreach (int nextNodeIndex in visitIndexList)
                {
                    Tile searchingTile;
                    if (mapManager.TileList[nextNodeIndex].Heuristics < minHeuristics)
                    {
                        searchingTile = mapManager.TileList[nextNodeIndex];
                    }
                }

                for (int i = 0; i < 4; ++i)
                {
                    int checkNodeIndex = aroundNodeIndex[i];
                }
            }
        }
    }
}