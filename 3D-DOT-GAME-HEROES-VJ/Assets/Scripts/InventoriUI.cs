using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoriUI : MonoBehaviour
{


    private TextMeshProUGUI coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoinText(PlayerInventory playerInventory)
    {
        coinText.text = PlayerInventory.NumberOfCoins.ToString();
    }
}
