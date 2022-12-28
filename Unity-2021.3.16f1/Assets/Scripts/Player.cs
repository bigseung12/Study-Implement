using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBasedAutoBattle;
using UnityEngine.UI;
using TMPro;

namespace TurnBasedAutoBattle
{
    public class Player : MonoBehaviour, IDamageable
    {
        public int HealthPoint { get { return healthPoint; } }
        public int MaxHealthPoint { get { return maxHealthPoint; } }
        public int AttackPower { get { return attackPower; } }
        public int BehaviourSpeed { get { return behaviourSpeed; } }
        public Slider HealthBar { get { return healthBar; } }
        public Slider BehaviourBar { get { return behaviourBar; } }
        public Vector3 MovePoint { get { return movePoint; } }
        public Player Enemy { get { return enemy; } }
        public PlayerActionController MyActionController { get { return myActionController; } }
        public int DefenseValue { get { return defense; } }

        [SerializeField] private PlayerData playerData;
        [SerializeField] private Slider healthBar;
        [SerializeField] private Slider behaviourBar;
        [SerializeField] private TextMeshProUGUI takeDamageMessage;
        [SerializeField] private Vector3 movePoint;
        [SerializeField] private Player enemy;
        [SerializeField] private PlayerActionController myActionController;

        private int healthPoint;
        private int maxHealthPoint;
        private int attackPower;
        private int behaviourSpeed;
        private int defense;

        private Dictionary<EPlayerState, PlayerState> myStates;
        private PlayerState nowState;

        private PlayerState idleState;
        private PlayerState attackState;
        private PlayerState takeDamageState;
        private PlayerState victoryState;

        private void Awake()
        {
            healthPoint = Random.Range(playerData.HealthPointMinValue, playerData.HealthPointMaxValue + 1);
            maxHealthPoint = healthPoint;
            attackPower = Random.Range(playerData.AttackPowerMinValue, playerData.AttackPowerMaxValue + 1);
            behaviourSpeed = Random.Range(playerData.BehaviourSpeedMinValue, playerData.BehaviourSpeedMaxValue + 1);
            defense = Random.Range(playerData.DefenseMinValue, playerData.DefenseMaxValue);

            myActionController.Initialize(this);

            myStates = new Dictionary<EPlayerState, PlayerState>();

            idleState = GetComponent<PlayerIdleState>();
            attackState = GetComponent<PlayerAttackState>();
            takeDamageState = GetComponent<PlayerTakeDamageState>();
            victoryState = GetComponent<PlayerVictoryState>();

            AddState(EPlayerState.Idle, idleState);
            AddState(EPlayerState.Attack, attackState);
            AddState(EPlayerState.TakeDamage, takeDamageState);
            AddState(EPlayerState.Victory, victoryState);

            ChangeState(EPlayerState.Idle);
        }

        private void Update()
        {
            nowState.OnUpdate();
        }

        public void AddState(EPlayerState stateKey, PlayerState state)
        {
            state.BaseInitialize(this);
            myStates[stateKey] = state;
        }

        public void ChangeState(EPlayerState stateKey)
        {
            if (nowState != null)
            {
                nowState.OnExit();
            }
            nowState = myStates[stateKey];
            nowState.OnEnter();
        }

        public void Healing(int power)
        {
            healthPoint += power;
            StartCoroutine(IncreaseHealthPoint(power));
        }

        public void AttackToTarget(int power)
        {
            enemy.TakeDamage(power);
        }

        public void TakeDamage(int power)
        {
            int takeDamageValue = power - defense;
            healthPoint -= takeDamageValue;
            ChangeState(EPlayerState.TakeDamage);
            StartCoroutine(DecreaseHealthPoint(healthPoint));
            StopCoroutine(PopUpTakeDamageMessage(takeDamageValue));
            StartCoroutine(PopUpTakeDamageMessage(takeDamageValue));
        }

        IEnumerator IncreaseHealthPoint(int targetValue)
        {
            float increaseSpeed = 20f;

            while (healthBar.value < targetValue)
            {
                healthBar.value += increaseSpeed * Time.deltaTime;
                yield return null;
            }
        }

        IEnumerator DecreaseHealthPoint(int targetValue)
        {
            float decreaseSpeed = 20f;

            while (targetValue < healthBar.value)
            {
                healthBar.value -= decreaseSpeed * Time.deltaTime;
                yield return null;
            }

            if (healthBar.value <= 0f)
            {
                Enemy.ChangeState(EPlayerState.Victory);
                Destroy(gameObject);
            }
        }

        IEnumerator PopUpTakeDamageMessage(int power)
        {
            float fadeOutSpeed = 1f;
            Color color = takeDamageMessage.color;
            takeDamageMessage.text = power.ToString();
            color.a = 1f;
            takeDamageMessage.color = color;

            while (0f < takeDamageMessage.color.a)
            {
                color.a -= fadeOutSpeed * Time.deltaTime;
                takeDamageMessage.color = color;
                yield return null;
            }
        }
    }
}