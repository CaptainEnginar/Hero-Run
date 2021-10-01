using System.Collections;
using System.Collections.Generic;
using Ability;
using UnityEngine;

namespace Heros
{
    abstract public class AHero : MonoBehaviour
    {
        abstract public void SetActive();
        abstract public void DeActive();
        abstract public AbilityType GetAbility();
        abstract public HeroSettings GetHeroSettings();
        abstract public float GetSpeed();
        abstract public void RightInteraction();
        abstract public void WrongInteraction(AbilityType abilityType);
        abstract public void ResetIntegration();
    }
}
