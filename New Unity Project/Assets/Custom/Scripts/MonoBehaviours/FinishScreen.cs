using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FinishScreen : MonoBehaviour, IPointerDownHandler {
    public void OnPointerDown(PointerEventData eventData) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
