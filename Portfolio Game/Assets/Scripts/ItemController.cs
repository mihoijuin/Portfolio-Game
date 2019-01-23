using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    ItemDirector itemDirector;
    ItemCountController itemCountController;

    bool collidedByPlayer = false;

	void Start () {
        itemDirector = FindObjectOfType<ItemDirector>();
        itemCountController = FindObjectOfType<ItemCountController>();
	}
	
	
	void Update () {
	}


    private void OnMouseDown()
    {
        if (collidedByPlayer)
        {
            // アイテムレベルを更新
            itemDirector.UpdateItemLevel();
            // uGUIテキストを更新
            itemCountController.UpdateItemCountText();

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidedByPlayer = collision.gameObject.CompareTag("Player");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collidedByPlayer = !collision.gameObject.CompareTag("Player");
    }


}
