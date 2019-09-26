using UnityEngine;

public class TestSelectableButton : MonoBehaviour {
    public static bool isPreviewActive;

    void OnMouseEnter() {
        RevealPreview();


    }

    private void RevealPreview() {
        //This is optional,
        TestVideoPreview test = TestVideoPreview.instance;

        SwapVideoContent(test);
        
        // If we already have a video selected, we assume we just want to swap content and 
        if (isPreviewActive) {
            if (test.corBounce == null) {
                test.corBounce = StartCoroutine(test.Bounce());
            }

            return;
        }

        isPreviewActive = true;

        // This is only called the first time you reveal the UI.
        // The return statement above prevents this from repeating.
        StartCoroutine(
            test.Reveal(
                transform.position
            ,   transform.localScale
            )
        );
    }

    private void SwapVideoContent(TestVideoPreview test) {
        // Probably want to swap a video clip instead of a material colour.
        // Basically you need to send a VideoClip to the VideoPreview's UI.
        test.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
    }
}
