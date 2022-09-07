using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest : MonoBehaviour
{
    public Transform player, questGive;
    public TextMeshProUGUI questText;

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
        if(ScoreManager.score == 3){
            questText.text = "Quest Completed!";
        }
    }
}
