using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField]
    private int NumberOfEnemy;
    [SerializeField]
    private float MinX;
    [SerializeField]
    private float MaxX;
    [SerializeField]
    private float MinZ;
    [SerializeField]
    private float MaxZ;

    void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        Vector3 position = new Vector3(0f, 0f, 0f);
        Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
        for (int i = 0; i < NumberOfEnemy; i++)
        {
            position.Set(Random.Range(MinX, MaxX), 0f, Random.Range(MinZ, MaxZ));
            Instantiate(EnemyPrefab, position, rotation);
        }
    }
}