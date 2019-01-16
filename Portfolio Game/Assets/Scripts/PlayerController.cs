using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D playerRigid;
    public float playerSpeed;

    void Start () {
        playerRigid = GetComponent<Rigidbody2D>();

	}

    private void FixedUpdate()
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


    void MoveUp()
    {
        playerRigid.MovePosition(playerRigid.position + Vector2.up * playerSpeed);
    }

    void MoveDown()
    {
        playerRigid.MovePosition(playerRigid.position + Vector2.down * playerSpeed);
    }


    void MoveRight()
    {
        playerRigid.MovePosition(playerRigid.position + Vector2.right * playerSpeed);
    }

    void MoveLeft()
    {
        playerRigid.MovePosition(playerRigid.position + Vector2.left * playerSpeed);
    }
}
