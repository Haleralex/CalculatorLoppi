using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Localization
{
    [CreateAssetMenu(fileName = "StringsContainer", menuName = "ScriptableObjects/StringsContainer", order = 1)]
    public class StringsContainer : ScriptableObject
    {
        [SerializeField] private List<StringKeyValuePair> stringKeyValuePairs = new();

        private Dictionary<string, string> strings = new();
        public IReadOnlyDictionary<string, string> Strings => strings;

        void OnEnable()
        {
            foreach (var k in stringKeyValuePairs)
            {
                strings[k.Key] = k.Value;
            }
        }
    }
}