using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoButtonSelect : MonoBehaviour
{
public static bool isPreviewActive;
  void OnMouseEnter()
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
    _videoPreview.GetComponent<VideoPlayer>().Play();
     VideoPreview.instance.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
}

}
