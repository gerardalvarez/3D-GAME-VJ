using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{

    public static int NumberOfCoins = 0;
    private int vidas = 3;
    public GameObject[] keys;

    public UnityEvent<PlayerInventory> oncoinCollected;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 2; i >= 0; i--)
        {
           keys[i].gameObject.SetActive(false);
        }
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

    public void appleCollected() { 
    
        if (vidas<4) ++vidas;
    
    }
    public void perderVida()
    {
        LifeSystem lifesystem = GetComponent<LifeSystem>();
        lifesystem.takeDamage(1);
    }

    public void ganarVida()
    {
        LifeSystem lifesystem = GetComponent<LifeSystem>();
        lifesystem.getLife();
    }
}
