using Ability;
using UnityEngine;

namespace Heros.Controller
{
    abstract public class AHeroController: MonoBehaviour
    {
        abstract public void ChangeAbility(AbilityType abilityType);
        abstract public bool GetInSpaceArea();
        //Only Space obstacle use that function
        abstract public void SetInSpaceArea(bool value);
        abstract public AHero GetCurrentHero();
        abstract public void Move();
    }
}
