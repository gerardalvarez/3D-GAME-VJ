using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject gameManager;
    public static int vidas;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
