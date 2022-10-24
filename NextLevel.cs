using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    UnityADS unityADS;
    
    public string nameNextLevel;
    
    public AudioSource hitStar;
    
    private Animator animStar;
    
    void Start()
    {
        animStar = GetComponent<Animator>();
        unityADS = FindObjectOfType<UnityADS>();
    }

    
    public void ActivateHitStar()
    {
        animStar.SetBool("hit", true);
    }
    void StarSFX()
    {
        hitStar.PlayOneShot(hitStar.clip);
    }
    
    void StarNextLevel()
    {
        unityADS.ShowInterstitial();
        animStar.SetBool("hit", false);
        SceneManager.LoadScene(nameNextLevel);
    }

    
}
