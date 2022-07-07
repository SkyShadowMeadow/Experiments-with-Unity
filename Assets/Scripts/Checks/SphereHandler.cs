using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Checks
{
    public class SphereHandler : MonoBehaviour
    {
        [SerializeField] private float _timeForNewNumber = 0.5f;
        private Sphere[] _spheres;
        private void Awake()
        {
            _spheres = GetComponentsInChildren<Sphere>();
        }

        private void Start()
        {
            StartCoroutine(ChangeColorWithTime());
        }

        IEnumerator ChangeColorWithTime()
        {
            float _currentTime = 0;
            while (_currentTime < _timeForNewNumber)
            {
                _currentTime += Time.deltaTime;
                yield return null;
            }

            int remainder = UnityEngine.Random.Range(0, 65) % 4;
            foreach (var sphere in _spheres)
            {
                if (!sphere.IsColorChanged && sphere.Remainder == remainder)
                {
                    sphere.ChangeColor();
                }
            }

            if (_spheres.FirstOrDefault(sphere => sphere.IsColorChanged is false) != null)
            {
                StartCoroutine(ChangeColorWithTime());
            }
            else
            {
                Debug.Log("all spheres are colored");
            }
        }
    }
}
