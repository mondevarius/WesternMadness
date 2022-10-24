using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadRight : MonoBehaviour
{
    public GameObject rightHand,
                      canvasRight,
                      orangeShoot,
                      redShoot;

    public AudioSource sfxReload;
    
    public static bool isReload = false;
    
    private bool sfxPlay = true;
        
    void Update()
    {
        if (isReload && RightHand.emptyBullets)
        {
            Reload();
            Invoke("ReloadOff", 2f);
        }
        
    }

    public void Reload() // Linkado no Botão ReloadRight
    {
        isReload = true;
        rightHand.transform.position = Vector3.Lerp(rightHand.transform.position, new Vector3(rightHand.transform.position.x, -7, rightHand.transform.position.z), Time.deltaTime * 10);
        if (sfxPlay)
        {
            sfxReload.PlayOneShot(sfxReload.clip);
        }
        sfxPlay = false;
        RightHand.bullets = 5;
        Invoke("ActiveShoot", 2f);
    }

    public void ReloadOff()
    {
        isReload = false;
        rightHand.transform.position = Vector3.Lerp(rightHand.transform.position, new Vector3(rightHand.transform.position.x, -4, rightHand.transform.position.z), Time.deltaTime * 10);
        RightHand.emptyBullets = false;
        gameObject.SetActive(false);
        canvasRight.SetActive(true);
        sfxPlay = true;
    }
    void ActiveShoot()
    {

        orangeShoot.SetActive(true);
        redShoot.SetActive(true);
        
    }

    
}
