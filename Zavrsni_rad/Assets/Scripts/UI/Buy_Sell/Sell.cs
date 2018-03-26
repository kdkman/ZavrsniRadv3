using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sell : MonoBehaviour,IPointerClickHandler {
    public Invenotry inv_player;
    public Invenotry inv_market;
    private const int id_for_coins = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        
        print("sell");
        SellItems();

    }

   private void SellItems()
    {
        float coinAmount=0;
        for(int i = 0; i < inv_player.selectedItemsSave.Count; i++)//how many coins
        {
            coinAmount += inv_player.selectedItemsSave[i].Value * +inv_player.selectedItemsSave[i].Amount;
            inv_player.selectedItemsSave[i].Parent.transform.GetChild(0).GetComponent<Slot_Item>().item = new Item(); //restertin in slot its item to null
            inv_player.selectedItemsSave[i].Parent.transform.GetChild(1).GetComponent<Text>().text = ""; //restertin in slot its item to null
            inv_player.selectedItemsSave[i].Parent.transform.GetChild(0).GetComponent<Image>().sprite = new Item().Sprite; //restertin in slot its image to null
        }

        for(int i = 0; i < coinAmount; i++)
        {
            inv_player.AddItem(id_for_coins);//0 id for coins
        }
        inv_player.RestartSelectedItems();
       
    }
}
