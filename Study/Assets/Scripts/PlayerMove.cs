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
        DrawLine();
    }

    private void Move()
    {
        Vector3 movePosition = new Vector3(_inputX, _inputY, 0f).normalized * MoveSpeed * Time.deltaTime;
        transform.position += movePosition;
    }

    private void DrawLine()
    {
        Vector3 upPosition = new Vector3(0f, 0.5f, 0f);
        Vector3 downPosition = new Vector3(0f, -0.5f, 0f);
        Vector3 leftPosition = new Vector3(-0.5f, 0f, 0f);
        Vector3 rightPosition = new Vector3(0.5f, 0f, 0f);

        Debug.DrawLine(transform.position, upPosition);
        Debug.DrawLine(transform.position, downPosition);
        Debug.DrawLine(transform.position, leftPosition);
        Debug.DrawLine(transform.position, rightPosition);
    }
}