using System.Collections;
using UnityEngine;

public class TestTheQuestions : MonoBehaviour {
    public Question[] question;

    void Awake() {
        StartCoroutine("Test");
    }

    private IEnumerator Test() {
        foreach (Question q in question) {
            yield return new WaitForSeconds(0.5f);
            q.AskQuestion();
        }
    }
}
