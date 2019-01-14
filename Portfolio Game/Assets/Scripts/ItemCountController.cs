using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemCountController : MonoBehaviour {

    Text itemCountText;
    public ItemDirector itemDirector;

    void Start () {
        itemCountText = GetComponent<Text>();
        UpdateItemCountText();
	}
	
	
	void Update () {
		
	}

    public void UpdateItemCountText()
    {
        // 現在のアイテム状態を取得
        int maxLevel = (int)ItemDirector.ITEM.NUM - 1;
        int currentLevel = (int)itemDirector.itemLevel;

        // アイテム状況を表示
        itemCountText.text = string.Format("{0}/{1}", currentLevel, maxLevel);
    }
}
