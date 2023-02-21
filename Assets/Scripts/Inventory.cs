using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> myInventory = new Dictionary<string, int>();
    [SerializeField] private TMP_Text inventoryDisplay;

    // Start is called before the first frame update
    void Start()
    {
        myInventory.Add("Knife", 1);
        myInventory.Add("White Door Key", 1);
        myInventory.Add("Potion", 3);

        

        inventoryDisplay.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        refreshInventory();
        UseKnife();
    }

    private void UseKnife()
    {
        
            if (Input.GetKeyDown(KeyCode.K))
            {
            if (myInventory.ContainsKey("Knife"))
            {
                myInventory.Remove("Knife");
                Debug.Log("You used your knife.");
            }
            else
            {
                Debug.Log("You don´t have a knife.");
            }
            }
        
    }

    private void refreshInventory()
    {
        inventoryDisplay.text = "";
        foreach (var item in myInventory)
        {
            
            inventoryDisplay.text += "Item: " + item.Key + " Quantity: " + item.Value + "\n";
        }
    }
}
