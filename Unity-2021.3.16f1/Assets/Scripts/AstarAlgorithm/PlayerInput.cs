using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AstarAlgorithm;

namespace AstarAlgorithm
{
    public class PlayerInput : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("���콺 ��Ŭ��");
            }
        }
    }
}