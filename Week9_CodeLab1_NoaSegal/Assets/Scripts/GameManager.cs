using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Button = UnityEngine.UI.Button;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI itemList;
    public TextMeshProUGUI partyStatus;

    //next item in the trash can:
    public ItemScriptableObject currentItem;
    
    public Button rummageButton;
    public Button partyButton;
    public Button fireButton;
    
    //max number of items that can be held:
    public int maxItems = 3;
    
    //list of items in the trash can:
    public List<ItemScriptableObject> itemsInBin = new List<ItemScriptableObject>();
    
    //empty list of items found:
    public List<ItemScriptableObject> itemsFound = new List<ItemScriptableObject>();
    
    //only used in last scene:
    //public List<ItemScriptableObject> itemsHeld = new List<ItemScriptableObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
        partyButton.gameObject.SetActive(false);

        if (SceneManager.sceneCount == 2)
        {
            title.gameObject.SetActive(false);
            description.gameObject.SetActive(false);
        }
        
        /*
        foreach (ItemScriptableObject item in itemsFound)
        {
           // Debug.Log((item));
        }
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void Rummage(ItemScriptableObject nextItem)
    {
        //TODO: fix whatever is making my last item not show up
        //if (itemsFound.Count < maxItems) //ISSUE IS HERE???
        
        if (itemsFound.Count < maxItems)
        {
            currentItem = currentItem.nextItem;
            itemsFound.Add(itemsInBin[0]);
            itemsInBin.Remove(itemsInBin[0]);
            //Debug.Log(itemsInBin[0]);
        }
        
        if (currentItem)
        {
            currentItem.UpdateInventory(this);
        }
        
        else if (currentItem == false)
        {
            Debug.Log("Inventory full!");
            partyButton.gameObject.SetActive(true);
            rummageButton.gameObject.SetActive(false);
            title.text = "Out of hands!";
            description.text = "Can't carry anything else!";
        }
    }
    
    public void GoToParty()
    {
        SceneManager.LoadScene("RoadtoParty");
    }
    
    public void Throw()
    {
        if (itemsFound.Count > 1)
        {
            currentItem = currentItem.nextItem;
            itemsFound.Remove(itemsFound[0]);
        }
        

        if (currentItem)
        {
            currentItem.RemoveFromInventory(this);
        }
        
        else if (currentItem == false)
        {
            Debug.Log("Nothing else to throw");
            fireButton.gameObject.SetActive(false);
            partyStatus.text = "Nothing left to throw!";
        }
       
    }
}
