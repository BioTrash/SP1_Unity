using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartOver : MonoBehaviour
{
    public void ReplayGame(){
        SceneManager.LoadScene(PlayerMove.lastScene);
        EnemyMove.HP = 1;
        PlayerMove.isFacingRight = true;
    }
}
