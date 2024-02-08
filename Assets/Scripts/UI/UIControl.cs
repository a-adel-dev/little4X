
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace BB.Scripts.UI
{
    public class UIControl : MonoBehaviour
    {
        [SerializeField] private UIDocument _document;
        [SerializeField] private StyleSheet _styleSheet;


        public static event Action pauseClicked;
        public static event Action resumeClicked;
        public static event Action doubleClicked;
        public static event Action quadrupleClicked;


        private void Start()
        {
            StartCoroutine(Generate());
        }


        private void OnValidate()
        {
            if (Application.isPlaying) return;
            StartCoroutine(Generate());

        }


        private IEnumerator Generate()
        {
            yield return null;
            var root = _document.rootVisualElement;
            root.Clear();

            root.styleSheets.Add(_styleSheet);

            var container = Create<VisualElement>("container");
            root.Add(container);
            VisualElement buttons = CreateTimeControlButtons();

            container.Add(buttons);
        }

        private VisualElement CreateTimeControlButtons()
        {
            var buttons = Create<VisualElement>("time-controls");

            Button pauseBtn =Create<Button>("time-control");
            pauseBtn.text = "II";
            pauseBtn.clicked += pauseClicked;
            buttons.Add(pauseBtn);
            

            Button normalBtn = Create<Button>("time-control");
            normalBtn.text = "1x";
            normalBtn.clicked += resumeClicked;
            buttons.Add(normalBtn);

            Button doubleBtn = Create<Button>("time-control");
            doubleBtn.text = "2x";
            doubleBtn.clicked += doubleClicked;
            buttons.Add(doubleBtn);

            Button fiveBtn = Create<Button>("time-control");
            fiveBtn.text = "5x";
            fiveBtn.clicked += quadrupleClicked;
            buttons.Add(fiveBtn);
            return buttons;
        }

        private void PauseBtn_clicked()
        {
            throw new NotImplementedException();
        }

        private T Create<T>(string className) where T : VisualElement, new()
        {
            var visualElement = new T();
            visualElement.AddToClassList(className);
            return visualElement;
        }
    }
}
