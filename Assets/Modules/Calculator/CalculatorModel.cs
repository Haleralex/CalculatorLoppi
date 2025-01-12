using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator
{
    public class CalculatorModel : ICalculatorModel
    {
        private const string StateKey = "CalculatorState";
        private const string ERROR = "Error";

        public string EvaluateExpression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression) || !expression.Contains("+"))
                return ERROR;

            var parts = expression.Split('+');
            if (parts.Length != 2 || !int.TryParse(parts[0], out var left) || !int.TryParse(parts[1], out var right))
                return ERROR;

            if (left < 0 || right < 0)
                return ERROR;

            return (left + right).ToString();
        }

        public void SaveState(string expression, List<string> history)
        {
            var state = new CalculatorState { LastExpression = expression, History = history };
            PlayerPrefs.SetString(StateKey, JsonUtility.ToJson(state));
            PlayerPrefs.Save();
        }

        public (string LastExpression, List<string> History) LoadState()
        {
            if (PlayerPrefs.HasKey(StateKey))
            {
                var state = JsonUtility.FromJson<CalculatorState>(PlayerPrefs.GetString(StateKey));
                return (state.LastExpression, state.History);
            }
            return (string.Empty, new List<string>());
        }

        [System.Serializable]
        private class CalculatorState
        {
            public string LastExpression;
            public List<string> History;
        }
    }
}