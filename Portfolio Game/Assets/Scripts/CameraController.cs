using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject door;

    public float zoomInterval;
    public float zoomSpeed;
    public float zoomSize;
    public float zoomOffset;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ZoomInBeforeCharacterScreenTransition()
    {
        StartCoroutine(ZoomIn());
    }

    public IEnumerator ZoomIn()
    {

        while (Camera.main.orthographicSize > zoomSize + 0.01f)
        {
            // カメラをドアの位置に移動
            float targetPosx = Mathf.SmoothStep(transform.position.x, door.transform.position.x - zoomOffset, zoomSpeed);
            float targetPosy = Mathf.SmoothStep(transform.position.y, door.transform.position.y, zoomSpeed);

            Camera.main.transform.position = new Vector3(targetPosx, targetPosy, -10f);

            // カメラをズームイン
            Camera.main.orthographicSize = Mathf.SmoothStep(Camera.main.orthographicSize, zoomSize, zoomSpeed);

            yield return new WaitForSeconds(zoomInterval);
        }

        door.GetComponent<Animator>().SetTrigger("Open");

    }


}
