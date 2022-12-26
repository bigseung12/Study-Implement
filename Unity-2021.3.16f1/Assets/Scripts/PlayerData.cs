using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBasedAutoBattle;

namespace TurnBasedAutoBattle
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "TurnBasedAutoBattle/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public int AttackPowerMinValue { get { return attackPowerMinValue; } }
        public int AttackPowerMaxValue { get { return attackPowerMaxValue; } }
        public int BehaviourSpeedMinValue { get { return behaviourSpeedMinValue; } }
        public int BehaviourSpeedMaxValue { get { return behaviourSpeedMaxValue; } }
        public int HealthPointMinValue { get { return healthPointMinValue; } }
        public int HealthPointMaxValue { get { return healthPointMaxValue; } }

        [SerializeField] private int healthPointMinValue;
        [SerializeField] private int healthPointMaxValue;
        [SerializeField] private int attackPowerMinValue;
        [SerializeField] private int attackPowerMaxValue;
        [SerializeField] private int behaviourSpeedMinValue;
        [SerializeField] private int behaviourSpeedMaxValue;
    }
}