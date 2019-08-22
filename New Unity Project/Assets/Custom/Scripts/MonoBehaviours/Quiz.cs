using System;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {
    [Serializable]
    public class Question {
        public string text;
        public string asnwer;
    }

    public Question[] questions;
    public RectTransform pnlIntroduction;
    public RectTransform pnlQuestion;
    public FinishScreen finishScreen;
    public Button btnStart;
    public Button btnGood;
    public Button btnBad;
    public Text txtQuestion;

    private int progress;
    private int answerCount = 0;

    private void Awake() {
        StaticMethods.AssignButtonAction(btnStart, AskQuestion);
        StaticMethods.AssignButtonAction(btnGood, Answer);
        StaticMethods.AssignButtonAction(btnBad, IncorrectAnswer);
    }

    private void ShowIntroduction() {
        pnlIntroduction.gameObject.SetActive(true);
        pnlQuestion.gameObject.SetActive(false);
    }

    private void ShowQuestion() {
        pnlIntroduction.gameObject.SetActive(false);
        pnlQuestion.gameObject.SetActive(true);
    }

    private void Answer() {
     //if i click the good button increment the answercount... just do not know how to acess the good button...
        AskQuestion();
        answerCount++;
    }

    private void IncorrectAnswer(){
        AskQuestion();
    }

    private void AskQuestion() {
        ShowQuestion();

        if (progress >= questions.Length) {
            EndQuiz();
        } else {
            txtQuestion.text = questions[progress++].text;
        }
    }

    private void EndQuiz() {
        gameObject.SetActive(false);
        finishScreen.gameObject.SetActive(true);
           Text _finishText = finishScreen.GetComponentInChildren<Text>();
        Debug.Log(questions.Length);
        if(answerCount == 2){
           _finishText.text = "win";

        } else{
           _finishText.text = "Lose";
        }
    }
}
