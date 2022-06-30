using System.Collections.Generic;
using Extensions;
using FunctionalProgramming;
using UnityEngine;

namespace Checks
{
    public class FunctionalityChecker : MonoBehaviour
    {
        [SerializeField] private List<float> _listOfNumbers;
        [SerializeField] private TransformChanger _transformChanger;
        void Start()
        {
            Debug.Log(_listOfNumbers.Average());
            _transformChanger.ChangeTransform(transform.localScale.x, 5, (f => transform.localScale = new Vector3(transform.localScale.x, f, transform.localScale.z)));
            _transformChanger.ChangeTransform(0, 5, (f => transform.position = new Vector3(transform.position.x, f, transform.position.z)));
            _transformChanger.ChangeTransform(0, 5, (f => transform.position = new Vector3(f, f, 0)));
        }
    }
}
