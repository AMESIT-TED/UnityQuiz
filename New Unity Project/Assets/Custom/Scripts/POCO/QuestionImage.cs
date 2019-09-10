using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class QuestionImage : Question {
    [Serializable]
    public class Answers {
        public Sprite correctAnswer;
        public Sprite decoyAnswerA;
        public Sprite decoyAnswerB;

        public Sprite[] GetAnswersArray() {
            return new Sprite[]{correctAnswer, decoyAnswerA, decoyAnswerB };
        }
    }

    public Answers answers;

    public override void AskQuestion() {
    }

    public override void AssignAnswer(int buttonIndex, int _i) {
        Quiz quiz = Quiz.instance;
        
        StaticMethods.AssignButtonAction(quiz.answerButtons[buttonIndex], (_i == 0) ? (UnityAction)quiz.CorrectAnswer : quiz.IncorrectAnswer);
        
        // Set the correct graphic for this answer.
        Sprite[] arrAnswers = answers.GetAnswersArray();
        // Target the current button and assigns the text that matches it's answer.
        quiz.answerButtons[buttonIndex].transform.GetChild(0).GetComponent<Image>().sprite = arrAnswers[_i];
    }
}
