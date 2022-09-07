using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{

    public Transform player, elevatorSwitch, downPos, upperPos, sidePos;
    public float speed;
    private bool isElevatorDown = true;
    private bool isElevatorSideDown = false;

    // Update is called once per frame
    void Update()
    {
        StartElevator();   
    }

    void StartElevator(){
        if(Vector2.Distance(player.position, elevatorSwitch.position)<3f /*&& Input.GetKeyDown("e")*/){
            if(transform.position.y <= downPos.position.y){
                isElevatorDown = true;
                isElevatorSideDown = true;
            }
            else if(transform.position.y >= upperPos.position.y){
                isElevatorDown = false;
                isElevatorSideDown = false;
            }
            else if(Math.Round(transform.position.y) == Math.Round(sidePos.position.y) && Math.Round(transform.position.x) == Math.Round(sidePos.position.x)){
                isElevatorSideDown = true;
            }
        }

        if(isElevatorDown == true && isElevatorSideDown == true){
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
        if(isElevatorDown == false && isElevatorSideDown == false){
            transform.position = Vector2.MoveTowards(transform.position, sidePos.position, speed * Time.deltaTime);
        }
        if(isElevatorSideDown == true && isElevatorDown == false){
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
        }
     }
}
