using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class IconScript : MonoBehaviour ,IPointerClickHandler
{
    public GameObject button;
    private Player_input player;

    public void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player_input>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        player.Toggle();//turn off or on so duble - = + 
     
        if (!player.invenotry_Canvas.activeSelf) { player.Toggle(); }//if inventory is open close it an open (buy or sell)
        button.SetActive(true);
    }


}
