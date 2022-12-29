using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel ()
    {
        animator.SetTrigger("Fadeout");
    }

    public void OnFadeComplete()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameScene");
    }

   
}
