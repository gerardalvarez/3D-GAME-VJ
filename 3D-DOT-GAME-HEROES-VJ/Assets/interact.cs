using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interact : MonoBehaviour
{
    // Start is called before the first frame update
    bool abrir=false;
    public GameObject aviso;
    void Start()
    {
        aviso.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (abrir && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Dungeon");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el trigger es la puerta, muestra el mensaje
        if (other.tag == "Player")
        {
            abrir = true;
            aviso.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el trigger es la puerta, muestra el mensaje
        if (other.tag == "Player")
        {
            abrir = false;
            aviso.SetActive(false);
        }
    }

}
