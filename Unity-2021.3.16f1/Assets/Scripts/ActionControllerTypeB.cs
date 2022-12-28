using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TurnBasedAutoBattle;

namespace TurnBasedAutoBattle
{
    public class ActionControllerTypeB : PlayerActionController
    {
        private void Awake()
        {
            A_skillRemainingCool = A_skillCool;
            B_skillRemainingCool = B_skillCool;
        }

        public override void SetNextAction()
        {

        }

        public override void UpdateSkillCool()
        {
            if (A_skillRemainingCool == 0)
            {
                UseSkillTypeA();
                return;
            }
            else if (B_skillRemainingCool == 0)
            {
                UseSkillTypeB();
                return;
            }

            A_skillRemainingCool--;
            B_skillRemainingCool--;

            if (A_skillRemainingCool == 0 && B_skillRemainingCool == 0)
            {
                if (A_skillPriority <= B_skillPriority)
                {
                    UseSkillTypeB();
                }
                else
                {
                    UseSkillTypeA();
                }
            }
            else if (A_skillRemainingCool == 0)
            {
                UseSkillTypeA();
            }
            else if (B_skillRemainingCool == 0)
            {
                UseSkillTypeB();
            }
            else
            {
                myPlayer.AttackToTarget(myPlayer.AttackPower);
            }
        }

        protected override void UseSkillTypeA()
        {
            int attackPower = Mathf.RoundToInt((myPlayer.AttackPower * 130) / 100);
            myPlayer.Enemy.TakeDamage(attackPower);
            StartCoroutine(PopUpUsingSkillMessage("Using Skill A !!!"));
            A_skillRemainingCool = A_skillCool;
        }

        protected override void UseSkillTypeB()
        {
            int attackPower = Mathf.RoundToInt((myPlayer.AttackPower * 90) / 100);
            myPlayer.Enemy.TakeDamage(attackPower);
            myPlayer.Enemy.TakeDamage(attackPower);
            StartCoroutine(PopUpUsingSkillMessage("Using Skill B !!!"));
            B_skillRemainingCool = B_skillCool;
        }
    }
}