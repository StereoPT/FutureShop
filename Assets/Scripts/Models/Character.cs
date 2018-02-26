using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character {
    public string name;
    public bool isLocked;

    public int maxHealth;
    public int health;

    public int attack;
    public int defense;

    public Character(string name, int health, int attack, int defense, bool isLocked) {
        this.name = name;
        this.health = health;
        this.maxHealth = health;
        this.attack = attack;
        this.defense = defense;
        this.isLocked = isLocked;
    }
}
