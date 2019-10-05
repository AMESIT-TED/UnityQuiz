using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;


public class VideoButtonSelect : MonoBehaviour,IPointerEnterHandler
{
public static bool isPreviewActive;

    public void OnPointerEnter(PointerEventData eventData)
    {
      RevealPreview();
      
    }



  private void RevealPreview(){
      SwapVideoContent(VideoPreview.instance);

      if(isPreviewActive){
          if(VideoPreview.instance.corBounce == null){
              VideoPreview.instance.corBounce = StartCoroutine(VideoPreview.instance.Bounce());
          }
          return;
      }

    isPreviewActive = true;

    StartCoroutine(VideoPreview.instance.RevealVideo(transform.position,transform.localScale));


  }

private void SwapVideoContent(VideoPreview _videoPreview){
  //use this method to switch the contents 
    _videoPreview.GetComponent<VideoPlayer>().Play();
    _videoPreview.GetComponentInChildren<Text>().text = GetComponentInChildren<Text>().text;
   
}

}
