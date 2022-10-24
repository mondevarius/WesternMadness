using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightHand : MonoBehaviour
{
    public GameObject bulletRight,
                      reload,
                      orangeShoot,
                      redShoot;

    public static GameObject[] orangeBandits,
                               redBandits;
    
    public AudioSource sfxShoot;
    
    private Animator animHand;

    public Text bulletCanvas;
       
    private int hit;

    public static int orangeScore,
                      redScore;

    public static int bullets = 5;
    
    public static bool emptyBullets = false,
                       wrongColorActive = false;
    
    private bool shootReady = true;
    

    void Start()
    {
        animHand = GetComponent<Animator>();
    }

    void Update()
    {
        bulletCanvas.text = bullets.ToString();
        orangeBandits = GameObject.FindGameObjectsWithTag("Orange");
        redBandits = GameObject.FindGameObjectsWithTag("Red");


        if (bullets <= 0)
        {
            emptyBullets = true;
            ShowReload();
        }
     
    }

    public void OrangeShoot() // Está linkado no botão OrangeShoot
    {
        if (shootReady)
        {
            animHand.SetBool("shoot", true);
            sfxShoot.PlayOneShot(sfxShoot.clip);
            bullets -= 1;
            shootReady = false;
            
            if (orangeBandits.Length != 0)
            {
                for (int x = 0; x < orangeBandits.Length; x++)
                {
                    orangeBandits[x].GetComponent<Animator>().SetBool("die", true);
                    hit = +1;
                    orangeScore = orangeScore + hit;

                }

            }
            else
            {
                wrongColorActive = true;
            }
        }

    }

    public void RedShoot() // Está linkado no botão RedShoot
    {
        if (shootReady)
        {
            animHand.SetBool("shoot", true);
            sfxShoot.PlayOneShot(sfxShoot.clip);
            bullets -= 1;
            shootReady = false;
            
            if (redBandits.Length != 0)
            {
                for (int x = 0; x < redBandits.Length; x++)
                {
                    redBandits[x].GetComponent<Animator>().SetBool("die", true);
                    hit = +1;
                    redScore = redScore + hit;

                }

            }
            else
            {
                wrongColorActive = true;

            }

        }

    }

    public void DesactiveShoot() // Está linkado em um evento no final da animação shoot
    {
        animHand.SetBool("shoot", false);
        if (bullets >= 1)
        {
            ActiveShoot();

        }
    }

    public void ActiveShoot()
    {
        
        orangeShoot.SetActive(true);
        redShoot.SetActive(true);
         
    }

    public void ShowReload()
    {
        reload.SetActive(true);
        bulletRight.SetActive(false);
        orangeShoot.SetActive(false);
        redShoot.SetActive(false);
    }

    public void ShootIsReady()// Está linkado em um evento no final da animação shoot
    {
        shootReady = true;
    }

    
}
