using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
    public Image progress;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float fill = (float)Progression.getPercentageDiscovered();
        if (Equals(fill, 0.0f)) {
            fill = 0.001f;
        }
        progress.fillAmount = fill;
	}
}
