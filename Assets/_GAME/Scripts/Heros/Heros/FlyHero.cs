using System.Collections;
using System.Collections.Generic;
using Ability;
using UnityEngine;

namespace Heros
{
    public class FlyHero : AHero
    {
        [SerializeField] private HeroSettings _heroSettings;
        public Animator animator;

        private float _currentSpeed;
        private CapsuleCollider _collider;

        private void Awake()
        {
            _currentSpeed = _heroSettings.NormalSpeed;

            animator = GetComponent<Animator>();
            _collider = GetComponent<CapsuleCollider>();
        }

        public override void SetActive()
        {
            gameObject.SetActive(true);
        }

        public override void DeActive()
        {
            gameObject.SetActive(false);
        }

        public override void RightInteraction()
        {
            ChangeSpeed(_heroSettings.RightSpeed);
            animator.SetBool("FastFlying", true);
            _collider.direction = 2;
        }

        public override void WrongInteraction(AbilityType abilityType)
        {
            switch(abilityType)
            {
                case AbilityType.MUSCLE:
                    ChangeSpeed(_heroSettings.WrongSpeed);
                    animator.SetBool("LookAround", true);
                    break;
                case AbilityType.FLEX:
                    ChangeSpeed(_heroSettings.WrongSpeed);
                    //Yapışıp kalabilir.
                    break;
            }
        }

        public override void ResetIntegration()
        {
            ChangeSpeed(_heroSettings.NormalSpeed);
            animator.SetBool("FastFlying", false);
            animator.SetBool("LookAround", false);

            _collider.direction = 0;
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
