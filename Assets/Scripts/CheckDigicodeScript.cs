using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckDigicodeScript : MonoBehaviour
{
    public bool isActivated = false;
	[SerializeField]
	private TMP_InputField input;

	public void GetInput(string guess) {
		if (isActivated == true) {
			Debug.Log(guess);
        	if (guess == "58624") {
            	Debug.Log("Correct!");
        	} else {
           		Debug.Log("Wrong!");
				input.text = "";
        	}
    	}
	}
}
