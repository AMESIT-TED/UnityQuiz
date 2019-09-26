using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VideoManager : MonoBehaviour, IPointerEnterHandler
{
    // Start is called before the first frame update
    public RectTransform mainCanvas;
    private CanvasGroup canvasGroup;
    private float panelWidth;
    private float panelHeight;

    public void OnPointerEnter(PointerEventData eventData) {
        StartCoroutine(ScaleVideoUi());
    }

    private void Awake() {
        panelHeight = (mainCanvas.rect.width * mainCanvas.localScale.x)/2;
        panelWidth = (mainCanvas.rect.height * mainCanvas.localScale.y)/2;
    }


  private IEnumerator ScaleVideoUi(){
      float t = 0;
      float duration = 10.0f;

    while(t<duration){
           // videoPanel.transform.localScale = Vector3.Lerp(videoPanel.transform.localScale,  (int)1.5*(videoPanel.transform.position), t / duration);

        t += Time.deltaTime;
      yield return null;
    }

  }

   


}
