using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public int money;
    public int price;
    public Text moneyText;
    public string itemName;

    void Awake()
    {
        money = 10;
    }

    void Update()
    {
        moneyText.text = "$" + money.ToString();
    }

    public void NameObject(string objectName)
    {
        itemName = objectName;
    }

    public void BuyItem(GameObject item)
    {
        price = int.Parse(item.transform.GetChild(1).gameObject.GetComponent<Text>().text);
        if(money >= price)
        {
            money -= price;
            item.GetComponent<Image>().color = Color.white;
            item.transform.GetChild(0).GetComponent<Text>().text = itemName;
            item.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            //item.GetComponent<Animator>().speed = 1;
        }
    }
}
