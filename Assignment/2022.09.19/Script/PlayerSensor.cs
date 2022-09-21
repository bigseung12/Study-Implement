using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    [SerializeField]
    private GameManager Manager;
    [SerializeField]
    private GameObject CloseEnemy;

    public float _targetMagnitude = 10000f;

    void Update()
    {
        FindCloseEnemy();
    }

    void FindCloseEnemy()
    {
        int positionX = (int)transform.position.x;
        int positionZ = (int)transform.position.z;
        _targetMagnitude = Vector3.SqrMagnitude(CloseEnemy.transform.position - transform.position);
        for (int i = positionX - 6; i <= positionX + 6; i++)
        {
            if (i < -100 || 100 < i)
            {
                continue;
            }

            for (int j = positionZ - 6; j <= positionZ + 6; j++)
            {
                if (j < -100 || 100 < j)
                {
                    continue;
                }

                Vector3Int findIndex = ChangeToIndex(new Vector3(i, 0f, j));
                foreach (GameObject enemy in Manager.EnemyPosition[findIndex.x, findIndex.z])
                {
                    float newMagnitude = Vector3.SqrMagnitude(enemy.transform.position - transform.position);

                    if (newMagnitude < _targetMagnitude)
                    {
                        ChangeColor(CloseEnemy, enemy);
                        CloseEnemy = enemy;
                    }
                }
            }
        }

        //if (10f < _targetMagnitude)
        //{
        //    Material material = CloseEnemy.GetComponent<MeshRenderer>().material;
        //    material.color = new Color(255f, 255f, 255f);
        //}
    }

    private Vector3Int ChangeToIndex(Vector3 index)
    {
        // 나올 수 있는 값 : -100 ~ 100
        int newIndexX = (int)index.x;
        if (newIndexX <= 0)
        {
            newIndexX *= -1;
            newIndexX = 100 - newIndexX;
        }
        else
        {
            newIndexX += 100;
        }

        int newIndexZ = (int)index.z;
        if (newIndexZ <= 0)
        {
            newIndexZ *= -1;
            newIndexZ = 100 - newIndexZ;
        }
        else
        {
            newIndexZ += 100;
        }

        return new Vector3Int(newIndexX, 0, newIndexZ);
    }

    private void ChangeColor(GameObject oldObject, GameObject newObject)
    {
        Material oldObjectMaterial = oldObject.GetComponent<MeshRenderer>().material;
        Material newObjectMaterial = newObject.GetComponent<MeshRenderer>().material;

        oldObjectMaterial.color = new Color(255f, 255f, 255f);
        newObjectMaterial.color = new Color(255f, 0f, 0f);
    }
}