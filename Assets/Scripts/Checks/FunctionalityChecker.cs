using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace Checks
{
    public class FunctionalityChecker : MonoBehaviour
    {
        [SerializeField] private List<float> _listOfNumbers;
        void Start()
        {
            Debug.Log(_listOfNumbers.Average());
        }
    }
}
