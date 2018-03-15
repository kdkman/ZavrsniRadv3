using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot_Item : MonoBehaviour ,IPointerClickHandler {//script is only active when onPress AKA no perment item status beyond items

    [HideInInspector]
    public Item item;
    private Sell sell;
    private  List<Item> selectedItems;
    private Player_input invenotryOnOff;
    [HideInInspector]
    public Color all_1 =  new Color(1f, 1f,1f,1f);


    public void Awake()
    {
        invenotryOnOff = GameObject.Find("Player").GetComponent<Player_input>();
        selectedItems = GameObject.Find("Invenotry_Background").GetComponent<Invenotry>().selectedItemsSave;
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        selectedItems = GameObject.Find("Invenotry_Background").GetComponent<Invenotry>().selectedItemsSave; //this is the list that saves item 
        ToggelItem(eventData.pointerPress.gameObject.GetComponent<Slot_Item>().item);//adding item to selecteditems list

        ListAllObjects();
    }



    public void ListAllObjects()//debug
    {
        print("Begingi: \n");
        for (int i = 0; i < selectedItems.Count; i++)
        {
            print(selectedItems[i].Title + " is on id " + selectedItems[i].ID + " selected: " + selectedItems[i].Selected);
        }
        print("End: \n");
    }



    private void ToggelItem(Item item)
    {
        if (item == null) { return; }
        Color help = this.GetComponent<Image>().color;

        for (int i = 0; i < selectedItems.Count; i++) //go through everyselceted obj
        {
            if((selectedItems[i].Selected == item.Selected) && (selectedItems[i].ID == item.ID))//if its selected and has the right ID
            {
                selectedItems[i].Selected = false; //remove selected
                selectedItems.RemoveAt(i); // remove it form list of selected objects
                this.GetComponent<Image>().color = all_1;//setting color compoent 
                return;
            }
        }
        
        help.a = 0.8f;//setting visualy that itmes have been selected
        help.r -= 0.4f;
        this.GetComponent<Image>().color = help;//setting color compoent 
        item.Selected = true; //set selected true 
        selectedItems.Add(item);//add item to seleccted item

    }

}
