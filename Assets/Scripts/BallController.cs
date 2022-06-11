using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] AudioSource remateSound;
    [SerializeField] AudioSource postSound;

    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Head")) 
        {
            remateSound.Play();
        }

        if (collision.gameObject.CompareTag("Post")) 
        {
            postSound.Play();
        }

    }

}
