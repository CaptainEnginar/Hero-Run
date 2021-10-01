using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Heros.Controller;
using Ability;

namespace Heros
{
    public class HeroChanger : MonoBehaviour
    {
        private AHeroController _heroController;
        
        private void Start() 
        {
            _heroController = GetComponent<AHeroController>();
        }

        private void SetChanges(AbilityType abilityType)
        {
            _heroController.GetCurrentHero().ResetIntegration();
            _heroController.ChangeAbility(abilityType);
        }

        public void MakeFly()
        {
            SetChanges(AbilityType.FLY);
        }

        public void MakeMuscle()
        {
            SetChanges(AbilityType.MUSCLE);
        }

        public void MakeFlex()
        {
            SetChanges(AbilityType.FLEX);
        }
    }

}