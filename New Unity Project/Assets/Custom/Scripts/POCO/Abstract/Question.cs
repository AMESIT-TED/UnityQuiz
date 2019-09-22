using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Question : ScriptableObject {
    public static Question instance;
    public string question;
    public bool isCorrect { get; set; }

    public virtual void AskQuestion() {
        DisablePanels();
        EnablePanel();

        Quiz quiz = Quiz.instance;
        
        quiz.txtQuestion.text = quiz.questions[quiz.progress].question;
            
        // Shuffle answers.
        List<int> ints = new List<int> { 0, 1, 2 };
        StaticMethods.ShuffleList(ints);
        AssignAnswer(0, ints[0]);
        AssignAnswer(1, ints[1]);
        AssignAnswer(2, ints[2]);

        // DebugAnswers(ints);
            
        quiz.progress++;
    }

    protected virtual void EnablePanel() {
    }

    protected virtual void DisablePanels() {
        Quiz.instance.DisablePanels();
    }


    public virtual void AssignAnswer(int buttonIndex, int _i) {
    }

    // TODO: Could be moved to Question.cs;
    public  void CorrectAnswer() {
        Quiz.instance.isAnswered = true;
        Quiz.instance.answerCount++;
        // We've already incremented, set data for the question we just answered.
        isCorrect = true;
    }

    // TODO: Could be moved to Question.cs;
    public void IncorrectAnswer() {
        Quiz.instance.isAnswered = true;
    }

    //private void DebugAnswers(List<int> ints) {
    //    for (int i = 0; i < answerButtons.Length; i++) {
    //        Image image = answerButtons[i].GetComponent<Image>();
    //        image.color = Color.grey;
    //        if (ints[i] == 0) {
    //            image.color = Color.green;
    //        }
    //    }
    //}
}
