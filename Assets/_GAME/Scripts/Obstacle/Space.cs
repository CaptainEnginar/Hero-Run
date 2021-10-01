using System.Collections;
using System.Collections.Generic;
using Ability;
using Heros.Controller;
using UnityEngine;

namespace Obstacles
{
    public class Space : AObstacle
    {
        [SerializeField] private float MaxYValue;
        [SerializeField] private float MinYValue;
        [SerializeField] private float _speed;
        [SerializeField] private AbilityType _abilityType;
        [SerializeField] private Transform _enterPoint;
        
        AHeroController heroController;

        private void OnTriggerStay(Collider other) 
        {
            CheckHero(other,null);
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
            if(collision != null)
                heroController = collision.transform.GetComponentInParent<AHeroController>();

            if(collider != null)
                heroController = collider.transform.GetComponentInParent<AHeroController>();
            
            if (heroController != null)
            {
                heroController.SetInSpaceArea(true);
                if (heroController.GetCurrentHero().GetHeroSettings().AbilityType == _abilityType)
                {
                    heroController.GetCurrentHero().RightInteraction();
                    
                    if (heroController.transform.position.y < MaxYValue)
                        MoveYAxis(_speed * 3, MaxYValue);
                }
                else
                {
                    MoveYAxis(_speed, MinYValue);
                    heroController.GetCurrentHero().WrongInteraction(_abilityType);
                }
            }
        }

        private void MoveYAxis(float speed, float YValue)
        {
            heroController.transform.position = Vector3.Lerp(heroController.transform.position,
                        new Vector3(heroController.transform.position.x, YValue, heroController.transform.position.z),
                            Time.deltaTime * speed);
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
                heroController.SetInSpaceArea(false);
            }
        }
    }

}