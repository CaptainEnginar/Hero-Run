using Ability;
using Heros.Controller;
using UnityEngine;

namespace Obstacles
{
    public class Tunel : AObstacle
    {
        [SerializeField] private AbilityType _abilityType;
        [SerializeField] private Material _transparentMaterial;

        private AHeroController heroController;
        private bool _isChanged = false;

        private void OnCollisionStay(Collision other)
        {
            CheckHero(null, other);
        }

        private void OnTriggerStay(Collider other) 
        {
            CheckHero(other, null);
        }

        private void OnTriggerExit(Collider other)
        {
            AHeroController heroControllerExit = other.transform.gameObject.GetComponentInParent<AHeroController>();
            if( heroControllerExit != null)
            {
                SetColliderTriger(heroControllerExit, false);
                heroControllerExit.GetCurrentHero().ResetIntegration();
            }
        }

        public override void CheckHero(Collider collider, Collision collision)
        {
            if(collision != null)
                heroController = collision.transform.GetComponentInParent<AHeroController>();

            if(collider != null)
                heroController = collider.transform.GetComponentInParent<AHeroController>();

            if (heroController != null)
            {
                if (heroController.GetCurrentHero().GetHeroSettings().AbilityType == _abilityType)
                {
                    SetColliderTriger(heroController, true);
                    heroController.GetCurrentHero().RightInteraction();

                    if(!_isChanged)
                        ChangeMaterial();
                }
                else
                {
                    SetColliderTriger(heroController, false);
                    heroController.GetCurrentHero().WrongInteraction(_abilityType);
                }
            }
        }

        public override AbilityType GetAbility()
        {
            return _abilityType;
        }

        private void SetColliderTriger(AHeroController tmepController, bool value)
        {
            tmepController.GetCurrentHero().GetComponent<Collider>().isTrigger = value;
        }

        private void ChangeMaterial()
        {
            _isChanged = true;
            
            if(GetComponentsInChildren<Renderer>() != null)
            {
                foreach(Renderer render in GetComponentsInChildren<Renderer>())
                {
                    render.material = _transparentMaterial;
                }
            }

        }
    }
}
