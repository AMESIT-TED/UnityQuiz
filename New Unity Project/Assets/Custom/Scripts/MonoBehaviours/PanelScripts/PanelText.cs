using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelText : MonoBehaviour
{
public Button[] textButtons;
public static PanelText instance;
    public Text textQuestion;

void Start()
{
    Quiz quiz = Quiz.instance;
    textQuestion.text = quiz.questions[quiz.progress -1 ].question;
        instance = this;
   // textButtons = Quiz.instance.questionPanels.text.GetComponentsInChildren<Button>(true);
}

}
