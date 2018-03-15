using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invenotry : MonoBehaviour{//this scripts is on Invenotry_Background


    public GameObject slot_UI; //prefab slot
    [HideInInspector]
    public List<GameObject> slots = new List<GameObject>();//contains list of all slot in inv

    private ItemDataBase allItem;

    [HideInInspector]
    public List<Item> selectedItemsSave = new List<Item>();
    private float timeHelp;


    public void Awake()
    {

        allItem = GameObject.Find("AllItems").GetComponent<ItemDataBase>();
        for (int i = 0; i < 16; i++)
        {
            var UI = Instantiate(slot_UI);//make new game object from prefab
            UI.transform.SetParent(GameObject.Find("Invenotry_Background").transform);//sets parent ot be inv_bckgrnd
            UI.transform.GetChild(0).GetComponent<Slot_Item>().item = new Item();//sets item to empyt item
            UI.transform.GetChild(0).GetComponent<Slot_Item>().item.Parent = UI;
            UI.transform.GetChild(0).GetComponent<Image>().sprite =new Item().Sprite ; //setting Sprite
            slots.Add(UI);

        }

        AddItem(1);
        AddItem(2);

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.I) && (Time.realtimeSinceStartup - timeHelp > 0.3f))
        {//if more then 0.3s past on I open inv
            timeHelp = Time.realtimeSinceStartup;
            RestartSelectedItems();

        }
    }//restarts selected invenotry items


    public void AddItem(int id)
    {
        Item itemToAdd = allItem.FetchItemByID(id);
        for(int i = 0; i < slots.Count; i++)//for every slot
        {
            
            if (slots[i].transform.GetChild(0).GetComponent<Slot_Item>().item.ID == -1)//if item in slot has id -1 
            {
                slots[i].transform.GetChild(0).GetComponent<Slot_Item>().item = itemToAdd; //changing item to itemByID
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = itemToAdd.Sprite; //changing Spiret to itemByID 
                slots[i].transform.GetChild(0).GetComponent<Slot_Item>().item.Parent = slots[i]; //setting parent of itemToAdd
                break;
            }
            
        }
    } //TODO FIX stackabels

    public void RestartSelectedItems()//restats all items and images
    {
        for(int i=0; i< slots.Count; i++)//bc only slots that have items and it goes in a row
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            slots[i].transform.GetChild(0).GetComponent<Slot_Item>().item.Selected = false;
        }
        selectedItemsSave.Clear();
    }
}
