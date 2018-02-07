using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour {

	void Update () {
        if(Input.GetKeyDown(KeyCode.F2)) {
            ScreenCapture.CaptureScreenshot("D:/StereoPT/IoD/Screen.png");
        }		
	}
}
