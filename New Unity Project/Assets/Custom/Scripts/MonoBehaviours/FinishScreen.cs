using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class FinishScreen : MonoBehaviour, IPointerDownHandler {
    public static FinishScreen instance;
    public Text txtfeedBack;
    public List<String> feedBackList = new List<String>();
    
    void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        instance = this;
        if (gameObject.activeSelf) { 
}
        PresentFeedBack();
      
    }
    
 
    public  void PresentFeedBack()
    {
       for(int i = 0; i < feedBackList.Count; i++)
        {
             txtfeedBack.text += feedBackList[i];
          
        }
    }
  

    public void OnPointerDown(PointerEventData eventData) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
