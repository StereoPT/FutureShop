using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Job {
    public string name;
    public float duration;

    public int minDamage;
    public int maxDamage;

    public Job(string name, float duration, int minDamage, int maxDamage) {
        this.name = name;
        this.duration = duration;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
    }
}
