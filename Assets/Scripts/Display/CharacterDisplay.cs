using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour {

    public Character character;

    public Text nameText;
    public Text healthText;
    public Text attackText;
    public Text defenseText;

    public Image isLockedImage;

    void Start() {
        nameText.text = character.name;
        healthText.text = "Health: " + character.health + " / " + character.maxHealth;
        attackText.text = "Attack: " + character.attack;
        defenseText.text = "Defense: " + character.defense;

        isLockedImage.gameObject.SetActive(character.isLocked);
    }
}
