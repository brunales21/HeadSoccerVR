using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private float xPos;
    private float yPos;
    private float zPos = 3.34f;

    public float minX = -3.5f;
    public float maxX = 2.84f;
    public float minY = 0.6f;
    public float maxY = 2.7f;

    int randomSound;

    public ParticleSystem goalEffect;
    [SerializeField] Transform burstPoint;
    [SerializeField] AudioSource targetSound;
    [SerializeField] AudioSource targetSound2;


    void Start()
    {
        setPosition();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(goalEffect, burstPoint.position, Quaternion.identity); //Efecto confeti
            randomSound = Random.Range(0, 2);
            Debug.Log(randomSound);

            switch (randomSound)
            {
                case 0: targetSound.Play();
                break;
                case 1: targetSound2.Play();
                break;
            }
            setPosition();
        }
    }

    public void setPosition()
    {
        xPos = Random.Range(minX, maxX);
        yPos = Random.Range(minY, maxY);

        transform.position = new Vector3(xPos, yPos, zPos);
    }
}
