using System;
using System.Collections;
using System.Collections.Generic;
using ErrorDialog;
using Localization;
using UnityEngine;
using Zenject;

namespace Calculator
{
    public class CalculatorPresenter : ICalculatorPresenter
    {
        private readonly ICalculatorModel model;
        private readonly ICalculatorView view;
        private readonly IErrorDialogView errorDialogView;
        private List<string> history = new();

        private const string ERROR_WRONG_EXPRESSION = "error_wrong_expression";

        [Inject]
        private StringsContainer stringsContainer;

        [Inject]
        public CalculatorPresenter(ICalculatorModel model, ICalculatorView view, IErrorDialogView errorDialogView)
        {
            this.model = model;
            this.view = view;
            this.errorDialogView = errorDialogView;
            var state = model.LoadState();
            view.InputExpression = state.LastExpression;
            history = state.History;
            view.UpdateHistory(history);

            view.SetPresenter(this);
            errorDialogView.OnGotItClicked += OnGotItClicked;
        }

        private void OnGotItClicked()
        {
            errorDialogView.Hide();
            view.Show();
        }

        public void RequestResult()
        {
            var expression = view.InputExpression;
            var result = model.EvaluateExpression(expression);

            if (result == "Error")
            {
                string messageForErrorWindow;
                if (stringsContainer.Strings.TryGetValue(ERROR_WRONG_EXPRESSION, out var error))
                {
                    messageForErrorWindow = error;
                }
                else
                {
                    messageForErrorWindow = ERROR_WRONG_EXPRESSION;
                }

                errorDialogView.Show(messageForErrorWindow);
                view.Hide();
            }

            history.Add($"{expression} = {result}");
            view.DisplayResult(result);
            view.UpdateHistory(history);

            model.SaveState(expression, history);
        }
    }
}