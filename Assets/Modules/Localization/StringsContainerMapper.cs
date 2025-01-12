using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
namespace Localization
{
    public class StringsContainerMapper : MonoBehaviour
    {
        private TextMeshProUGUI[] texts;
        [Inject]
        private StringsContainer stringsContainer;
        void Awake()
        {
            texts = GetComponentsInChildren<TextMeshProUGUI>(true);

            foreach (var text in texts)
            {
                if (stringsContainer.Strings.TryGetValue(text.text, out var value))
                    text.text = value;
            }
        }
    }
}