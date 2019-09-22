using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelText : MonoBehaviour
{
public Button[] textButtons;
public static PanelText instance;

void Start()
{   
    
    instance = this;
    textButtons = Quiz.instance.questionPanels.text.GetComponentsInChildren<Button>(true);
}

}
