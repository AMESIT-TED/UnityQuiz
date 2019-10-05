using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelImage : MonoBehaviour
{
    public Button[] imageButtons;
    public Text question;
    public static PanelImage instance;
    


    void Start()
{
    instance = this;
    imageButtons = Quiz.instance.questionPanels.image.GetComponentsInChildren<Button>(true);
     Quiz quiz = Quiz.instance;
    question.text = quiz.questions[quiz.progress-1].question;
        
        
    }
}
