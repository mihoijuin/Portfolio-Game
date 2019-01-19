using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    // 探索画面
    public GameObject exploreScreen;

    public GameObject overlay;

    // プレイヤー
    public GameObject door;
    public GameObject player;

    public float zoomInterval;
    public float zoomSpeed;
    public float zoomSize;


    private void Start()
    {
        ScreenState = SCREEN.EXPLORE;
    }

    public bool IsExplore(){ return ScreenState == SCREEN.EXPLORE; }
    public bool IsCharactor() { return ScreenState == SCREEN.CHARACTOR; }

    public void SwitchExplore()
    {

        // キャラクター画面かつ画面遷移していないときのときのみ遷移できる
        if (IsCharactor())
        {
            ScreenState = SCREEN.EXPLORE;
            // 探索画面へ遷移
                       
        }
       else
        {
            Debug.Log("Same Scene");
        }
    }



    public void SwitchCharactor()
    {
        // 探索画面かつ画面遷移していないときのみ遷移できる
        if(IsExplore())
        {

            ScreenState = SCREEN.CHARACTOR;

            // 画面遷移前の動き
            StartCoroutine(ExecuteEffectesBeforeCharacterScreenTransition());


        }
        else
        {
            Debug.Log("Same Scene");
        }
    }


    private IEnumerator ExecuteEffectesBeforeCharacterScreenTransition()
    {

        while (Camera.main.orthographicSize > zoomSize + 0.01f)
        {
            // カメラをドアの位置に移動
            float targetPosx = Mathf.SmoothStep(Camera.main.transform.position.x, door.transform.position.x, zoomSpeed);
            float targetPosy = Mathf.SmoothStep(Camera.main.transform.position.y, door.transform.position.y, zoomSpeed);

            Camera.main.transform.position = new Vector3(targetPosx, targetPosy, -10f);

            // カメラをズームイン
            Camera.main.orthographicSize = Mathf.SmoothStep(Camera.main.orthographicSize, zoomSize, zoomSpeed);

            yield return new WaitForSeconds(zoomInterval);
        }

        // ドアを開く動き
        door.GetComponent<Animator>().SetTrigger("Open");
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.transform.Translate(1.5f, 0, 0);

        yield return new WaitForSeconds(0.8f);
        overlay.SetActive(true);

    }



}
