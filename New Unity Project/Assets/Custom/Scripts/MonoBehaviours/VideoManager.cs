using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    // Start is called before the first frame update
  public RectTransform videoPanel;
  public Vector3 endMarker;
  public Vector3 endScale;

    private void Awake() {
        StartCoroutine(ScaleVideoUi());
    }

 
  
  

  private IEnumerator ScaleVideoUi(){
      float t = 0;
      float duration = 10.0f;

    while(t<duration){
        videoPanel.transform.position = Vector3.Lerp(videoPanel.transform.position,endMarker,t/duration);
        videoPanel.transform.localScale= Vector3.Lerp(videoPanel.localScale,endScale,t/duration);
        t += Time.deltaTime;
      yield return null;
    }

  }


}
