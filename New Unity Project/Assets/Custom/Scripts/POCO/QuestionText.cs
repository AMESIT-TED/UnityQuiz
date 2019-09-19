using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable, CreateAssetMenu(fileName = "New Text Question", menuName = "Question/Text")]
public class QuestionText : Question {

    [Serializable]
    public class Answers {
        public string correctAnswer;
        public string decoyAnswerA;
        public string decoyAnswerB;

        public string[] GetAnswersArray() {
            return new string[] { correctAnswer, decoyAnswerA, decoyAnswerB };
        }
    }
    
    public Answers answers;

    public override void AskQuestion() {
        base.AskQuestion();
    }

    public override void AssignAnswer(int buttonIndex, int _i) {
        base.AssignAnswer(buttonIndex, _i);

        Quiz quiz = Quiz.instance;

        // Set the correct graphic for this answer.
        string[] arrAnswers = answers.GetAnswersArray();
        // Target the current button and assigns the text that matches it's answer.
        quiz.answerButtons[buttonIndex].transform.GetChild(0).GetComponent<Text>().text = arrAnswers[_i];
        StaticMethods.AssignButtonAction(quiz.answerButtons[buttonIndex], (_i == 0) ? (UnityAction)CorrectAnswer : IncorrectAnswer);
    }

    protected override void EnablePanel() {
        Quiz.instance.questionPanels.text.gameObject.SetActive(true);
    }
}
