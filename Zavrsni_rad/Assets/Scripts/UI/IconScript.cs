using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class IconScript : MonoBehaviour ,IPointerClickHandler
{
    public GameObject button;
    public Player_input player;
    public MarketUI market;



    public void OnPointerClick(PointerEventData eventData)
    {

        if (button.name == "Buy")
        {

    
            player.invUI.SetActive(false);
            player.sellButton.SetActive(false);
            market.Toggle();
        }
        if(button.name == "Sell")
        {
       
            market.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            market.gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            player.Toggle();
            player.sellButton.SetActive(true);
           
        }
    }


}
