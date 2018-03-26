using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class ShopKeeprAnimation : MonoBehaviour {

    private Animator anim;


    private GameObject player;
    private float dist;
    private bool canToggle;
    public GameObject marketUI;


    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))//on click
        {

            if(dist < 5f) {
                player.GetComponent<Player_input>().invUI.SetActive(false);
                marketUI.SetActive(true);
                marketUI.transform.GetChild(0).gameObject.SetActive(false);

                anim.SetInteger("go", 0);// puting hmm aniation
                marketUI.transform.GetChild(1).gameObject.SetActive(true);
                marketUI.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);

            }
        
        }

    }
    

    // Use this for initialization
    void Awake () {

        anim = GetComponent<Animator>();
 
        player = GameObject.Find("Player");


    }
	
	// Update is called once per frame
	void Update () {
        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > 5f)
        {
            marketUI.SetActive(false);
            marketUI.transform.GetChild(1).gameObject.SetActive(false);
            marketUI.transform.GetChild(0).gameObject.SetActive(false);
            marketUI.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        }


        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && anim.GetCurrentAnimatorStateInfo(0).IsName("Hmm")){
            anim.SetInteger("go", 1);
        }
    }
}
