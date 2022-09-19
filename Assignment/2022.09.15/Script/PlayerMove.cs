using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private enum PlayerState
    {
        Waiting,
        Moving
    }

    [SerializeField]
    private Map NowLocation;
    [SerializeField]
    private float MoveSpeed;
    [SerializeField]
    private float stopDistance;

    private PlayerState _state;
    private WaitForFixedUpdate _waitForFixedUpdate;

    public Map destination;

    void Start()
    {
        _state = PlayerState.Waiting;
        _waitForFixedUpdate = new WaitForFixedUpdate();
    }

    void Update()
    {
        switch (_state)
        {
            case PlayerState.Waiting:
                WaitingUpdate();
                break;
            case PlayerState.Moving:
                MovingUpdate();
                break;
        }
    }

    void WaitingUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            destination = NowLocation.LinkMapList[(int)Map.LinkMapIndex.Left];
            if (destination != null)
            {
                StartCoroutine(MoveToDestination(destination));
                _state = PlayerState.Moving;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            destination = NowLocation.LinkMapList[(int)Map.LinkMapIndex.Right];
            if (destination != null)
            {
                StartCoroutine(MoveToDestination(destination));
                _state = PlayerState.Moving;
            }
        }
    }
    
    void MovingUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("좀 기다려라. 목적지 가고 있잖아 ㅡㅡ");
        }
    }

    IEnumerator MoveToDestination(Map destination)
    {
        Vector3 moveDirection = (destination.transform.position - transform.position).normalized;
        float distance = (destination.transform.position - transform.position).sqrMagnitude;
        while (stopDistance <= distance)
        {
            transform.Translate(moveDirection * MoveSpeed * Time.fixedDeltaTime);
            distance = (destination.transform.position - transform.position).magnitude;

            yield return _waitForFixedUpdate;
        }

        NowLocation = destination;
        _state = PlayerState.Waiting;
    }
}