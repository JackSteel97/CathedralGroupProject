using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public string Name { get;set;}
    public string Description { get; set; }

    public Item(string name, string desc = "") {
        Name = name;
        Description = desc;
    }
}
