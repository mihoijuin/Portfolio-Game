using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneStart : SceneBase
{
    protected override void Awake(){
        base.Awake();

        // ゲームデータがないときは「つづきから」を表示しない
        if(SceneBase.currentScinario == SCENARIO.NONE){
            GameObject.Find("ContinueButton").SetActive(false);
        }

        // ボタンにイベントを設定
        transform.Find("Canvas/ResetButton").GetComponent<Button>().onClick.AddListener(ShowConfirmDialog);
        transform.Find("Canvas/ConfirmDialog/YesButton").GetComponent<Button>().onClick.AddListener(StartGame);
    }

    private void ShowConfirmDialog(){
        // ゲームデータがないときはダイアログを表示せずにゲームをスタート
        if(SceneBase.currentScinario == SCENARIO.NONE){
            StartGame();
        } else
        {
            transform.Find("Canvas/ConfirmDialog").gameObject.SetActive(true);
        }
    }

    private void StartGame(){
        SceneBase.LoadScenario(SCENE.探索, SCENARIO.Chapter1_1);
    }
}
