using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    public Transform player, questGive;
    public TextMeshProUGUI questText;
    private float fltTime;
    private int intTime;

    void Start(){
        questText.GetComponent<TextMeshProUGUI>().enabled = false;
    }
    void Update()
    {
        StartQuest();
        EndQuest();
    }

    void StartQuest(){
        if(Vector2.Distance(player.position, questGive.position)<3f){
            questText.GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }

    void EndQuest(){
        if(ScoreManager.score >= 3){
            fltTime += 1 * Time.deltaTime;
            intTime = Mathf.RoundToInt(fltTime);
            questText.text = "Quest Completed! Next Level in "+(5 - intTime);

            if(intTime == 5){
                SceneManager.LoadScene("MoonStage");
                PlayerMove.isFacingRight = true;
            }
        }
    }
}
