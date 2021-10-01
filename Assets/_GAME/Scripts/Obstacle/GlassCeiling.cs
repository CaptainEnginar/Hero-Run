using System.Collections;
using System.Collections.Generic;
using Ability;
using Heros.Controller;
using UnityEngine;

namespace Obstacles
{
    public class GlassCeiling : AObstacle
    {
        [SerializeField] private AbilityType _abilityType;
        AHeroController heroController;

        private void OnTriggerStay(Collider other)
        {
            CheckHero(other, null);
        }

        private void OnCollisionStay(Collision other)
        {
            CheckHero(null, other);
        }

        private void OnTriggerExit(Collider other)
        {
            AHeroController heroControllerExit = other.transform.gameObject.GetComponentInParent<AHeroController>();
            ResetHeroController(heroControllerExit);
        }

        private void OnColliderExit(Collision other)
        {
            AHeroController heroControllerExit = other.transform.gameObject.GetComponentInParent<AHeroController>();
            ResetHeroController(heroControllerExit);
        }

        public override void CheckHero(Collider collider, Collision collision)
        {
            if (collision != null)
                heroController = collision.transform.GetComponentInParent<AHeroController>();

            if (collider != null)
                heroController = collider.transform.GetComponentInParent<AHeroController>();

            if (heroController != null)
            {
                if (heroController.GetCurrentHero().GetHeroSettings().AbilityType == _abilityType)
                {
                    heroController.GetCurrentHero().RightInteraction();
                }
                else
                {
                    heroController.GetCurrentHero().WrongInteraction(_abilityType);
                }
            }
        }

        public override AbilityType GetAbility()
        {
            return _abilityType;
        }

        private void ResetHeroController(AHeroController heroController)
        {
            if (heroController != null)
            {
                heroController.GetCurrentHero().ResetIntegration();
            }
        }
    }

}