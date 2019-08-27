using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {
    [Serializable]
    public class Question {
        public string sQuestion;
        public string[] answers;
    }

    public Question[] questions;
    public RectTransform pnlIntroduction;
    public RectTransform pnlQuestion;
    public FinishScreen finishScreen;
    public Button btnStart;
    public Button[] answerButtons;
    public Text txtQuestion;

    private int progress;
    private int answerCount = 0;
    private void Update() {
        Debug.Log(answerCount);
    }

    private void Awake() {
        StaticMethods.AssignButtonAction(btnStart, AskQuestion);
        answerButtons = pnlQuestion.GetComponentsInChildren<Button>(true);
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
        answerCount++;
        AskQuestion();
    }

    private void IncorrectAnswer(){
        AskQuestion();
    }

    private void AskQuestion() {
        ShowQuestion();

        if (progress == questions.Length) {
            EndQuiz();
        } else {
            txtQuestion.text = questions[progress].sQuestion;

            // Shuffle answers.
            List<int> ints = new List<int> { 0, 1, 2 };
            StaticMethods.ShuffleList(ints);

            AssignAnswer(0, ints[0]);
            AssignAnswer(1, ints[1]);
            AssignAnswer(2, ints[2]);

            DebugAnswers(ints);

            progress++;
        }
    }

    private void DebugAnswers(List<int> ints) {
        for (int i = 0; i < answerButtons.Length; i++) {
            answerButtons[i].GetComponent<Image>().color = Color.grey;

            if (ints[i] == 0) {
                answerButtons[i].GetComponent<Image>().color = Color.green;
            }
        }
    }

    private void AssignAnswer(int buttonIndex, int _i) {
        StaticMethods.AssignButtonAction(answerButtons[buttonIndex], (_i == 0) ? (UnityAction)Answer : IncorrectAnswer);
        answerButtons[buttonIndex].transform.GetChild(0).GetComponent<Text>().text = questions[progress].answers[_i];
    }

    private void EndQuiz() {
        gameObject.SetActive(false);
        finishScreen.gameObject.SetActive(true);
           Text _finishText = finishScreen.GetComponentInChildren<Text>();
     
        if(answerCount == questions.Length){
           _finishText.text = "win";

        } else{
           _finishText.text = "Lose";
        }
    }
}
