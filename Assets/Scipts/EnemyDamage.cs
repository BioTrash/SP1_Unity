using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public static double HP = 1;

    private void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.tag == "Weapon"){
            HP -= 0.33;
            Debug.Log(HP);

            if(HP <= 0.01){
             Destroy(gameObject);
            }
        }
    }
}
