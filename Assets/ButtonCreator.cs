using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonCreator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject storePanel;

    void Start()
    {
        foreach (Item item in ItemDB.instance.itemDatabase)
        {
            GameObject newButton = Instantiate<GameObject>(buttonPrefab, Vector3.zero, Quaternion.identity);
            newButton.name = item.name;
            newButton.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;
            /*if (item.bought)
            {
                newButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                newButton.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Select";
            }
            else
            {
                newButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.price.ToString();
                newButton.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Buy";
                newButton.GetComponent<ButtonController>().price = item.price;
            }
            newButton.GetComponent<ButtonController>().id = item.itemID;*/
            if (item.boughtInt == PlayerPrefs.GetInt("storeItem" + item.itemID.ToString(), 0)) //ten item nie jest kupiony
            {
                Debug.Log(PlayerPrefs.GetInt("storeItem" + item.itemID.ToString(), 0));
                newButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.price.ToString();
                newButton.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Buy";
                newButton.GetComponent<ButtonController>().price = item.price;
            }
            else //ten item jest kupiony
            {
                newButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                newButton.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Select";
            }
            newButton.GetComponent<ButtonController>().id = item.itemID;
            newButton.transform.SetParent(storePanel.transform, false);
            Wallet.instance.objectsForSell.Add(newButton);
        } 
    }
}