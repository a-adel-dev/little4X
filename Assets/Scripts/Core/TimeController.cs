using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ARTillery.Core
{
    public class TimeController : MonoBehaviour
    {
        [SerializeField]
        private float _timeMultiplier = 1f;
        private float _modifiedTime;

        public static TimeController Instance { get; set; }
        
        private List<ITimeUpdatable> timeUpdatables = new List<ITimeUpdatable>();


        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            Instance = this;
        }
        // Update is called once per frame
        void Update()
        {
            _modifiedTime = Time.deltaTime * _timeMultiplier;
            foreach (ITimeUpdatable timeUpdatable in timeUpdatables)
            {
                timeUpdatable.UpdateObject(_modifiedTime);
            }
        }

        public void AddToUpdatables(ITimeUpdatable updatable)
        {
            timeUpdatables.Add(updatable);
        }

        public void SetTimeMultiplier(int multiplier)
        {
            _timeMultiplier = multiplier;
        }

        
    }
}