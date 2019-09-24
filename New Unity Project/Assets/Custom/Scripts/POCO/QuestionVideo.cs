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
        public VideoClip correctAnswer;
        public VideoClip decoyAnswerA;
        public VideoClip decoyAnswerB;

        public VideoClip[] GetAnswersArray()
        {
            return new VideoClip[] { correctAnswer, decoyAnswerA, decoyAnswerB };
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
        VideoClip[] arrAnswers = answers.GetAnswersArray();
        Debug.Log(Quiz.instance.questionPanels.video.GetComponent<PanelVideo>().videoButtons[buttonIndex]);
        Quiz.instance.questionPanels.video.GetComponent<PanelVideo>().videoButtons[buttonIndex].transform.GetComponent<VideoPlayer>().clip = arrAnswers[_i];
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