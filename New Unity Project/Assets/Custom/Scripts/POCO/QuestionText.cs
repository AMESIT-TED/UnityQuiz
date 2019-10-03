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
        public String feedBack;

        public string[] GetAnswersArray() {
            return new string[] { correctAnswer, decoyAnswerA, decoyAnswerB };
        }

        public string GetFeedBack()
        {
            return feedBack;
        }
    }
    
    public Answers answers;

    public override void AskQuestion() {
        base.AskQuestion();
        Quiz quiz = Quiz.instance;
    }

    public override void AssignAnswer(int buttonIndex, int _i) {
        base.AssignAnswer(buttonIndex, _i);

       PanelText panelText = PanelText.instance;
        // Set the correct graphic for this answer.
        string[] arrAnswers = answers.GetAnswersArray();
        // Target the current button and assigns the text that matches it's answer.
        Quiz.instance.questionPanels.text.GetComponent<PanelText>().textButtons[buttonIndex].transform.GetChild(0).GetComponent<Text>().text   =   arrAnswers[_i];

        StaticMethods.AssignButtonAction(Quiz.instance.questionPanels.text.GetComponent<PanelText>().textButtons[buttonIndex], (_i == 0) ? (UnityAction)CorrectAnswer : IncorrectAnswer);
    }

    protected override void EnablePanel() {
        Quiz.instance.questionPanels.text.gameObject.SetActive(true);
    }
}
