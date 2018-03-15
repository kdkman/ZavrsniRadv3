using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sell : MonoBehaviour,IPointerClickHandler {
    private Invenotry inv;
    private const int id_for_coins = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        inv = GameObject.Find("Invenotry_Background").GetComponent<Invenotry>();
        print("sell");
        SellItems();

    }

   private void SellItems()
    {
        float coinAmount=0;
        for(int i = 0; i < inv.selectedItemsSave.Count; i++)//how many coins
        {
            coinAmount += inv.selectedItemsSave[i].Value * +inv.selectedItemsSave[i].Amount;
            print(inv.selectedItemsSave[i].Parent.transform.GetChild(0));
            inv.selectedItemsSave[i].Parent.transform.GetChild(0).GetComponent<Slot_Item>().item = new Item(); //restertin in slot its item to null
            inv.selectedItemsSave[i].Parent.transform.GetChild(0).GetComponent<Image>().sprite = new Item().Sprite; //restertin in slot its image to null
        }

        for(int i = 0; i < coinAmount; i++)
        {
            inv.AddItem(id_for_coins);//0 id for coins
        }
        inv.RestartSelectedItems();
       
    }
}
