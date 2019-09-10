using System;
using UnityEngine.Events;
using UnityEngine.Video;

[Serializable]
public class QuestionVideo : Question {
    [Serializable]
    public class Answers {
        public VideoClip correctAnswer;
        public VideoClip decoyAnswerA;
        public VideoClip decoyAnswerB;

        public VideoClip[] GetAnswersArray() {
            return new VideoClip[]{correctAnswer, decoyAnswerA, decoyAnswerB };
        }
    }

    public Answers answers;

    public override void AskQuestion() {
    }

    public override void AssignAnswer(int buttonIndex, int _i) {
        Quiz quiz = Quiz.instance;
        
        StaticMethods.AssignButtonAction(quiz.answerButtons[buttonIndex], (_i == 0) ? (UnityAction)quiz.CorrectAnswer : quiz.IncorrectAnswer);
        
        // Set the correct graphic for this answer.
        VideoClip[] arrAnswers = answers.GetAnswersArray();
        // Target the current button and assigns the text that matches it's answer.
        quiz.answerButtons[buttonIndex].transform.GetChild(0).GetComponent<VideoPlayer>().clip = arrAnswers[_i];
    }
}
