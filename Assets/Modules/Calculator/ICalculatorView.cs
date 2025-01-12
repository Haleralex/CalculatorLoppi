using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Calculator
{
    public interface ICalculatorView
    {
        string InputExpression { get; set; }
        void DisplayResult(string result);
        void UpdateHistory(List<string> history);
        void SetPresenter(ICalculatorPresenter presenter);
        void Show();
        void Hide();
    }
}