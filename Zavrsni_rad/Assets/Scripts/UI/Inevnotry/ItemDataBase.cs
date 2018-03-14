using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class ItemDataBase : MonoBehaviour {//need to change exe order this first then inventry

    private List<Item> allItems = new List<Item>();
    private JsonData json; 

	void Awake () {
        json = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/items.json"));
        ConstructDatabes();  
    }

    private void ConstructDatabes()
    {
        for(int i = 0; i < json.Count; i++)//creating database by json
        {
            allItems.Add(new Item((int)json[i]["id"], json[i]["title"].ToString(), (int)json[i]["value"], json[i]["slug"].ToString()));
        }
    }

    public Item FetchItemByID(int id)//looking for item in dabebase by id
    {
        for(int i = 0; i < allItems.Count; i++)
        {
            if (allItems[i].ID == id)
            {
                return allItems[i];
            }
        }

        print("Error no Item by " + id + " found ");
        return null;
    }
	
}
