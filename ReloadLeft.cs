using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadLeft : MonoBehaviour
{
    public GameObject leftHand,
                      canvasRight,
                      blueShoot,
                      purpleShoot;

    public AudioSource sfxReload;

    public static bool isReload = false;
    
    private bool sfxPlay = true;

    
    void Update()
    {
        if (isReload && LeftHand.emptyBullets)
        {
            Reload();
            Invoke("ReloadOff", 2f);
        }

    }

    public void Reload() // Linkado no Botão ReloadRight
    {
        isReload = true;
        leftHand.transform.position = Vector3.Lerp(leftHand.transform.position, new Vector3(leftHand.transform.position.x, -7, leftHand.transform.position.z), Time.deltaTime * 10);
        if (sfxPlay)
        {
            sfxReload.PlayOneShot(sfxReload.clip);
        }
        sfxPlay = false;
        LeftHand.bullets = 5;
        Invoke("ActiveShoot", 2f);
    }

    public void ReloadOff()
    {
        isReload = false;
        leftHand.transform.position = Vector3.Lerp(leftHand.transform.position, new Vector3(leftHand.transform.position.x, -4, leftHand.transform.position.z), Time.deltaTime * 10);
        LeftHand.emptyBullets = false;
        gameObject.SetActive(false);
        canvasRight.SetActive(true);
        sfxPlay = true;
    }
    void ActiveShoot()
    {

        blueShoot.SetActive(true);
        purpleShoot.SetActive(true);

    }

}
