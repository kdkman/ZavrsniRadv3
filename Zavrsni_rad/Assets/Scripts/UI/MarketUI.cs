using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketUI : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        print("MarketUI here");
        this.gameObject.SetActive(false);
	}

    // Update is called once per frame
    private void Update()
    {
      
    }
    public void Toggle()
    {

        
        if (transform.GetChild(0).gameObject.activeSelf) { transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
        }
        else { transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
        }

        this.GetComponentInChildren<Invenotry>().RestartSelectedItems();

    }
}
