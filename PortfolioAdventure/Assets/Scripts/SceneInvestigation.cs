﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInvestigation : SceneBase
{
    protected override void Awake(){
        base.Awake();
        Debug.Log(SceneBase.currentScinario);
    }

    private void Start(){
        SceneBase.ShowCurrentPlace("目覚めた場所");
    }

}
