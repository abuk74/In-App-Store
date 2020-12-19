using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonController : MonoBehaviour
{
    public int price;
    public Animator anim;
    public int id;
    private Button buyButton;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        buyButton = this.gameObject.transform.GetChild(2).GetComponent<Button>();
    }
    void Update()
    {
        if (price > Wallet.instance.coins)
        {
            buyButton.interactable = false;
        }
        else
        {
            buyButton.interactable = true;
        }
    }
    public void Buy()
    {
        if (price <= Wallet.instance.coins)
        {            
            Wallet.instance.coins -= price;
            //ItemDB.instance.itemDatabase[id].bought = true;
            PlayerPrefs.SetInt("storeItem"+id.ToString(), 1);
            //PlayerPrefs.SetInt(id.ToString(), 1);
            this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            this.gameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Select";
            Select();
        }
    }
    public void Select()
    { 
        anim = (Animator)AssetDatabase.LoadAssetAtPath("Assets/Animations/"+id.ToString(), typeof(Animator));
        Debug.Log("Select");
    }
    public void BuyOrSelect()
    {
        if (PlayerPrefs.GetInt("storeItem" + id.ToString(), 0) == 0)//(PlayerPrefs.GetInt(id.ToString(), 0) == 0)// //(!ItemDB.instance.itemDatabase[id].bought)
        {
            Debug.Log("Buy");
            Buy();
        }
        else
        {
            Debug.Log("kupiony");
            Select();
        }
    }
}
