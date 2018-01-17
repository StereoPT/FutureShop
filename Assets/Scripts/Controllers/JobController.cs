using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobController : MonoBehaviour {

    public List<Job> availableJobs;
    public GameObject jobPrefab;
    public Transform jobParent;

	void Start () {
        foreach(Job j in availableJobs) {
            GameObject go = Instantiate(jobPrefab, jobParent);
            go.GetComponentInChildren<Text>().text = j.name;

            go.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(GetItem(go, j.duration)));
        }
	}

    IEnumerator GetItem(GameObject go, float duration) {
        float time = 0f;
        Image progressBar = go.GetComponentsInChildren<Image>()[1];
        Button button = go.GetComponent<Button>();
        button.interactable = false;

        while (time < duration) {
            progressBar.fillAmount = (time / duration);
            time += Time.deltaTime;
            yield return new WaitForSeconds(0);
        }

        button.interactable = true;
        progressBar.fillAmount = 0;
        ItemController.Instance.GetItem();
    }
}
