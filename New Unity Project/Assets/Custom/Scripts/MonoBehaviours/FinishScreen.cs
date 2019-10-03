using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour, IPointerDownHandler {
    public static FinishScreen instance;
    public Text txtfeedBack;
    
    void Start()
    {
        instance = this;
    }

    public void PresentFeedBack(string _feedback)
    {
        txtfeedBack.text = _feedback.ToString();
    }
  

    public void OnPointerDown(PointerEventData eventData) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
