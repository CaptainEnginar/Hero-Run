using System.Collections;
using System.Collections.Generic;
using Ability;
using UnityEngine;

namespace Heros
{
    [CreateAssetMenu(menuName = "Legendary Run/Hero Setting")]
    public class HeroSettings : ScriptableObject
    {
        [SerializeField] private float _wrongSpeed;
        [SerializeField] private float _normalSpeed;
        [SerializeField] private float _rightSpeed;
        [SerializeField] private float _animationSpeed;
        [SerializeField] private float _damage;
        [SerializeField] private float _health;
        [SerializeField] private AbilityType _abilityType;
        
        public float WrongSpeed { get { return _wrongSpeed; } set { _wrongSpeed = value; } }
        public float NormalSpeed { get { return _normalSpeed; } set { _normalSpeed = value; } }
        public float RightSpeed { get{ return _rightSpeed; } set{ _rightSpeed = value; } }
        public float AnimationSpeed { get { return _animationSpeed; } set { _animationSpeed = value; } }
        public float Damage { get { return _damage; } set { _damage = value; } }
        public float Health { get { return _health; } set { _health = value; } }
        public AbilityType AbilityType { get{ return _abilityType; } set{ _abilityType = value;} }
    }
}
