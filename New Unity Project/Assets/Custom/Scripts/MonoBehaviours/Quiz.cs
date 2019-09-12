using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {
    [Serializable]
    public class QuestionPanelSet {
        public RectTransform text;
        public RectTransform image;
        public RectTransform video;
    }

    public static Quiz instance;


    public QuestionPanelSet questionPanels;
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
    public bool isAnswered { get; set; }



    public enum QuestionType {
        Text,
        Image,
        Video
    }

    public QuestionType type = QuestionType.Text;

    public int progress    { get; set; }
    public int answerCount { get; set; }
    

    private void Awake() {
        instance = this;

        StaticMethods.AssignButtonAction(btnStart, () => { StartQuiz();});
        answerButtons = pnlAnswerButtons.GetComponentsInChildren<Button>(true);
    }







    void StartQuiz() { StartCoroutine(AnswerFlow()); }

    public IEnumerator AnswerFlow()
    {
        //Run through the array of questions
        //If one question is answerd, move on 
        //Wait until each question is answerd. 
        float t = 0;
        float duration = 5;

        while (t < duration)
        {
            for (int i = 0; i < questions.Length; i++)
            {
                if (!isAnswered)
                {
                    questionPanels.text.gameObject.SetActive(true);
                    questions[i].AskQuestion();
                    yield return new WaitForSeconds(3);
                }
                yield return null;
            isAnswered = false;
            }
            t += Time.deltaTime;
        }



        yield return null;
    }






    public void EndQuiz() {
        //Check pls"
        gameObject.SetActive(false);
        finishScreen.gameObject.SetActive(true);
        Text _finishText = finishScreen.GetComponentInChildren<Text>();

        if (answerCount == questions.Length) {
            _finishText.text = "win";
            Debug.Log("Win");
        } else {
            _finishText.text = "Lose";
        }
    }
}
