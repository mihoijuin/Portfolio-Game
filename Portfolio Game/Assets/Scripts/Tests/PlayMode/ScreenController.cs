using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour {

    public enum SCREEN
    {
        NONE = -1,
        EXPLORE = 0,
        CHARACTOR,
        NUM
    }

    public SCREEN ScreenState { get; set; } = SCREEN.NONE;


    private void Start()
    {
        ScreenState = SCREEN.EXPLORE;
    }

    public void SwitchExploreScreen()
    {

        // キャラクター画面のときのみ遷移できる
        if(ScreenState == SCREEN.CHARACTOR)
        {
            ScreenState = SCREEN.EXPLORE;
            Debug.Log("探索へ");
        }
        else
        {
            Debug.Log("Same Scene");
        }
    }

    public void SwitchCharactorScreen()
    {
        // 探索画面のときのみ遷移できる
        if(ScreenState == SCREEN.EXPLORE)
        {
            ScreenState = SCREEN.CHARACTOR;
            Debug.Log("キャラクターへ");
        }
        else
        {
            Debug.Log("Same Scene");
        }
    }

}
