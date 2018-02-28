using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobController : MonoBehaviour {
    public static JobController Instance;

    public Dictionary<Job, GameObject> jobGameObjectMap;
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

        jobGameObjectMap = new Dictionary<Job, GameObject>();

        CreateJob(new Job("Drones", 1f, 0, 5));
        CreateJob(new Job("Droids", 5f, 5, 10));
        CreateJob(new Job("Enhanced Humans", 10f, 10, 15));
        CreateJob(new Job("Cyborgs", 20f, 15, 20));
        CreateJob(new Job("Robots", 30f, 20, 25));
	}

    void CreateJob(Job j) {
        GameObject jGo = Instantiate(jobPrefab, jobParent);
        jGo.GetComponent<JobDisplay>().job = j;

        jobGameObjectMap.Add(j, jGo);

        jGo.GetComponent<Button>().onClick.AddListener(() => {
            float level = (activeCharacter.attack + activeCharacter.defense) / 2;
            float toughness = Mathf.Pow(level, 2) * 10f;
            StartCoroutine(GetItem(j, jGo, j.duration, toughness));
        });
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
