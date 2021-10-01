using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Heros.Controller;

namespace Obstacles
{
    public class Glass : MonoBehaviour
    {
        [SerializeField] private GameObject berakGlass;
        private AHeroController _heroController;

        private void OnCollisionEnter(Collision other) 
        {
            _heroController = other.transform.GetComponentInParent<AHeroController>();
            if(_heroController != null)
            {
                berakGlass.SetActive(true);
            }
        }
    }
}
