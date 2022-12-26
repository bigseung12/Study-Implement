using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBasedAutoBattle;

namespace TurnBasedAutoBattle
{
    public class PlayerAttackState : PlayerState
    {
        private Vector3 initialPosition;
        private float elapsedTime;

        protected override void Initialize()
        {

        }

        public override void OnEnter()
        {
            initialPosition = transform.position;
            elapsedTime = 0f;
            myPlayer.Enemy.TakeDamage(myPlayer.AttackPower);
        }

        public override void OnUpdate()
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(initialPosition, myPlayer.MovePoint, elapsedTime);

            if (1 <= elapsedTime)
            {
                myPlayer.ChangeState(EPlayerState.Idle);
                myPlayer.Enemy.ChangeState(EPlayerState.Idle);
            }
        }

        public override void OnExit()
        {
            StartCoroutine(ReturnPosition());
            myPlayer.BehaviourBar.value = 0f;
        }

        IEnumerator ReturnPosition()
        {
            float elapsedTimeInCoroutine = 0f;

            while (elapsedTimeInCoroutine < 1f)
            {
                elapsedTimeInCoroutine += Time.deltaTime;
                transform.position = Vector3.Lerp(myPlayer.MovePoint, initialPosition, elapsedTime);
                yield return null;
            }
        }
    }
}