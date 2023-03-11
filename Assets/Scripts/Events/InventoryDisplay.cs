using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private Canvas inventoryPanel;


    void OnEnable()
    {
        PlayerController.OnInventoryActive += DisplayInventory;
    }

    private void OnDisable()
    {
        PlayerController.OnInventoryActive -= DisplayInventory;
    }

    void DisplayInventory()
    {
        if (inventoryPanel.isActiveAndEnabled)
        {
            inventoryPanel.gameObject.SetActive(false);
        }
        else
        {
            inventoryPanel.gameObject.SetActive(true);
        }
    }
}
