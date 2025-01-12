using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ErrorDialog
{
    public interface IErrorDialogView
    {
        void Show(string message);

        void Hide();

        event Action OnGotItClicked;
    }
}