using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelVideo : MonoBehaviour
{

 public static PanelVideo instance;
 public Button[] videoButtons;

    

    void Start()
{
    instance = this;
    videoButtons = Quiz.instance.questionPanels.video.GetComponentsInChildren<Button>(true);

    }


}
