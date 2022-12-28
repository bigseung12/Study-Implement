using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBasedAutoBattle;
using TMPro;

namespace TurnBasedAutoBattle
{
    public abstract class PlayerActionController : MonoBehaviour
    {
        [SerializeField] protected int A_skillCool;
        [SerializeField] protected int B_skillCool;
        [SerializeField] protected int A_skillPriority;
        [SerializeField] protected int B_skillPriority;
        [SerializeField] protected TextMeshProUGUI usingSkillMessage;

        protected Player myPlayer;
        protected int A_skillRemainingCool;
        protected int B_skillRemainingCool;

        public void Initialize(Player player)
        {
            myPlayer = player;
        }

        protected abstract void UseSkillTypeA();
        protected abstract void UseSkillTypeB();

        public abstract void SetNextAction();

        public abstract void UpdateSkillCool();

        protected IEnumerator PopUpUsingSkillMessage(string message)
        {
            float fadeOutSpeed = 1f;
            Color color = usingSkillMessage.color;
            usingSkillMessage.text = message;
            color.a = 1f;
            usingSkillMessage.color = color;

            while (0f < usingSkillMessage.color.a)
            {
                color.a -= fadeOutSpeed * Time.deltaTime;
                usingSkillMessage.color = color;
                yield return null;
            }
        }
    }
}