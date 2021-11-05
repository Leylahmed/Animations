using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    [SerializeField] private ItemDataSO itemData;
    [SerializeField] private Button buyOrSelectedButton;

   void Start()
    {
        if (itemData.isBought)
        {
            buyOrSelectedButton.onClick.AddListener(onBySelectPressed);

           
        }
        else
        {
            buyOrSelectedButton.onClick.AddListener(onByButtonPressed);
        }
    }

    void Update()
    {
        
    }

    private void onByButtonPressed()
    {

    }

    private void onBySelectPressed()
    {

    }
}
