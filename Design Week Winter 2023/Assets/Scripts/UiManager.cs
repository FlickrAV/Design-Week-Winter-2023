using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private int price;
    public Text moneyText;
    private GameManager manager;
    private GameObject prefabToAdd;
    private bool firstObjectGet = false;

    void Awake()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        moneyText.text = manager.money.ToString();
    }

    public void GetPrefab(GameObject prefab)
    {
        prefabToAdd = prefab;
    }

    public void BuyItem(GameObject item)
    {
        price = int.Parse(item.transform.GetChild(1).gameObject.GetComponent<Text>().text.Replace("$", string.Empty));
        if(manager.money >= price)
        {
            manager.money -= price;
            manager.objects.Add(prefabToAdd);
            if(!firstObjectGet)
            {
                firstObjectGet = true;
                Instantiate(manager.objects[Random.Range(0, manager.objects.Count)], new Vector3(15, 0, 0), Quaternion.identity);
            }
            item.GetComponent<Image>().color = Color.white;
            item.GetComponent<Button>().interactable = false;
            item.transform.GetChild(0).GetComponent<Text>().text = prefabToAdd.name;
            item.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
