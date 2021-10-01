using Ability;
using UnityEngine;

namespace Obstacles
{
    abstract public class AObstacle : MonoBehaviour
    {
        abstract public AbilityType GetAbility();
        abstract public void CheckHero(Collider collider, Collision collision);
    }
}
