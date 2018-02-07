using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

    public List<Character> availableChars;
    public GameObject charPrefab;
    public Transform charParent;

    public Transform jobPanel;

    void Start () {
	    foreach(Character c in availableChars) {
            GameObject go = Instantiate(charPrefab, charParent);

            go.GetComponentInChildren<Text>().text = c.name;
            go.GetComponentsInChildren<Image>()[1].gameObject.SetActive(c.isLocked);

            if(!c.isLocked) {
                go.GetComponent<Button>().onClick.AddListener(() => CanvasController.Instance.ShowPanel(jobPanel));
            }
        }	
	}
}
