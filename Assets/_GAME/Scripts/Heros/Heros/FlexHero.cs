using System.Collections;
using System.Collections.Generic;
using Ability;
using Heros.Controller;
using NVIDIA.Flex;
using UnityEngine;

namespace Heros
{
    public class FlexHero : AHero
    {
        [SerializeField] private HeroSettings _heroSettings;
        [SerializeField] private GameObject _softBody;
        [SerializeField] private GameObject _hardBody;
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
            _hardBody.SetActive(true);
            _collider.enabled = true;
        }

        public override void DeActive()
        {
            _hardBody.SetActive(false);
            _collider.enabled = false;
        }

        public override void RightInteraction()
        {
            ChangeSpeed(_heroSettings.RightSpeed);
            BodyChanges(false, true, true);
        }

        public override void WrongInteraction(AbilityType abilityType)
        {
            ChangeSpeed(_heroSettings.WrongSpeed);
            switch(abilityType)
            {
                case AbilityType.FLY:
                    if(_heroController.GetInSpaceArea())
                        animator.SetBool("Fall", true);
                    else
                        animator.SetBool("LeeryWalk", true);
                    break;
                case AbilityType.MUSCLE:
                    animator.SetBool("LookingAround", true);
                    break;
            }
        }

        public override void ResetIntegration()
        {
            ChangeSpeed(_heroSettings.NormalSpeed);
            BodyChanges(true, false, false);
            
            animator.SetBool("LookingAround", false);
            animator.SetBool("Fall", false);
            animator.SetBool("LeeryWalk", false);
        }

        private void BodyChanges(bool hardBodyActive, bool FlexSoftActorActive, bool SkinnedMeshRendererActive)
        {
            _hardBody.SetActive(hardBodyActive);
            _softBody.GetComponent<FlexSoftActor>().enabled = FlexSoftActorActive;
            _softBody.GetComponent<SkinnedMeshRenderer>().enabled = SkinnedMeshRendererActive;
        }

        public override HeroSettings GetHeroSettings()
        {
            return _heroSettings;
        }

        public override AbilityType GetAbility()
        {
            return _heroSettings.AbilityType;
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
