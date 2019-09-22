using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelImage : MonoBehaviour
{
    public Button[] imageButtons;
    public static PanelImage instance;
    void Start()
{
    instance = this;
    imageButtons = Quiz.instance.questionPanels.image.GetComponentsInChildren<Button>(true);

}
}
