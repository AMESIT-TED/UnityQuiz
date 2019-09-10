using System;

[Serializable]
public abstract class Question {
    public string question;
    public bool isCorrect { get; set; }

    public abstract void AskQuestion();
    public abstract void AssignAnswer(int buttonIndex, int _i);
}
