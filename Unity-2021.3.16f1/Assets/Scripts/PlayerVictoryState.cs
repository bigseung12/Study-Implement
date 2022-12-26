using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBasedAutoBattle;

namespace TurnBasedAutoBattle
{
    public class PlayerVictoryState : PlayerState
    {
        protected override void Initialize()
        {

        }

        public override void OnEnter()
        {
            StopAllCoroutines();
        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

        }
    }
}