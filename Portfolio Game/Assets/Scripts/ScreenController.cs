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

    // 画面
    public GameObject charactorScreen;
    public GameObject exploreScreen;

    public GameObject overlay;
    public GameObject door;
    public GameObject player;

    // カメラズーム用
    public float zoomInterval;
    public float zoomSpeed;
    public float zoomSize;
    public float scaleSpeed;
    public float scaleInterval;

    // カメラ初期値
    Vector3 cameraOriginPos;
    float cameraOriginSize;

    WaitingDogController waitingDogController;


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

        // キャラクター画面のときのみ遷移できる
        if (IsCharactor())
        {
            ScreenState = SCREEN.EXPLORE;

            StartCoroutine(ExecuteEffectesForTransitionToExplore());


        }
        else
        {
            Debug.Log("Same Scene");
        }
    }

    private IEnumerator ExecuteEffectesForTransitionToExplore()
    {

        // わんこがジャンプ
        waitingDogController = FindObjectOfType<WaitingDogController>();    // 初期は非アクティブなのでここで取得
        StartCoroutine(waitingDogController.Jump());

        yield return new WaitWhile(() => waitingDogController.isJumping);
        yield return new WaitForSeconds(0.1f);


        // オーバーレイを表示
        InitOverray();

        // 画面を切り替え
        SwitchActiveScreen();

        // 探索画面を初期化
        InitExploreScreen();

        yield return new WaitForSeconds(1.5f);

        // オーバーレイを非表示
        StartCoroutine(ShrinkOverlay());

        yield break;
    }


    void InitExploreScreen()
    {
        door.GetComponent<Animator>().SetTrigger("Close");
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        player.GetComponent<PlayerController>().MoveBasePos();
    }


    public void SwitchCharactor()
    {
        // 探索画面かつ画面遷移していないときのみ遷移できる
        if(IsExplore())
        {
            ScreenState = SCREEN.CHARACTOR;

            // 画面遷移前の動き
            StartCoroutine(ExecuteEffectesForTransitionToCharactor());

        }
        else
        {
            Debug.Log("Same Scene");
        }
    }


    private IEnumerator ExecuteEffectesForTransitionToCharactor()
    {
        // カメラをズームイン
        StartCoroutine(ZoomIn());
        yield return new WaitWhile(() => Camera.main.orthographicSize > zoomSize + 0.01f);

        // ドアを開く動き
        OpenDoor();
        yield return new WaitForSeconds(0.5f);

        // 画面切り替え用のオーバーレイを出現
        InitOverray();

        // カメラを元に戻す
        InitCamera();

        // 画面を切り替え
        SwitchActiveScreen();
        yield return new WaitForSeconds(1.5f);

        // オーバレイを消す
        StartCoroutine(ShrinkOverlay());

        yield break;
    }

    private IEnumerator ZoomIn()
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

        yield break;
    }

    void InitOverray()
    {
        overlay.SetActive(true);
        overlay.transform.localScale = new Vector3(2f, 2f, 1f);
    }

    private IEnumerator ShrinkOverlay()
    {
        while (overlay.transform.localScale.y > 0.01f)
        {
            float targetScaleY = Mathf.SmoothStep(overlay.transform.localScale.y, 0f, scaleSpeed);
            overlay.transform.localScale = new Vector3(overlay.transform.localScale.x, targetScaleY, overlay.transform.localScale.z);
            yield return new WaitForSeconds(scaleInterval);
        }

        overlay.SetActive(false);

        yield break;
    }


    void OpenDoor()
    {
        door.GetComponent<Animator>().SetTrigger("Open");   // TODO 2回目以降のときにうまく動作しない
        player.transform.Translate(1.5f, 0, 0);
        player.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void InitCamera()
    {
        Camera.main.transform.position = cameraOriginPos;
        Camera.main.orthographicSize = cameraOriginSize;
    }

    void SwitchActiveScreen()
    {
        if(ScreenState == SCREEN.CHARACTOR)
        {
            exploreScreen.SetActive(false);
            charactorScreen.SetActive(true);
        }
        else
        {
            exploreScreen.SetActive(true);
            charactorScreen.SetActive(false);
        }
    }

}
