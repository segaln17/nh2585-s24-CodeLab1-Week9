using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//change menu to include new ScriptableObject asset:
[CreateAssetMenu
    (fileName = "New Item", //what the item will be called
        menuName = "New ScriptableObject Item", //what it will say in the menu
        order = 0), //where in the menu it will be
]

public class ItemScriptableObject : ScriptableObject
{
    public string itemName; //what the item is
    public string itemDesc; //description of item
    public ItemScriptableObject nextItem; //the item that will come after this one
    public Sprite icon; //what the item looks like
    
    public void UpdateInventory(GameManager gm)
    {
        //for rummage scene only:
        if (gm.itemsFound.Count < gm.maxItems) //if there's still space in the list
        {
            //update text to reflect item picked up:
            gm.title.text = itemName;
            gm.description.text = itemDesc;
            gm.itemList.text += "\n" + gm.currentItem.itemName; 
            //Debug.Log(gm.itemsFound.Count);
            //Debug.Log(gm.maxItems);
        }
        if (gm.itemsFound.Count == gm.maxItems && SceneManager.sceneCount != 2) 
            //ideally what this would do is when you max out on items, it tells you so
        {
            gm.title.text = "YOU'RE OUT OF HANDS!";
            gm.title.text = "YA GOT NO MORE HANDS!";
            //Debug.Log(gm.itemsFound.Count);
            //Debug.Log(gm.maxItems);
        }
        /*
        else
        { //this for some reason doesn't get triggered here so I put it in gamemanager
            gm.partyButton.gameObject.SetActive(true);
            gm.rummageButton.gameObject.SetActive(false);
            
        } 
        */
        
    }

    //for end scene only:
    public void RemoveFromInventory(GameManager gm)
    {
        //Debug.Log(gm.itemsFound);
        gm.itemList.text += "\n" + gm.currentItem.itemName;
        //just updates the list of items burned
    
    }
}


