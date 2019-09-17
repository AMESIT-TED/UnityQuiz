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

    public int progress    { get; set; }
    public int answerCount { get; set; }
    

    private void Awake() {
        instance = this;

        StaticMethods.AssignButtonAction(btnStart, () => { StartQuiz();});
        answerButtons = pnlAnswerButtons.GetComponentsInChildren<Button>(true);

    

        questionPanels.text.gameObject.SetActive(false);
        questionPanels.image.gameObject.SetActive(false);
        questionPanels.video.gameObject.SetActive(false);

    }







    void StartQuiz() { StartCoroutine(AnswerFlow(questionPanels.image)); }



//I want this function to take in a panel set with a type...then the swapping should be possible
    public IEnumerator AnswerFlow( RectTransform _typeofPanel)
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
                    Debug.Log(questionPanels.image);
                    _typeofPanel.gameObject.SetActive(true);
                    questions[i].AskQuestion();
                  //  yield return new WaitForSeconds(3);
                }
                yield return null;
            isAnswered = true;
            }
            t += Time.deltaTime;
        }
//I did not expect this to work but it does... wtf


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
