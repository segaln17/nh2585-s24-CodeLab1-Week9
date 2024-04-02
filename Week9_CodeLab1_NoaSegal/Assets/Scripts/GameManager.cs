using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Button = UnityEngine.UI.Button;

public class GameManager : MonoBehaviour
{
    //declare text UI to be assigned in inspector
    public TextMeshProUGUI title; //item title
    public TextMeshProUGUI description; //item description
    public TextMeshProUGUI itemList; //displayed inventory list
    public TextMeshProUGUI partyStatus; //for use in end scene; displays whether you're out of objects

    //next item in the trash can:
    public ItemScriptableObject currentItem;
    
    //trashcanScene buttons:
    public Button rummageButton; //rummage through trash
    public Button partyButton; //go to second scene
    
    //endScene button:
    public Button fireButton; //throw items into the fire
    
    //max number of items that can be held:
    public int maxItems = 3;
    
    //list of items in the trash can:
    public List<ItemScriptableObject> itemsInBin = new List<ItemScriptableObject>();
    
    //empty list of items found:
    public List<ItemScriptableObject> itemsFound = new List<ItemScriptableObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        //partyButton isn't active until you've collected everything from the trash can that you can hold
        partyButton.gameObject.SetActive(false);

        //if you're in the endScene, buttons should be off
        if (SceneManager.sceneCount == 2)
        {
            title.gameObject.SetActive(false);
            description.gameObject.SetActive(false);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void Rummage(ItemScriptableObject nextItem)
    {
        //my last item doesn't show up but I made it a placeholder so all the items I want to show up do show up
        
        if (itemsFound.Count < maxItems) //if there are less things in the list than you can hold
        {
            //set the current item to the item that was next up
            currentItem = currentItem.nextItem;
            //add the top item from trash can list to the found list
            itemsFound.Add(itemsInBin[0]);
            //remove that item from trash can list
            itemsInBin.Remove(itemsInBin[0]);
            //Debug.Log(itemsInBin[0]);
        }
        
        //I got errors unless I checked to make sure a currentItem existed
        if (currentItem)
        {
            //update the displayed inventory to display the item just found
            currentItem.UpdateInventory(this);
        }
        
        //if there is no current item (I got NullReference Exceptions unless I did this)
        else if (currentItem == false)
        {
            Debug.Log("Inventory full!");
            //activate partyButton to take you to next scene
            partyButton.gameObject.SetActive(true);
            //disable rummageButton
            rummageButton.gameObject.SetActive(false);
            //update text to display out of room in inventory
            title.text = "Out of hands!";
            description.text = "Can't carry anything else!";
        }
    }
    
    //this is what the partyButton does:
    public void GoToParty()
    {
        SceneManager.LoadScene("RoadtoParty");
        //goes to second scene
    }
    
    //this is what the fireButton does:
    public void Throw()
    {
        if (itemsFound.Count > 1) //if there are items to throw:
        {
            //update the currentItem to be the one following
            currentItem = currentItem.nextItem;
            //remove it from the itemsFound list
            itemsFound.Remove(itemsFound[0]);
        }
        

        //if there is an item still there:
        if (currentItem)
        {
            //update the inventory list text
            currentItem.RemoveFromInventory(this);
        }
        
        //if there is no currentItem left
        else if (currentItem == false)
        {
            //Debug.Log("Nothing else to throw");
            //set throw button to inactive:
            fireButton.gameObject.SetActive(false);
            //update the text to reflect that there's nothing left to throw
            partyStatus.text = "Nothing left to throw!";
        }
       
    }
}
