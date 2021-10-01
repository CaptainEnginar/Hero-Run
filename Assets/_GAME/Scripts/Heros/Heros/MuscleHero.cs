using System.Collections;
using System.Collections.Generic;
using Ability;
using Heros.Controller;
using UnityEngine;

namespace Heros
{
    public class MuscleHero : AHero
    {

        [SerializeField] private HeroSettings _heroSettings;
        public Animator animator;

        private AHeroController _heroController;
        private float _currentSpeed;
        private CapsuleCollider _collider;

        private void Awake()
        {
            _currentSpeed = _heroSettings.NormalSpeed;

            animator = GetComponent<Animator>();
            _collider = GetComponent<CapsuleCollider>();
            _heroController = GetComponentInParent<AHeroController>();
        }

        public override void SetActive()
        {
            gameObject.SetActive(true);
        }

        public override void DeActive()
        {
            gameObject.SetActive(false);
        }

        public void Kick()
        {
            animator.SetTrigger("Attack");
        }

        public override void RightInteraction()
        {
            ChangeSpeed(_heroSettings.RightSpeed);
            Kick();
        }

        public override void WrongInteraction(AbilityType abilityType)
        {
            ChangeSpeed(_heroSettings.WrongSpeed);
            switch (abilityType)
            {
                case AbilityType.FLY:
                    if (_heroController.GetInSpaceArea())
                        animator.SetBool("Fall", true);
                    else
                        animator.SetBool("LeeryWalk", true);
                        break;
                case AbilityType.FLEX:
                    animator.SetBool("LookingInside",true);
                    break;
            }  
        }

        public override void ResetIntegration()
        {
            ChangeSpeed(_heroSettings.NormalSpeed);
            animator.SetBool("LookingInside", false);
            animator.SetBool("Fall", false);
            animator.SetBool("LeeryWalk", false);
        }

        public override AbilityType GetAbility()
        {
            return _heroSettings.AbilityType;
        }

        public override HeroSettings GetHeroSettings()
        {
            return _heroSettings;
        }

        public override float GetSpeed()
        {
            return _currentSpeed;
        }

        private void ChangeSpeed(float value)
        {
            _currentSpeed = value;
        }
    }
}
