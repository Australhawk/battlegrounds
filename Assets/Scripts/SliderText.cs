using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void textUpdate(float textUpdateNumber)
    {
        string sliderTextString = textUpdateNumber.ToString();
        GetComponent<TextMeshProUGUI>().SetText(sliderTextString);
    }
}
