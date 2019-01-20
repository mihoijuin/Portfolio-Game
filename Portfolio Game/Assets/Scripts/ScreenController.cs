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

    public float scaleSpeed;
    public float scaleInterval;

    // カメラ
    Vector3 cameraOriginPos;
    float cameraOriginSize;


    private void Start()
    {
        ScreenState = SCREEN.EXPLORE;
        cameraOriginPos = Camera.main.transform.position;
        cameraOriginSize = Camera.main.orthographicSize;
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
            float targetPosX = Mathf.SmoothStep(Camera.main.transform.position.x, door.transform.position.x, zoomSpeed);
            float targetPosY = Mathf.SmoothStep(Camera.main.transform.position.y, door.transform.position.y, zoomSpeed);

            Camera.main.transform.position = new Vector3(targetPosX, targetPosY, cameraOriginPos.z);

            // カメラをズームイン
            Camera.main.orthographicSize = Mathf.SmoothStep(Camera.main.orthographicSize, zoomSize, zoomSpeed);

            yield return new WaitForSeconds(zoomInterval);
        }

        // ドアを開く動き
        door.GetComponent<Animator>().SetTrigger("Open");
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.transform.Translate(1.5f, 0, 0);

        // 画面切り替え用のオーバーレイを出現
        yield return new WaitForSeconds(0.5f);
        overlay.SetActive(true);

        // カメラを元に戻す
        Camera.main.transform.position = cameraOriginPos;
        Camera.main.orthographicSize = cameraOriginSize;

        // 画面を切り替え
        exploreScreen.SetActive(false);
        charactorScreen.SetActive(true);

        // オーバレイを消す
        yield return new WaitForSeconds(1f);
        while(overlay.transform.localScale.y > 0f)
        {
            float targetScaleY = Mathf.SmoothStep(overlay.transform.localScale.y, 0f, scaleSpeed);
            overlay.transform.localScale = new Vector3(overlay.transform.localScale.x, targetScaleY, overlay.transform.localScale.z);
            yield return new WaitForSeconds(scaleInterval);
        }


    }



}
