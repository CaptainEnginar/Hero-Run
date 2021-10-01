using System.Collections;
using System.Collections.Generic;
using Ability;
using UnityEngine;

namespace Heros.Controller
{
    public class HeroControllerAI : AHeroController
    {
        [Header("Heroes")]
        [SerializeField] private AHero[] heroes;

        void Start()
        {

        }

        void Update()
        {

        }

        public override void ChangeAbility(AbilityType abilityType)
        {
            throw new System.NotImplementedException();
        }

        public override void Move()
        {
            throw new System.NotImplementedException();
        }

        public override AHero GetCurrentHero()
        {
            throw new System.NotImplementedException();
        }

        public override bool GetInSpaceArea()
        {
            throw new System.NotImplementedException();
        }

        public override void SetInSpaceArea(bool value)
        {
            throw new System.NotImplementedException();
        }
    }
}
