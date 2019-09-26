using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPreview : MonoBehaviour
{

    public static VideoPreview instance;

    public AnimationCurve bounceCurve;

    public Coroutine corBounce{get;set;}

    private Vector3 targetPosition;
    private Vector3 targetScale;


    

    void Awake()
    {
       instance = this;
       SetTargetTransform();
       Hide();
       
    }


    // Update is called once per frame
    void Update()
    {
           if (Input.GetMouseButtonDown(0)) {
            Hide();
        }
    }


    private void SetTargetTransform(){
        ///Setting transform to the scripts attached gameobject.
        targetPosition = transform.position;
        targetScale = transform.localScale;
    }

    public IEnumerator RevealVideo(Vector3 _originalPosition, Vector3 _originalScale){
        gameObject.SetActive(true);
        float t = 0;
        float duration = 0.125f;

        while(t<duration){
            transform.position = Vector3.Lerp(_originalPosition,targetPosition, t/duration);
            transform.localScale = Vector3.Lerp(_originalScale,targetScale, t/duration);

            t += Time.deltaTime;
            yield return null;
        }
    ///WHY??
        transform.position = targetPosition;
        transform.localScale = targetScale;
    }

    
    public IEnumerator Bounce() {
        float t = 0;
        float duration = 0.125f;

        while (t < duration) {
            transform.localScale = Vector3.Lerp(targetPosition, targetScale * 1.1f, bounceCurve.Evaluate(t / duration));

            t += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;

        // Make bounce available again.
        corBounce = null;
    }

    void Hide(){
        gameObject.SetActive(false);
        //Because static i can acess without instance :)
        VideoButtonSelect.isPreviewActive = false;
    }
}
