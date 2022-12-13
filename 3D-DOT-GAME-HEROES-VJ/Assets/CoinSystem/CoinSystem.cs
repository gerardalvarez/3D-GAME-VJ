using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{

    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory inventory = GetComponent<PlayerInventory>();
        if (other.tag == "Coin")
        {
            if (inventory != null)
            {
                inventory.coinCollected();
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "Apple")
        {
            if (inventory != null)
            {
                inventory.ganarVida();
            }
            Destroy(other.gameObject);
        }
    }
}
