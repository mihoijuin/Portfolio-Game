using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private static bool isInitialized = false;

    // Playerデータキー
    private static readonly string m_CurrentScene = "Scene";
    private static readonly string m_CurrentScinario = "Scinario";
    // private static readonly string m_OpendPortfolio = "Portfolio";

    private static SCENE _currentScene;
    public static SCENE currentScene {
        get { return _currentScene; }
        private set{
            _currentScene = value;
            PlayerPrefs.SetString(m_CurrentScene, Enum.GetName(typeof(SCENE), value));
        }
    }

    private static SCENARIO _currentScinario;
    public static SCENARIO currentScinario {
        get { return _currentScinario; }
        private set{
            _currentScinario = value;
            PlayerPrefs.SetString(m_CurrentScinario, Enum.GetName(typeof(SCENARIO), value));
        }
    }

    protected virtual void Awake(){
        if(!isInitialized){
            GameObject debugMenu = Instantiate(debugCanvas) as GameObject;
            DontDestroyOnLoad(debugMenu);
            isInitialized = true;

            SceneManager.sceneLoaded += OnSceneLoaded;

            AppUtil.InitTween();
        }
    }

    public static void LoadPlayerData(){
        currentScene =  (SCENE)Enum.Parse(typeof(SCENE), PlayerPrefs.GetString(m_CurrentScene, "スタート"));
        currentScinario = (SCENARIO)Enum.Parse(typeof(SCENARIO), PlayerPrefs.GetString(m_CurrentScinario, "NONE"));
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

}
