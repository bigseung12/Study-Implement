using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBasedAutoBattle;

namespace TurnBasedAutoBattle
{
    public class PlayerIdleState : PlayerState
    {
        private float increaseValue;

        protected override void Initialize()
        {
            increaseValue = myPlayer.BehaviourSpeed;
        }

        public override void OnEnter()
        {

        }

        public override void OnUpdate()
        {
            myPlayer.BehaviourBar.value += increaseValue * Time.deltaTime;

            if (100 <= myPlayer.BehaviourBar.value)
            {
                myPlayer.ChangeState(EPlayerState.Attack);
            }
        }

        public override void OnExit()
        {

        }
    }
}