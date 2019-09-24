using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable, CreateAssetMenu(fileName = "New Image Question", menuName = "Question/Image")]
public class QuestionImage : Question {
     [Serializable]
    public class Answers {
        public string correctAnswer;
        public string decoyAnswerA;
        public string decoyAnswerB;

        public Sprite correctAnswerImage;
        public Sprite decoyImageA;
        public Sprite decoyImageB;



        public string[] GetAnswersArray() {
            return new string[] { correctAnswer, decoyAnswerA, decoyAnswerB };
            

        }

        public Sprite[] GetAnswerImagesArray()
        {
            return new Sprite[] { correctAnswerImage, decoyImageA, decoyImageB };
        }
    }

    public Answers answers;

    public override void AskQuestion() {
        Debug.Log("AskQuestion");
        base.AskQuestion();
        // TODO: Turn the required panel on.
        EnablePanel();
    }

    public override void AssignAnswer(int buttonIndex, int _i) {
        base.AssignAnswer(buttonIndex, _i);
        PanelImage panelImage =PanelImage.instance;


        // Set the correct graphic for this answer.
        string[] arrAnswers = answers.GetAnswersArray();
        Sprite[] arrImageAnswers = answers.GetAnswerImagesArray();
        // Target the current button and assigns the text that matches it's answer.
        Quiz.instance.questionPanels.image.GetComponent<PanelImage>().imageButtons[buttonIndex].transform.GetChild(0).GetComponent<Text>().text= arrAnswers[_i];
        Quiz.instance.questionPanels.image.GetComponent<PanelImage>().imageButtons[buttonIndex].transform.GetComponent<Image>().sprite = arrImageAnswers[_i];


        StaticMethods.AssignButtonAction(Quiz.instance.questionPanels.image.GetComponent<PanelImage>().imageButtons[buttonIndex], (_i == 0) ? (UnityAction)CorrectAnswer : IncorrectAnswer);
    }

    protected override void EnablePanel() {
        Quiz.instance.questionPanels.image.gameObject.SetActive(true);        
    }

    protected override void DisablePanels() {
        Quiz.instance.questionPanels.text.gameObject.SetActive(false);
        Quiz.instance.questionPanels.image.gameObject.SetActive(false);
        Quiz.instance.questionPanels.video.gameObject.SetActive(false);
    }
}
