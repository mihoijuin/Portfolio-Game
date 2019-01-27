using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingDogController : MonoBehaviour {

    public GameObject exploreScreenButton;

    public float jumpHeight;
    public float jumpSpeed;
    public float jumpInterval;

    public bool isJumping;


    private void OnMouseDown()
    {
        exploreScreenButton.SetActive(true);
    }

    public IEnumerator Jump()
    {
        isJumping = true;

        float height = 0f;
        Vector3 originPos =　transform.position;

        // 上がる
        while(transform.position.y < originPos.y + jumpHeight)
        {
            height = Mathf.SmoothStep(0f, jumpHeight, jumpSpeed);
            transform.Translate(0, height, 0);
            yield return new WaitForSeconds(jumpInterval);

        }

        yield return new WaitForSeconds(jumpInterval);

        // 下がる
        while(transform.position.y > originPos.y)
        {
            height = Mathf.SmoothStep(0f, jumpHeight, jumpSpeed);
            transform.Translate(0, -height, 0);
            yield return new WaitForSeconds(jumpInterval);
        }

        isJumping = false;

        yield break;

    }
}
