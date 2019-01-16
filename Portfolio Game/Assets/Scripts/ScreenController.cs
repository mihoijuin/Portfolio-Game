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
    Vector3 defaultExploreScreenPos;

    // 画面遷移
    public Ease ease;
    public float screenTransitionSpeed;
    public float countSpeed;

    bool isMoving;

    // プレイヤー
    public PlayerController playerController;


    private void Start()
    {
        ScreenState = SCREEN.EXPLORE;

        // キャラクター画面の初期位置
        defaultCharaScreenPos = charactorScreen.transform.position;

        // 探索画面の初期位置
        defaultExploreScreenPos = exploreScreen.transform.position;
        

    }

    public void SwitchExploreScreen()
    {

        // キャラクター画面かつ画面遷移していないときのときのみ遷移できる
        if (ScreenState == SCREEN.CHARACTOR && !isMoving)
        {
            ScreenState = SCREEN.EXPLORE;
            // 探索画面へ遷移
            StartCoroutine(MoveToExplore());
                       
        }
       else
        {
            Debug.Log("Same Scene");
        }
    }

    IEnumerator MoveToExplore()
    {
         
        float t = 0f;
        isMoving = true;

        while (defaultCharaScreenPos.x - charactorScreen.transform.position.x > Mathf.Epsilon)
        {
            // 移動          
            charactorScreen.transform.Translate(ease.EaseOutCubic(t) * screenTransitionSpeed, 0, 0);
            exploreScreen.transform.Translate(ease.EaseOutCubic(t) * screenTransitionSpeed, 0, 0);

            // カウントを足す
            t += countSpeed;

            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false;
    }

    public void SwitchCharactorScreen()
    {
        // 探索画面かつ画面遷移していないときのみ遷移できる
        if(ScreenState == SCREEN.EXPLORE && !isMoving)
        {
            ScreenState = SCREEN.CHARACTOR;

            // 移動キャラが右端まで移動
            playerController.MoveBasePos();


            // キャラクター画面へ遷移
            StartCoroutine(MoveToCharactor());
        }
        else
        {
            Debug.Log("Same Scene");
        }
    }


    IEnumerator MoveToCharactor()
    {
        
        float t = 0f;
        isMoving = true;

        while (charactorScreen.transform.position.x - defaultExploreScreenPos.x > Mathf.Epsilon)
        {
            // 移動          
            charactorScreen.transform.Translate(-ease.EaseOutCubic(t) * screenTransitionSpeed, 0, 0);
            exploreScreen.transform.Translate(-ease.EaseOutCubic(t) * screenTransitionSpeed, 0, 0);

            // カウントを足す
            t += countSpeed;

            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false;

    }

}
