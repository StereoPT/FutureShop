using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobController : MonoBehaviour {
    public static JobController Instance;

    public List<Job> availableJobs;
    public GameObject jobPrefab;
    public Transform jobParent;

    //[HideInInspector]
    public Character activeCharacter;

	void Start () {
        if (Instance != null) {
            Debug.Log("JobController - Can only have 1 Instance!");
            return;
        }

        Instance = this;

        foreach (Job j in availableJobs) {
            GameObject go = Instantiate(jobPrefab, jobParent);

            Text[] labels = go.GetComponentsInChildren<Text>();
            labels[0].text = j.duration.ToString();
            labels[1].text = j.name;

            go.GetComponent<Button>().onClick.AddListener(() => {
                float level = (activeCharacter.attack + activeCharacter.defense) / 2;
                float toughness = Mathf.Pow(level, 2) * 10f;
                StartCoroutine(GetItem(j, go, j.duration, toughness));
            });
        }
	}

    IEnumerator GetItem(Job j, GameObject go, float duration, float toughness) {
        int dmg = Random.Range(j.minDamage, j.maxDamage) * 20;

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

        if(dmg < toughness) {
            ItemController.Instance.GetItem();
        }
    }
}
