//using system;
//using unityengine;
//using unityengine.events;
//using unityengine.ui;
//using unityengine.video;

//[serializable, createassetmenu(filename = "new video question", menuname = "question/video")]
//public class questionvideo : question
//{
//    [serializable]
//    public class answers
//    {
//        public videoclip correctanswer;
//        public videoclip decoyanswera;
//        public videoclip decoyanswerb;

//        public videoclip[] getanswersarray()
//        {
//            return new videoclip[] { correctanswer, decoyanswera, decoyanswerb };
//        }
//    }

//    public answers answers;

//    public override void askquestion()
//    {
//        base.askquestion();
//        enablepanel();
//        // todo: turn the required panel on.
//    }

//    public override void assignanswer(int buttonindex, int _i)
//    {
//        base.assignanswer(buttonindex, _i);

//        panelvideo panelvideo = panelvideo.instance;
//        videoclip[] arranswers = answers.getanswersarray();

//        quiz.instance.questionpanels.video.getcomponent<panelvideo>().videobuttons[buttonindex].transform.getcomponent<videoplayer>().clip = arranswers[_i];


//        staticmethods.assignbuttonaction(panelvideo.videobuttons[buttonindex], (_i == 0) ? (unityaction)correctanswer : incorrectanswer);
//        // set the correct graphic for this answer.
//        panelvideo.videobuttons[buttonindex].transform.getc   hild(0).getcomponentinchildren<videoplayer>().clip = arranswers[_i];
//        // target the current button and assigns the text that matches it's answer.
//        //  quiz.answerbuttons[buttonindex].transform.getchild(0).getcomponent<videoplayer>().clip = arranswers[_i];
//    }

//    protected override void enablepanel()
//    {
//        quiz.instance.questionpanels.video.gameobject.setactive(true);
//    }
//}
