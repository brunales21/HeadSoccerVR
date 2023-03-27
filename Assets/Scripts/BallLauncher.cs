using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private GameObject ball;
    [SerializeField] Transform initPos;
    [SerializeField] GameObject ballPrefab;
    Vector3 shootDirection;
    [SerializeField] Transform canonTransform;
    [SerializeField] Transform targetTransform;
    Vector3 aimOffset;
    public float shootForce;
    public int shootDelay = 4;
    public float fallOffset;
    
    void Start()
    {
        StartCoroutine("shootingRoutine");
    }

    void Update()
    {
        botShooter();
    }

    public void shoot()
    {
        shootForce = (float)(Vector3.Distance(initPos.position, targetTransform.position)*1.15);
        ball.transform.eulerAngles = canonTransform.eulerAngles;

        shootDirection = -ball.transform.up;
        ball.GetComponent<Rigidbody>().AddForce(shootDirection * shootForce, ForceMode.Impulse);
    }
    
    IEnumerator shootingRoutine()
    {
        while(Time.deltaTime < 20f)
        {
            ball = Instantiate(ballPrefab, initPos.position, Quaternion.identity);
            shoot();
            yield return new WaitForSecondsRealtime(shootDelay);
            Destroy(ball);

        }
        
    }

    public void botShooter()
    {
        aimOffset = new Vector3(0, targetTransform.position.y + fallOffset, 0);
        canonTransform.up = canonTransform.position - (targetTransform.position + aimOffset);

    }
}