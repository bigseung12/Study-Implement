using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AstarAlgorithm;

namespace AstarAlgorithm
{
    public class PathfindingTool : MonoBehaviour
    {
        // �켱���� ť�� �̿��Ͽ� �޸���ƽ�� ���� ������ Ž���ϰԲ�
        // �켱���� ť�� �̿����� ���ϸ�? �� Ž���ؼ� ����?
        // �׷� �� �� Ž���� ������ ������ ����Ʈ�� ���� ��ȸ�ϸ鼭 ���� Ž���� ����Ʈ�� ��󳽴�?
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