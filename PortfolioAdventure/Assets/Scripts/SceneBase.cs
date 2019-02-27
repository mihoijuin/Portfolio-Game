using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBase : MonoBehaviour
{

    public enum SCENE {
        NONE = -1,

        探索 = 0,
        PORINのいる場所,

        NUM
    }

    public enum SCENARIO
    {
        NONE = -1,

        Chapter1_1 = 0,
        Chapter1_2,
        Chapter1_3,

        NUM
    }

    [SerializeField]
    GameObject debugCanvas = null;

    private bool isInitialized = false;

    public static SCENARIO currentScinario{ get; set; }

    protected virtual void Awake(){
        if(!isInitialized){
            GameObject debugMenu = Instantiate(debugCanvas) as GameObject;
            DontDestroyOnLoad(debugMenu);
            isInitialized = true;
        }
    }
}
