using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ErrorDialog
{
    public class ErrorDialogView : MonoBehaviour, IErrorDialogView
    {
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private Button gotItButton;

        public event Action OnGotItClicked;

        private void Awake()
        {
            gotItButton.onClick.AddListener(() => OnGotItClicked?.Invoke());
        }

        public void Show(string message)
        {
            messageText.text = message;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}