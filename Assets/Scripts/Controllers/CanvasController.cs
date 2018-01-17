using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    public GameObject visiblePanel;

    public void ShowPanel(Transform panelToShow) {
        if (visiblePanel != panelToShow.gameObject) {
            visiblePanel.SetActive(false);

            visiblePanel = panelToShow.gameObject;
            visiblePanel.SetActive(true);
        }
    }
}
