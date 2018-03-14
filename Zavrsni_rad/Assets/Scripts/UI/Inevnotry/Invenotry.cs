using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invenotry : MonoBehaviour {//this scripts is on Invenotry_background

    public GameObject slot_UI; //prefab slot
    private List<GameObject> slots = new List<GameObject>();//contains list of all slot in inv

    private ItemDataBase allItem;

    public void Awake()
    {
        allItem = GameObject.Find("AllItems").GetComponent<ItemDataBase>();
        for (int i = 0; i < 16; i++)
        {
            var UI = Instantiate(slot_UI);//make new game object from prefab
            UI.transform.SetParent(GameObject.Find("Invenotry_Background").transform);//sets parent ot be inv_bckgrnd
            UI.transform.GetChild(0).GetComponent<Slot_Item>().item = new Item();//sets item to empyt item
            UI.transform.GetChild(0).GetComponent<Image>().sprite =new Item().Sprite ; //setting Sprite
            slots.Add(UI);

        }
        AddItem(1);
        AddItem(2);

    }

    void AddItem(int id)
    {
        
        Item itemToAdd = allItem.FetchItemByID(id);


        for(int i = 0; i < slots.Count; i++)//for every slot
        {
            
            if (slots[i].transform.GetChild(0).GetComponent<Slot_Item>().item.ID == -1)//if item in slot has id -1 
            {
                print(slots[i].transform.GetChild(0).GetComponent<Slot_Item>().item.ID);
                slots[i].transform.GetChild(0).GetComponent<Slot_Item>().item = itemToAdd; //changing item to itemByID
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = itemToAdd.Sprite; //changing Spiret to itemByID 
                print(slots[i].transform.GetChild(0).GetComponent<Slot_Item>().item.ID);
                break;
            }
            
        }
    }

}
