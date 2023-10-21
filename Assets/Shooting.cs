using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Shoot Logic")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    
    private bool shootStatus = true;

    

    private float timeBtwShots = 0.1f;
    
    IEnumerator ShootTime(float timeBtwShots)
    {
        shootStatus = false;
        yield return new WaitForSeconds(timeBtwShots);
        shootStatus = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();    
        }
        
    }

    private void Shoot()
    {
        if (shootStatus)
        {
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);

            StartCoroutine(ShootTime(timeBtwShots));
        }
    }
    
}
