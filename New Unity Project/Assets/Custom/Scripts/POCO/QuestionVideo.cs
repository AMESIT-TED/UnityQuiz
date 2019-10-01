using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

[Serializable, CreateAssetMenu(fileName = "New Video Question", menuName = "Question/Video")]
public class QuestionVideo : Question
{
    [Serializable]
    public class Answers
    {
        public String correctAnswer;
        public String decoyAnswerA;
        public String decoyAnswerB;

        public String[] GetAnswersArray()
        {
            return new String[] { correctAnswer, decoyAnswerA, decoyAnswerB };
        }
    }

    public Answers answers;
    

    public override void AskQuestion()
    {
        base.AskQuestion();
        EnablePanel();
        // TODO: Turn the required panel on.
    }

    public override void AssignAnswer(int buttonIndex, int _i)
    {
        base.AssignAnswer(buttonIndex, _i);

        PanelVideo panelVideo = PanelVideo.instance;

        // Set the correct graphic for this answer.
        String[] arrAnswers = answers.GetAnswersArray();
        
        Quiz.instance.questionPanels.video.GetComponent<PanelVideo>().videoButtons[buttonIndex].transform.GetComponent<VideoPlayer>().url = arrAnswers[_i];
        StaticMethods.AssignButtonAction(Quiz.instance.questionPanels.video.GetComponent<PanelVideo>().videoButtons[buttonIndex], (_i == 0) ? (UnityAction)CorrectAnswer : IncorrectAnswer);
        //TODO play the video...
        Quiz.instance.questionPanels.video.GetComponent<PanelVideo>().videoButtons[buttonIndex].transform.GetComponent<VideoPlayer>().Play();



        // Target the current button and assigns the text that matches it's answer.
        //  quiz.answerButtons[buttonIndex].transform.GetChild(0).GetComponent<VideoPlayer>().clip = arrAnswers[_i];
    }

    protected override void EnablePanel()
    {
        Quiz.instance.questionPanels.video.gameObject.SetActive(true);
    }
}