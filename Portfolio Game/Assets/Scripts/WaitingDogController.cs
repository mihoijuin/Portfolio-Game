using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingDogController : MonoBehaviour {

    public GameObject exploreScreenButton;

    public float jumpHeight;
    public float jumpSpeed;
    public float jumpInterval;

    private void OnMouseDown()
    {
        exploreScreenButton.SetActive(true);
    }

    public IEnumerator Jump()
    {
        float height = 0f;
        Vector3 originPos = transform.position;

        while(transform.position.y < originPos.y + jumpHeight)
        {
            height = Mathf.SmoothStep(0f, jumpHeight, jumpSpeed);
            transform.Translate(0, height, 0);
            yield return new WaitForSeconds(jumpInterval);

        }

        yield return new WaitForSeconds(0.05f);

        while(transform.position.y > originPos.y)
        {
            height = Mathf.SmoothStep(0f, jumpHeight, jumpSpeed);
            transform.Translate(0, -height, 0);
            yield return new WaitForSeconds(jumpInterval);
        }

    }
}
