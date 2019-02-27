using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBase : MonoBehaviour
{

    public enum SCENE {
        NONE = -1,

        スタート = 0,
        探索,
        PORINのいる場所,

        NUM
    }

    public enum SCENARIO
    {
        NONE = -1,

        Chapter1_1 = 0,
        Chapter1_2,
        Chapter1_3,
        Chapter1_4,
        Chapter1_5,

        NUM
    }

    [SerializeField]
    GameObject debugCanvas = null;

    private static bool isInitialized = false;

    public static SCENE currentScene {get; private set;}
    public static SCENARIO currentScinario{ get; private set; }

    protected virtual void Awake(){
        if(!isInitialized){
            GameObject debugMenu = Instantiate(debugCanvas) as GameObject;
            DontDestroyOnLoad(debugMenu);
            isInitialized = true;

            SceneManager.sceneLoaded += OnSceneLoaded;
            ChangeScenario(SCENARIO.NONE);   // TODOプレイヤーデータを読み込んでNONEじゃないときはそれにする
        }
    }

    public static void LoadScenario(string scene, string scenario){
        ChangeScenario((SCENARIO)Enum.Parse(typeof(SCENARIO), scenario));
        SceneManager.LoadScene(scene);
    }

    public static void ChangeScenario(SCENARIO scenario){
        currentScinario = scenario;
    }

    private void OnSceneLoaded( Scene scene, LoadSceneMode mode )
    {
        currentScene = (SCENE)Enum.Parse(typeof(SCENE), scene.name);
    }

}
