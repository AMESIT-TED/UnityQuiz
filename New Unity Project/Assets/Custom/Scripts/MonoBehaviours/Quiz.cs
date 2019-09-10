using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {
    public static Quiz instance;

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

    public enum QuestionType {
        Text,
        Image,
        Video
    }

    public QuestionType type = QuestionType.Text;

    public int progress { get; set; }

    private int answerCount = 0;

    private void Awake() {
        instance = this;

        StaticMethods.AssignButtonAction(btnStart, () => { AskQuestion(); });
        StaticMethods.AssignButtonAction(btnBack, () => { AskQuestion(true); });
        answerButtons = pnlAnswerButtons.GetComponentsInChildren<Button>(true);
    }

    private void ShowIntroduction() {
        pnlIntroduction.gameObject.SetActive(true);
        pnlQuestion.gameObject.SetActive(false);
    }

    private void ShowQuestion() {
        pnlIntroduction.gameObject.SetActive(false);
        pnlQuestion.gameObject.SetActive(true);
    }

    public void CorrectAnswer() {
        answerCount++;
        // We've already incremented, set data for the question we just answered.
        questions[progress - 1].isCorrect = true;
        AskQuestion();
    }

    public void IncorrectAnswer() {
        AskQuestion();
    }

    private void AskQuestion(bool _isGoBack = false) {
        ShowQuestion();

        progress += _isGoBack ? -2 : 0;

        // Debug.Log(txtQuestionCount.text = "You are on: " + (1+progress)+ " out of: " + questions.Length);
        if (progress == questions.Length) {
            EndQuiz();
        } else {
            txtQuestion.text = questions[progress].question;
            
            // Shuffle answers.
            List<int> ints = new List<int> { 0, 1, 2 };
            StaticMethods.ShuffleList(ints);
            questions[progress].AssignAnswer(0, ints[0]);
            questions[progress].AssignAnswer(1, ints[1]);
            questions[progress].AssignAnswer(2, ints[2]);

            // TODO: Call this from Question.
            // DebugAnswers(ints);
            
            progress++;
        }
    }

    // TODO: Move this to Question.
    private void DebugAnswers(List<int> ints) {
        for (int i = 0; i < answerButtons.Length; i++) {
            Image image = answerButtons[i].GetComponent<Image>();
            image.color = Color.grey;
            if (ints[i] == 0) {
                image.color = Color.green;
            }
        }
    }

    private void EndQuiz() {
        //Check pls"
        gameObject.SetActive(false);
        finishScreen.gameObject.SetActive(true);
        Text _finishText = finishScreen.GetComponentInChildren<Text>();

        if (answerCount == questions.Length) {
            _finishText.text = "win";
        } else {
            _finishText.text = "Lose";
        }
    }
}
