using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class StaticMethods {
    public static void AssignButtonAction(Button _button, UnityAction _method) {
        _button.onClick.RemoveAllListeners();

        _button.onClick.AddListener(() => {
            _method();
        });
    }
   
    public static void ShuffleList<T>(List<T> list) {
        for (int i = 0; i < list.Count; i++) {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}