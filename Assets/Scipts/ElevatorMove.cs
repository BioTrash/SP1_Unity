using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{

    public Transform player, elevatorSwitch, downPos, upperPos;
    public float speed;
    private bool isElevatorDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartElevator();   
    }

    void StartElevator(){
        if(Vector2.Distance(player.position, elevatorSwitch.position)<3f /*&& Input.GetKeyDown("e")*/){
            if(transform.position.y <= downPos.position.y){
                isElevatorDown = true;
            }
            else if(transform.position.y >= upperPos.position.y){
                isElevatorDown = false;
            }
        }

        if(isElevatorDown){
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);   
        }
    }
}
