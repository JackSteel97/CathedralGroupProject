using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Buttonpop : MonoBehaviour, Vuforia.ITrackableEventHandler {

	private Vuforia.TrackableBehaviour mTrackableBehaviour;

	private bool mShowGUIButton = false;
	private Rect mButtonRect = new Rect(50,50,500,300);


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
		//else
		//{
		//	mShowGUIButton = false;
		//}
	}
	void DoMyWindow(int windowID) {
		GUIStyle Textbox = new GUIStyle(GUI.skin.textArea);
		Textbox.fontSize = 20;
		Textbox.normal.background = null;
		Textbox.active.background = null;
		Textbox.onHover.background = null;
		Textbox.hover.background = null;
		Textbox.onFocused.background = null;
		Textbox.focused.background = null;
		Textbox.normal.textColor = Color.cyan;
		GUI.TextArea (new Rect(50,50,300,150), "This is some text for the main box xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", Textbox);
		if (GUI.Button (new Rect (10, 20, 100, 20), "Close")) 
		{
			mShowGUIButton = false;

		}

	}
	void OnGUI() {
		if (mShowGUIButton) {
			mButtonRect = GUI.Window(0, mButtonRect, DoMyWindow, "Name of Item at York Minster");
		}
	}
}