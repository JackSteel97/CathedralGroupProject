using System.Collections.Generic;
using UnityEngine;

public class Progression {

    private int numberOfItemsToFind;
    private int numberFoundByPlayer;
    private List<string> itemsFound;
    private List<string> allPossibleItems;

    public Progression(List<string> allPossibleItemNames) {
        numberOfItemsToFind = allPossibleItemNames.Count;
        allPossibleItems = allPossibleItemNames;
        loadPreviouslyFound();
    }

    private void loadPreviouslyFound() {
        foreach(string item in allPossibleItems) {
            if(PlayerPrefs.HasKey(item) && PlayerPrefs.GetInt(item, 0) == 1) {
                //found
                itemsFound.Add(item);
            }
        }
    }

    public bool discoverItem(string itemName) {
        if(allPossibleItems.Contains(itemName) && !itemsFound.Contains(itemName)) {
            //discoverable
            PlayerPrefs.SetInt(itemName, 1);
            return true;
        }
        //failed
        return false;
    }

    public bool undiscoverItem(string itemName) {
        if (allPossibleItems.Contains(itemName) && itemsFound.Contains(itemName)) {
            //already discovered
            PlayerPrefs.SetInt(itemName, 0);
            return true;
        }
        //failed
        return false;
    }

    public decimal getPercentageDiscovered() {
        return System.Math.Round((decimal)(numberFoundByPlayer / numberOfItemsToFind) * 100, 2);
    }
}
