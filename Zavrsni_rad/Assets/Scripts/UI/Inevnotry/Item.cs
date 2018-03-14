using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item  {
    
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item() {
        this.ID = -1;
        this.Slug = "empty";
        this.Sprite = Resources.Load<Sprite>("Sprites/" + Slug);
    }

    public Item(int ID, string title, int value, string slug)
    {
        this.ID = ID;
        this.Title = title;
        this.Value = value;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/" + Slug);
    }


}
