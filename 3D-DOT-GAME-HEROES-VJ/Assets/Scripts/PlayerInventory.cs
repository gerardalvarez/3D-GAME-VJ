using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{

    public int NumberOfCoins { get; private set; }

    public UnityEvent<PlayerInventory> oncoinCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void coinCollected()
    {
        NumberOfCoins++;
        oncoinCollected.Invoke(this);
    }
}
