using System.Collections.Generic;
using Extensions;
using UnityEngine;

namespace Checks
{
    public class ListChecking : MonoBehaviour
    {
        [SerializeField] private List<float> _listOfNumbers;
        void Start()
        {
            Debug.Log(_listOfNumbers.Average());
        }

    }
}
