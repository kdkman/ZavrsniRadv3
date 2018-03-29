using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInstance : MonoBehaviour {

    public GameObject player;

    private GameObject enemy;//TODO MAKE IT Array
    private CameraRoation mainCamera;
    private float onlyAttackOnce;

    
    /// <summary>
    /// Makes movment for player unavablie 
    /// locks camera rotation and 
    /// turn base 
    /// </summary>
    // Use this for initialization

    void Awake () {
        //TODO if in range by someone 
        enemy = GameObject.Find("Enemy");
        player.transform.position = player.transform.position;//locking player in place
        mainCamera = Camera.main.gameObject.GetComponent<CameraRoation>();
        mainCamera.lockCamera = true;
        mainCamera.CamOverTheSholeder();

        //putting enemy in fronot of the player
        Vector3 dir = new Vector3(0, 0, 10);
        Quaternion rotation = Quaternion.Euler(mainCamera.currentY, mainCamera.currentX, 0);
        enemy.transform.position = player.transform.position + rotation * dir;
        enemy.transform.position = new Vector3(enemy.transform.position.x, 1f , enemy.transform.position.z);


    }
	
    

	// Update is called once per frame
	void Update () {//TODO Creat turns make player 
        if (enemy == null)
        { mainCamera.lockCamera = false;
            Destroy(this.gameObject);
        }
        if (Input.GetKey(KeyCode.Alpha1) && (Time.realtimeSinceStartup - onlyAttackOnce > 0.5f)) { 
            onlyAttackOnce = Time.realtimeSinceStartup;

            
            player.GetComponent<Atributes>().DealDamge(enemy.GetComponent<Atributes>());
            
        }
	}
}
