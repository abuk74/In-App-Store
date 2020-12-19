using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public static ItemDB instance;
    public List<Item> itemDatabase = new List<Item>();

    void Awake()
    {
        instance = this;  
    }
    void Start()
    {
        foreach (Item item in itemDatabase)
        {
            //item.bought = SerializableItemInfo.instance.boughtItem[item.itemID];
            Debug.Log(item.name);
        }
    }
}
