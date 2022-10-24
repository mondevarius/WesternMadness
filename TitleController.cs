using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{

    public AudioSource irra;

    public GameObject shot1,
                      shot2,
                      shot3,
                      ticoRodrigues,
                      startButton;

    
    
    public void LoadLevel()
    {
        SceneManager.LoadScene("Language");
    }

    
    void Shot1()
    {
        shot1.SetActive(true);
        irra.PlayOneShot(irra.clip);

    }

    void Shot2()
    {
        shot2.SetActive(true);

    }

    void Shot3()
    {
        shot3.SetActive(true);
    }

    public void ShotsEffects()
    {
        Shot1();
        Invoke("Shot2", 0.3f);
        Invoke("Shot3", 0.5f);
        Invoke("ShowButtons", 3f);
    }

    void ShowButtons()
    {
        startButton.SetActive(true);
        ticoRodrigues.SetActive(true);
    }
}
