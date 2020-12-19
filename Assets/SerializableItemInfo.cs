using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableItemInfo : MonoBehaviour
{
    public static SerializableItemInfo instance;
    public int[] itemId;
    public bool[] boughtItem;
    private int i = 0;
    void Awake()
    {
        instance = this;
    }
    public SerializableItemInfo(Item item)
    {
        //i = ItemDB.instance.itemDatabase.Count;
        //itemId = new int[i];
        boughtItem = new bool[ItemDB.instance.itemDatabase.Count];
        //i = 0;
        foreach (Item itemElemet in ItemDB.instance.itemDatabase)
        {
            //itemId[i] = itemElemet.itemID;
            boughtItem[i] = itemElemet.bought;
            i++;
        }
    }
}
