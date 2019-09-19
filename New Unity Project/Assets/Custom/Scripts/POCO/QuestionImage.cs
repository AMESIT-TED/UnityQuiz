using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable, CreateAssetMenu(fileName = "New Image Question", menuName = "Question/Image")]
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
    public static QuestionImage instance;

    void awake()
    {
        instance = this;
    }
    public override void AskQuestion() {
        base.AskQuestion();

        // TODO: Turn the required panel on.
        Debug.Log("Video: " + answers.correctAnswer.name);
    }



    public override void AssignAnswer(int buttonIndex, int _i) {
        base.AssignAnswer(buttonIndex, _i);
        Quiz quiz = Quiz.instance;
        
        StaticMethods.AssignButtonAction(quiz.answerButtons[buttonIndex], (_i == 0) ? (UnityAction)CorrectAnswer : IncorrectAnswer);
        
        // Set the correct graphic for this answer.
        Sprite[] arrAnswers = answers.GetAnswersArray();
        // Target the current button and assigns the text that matches it's answer.
        quiz.answerButtons[buttonIndex].GetComponent<Image>().sprite = arrAnswers[_i];
    }

    protected override void EnablePanel() {
        Quiz.instance.questionPanels.image.gameObject.SetActive(true);
    }
}
