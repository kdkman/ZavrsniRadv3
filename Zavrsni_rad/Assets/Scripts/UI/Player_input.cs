using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_input : MonoBehaviour {

    public GameObject BuyButton;
    private float timeHelp;
    [HideInInspector]
    public GameObject sellButton;
    [HideInInspector]
    public GameObject invUI;

    public MarketUI market;



    private void Awake()
    {
        
        sellButton = this.GetComponentInChildren<Sell>().transform.gameObject;
        sellButton.SetActive(false);

        invUI = this.gameObject.GetComponentInChildren<Canvas>().gameObject;
        Toggle();

    }
    public void Update()
    {

        if (Input.GetKey(KeyCode.I) && (Time.realtimeSinceStartup-timeHelp>0.3f)) {//if more then 0.3s past on I open inv
          
            timeHelp = Time.realtimeSinceStartup;
           if ( market.transform.GetChild(1).gameObject.activeSelf){ return; }
            Toggle();
            invUI.GetComponentInChildren<Invenotry>().RestartSelectedItems(); //on inv open restarst all values
        }
    }

    public void Toggle()//turns on off invenotry panel
    {
        invUI.GetComponentInChildren<Invenotry>().RestartSelectedItems();
        if (invUI.activeSelf)
        {
            sellButton.SetActive(false);
            invUI.SetActive(false);
        }
        else
        {
            invUI.SetActive(true);

        }
    }
}
