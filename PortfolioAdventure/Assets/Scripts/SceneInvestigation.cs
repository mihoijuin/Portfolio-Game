using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInvestigation : SceneBase
{
    public static string currentPlace = "目覚めた場所";

    protected override void Awake(){
        base.Awake();
        Debug.Log(currentScinario);
    }

    private void Start(){
        SceneBase.ShowCurrentPlace(currentPlace);
    }

}
