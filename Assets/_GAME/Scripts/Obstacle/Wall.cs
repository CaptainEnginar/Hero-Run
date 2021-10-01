using System.Collections;
using System.Collections.Generic;
using Ability;
using Heros;
using Heros.Controller;
using UnityEngine;

namespace Obstacles
{
    public class Wall : AObstacle
    {
        [SerializeField] private AbilityType _abilityType;
        [SerializeField] private GameObject breakWallPrefab;
        AHeroController heroController;

        private bool _isKicked = false;

        public override AbilityType GetAbility()
        {
            return _abilityType;
        }

        private void OnCollisionStay(Collision other) 
        {
            CheckHero(null,other);
        }

        private IEnumerator BreakTheDoor(float sceonds)
        {
            _isKicked = true;

            yield return new WaitForSeconds(sceonds);

            GameObject breakWall = Instantiate(breakWallPrefab);
            breakWall.transform.position = transform.position;
            Rigidbody[] rbs = breakWall.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in rbs)
            {
                rb.AddForce(new Vector3(Random.Range(-5f,5f), Random.Range(5, 15), Random.Range(5, 15)));
            }

            if(heroController!=null)
                heroController.GetCurrentHero().ResetIntegration();

            Destroy(gameObject);
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
                    //Muscle Kick the door
                    if(!_isKicked)
                    {
                        heroController.GetCurrentHero().RightInteraction();
                        StartCoroutine(BreakTheDoor(.1f));
                    }
                        
                }
                else
                {
                    heroController.GetCurrentHero().WrongInteraction(_abilityType);
                }
            }
        }
    }

}