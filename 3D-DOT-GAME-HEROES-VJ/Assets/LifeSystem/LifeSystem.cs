using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour
{

    public GameObject[] apples;
    public static int life=2;
    private bool dead;
    public bool invulnerable=false;
    public GameObject cartel;
    // Start is called before the first frame update
    void Start()
    {   for(int i=4;i>life;i--)
        {
            apples[i].gameObject.SetActive(false);
        }
     invulnerable = false;
}

    // Update is called once per frame
    void Update()
    {
        
        if (dead)
        {
            Debug.Log("gameover");
            SceneManager.LoadScene("GameOver");
            life = 2;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            invulnerable= !invulnerable;
            cartel.SetActive(invulnerable);
        }
    }

    public void takeDamage(int damage)
    {
        if (life >= 0)
        {
            
            for (int i = 0; i < damage; i++) apples[life].gameObject.SetActive(false);
            life -= damage;
            
            if (life < 0)
            {
                dead = true;
            }
        }
    }

    public void getLife()
    {
        if (life < 4)
        {
            
            ++life;
            apples[life].gameObject.SetActive(true);
        }
    }

}
