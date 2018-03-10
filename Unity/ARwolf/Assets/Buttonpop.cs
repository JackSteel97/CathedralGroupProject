using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Buttonpop : MonoBehaviour, Vuforia.ITrackableEventHandler {

	private Vuforia.TrackableBehaviour mTrackableBehaviour;

	private bool mShowGUIButton = false;
	private Rect mButtonRect = new Rect(50,50,120,60);

	void Start () {
		mTrackableBehaviour = GetComponent<Vuforia.TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	public void OnTrackableStateChanged(
		Vuforia.TrackableBehaviour.Status previousStatus,
		Vuforia.TrackableBehaviour.Status newStatus)
	{
		if (newStatus == Vuforia.TrackableBehaviour.Status.DETECTED ||
			newStatus == Vuforia.TrackableBehaviour.Status.TRACKED)
		{
			mShowGUIButton = true;
		}
		else
		{
			mShowGUIButton = false;
		}
	}

	void OnGUI() {
		if (mShowGUIButton) {
			// draw the GUI button
			if (GUI.Button(mButtonRect, "Hello")) {
				// do something on button click 
			}
		}
	}
}