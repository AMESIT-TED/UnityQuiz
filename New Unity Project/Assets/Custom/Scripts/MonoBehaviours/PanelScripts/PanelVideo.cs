using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelVideo : MonoBehaviour
{
 public Button[] videoButtons;
 public static PanelVideo instance;

void Start()
{
    instance = this;
    videoButtons = Quiz.instance.questionPanels.video.GetComponentsInChildren<Button>(true);

}


}
