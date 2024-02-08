using BB.Scripts.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.ARTillery.Core
{
    public class TimeController : MonoBehaviour
    {
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

        private void OnEnable()
        {
            UIControl.pauseClicked += Pause;
            UIControl.resumeClicked += Resume;
            UIControl.doubleClicked += DoubleTime;
            UIControl.quadrupleClicked += QuadrupleTime;
        }

        private void OnDisable()
        {
            UIControl.pauseClicked -= Pause;
            UIControl.resumeClicked -= Resume;
            UIControl.doubleClicked -= DoubleTime;
            UIControl.quadrupleClicked -= QuadrupleTime;
        }
        void Update()
        {
            UpdateTimeUpdatables();
        }

        private void UpdateTimeUpdatables()
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

        private void SetTimeMultiplier(float timeMultiplier)
        {
            _timeMultiplier = timeMultiplier;
        }

        private void Pause()
        {
            SetTimeMultiplier(0);
        }

        private void Resume()
        {
            SetTimeMultiplier(1f);
        }

        private void DoubleTime()
        {
            SetTimeMultiplier(2f);
        }

        private void QuadrupleTime()
        {
            SetTimeMultiplier(5f);
        }
    }
}