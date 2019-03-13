using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneBase : MonoBehaviour
{

    public enum SCENE {
        NONE,

        スタート,
        探索,
        PORINのいる場所,

        NUM
    }

    public enum SCENARIO
    {
        NONE,

        Chapter1_1,
        Chapter1_2,
        Chapter1_3,
        Chapter1_4,
        Chapter1_5,

        NUM
    }

    [SerializeField]
    GameObject debugCanvas = null;

    private static RectTransform placeRect;
    private static Vector2 placeOriginPos;

    private static bool isInitialized = false;

    public static string currentPlace;

    // プレイヤーステータス
    public static SCENE currentScene {
        get { return (SCENE)Enum.Parse(typeof(SCENE), PlayerPrefs.GetString("Scene", "NONE")); }
        private set { PlayerPrefs.SetString("Scene", Enum.GetName(typeof(SCENE), value)); }
    }

    public static SCENARIO currentScinario {
        get { return (SCENARIO)Enum.Parse(typeof(SCENARIO), PlayerPrefs.GetString("Scinario", "NONE")); }
        private set { PlayerPrefs.SetString("Scinario", Enum.GetName(typeof(SCENARIO), value)); }
    }

    protected virtual void Awake(){
        if(!isInitialized){
            GameObject debugMenu = Instantiate(debugCanvas) as GameObject;
            DontDestroyOnLoad(debugMenu);
            SceneManager.sceneLoaded += OnSceneLoaded;
            AppUtil.InitTween();

            isInitialized = true;
        }

        if(SceneManager.GetActiveScene().name != "スタート"){
            placeRect = GameObject.Find("CurrentPlace").GetComponent<RectTransform>();
            placeOriginPos = placeRect.anchoredPosition;
        }
    }


    public static void LoadScenario(SCENE scene, SCENARIO scenario){
        ChangeScenario(scenario);
        SceneManager.LoadScene(Enum.GetName(typeof(SCENE), scene));
    }

    public static void ChangeScenario(SCENARIO scenario){
        currentScinario = scenario;
    }

    private void OnSceneLoaded( Scene scene, LoadSceneMode mode )
    {
        if(SceneManager.GetActiveScene().name != "スタート"){   // スタート時にプレイヤーデータを更新するのを防止
            currentScene = (SCENE)Enum.Parse(typeof(SCENE), scene.name);
        }
    }

    public static void ShowCurrentPlace(string placeName){
        placeRect.GetChild(0).GetComponent<Text>().text = placeName;
        placeRect.anchoredPosition = placeOriginPos;
        AppUtil.DOSequence(
            new DG.Tweening.Tween[] {
                AppUtil.MoveRect(placeRect, "上", true, 1f, "InOutQuart"),
                AppUtil.MoveRect(placeRect, "上", false, 0.8f, "InOutQuart", 2f)
            },
            0f,
            0f
        );
        currentPlace = placeName;
        // 演出別パターン
        // AppUtil.DOSequence(
        //     new DG.Tweening.Tween[] {
        //         AppUtil.ShowRect(placeRect, "x", 0f, 0.25f, "InOutQuart", 1f),
        //         AppUtil.HideRect(placeRect, "x", 0.25f, "InOutQuart", 2f)
        //     },
        //     0f,
        //     0f
        // );
    }

}
