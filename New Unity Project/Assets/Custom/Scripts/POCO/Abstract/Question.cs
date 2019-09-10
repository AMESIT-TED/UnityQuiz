using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Question : ScriptableObject {
    public string question;
    public bool isCorrect { get; set; }
    public GameObject _canvasGroup;

    public virtual void AskQuestion() {
        // TODO: Turn off all 3 question panels in the UI.
        _canvasGroup.GetComponent<CanvasGroup>().alpha = 0;
    }

    public virtual void AssignAnswer(int buttonIndex, int _i) { }
}
