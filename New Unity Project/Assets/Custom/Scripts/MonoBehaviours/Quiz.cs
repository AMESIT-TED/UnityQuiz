using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Serializable]
    public class Question
    {
        public string sQuestion;
        public string[] answers;
        public bool isCorrect = false;
    }

    public Question[] questions;
    public RectTransform pnlIntroduction;
    public RectTransform pnlQuestion;
    public RectTransform pnlAnswerButtons;
    public FinishScreen finishScreen;
    public Button btnStart;
    public Button[] answerButtons;
    public Button btnBack;
    public Text txtQuestion;
    public Text txtQuestionCount;

    private int progress = 0;
    private int answerCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown("b") && progress > 0)
        {
            AskQuestion(true);
        }
        // Debug.Log("list of correct: " + listCorrectAnswers.Count);

    }

    private void Awake()
    {
        StaticMethods.AssignButtonAction(btnStart, () => { AskQuestion(); });
        StaticMethods.AssignButtonAction(btnBack, () => { AskQuestion(true); });
        answerButtons = pnlAnswerButtons.GetComponentsInChildren<Button>(true);
    }

    private void ShowIntroduction()
    {
        pnlIntroduction.gameObject.SetActive(true);
        pnlQuestion.gameObject.SetActive(false);
    }

    private void ShowQuestion()
    {
        pnlIntroduction.gameObject.SetActive(false);
        pnlQuestion.gameObject.SetActive(true);
    }

    private void CorrectAnswer() {
        answerCount++;
        // We've already incremented, set data for the question we just answered.
        questions[progress - 1].isCorrect = true;
        AskQuestion();
    }

    private void IncorrectAnswer()
    {
        AskQuestion();
    }

    private void AskQuestion(bool _isGoBack = false)
    {
        ShowQuestion();

        progress += _isGoBack ? -2 : 0;

        // Debug.Log(txtQuestionCount.text = "You are on: " + (1+progress)+ " out of: " + questions.Length);
        if (progress == questions.Length)
        {
            EndQuiz();
        }
        else
        {
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


    private void DebugAnswers(List<int> ints)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image image = answerButtons[i].GetComponent<Image>();
            image.color = Color.grey;
            if (ints[i] == 0)
            {
                image.color = Color.green;
            }
        }
    }

    private void AssignAnswer(int buttonIndex, int _i)
    {
        StaticMethods.AssignButtonAction(answerButtons[buttonIndex], (_i == 0) ? (UnityAction)CorrectAnswer : IncorrectAnswer);
        answerButtons[buttonIndex].transform.GetChild(0).GetComponent<Text>().text = questions[progress].answers[_i];
    }

    private void EndQuiz()
    {
        //Check pls"
        gameObject.SetActive(false);
        finishScreen.gameObject.SetActive(true);
        Text _finishText = finishScreen.GetComponentInChildren<Text>();

        if (answerCount == questions.Length)
        {
            _finishText.text = "win";

        }
        else
        {
            _finishText.text = "Lose";
        }
    }
}
