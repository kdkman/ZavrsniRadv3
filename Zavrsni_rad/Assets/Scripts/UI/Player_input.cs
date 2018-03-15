using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_input : MonoBehaviour {
    [HideInInspector]
    public GameObject invenotry_Canvas;
    private float timeHelp;
    private IconScript buy;
    private IconScript sell;



    private void Awake()
    {
        invenotry_Canvas = GameObject.Find("Invenotrty_with_all_buttons");
        buy = GameObject.Find("Market_Buy").GetComponentInChildren<IconScript>();
        sell = GameObject.Find("Market_Sell").GetComponentInChildren<IconScript>();


        Toggle();

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.I) && (Time.realtimeSinceStartup-timeHelp>0.3f)) {//if more then 0.3s past on I open inv
            timeHelp = Time.realtimeSinceStartup;
            Toggle();
            invenotry_Canvas.GetComponentInChildren<Invenotry>().RestartSelectedItems(); //on inv open restarst all values
        }
    }

    public void Toggle()//turns on off invenotry panel
    {
        buy.button.SetActive(false);
        sell.button.SetActive(false);

        if (invenotry_Canvas.activeSelf)
        {
            
            invenotry_Canvas.SetActive(false);
        }
        else
        {
            invenotry_Canvas.SetActive(true);
        }

    }
}
