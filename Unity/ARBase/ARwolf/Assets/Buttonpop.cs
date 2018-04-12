using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Buttonpop : MonoBehaviour, Vuforia.ITrackableEventHandler {

	private Vuforia.TrackableBehaviour mTrackableBehaviour;

	private bool mShowGUIButton = false;
	private Rect mButtonRect = new Rect(50,50,800,1000);
	public GameObject chest;



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

		GUIStyle buttonFont = new GUIStyle(GUI.skin.button);
		buttonFont.fontSize = 35;

		GUIStyle Textbox = new GUIStyle(GUI.skin.label);
		Textbox.fontSize = 40;
		Textbox.normal.background = null;
		Textbox.active.background = null;
		Textbox.onHover.background = null;
		Textbox.hover.background = null;
		Textbox.onFocused.background = null;
		Textbox.focused.background = null;
		Textbox.normal.textColor = Color.cyan;
		Textbox.alignment = TextAnchor.MiddleCenter;

		GUIStyle TitleStyle = new GUIStyle (GUI.skin.label);
		TitleStyle.alignment = TextAnchor.UpperRight;
		TitleStyle.normal.textColor = Color.red;

		GUI.Label (new Rect (500, 500, 800, 600), "ITEM FOUND", TitleStyle);

		//GUI.Label (new Rect(50,50,700,900), "This is some text for the main box xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", Textbox);

		if (GUI.Button (new Rect (10, 20, 300, 60), "Close", buttonFont)) 
		{
			mShowGUIButton = false;

		}

	}
	void OnGUI() {
		if (mShowGUIButton == true) {
			
			chest = GameObject.Find ("OldChest/Chest");
			chest.SetActive (true);
			GameObject.Destroy (chest, 5);

			mButtonRect = GUI.Window (0, mButtonRect, DoMyWindow, "");
		} else {
			chest = GameObject.Find ("OldChest/Chest");
			chest.SetActive (false);
		}
	}
}