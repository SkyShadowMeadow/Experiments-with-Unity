using System;
using System.Collections;
using UnityEngine;

namespace Checks
{
    public class SerializableChecking : MonoBehaviour
    {
        [SerializeField] private SphereScaleParameters _sphereScaleParameters;

        private void Start()
        {
            StartCoroutine(ChangeScale());
        }

        private IEnumerator ChangeScale()
        {
            yield return new WaitForSeconds(2f);
            transform.localScale = transform.localScale * _sphereScaleParameters._firstScale;
            Debug.Log(transform.localScale);
            yield return new WaitForSeconds(2f);
            transform.localScale = transform.localScale * _sphereScaleParameters._secondScale;
            Debug.Log(transform.localScale);
        }
    }
}
