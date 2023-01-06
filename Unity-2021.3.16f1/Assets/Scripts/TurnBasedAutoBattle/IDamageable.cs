using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBasedAutoBattle;

namespace TurnBasedAutoBattle
{
    public interface IDamageable
    {
        public void TakeDamage(int power);
    }
}