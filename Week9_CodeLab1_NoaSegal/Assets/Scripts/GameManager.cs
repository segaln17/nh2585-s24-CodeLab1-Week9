using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    //next item in the trash can:
    public ItemScriptableObject currentItem;
    
    public Button rummageButton;
    public Button partyButton;
    
    //max number of items that can be held:
    public int maxItems = 3;
    
    //list of items in the trash can:
    public List<ItemScriptableObject> itemsInBin = new List<ItemScriptableObject>();
    
    //empty list of items found:
    public List<ItemScriptableObject> itemsFound = new List<ItemScriptableObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        partyButton.gameObject.SetActive(false);

        
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
        //TODO: fix whatever nonsense is going on here --> NullReferenceException
        //if (itemsFound.Count < maxItems) //ISSUE IS HERE???
        
        if (itemsFound.Count < maxItems)
        {
            currentItem = currentItem.nextItem;
            itemsFound.Add(itemsInBin[0]);
            itemsInBin.Remove(itemsInBin[0]);
            //Debug.Log(itemsInBin[0]);
        }
        else
        {
            Debug.Log("Inventory full!");
            partyButton.gameObject.SetActive(true);
            rummageButton.gameObject.SetActive(false);
        }
        
        if (currentItem)
        {
            currentItem.UpdateInventory(this);
        }
        
    }
    
    public void GoToParty()
    {
        SceneManager.LoadScene("RoadtoParty");
    }
}
