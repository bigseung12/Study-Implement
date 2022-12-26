using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBasedAutoBattle;

namespace TurnBasedAutoBattle
{
    public class BattleManager : MonoBehaviour
    {
        public bool IsInteracting { get { return isInteracting; } }

        private bool isInteracting;

        private void Awake()
        {
            isInteracting = false;
        }

        public void ChangeState(bool value)
        {
            isInteracting = value;
        }
    }
}