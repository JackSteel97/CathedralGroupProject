using System.Collections;
using System.Collections.Generic;
using Vuforia;
using UnityEngine;
using UnityEngine.UI;

public class ChestHandler : MonoBehaviour, ITrackableEventHandler {

    private TrackableBehaviour mTrackableBehaviour;

    private bool mShowGUIButton;
    private Rect mButtonRect = new Rect(50, 50, 800, 1000);

    public GameObject chest;
    private Item item;
    private string guiTitle;


    void Start() {
        mTrackableBehaviour = GetComponent<Vuforia.TrackableBehaviour>();
        if (mTrackableBehaviour) {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        PlayerPrefs.DeleteAll();
        Progression.init();
    }

    public void OnTrackableStateChanged(
        Vuforia.TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus) {
        if (newStatus == Vuforia.TrackableBehaviour.Status.DETECTED ||
            newStatus == Vuforia.TrackableBehaviour.Status.TRACKED) {
            mShowGUIButton = true;
        } else {
            mShowGUIButton = false;
        }
    }

    void DoMyWindow(int windowID) {

        GUIStyle buttonFont = new GUIStyle(GUI.skin.button);
        buttonFont.fontSize = 28;

        GUIStyle Textbox = new GUIStyle(GUI.skin.label);
        Textbox.fontSize = 32;
        Textbox.normal.background = null;
        Textbox.active.background = null;
        Textbox.onHover.background = null;
        Textbox.hover.background = null;
        Textbox.onFocused.background = null;
        Textbox.focused.background = null;
        Textbox.normal.textColor = Color.cyan;
        Textbox.alignment = TextAnchor.MiddleCenter;

        GUIStyle TitleStyle = new GUIStyle(GUI.skin.label);
        TitleStyle.alignment = TextAnchor.UpperRight;
        TitleStyle.normal.textColor = Color.red;
        TitleStyle.fontSize = 40;

        GUI.Label(new Rect(50, 50, 700, 600), guiTitle, TitleStyle);
        string desc = item.Description;
        string btnStr = "Discover";
        if (guiTitle != "ITEM FOUND!") {
            desc = "";
            btnStr = "Close";
        }
        GUI.Label(new Rect(50, 50, 700, 900), desc, Textbox);

        if (GUI.Button(new Rect(10, 20, 300, 60), btnStr, buttonFont)) {
            mShowGUIButton = false;
            Progression.discoverItem(item.Name.ToLower());
        }

    }

    void OnGUI() {

        if (mShowGUIButton) {
            string parentName = gameObject.name;
            item = new Item(parentName, DetermineDescription(parentName));
            if (Progression.discovered(item.Name.ToLower())) {
                guiTitle = "ALREADY FOUND!";
            } else {
                guiTitle = "ITEM FOUND!";
            }

            mButtonRect = GUI.Window(0, mButtonRect, DoMyWindow, "");
        }

    }

    private string DetermineDescription(string itemName) {
        switch (itemName.ToLower()) {
            case "brokenfork":
                return "Stand at the west doors and look down the Nave. It was built 1291-1360, so it’s more than 600 years old. The statue behind you is St Peter, the patron saint of York Minster. The “Keys of Heaven” are his symbol. Look out for red shields with crossed keys around the Minster.";
            case "whisperingeye":
                return "Watch out for The Dragon above your head! It is on a pivot. It was probably used to lift a heavy font lid in medieval times. A font holds the water for baptism. Turn to look at the Great West Window at the end of the Nave. Can you see why its nickname is “the heart of Yorkshire”?";
            case "clover":
                return "This is where daily Evensong takes place. The carved wood and furniture are only 180 years old - a fire in 1829 destroyed the medieval woodwork and the roof. This huge wooden chair is the “cathedra” - or the seat for the archbishop. The Latin word gives us the name “cathedral”";
            case "brexit":
                return "You are under the Central Tower, so look up! It’s 60 metres high, weighing 16,000 tons; about the same weight as 40 jumbo jets! It was finished in 1472.";
            case "hourglass":
                return "The Chapter House. Completed around 1280 this amazing structure was built to hold meetings of the Dean & Chapter, the Minster’s government. See if you can find the Dean’s stall and don’t forget to look for the treasure.";
            default:
                return "ERROR 404";
        }
    }
}
