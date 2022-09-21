using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed;

    private float _inputX = 0f;
    private float _inputY = 0f;

    void Update()
    {
        _inputX = 0f;
        _inputY = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) { _inputY += 1; }
        if (Input.GetKey(KeyCode.DownArrow)) { _inputY -= 1; }
        if (Input.GetKey(KeyCode.LeftArrow)) { _inputX -= 1; }
        if (Input.GetKey(KeyCode.RightArrow)) { _inputX += 1; }

        Move();
    }

    private void Move()
    {
        Vector3 movePosition = MoveSpeed * Time.deltaTime * new Vector3(_inputX, 0f, _inputY).normalized;
        transform.position += movePosition;
    }
}