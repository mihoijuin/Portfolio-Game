using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : SceneBase
{
    protected override void Awake(){
        base.Awake();
        if(SceneBase.currentScinario == SCENARIO.NONE){
            GameObject.Find("ContinueButton").SetActive(false);
        }
    }
}
