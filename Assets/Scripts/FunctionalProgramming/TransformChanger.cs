using System;
using Unity.VisualScripting;
using UnityEngine;

namespace FunctionalProgramming
{
    public class TransformChanger : MonoBehaviour
    {
        public void ChangeTransform(float from, float to, Action<float> change)
        {
            change(to);
        }
    }
}
