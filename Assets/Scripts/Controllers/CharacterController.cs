using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {
    public Dictionary<Character, GameObject> characterGameObjectMap;
    public GameObject charPrefab;
    public Transform charParent;

    public Transform jobPanel;

    void Start () {
        characterGameObjectMap = new Dictionary<Character, GameObject>();

        CreateCharacter(new Character("StereoPT", 15, 5, 3, false));
        CreateCharacter(new Character("Jon Doe", 15, 5, 3, false));
    }

    void CreateCharacter(Character c) {
        GameObject cGo = Instantiate(charPrefab, charParent);
        cGo.GetComponent<CharacterDisplay>().character = c;

        characterGameObjectMap.Add(c, cGo);

        if (!c.isLocked) {
            cGo.GetComponent<Button>().onClick.AddListener(() => {
                CanvasController.Instance.ShowPanel(jobPanel);
                JobController.Instance.activeCharacter = c;
            });
        }
    }
}
