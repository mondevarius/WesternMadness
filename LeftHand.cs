using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeftHand : MonoBehaviour
{
    public GameObject bulletLeft,
                      reload,
                      blueShoot,
                      purpleShoot;

    public static GameObject[] blueBandits,
                               purpleBandits;

    public AudioSource sfxShoot;
    
    private Animator animHand;
    
    public Text bulletCanvas;
        
    private int hit;
    
    public static int blueScore,
                      purpleScore,
                      bullets = 5;
    
    public static bool emptyBullets = false,
                       wrongColorActive = false;
 
    private bool shootReady = true;
    
    void Start()
    {
        animHand = GetComponent<Animator>();

    }

    void Update()
    {
        blueBandits = GameObject.FindGameObjectsWithTag("Blue");
        purpleBandits = GameObject.FindGameObjectsWithTag("Purple");
        bulletCanvas.text = bullets.ToString();
        if (bullets <= 0)
        {
            emptyBullets = true;
            ShowReload();
        }

    }

    public void BlueShoot() // Está linkado no botão BlueShoot
    {
        if (shootReady)
        {
            animHand.SetBool("shoot", true);
            sfxShoot.PlayOneShot(sfxShoot.clip);
            bullets -= 1;
            shootReady = false;
            
            if (blueBandits.Length != 0)
            {
                for (int x = 0; x < blueBandits.Length; x++)
                {
                    blueBandits[x].GetComponent<Animator>().SetBool("die", true);
                    hit = +1;
                    blueScore = blueScore + hit;

                }

            }
            else
            {
                wrongColorActive = true;

            }

        }

    }

    public void PurpleShoot() // Está linkado no botão PurpleShoot
    {
        if (shootReady)
        {
            animHand.SetBool("shoot", true);
            sfxShoot.PlayOneShot(sfxShoot.clip);
            bullets -= 1;
            shootReady = false;
            if (purpleBandits.Length != 0)
            {
                for (int x = 0; x < purpleBandits.Length; x++)
                {
                    purpleBandits[x].GetComponent<Animator>().SetBool("die", true);
                    hit = +1;
                    purpleScore = purpleScore + hit;

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

        blueShoot.SetActive(true);
        purpleShoot.SetActive(true);

    }

    public void ShowReload()
    {
        reload.SetActive(true);
        bulletLeft.SetActive(false);
        blueShoot.SetActive(false);
        purpleShoot.SetActive(false);
    }

    public void ShootIsReady()// Está linkado em um evento no final da animação shoot
    {
        shootReady = true;
    }

}
