using UnityEngine.Events;
using UnityEngine.UI;

public static class StaticMethods {
    public static void AssignButtonAction(Button _button, UnityAction _method) {
        _button.onClick.RemoveAllListeners();

        _button.onClick.AddListener(() => {
            _method();
        });
    }
}