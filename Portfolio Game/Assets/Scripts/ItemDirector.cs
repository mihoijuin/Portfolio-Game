using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDirector : MonoBehaviour {

    private string itemCountKey = "itemCount";
    private int itemCount;
    Text itemCountText;


	void Start ()
    {
        itemCount = PlayerPrefs.GetInt(itemCountKey, 0);
        itemCountText = GameObject.Find("ItemCountText").GetComponent<Text>();

        // 取得アイテム数を表示
        itemCountText.text = string.Format("Item：{0}/6", itemCount);
    }
	
	
	void Update () {
		
	}

    void SaveItemCount()
    {
        PlayerPrefs.SetInt(itemCountKey, itemCount);
        PlayerPrefs.Save();
    }
}
