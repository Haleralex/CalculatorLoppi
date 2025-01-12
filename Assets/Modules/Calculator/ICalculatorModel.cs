using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Calculator
{
public interface ICalculatorModel
{
    string EvaluateExpression(string expression);
    void SaveState(string expression, List<string> history);
    (string LastExpression, List<string> History) LoadState();
}
}