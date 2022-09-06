using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public int coinValue = 1;
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            ScoreManager.instance.ChangeScore(coinValue);

            Destroy(gameObject);
        }
    }
}
