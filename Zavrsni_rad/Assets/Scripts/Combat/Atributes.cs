using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributes :MonoBehaviour{


    public int healt;
    public string avatarName;
    public int DamageOutput;

    public void Death()
    {
        print("Healt is " + healt + " and " + avatarName + " is dead");
        Destroy(this.gameObject);
    }

    public void DealDamge(Atributes character)
    {
        print(this.gameObject.GetComponent<Atributes>().avatarName + " is doing  damage");
        character.healt -= this.gameObject.GetComponent<Atributes>().DamageOutput;
        if (character.healt < 1)
        {
            character.Death();

        }
    }



}
