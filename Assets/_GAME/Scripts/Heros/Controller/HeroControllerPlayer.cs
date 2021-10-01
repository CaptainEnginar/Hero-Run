using System.Collections;
using System.Collections.Generic;
using Ability;
using UnityEngine;

namespace Heros.Controller
{
    public class HeroControllerPlayer : AHeroController
    {
        [Header("Heros")]
        [SerializeField] private AHero[] _heroes;

        private bool _isInSpaceArea = false;

        private Rigidbody rb;
        private AHero _currentHero;
        
        void Start()
        {
            _currentHero = _heroes[0];
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public override void Move()
        {
            rb.velocity = Vector3.forward * _currentHero.GetSpeed();
        }

        public override void ChangeAbility(AbilityType abilityType)
        {
            foreach (AHero hero in _heroes)
            {
                if (hero.GetAbility() == abilityType)
                {
                    hero.SetActive();
                    _currentHero = hero;
                }
                else
                {
                    hero.DeActive();
                }
            }
        }

        public override AHero GetCurrentHero()
        {
            return _currentHero;
        }

        //Only Space obstacle use this function
        public override void SetInSpaceArea(bool value)
        {
            _isInSpaceArea = value;
        }

        public override bool GetInSpaceArea()
        {
            return _isInSpaceArea;
        }
    }
}
