using System;
using Checks;
using EventSystem;
using EventSystem.Dispose;
using UnityEngine;

namespace Game
{
    public class GameLogic : MonoBehaviour
    {
        [SerializeField] private FunctionalityChecker _functionalityChecker;
        public EventDisposal _eventDisposal = new EventDisposal();
        
        public static GameLogic GOD { get; private set; }

        private void Awake()
        {
            GOD = this;
            EventManager.Add(GameEventsKey.CreateLevel, CreateSphere).AddTo(_eventDisposal);
        }

        private void Start()
        {
            EventManager.Invoke(GameEventsKey.CreateLevel);
        }

        public void CreateSphere()
        {
            Debug.Log("Create sphere");
            Instantiate(_functionalityChecker.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
