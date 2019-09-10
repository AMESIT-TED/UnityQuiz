using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;




<<<<<<< HEAD
public class Quiz : MonoBehaviour {
    public static Quiz instance;

=======
public class Quiz : MonoBehaviour
{
>>>>>>> ted
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

<<<<<<< HEAD
    public enum QuestionType {
=======
    public enum QuestionType
    {
>>>>>>> ted
        Text,
        Image,
        Video
    }
<<<<<<< HEAD

    public QuestionType type = QuestionType.Text;

    public int progress { get; set; }

    private int answerCount = 0;

    private void Awake() {
        instance = this;
=======
    public QuestionType type = QuestionType.Text;


    private int progress = 0;
    private int answerCount = 0;

    
>>>>>>> ted

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

<<<<<<< HEAD
    public void CorrectAnswer() {
=======
    private void CorrectAnswer()
    {
>>>>>>> ted
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

<<<<<<< HEAD
    private void EndQuiz() {
=======
    private void AssignAnswer(int buttonIndex, int _i)
    {
        StaticMethods.AssignButtonAction(answerButtons[buttonIndex], (_i == 0) ? (UnityAction)CorrectAnswer : IncorrectAnswer);
        //TODO this is bugging the array
        answerButtons[buttonIndex].transform.GetChild(0).GetComponent<Text>().text =   questions[progress].sAnswers[_i];

        //This is giving me problems
        Debug.Log(questions[progress].sAnswers[_i]);
    }

    private void EndQuiz()
    {
>>>>>>> ted
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
[Serializable]
public class Question
{

    public string sQuestion;
    public string[] sAnswers;
    //public Image[] iAnswers;
    //  public VideoClip[] vAnswers;
    public bool isCorrect = false;

}

