using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckDigicodeScript : MonoBehaviour
{
    public GameObject button;
    public bool isActivated = false;
	[SerializeField]
	private TMP_InputField input;

	public void GetInput(string guess) {
		if (isActivated == true) {
        	if (guess == "58624") {
				var openDoorScript = button.GetComponent<OpenDoorScript>();
			    openDoorScript.isActivated = true;
				input.text = "Well done!";
        	} else {
				input.text = "";
        	}
    	}
	}
}
