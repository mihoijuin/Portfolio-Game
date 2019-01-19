using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D playerRigid;
    Animator playerAnimator;
    public float playerSpeed;
    Vector3 basePos;

    // スクリーン
    public ScreenController screenController;

    void Start () {
        playerRigid = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        basePos = transform.position;

	}


    private void FixedUpdate()
    {
        // 探索画面の時のみ移動可能
        if (screenController.IsExplore())
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                MoveUp();
            }
            
            if (Input.GetKey(KeyCode.DownArrow))
            {
                MoveDown();
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
        }

    }


    void MoveUp()
    {
        playerRigid.MovePosition(playerRigid.position + Vector2.up * playerSpeed);
        playerAnimator.SetTrigger("MoveUp");
    }

    void MoveDown()
    {
        playerRigid.MovePosition(playerRigid.position + Vector2.down * playerSpeed);
        playerAnimator.SetTrigger("MoveDown");
    }


    public void MoveRight()
    {
        playerRigid.MovePosition(playerRigid.position + Vector2.right * playerSpeed);
        playerAnimator.SetTrigger("MoveRight");
    }

    void MoveLeft()
    {
        playerRigid.MovePosition(playerRigid.position + Vector2.left * playerSpeed);
        playerAnimator.SetTrigger("MoveLeft");
    }


    public void MoveBasePos()
    {
        // ふよんとして定位置に戻したい
        transform.position = new Vector2(basePos.x, basePos.y);

    }

}
