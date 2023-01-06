using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBasedAutoBattle;

namespace TurnBasedAutoBattle
{
    public abstract class PlayerState : MonoBehaviour
    {
        protected Player myPlayer;

        public void BaseInitialize(Player player)
        {
            myPlayer = player;
            Initialize();
        }

        protected abstract void Initialize();

        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
    }
}