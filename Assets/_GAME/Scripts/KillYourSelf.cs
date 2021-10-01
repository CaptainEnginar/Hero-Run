using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Killer
{
    public class KillYourSelf : MonoBehaviour
    {
        [SerializeField] private float _killTime = 1f;
        
        private void Start() 
        {
            StartCoroutine(KillIt());
        }

        private IEnumerator KillIt()
        {
            yield return new WaitForSeconds(_killTime);
            Destroy(gameObject);
        }
    }
}
