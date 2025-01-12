using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
namespace Calculator
{
    public class CalculatorView : MonoBehaviour, ICalculatorView, IDisposable
    {
        public TMP_InputField inputField;
        public TMP_Text resultText;
        public TMP_Text historyText;
        public Button resultButton;
        [SerializeField] private GameObject mainWindow;
        [SerializeField] private DynamicScrollView dynamicScrollView;
        private ICalculatorPresenter presenter;



        public string InputExpression
        {
            get => inputField.text;
            set => inputField.text = value;
        }

        public void SetPresenter(ICalculatorPresenter presenter)
        {
            this.presenter = presenter;
        }

        private void Awake()
        {
            resultButton.onClick.AddListener(OnResultRequested);
        }



        private void OnResultRequested()
        {
            presenter.RequestResult();
        }

        public void DisplayResult(string result)
        {
            resultText.text = result;
        }

        public void UpdateHistory(List<string> history)
        {
            historyText.text = string.Join("\n", history);
            dynamicScrollView.UpdateScrollView();
        }

        public void Dispose()
        {
            resultButton.onClick.RemoveListener(OnResultRequested);
        }

        public void Show()
        {
            mainWindow.SetActive(true);
        }

        public void Hide()
        {
            mainWindow.SetActive(false);
        }
    }
}