using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizFlow : MonoBehaviour {
    public Quiz quiz;
    public Button _feedBackPassText;
    public Button _feedBackFailText;

    private void Awake() {
        StaticMethods.AssignButtonAction(_feedBackFailText, ProceedFromFeedbackFail);
        StaticMethods.AssignButtonAction(_feedBackPassText, ProceedFromFeedbackPass);
    }

    private static void ProceedFromFeedbackPass() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private static void ProceedFromFeedbackFail() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }    
}
