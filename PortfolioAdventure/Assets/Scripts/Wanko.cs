using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanko : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider){
        Debug.Log(collider.name);
        switch(collider.name){
            case "WakeUpPlace":
            if(SceneBase.currentPlace == "目覚めた場所") {
                SceneBase.ShowCurrentPlace("だれかの部屋");
            } else if(SceneBase.currentPlace == "だれかの部屋") {
                SceneBase.ShowCurrentPlace("目覚めた場所");
            }
            break;
        }
    }
}
