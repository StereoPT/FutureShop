using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobDisplay : MonoBehaviour {

    public Job job;

    public Text nameText;
    public Text durationText;

    public Image progressBar;

	void Start () {
        nameText.text = job.name;
        durationText.text = job.duration.ToString();
	}
}
