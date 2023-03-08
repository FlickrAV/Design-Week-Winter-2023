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
    private GameManager manager;
    private GameObject prefabToAdd;
    bool firstObjectGet = false;

    void Awake()
    {
        money = 10;
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Start() 
    {
        InvokeRepeating("SpawnTest", 0, 5);
    }

    void Update()
    {
        moneyText.text = "$" + money.ToString();
    }

    void SpawnTest()
    {
        manager.SpawnNewObject();
    }

    public void GetPrefab(GameObject prefab)
    {
        prefabToAdd = prefab;
    }

    public void BuyItem(GameObject item)
    {
        price = int.Parse(item.transform.GetChild(1).gameObject.GetComponent<Text>().text.Replace("$", string.Empty));
        if(money >= price)
        {
            money -= price;
            manager.objects.Add(prefabToAdd);
            if(!firstObjectGet)
            {
                manager.objects.RemoveAt(0);
                manager.objects.TrimExcess();
                firstObjectGet = true;
            }
            item.GetComponent<Image>().color = Color.white;
            item.transform.GetChild(0).GetComponent<Text>().text = prefabToAdd.name;
            item.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            //item.GetComponent<Animator>().speed = 1;
        }
    }
}
