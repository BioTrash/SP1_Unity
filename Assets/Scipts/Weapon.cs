using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public void Fire(){

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        if(PlayerMove.isFacingRight == true){
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
        }
        else{
            bullet.GetComponent<Rigidbody2D>().AddForce((firePoint.right * -1f) * fireForce, ForceMode2D.Impulse);
        }
       
    }
}

