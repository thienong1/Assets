using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    //this create a itemtype enum (drop down)
enum Itemtype { coin, health, ammo, inventoryitem }
    [SerializeField] private Itemtype itemtype;

    [SerializeField] private string inventorystringname;
    [SerializeField] private Sprite inventorysprite;
    void Start()
    {


    }


    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player is touching me, print "Collect" in the console
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            if (itemtype == Itemtype.coin)
            {
                NewPlayer.Instance.coinscollected += 1;
            }
            else if (itemtype == Itemtype.health)
            {
                if (NewPlayer.Instance.health < 100)
                {
                    NewPlayer.Instance.health += 10;

                }   
            }
            else if (itemtype == Itemtype.ammo)
            {
            }
            else if (itemtype == Itemtype.inventoryitem)
            {
                NewPlayer.Instance.addinventoryitem(inventorystringname, inventorysprite);
            }
            else
            {
            }



            NewPlayer.Instance.updateUI();
            Destroy(gameObject);
        }
    }
}