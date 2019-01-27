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

    // キャラクター画面
    public GameObject charactorScreen;
    Vector3 defaultCharaScreenPos;

    // 探索画面
    public GameObject exploreScreen;


    private void Start()
    {
        ScreenState = SCREEN.EXPLORE;

        // キャラクター画面の待機位置
        defaultCharaScreenPos = charactorScreen.transform.position;
        

    }

    public void SwitchExploreScreen()
    {

        // キャラクター画面のときのみ遷移できる
        if(ScreenState == SCREEN.CHARACTOR)
        {
            ScreenState = SCREEN.EXPLORE;
            // TODO 移動キャラが左向きで待機


            // 探索画面へ遷移
            do
            {
                charactorScreen.transform.Translate(defaultCharaScreenPos.x, 0, 0);
                exploreScreen.transform.Translate(defaultCharaScreenPos.x, 0, 0);

            } while (charactorScreen.transform.position.x > 0);

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
            // TODO 移動キャラが右端まで移動

            // キャラクター画面へ遷移
            charactorScreen.transform.Translate(-defaultCharaScreenPos.x, 0, 0);
            exploreScreen.transform.Translate(-defaultCharaScreenPos.x, 0, 0);
        }
        else
        {
            Debug.Log("Same Scene");
        }
    }

}
