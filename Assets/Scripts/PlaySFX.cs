using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public AudioSource sfx;
    //public AudioSource sfx2;
    //public AudioSource sfx3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MainCamera"))
        {
            sfx.Play();
        }
        //else if (CompareTag("sfx2"))
        //{
        //    sfx2.Play();
        //}
        //else if (CompareTag("sfx3"))
        //{
        //    sfx3.Play();
        //}

    }
}
