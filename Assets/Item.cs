using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int itemID;
    public int price;
    public int boughtInt;
    public bool bought;
    public Sprite icon;
    public Animator anim;
}
