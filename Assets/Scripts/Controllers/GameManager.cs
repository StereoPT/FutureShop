using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour {

    public string saveFileName = "futureshop.fs";
    private string savePath;

	void Start () {
        savePath = Path.Combine(Application.persistentDataPath, saveFileName);
	}

    public void NewGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveGame() {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream fs = File.Create(savePath);
        bf.Serialize(fs, InventoryController.Instance.inventory);
        fs.Close();
    }

    public void LoadGame() {
        if(File.Exists(savePath)) {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream fs = File.Open(savePath, FileMode.Open);
                InventoryController.Instance.LoadInventory((List<ItemStack>)bf.Deserialize(fs));
            fs.Close();
        }
    }
}