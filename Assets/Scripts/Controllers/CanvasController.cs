using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {
    public static CanvasController Instance;

    public GameObject visiblePanel;

    void Start() {
        if (Instance != null) {
            Debug.Log("CanvasController - Can only have 1 Instance!");
            return;
        }

        Instance = this;
    }

    public void ShowPanel(Transform panelToShow) {
        if (visiblePanel != panelToShow.gameObject) {
            visiblePanel.SetActive(false);
                visiblePanel = panelToShow.gameObject;
            visiblePanel.SetActive(true);
        }
    }
}
