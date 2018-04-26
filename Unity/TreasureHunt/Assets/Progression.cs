using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progression {

    private static int numberOfItemsToFind;
    private static int numberFoundByPlayer;
    private static List<string> itemsFound;
    private static List<string> allPossibleItems;

    public static void init() {
        allPossibleItems = new List<string>() { "brokenfork", "clover", "brexit", "whisperingeye", "hourglass" };
        numberOfItemsToFind = allPossibleItems.Count;
        itemsFound = new List<string>();
        loadPreviouslyFound();
    }

    private static void loadPreviouslyFound() {
        foreach (string item in allPossibleItems) {
            if (PlayerPrefs.HasKey(item) && PlayerPrefs.GetInt(item, 0) == 1) {
                //found
                itemsFound.Add(item);
                numberFoundByPlayer++;
            }
        }
    }

    public static bool discoverItem(string itemName) {
        if (itemName != null && allPossibleItems.Contains(itemName) && !itemsFound.Contains(itemName)) {
            //discoverable
            PlayerPrefs.SetInt(itemName, 1);
            numberFoundByPlayer++;
            itemsFound.Add(itemName);
            return true;
        }
        //failed
        return false;
    }

    public static bool undiscoverItem(string itemName) {
        if (allPossibleItems.Contains(itemName) && itemsFound.Contains(itemName)) {
            //already discovered
            PlayerPrefs.SetInt(itemName, 0);
            numberFoundByPlayer--;
            itemsFound.Remove(itemName);
            return true;
        }
        //failed
        return false;
    }

    public static bool discovered(string itemName) {
        if (itemName != null && allPossibleItems.Contains(itemName) && !itemsFound.Contains(itemName)) {
            return false;
        }
        return true;
    }

    public static float getPercentageDiscovered() {
        return ((float)numberFoundByPlayer / (float)numberOfItemsToFind);
    }
}
