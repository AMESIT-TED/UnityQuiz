using System.Collections;
using UnityEngine;

public class TestVideoPreview : MonoBehaviour {
    public static TestVideoPreview instance;

    public AnimationCurve bounceCurve;

    public Coroutine corBounce { get; set; }

    private Vector3 toPosition;
    private Vector3 toScale;

    void Awake() {
        instance = this;

        SetTargetTranformations();
        Hide();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Hide();
        }
    }

    private void SetTargetTranformations() {
        toPosition = transform.position;
        toScale = transform.localScale;
    }

    public IEnumerator Reveal(Vector3 _fromPosition, Vector3 _fromScale) {
        gameObject.SetActive(true);

        float t = 0;
        float duration = 0.125f;

        while (t < duration) {
            transform.position = Vector3.Lerp(_fromPosition, toPosition, t / duration);
            transform.localScale = Vector3.Lerp(_fromScale, toScale, t / duration);

            t += Time.deltaTime;
            yield return null;
        }
    //WHy are we setting it here? dosent the lerp make it here
    //Eventually?
        transform.position = toPosition;
        transform.localScale = toScale;
    }

    public IEnumerator Bounce() {
        float t = 0;
        float duration = 0.125f;

        while (t < duration) {
            transform.localScale = Vector3.Lerp(toScale, toScale * 1.1f, bounceCurve.Evaluate(t / duration));

            t += Time.deltaTime;
            yield return null;
        }

        transform.localScale = toScale;

        // Make bounce available again.
        corBounce = null;
    }

    void Hide() {
        gameObject.SetActive(false);
        TestSelectableButton.isPreviewActive = false;
    }
}
