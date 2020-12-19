using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet instance;
    public int coins = 100;
    public List<GameObject> objectsForSell = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }

}
