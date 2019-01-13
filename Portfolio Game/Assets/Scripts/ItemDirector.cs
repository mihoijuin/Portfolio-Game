using System;
using UnityEngine;

public class ItemDirector : MonoBehaviour {

    // 1つ見つけるごとに見るレベルが上がり情報が増えていく
    public enum ITEM
    {
        NONE = -1,

        ITEM0 = 0,
        ITEM1,
        ITEM2,
        ITEM3,
        ITEM4,
        ITEM5,

        NUM
    }


    private string itemLevelKey = "itemLevel";
    public ITEM itemLevel;


    void Start ()
    {
        LoadItemLevel();
    }
	
	
	void Update () {
		
	}

    
    void LoadItemLevel()
    {
        // 所持アイテムのレベルを取得
        // なければNONE
         itemLevel = (ITEM)Enum.ToObject(typeof(ITEM),
            PlayerPrefs.GetInt(itemLevelKey, -1)
        );
    }

    public void SaveItemLevel()
    {
        PlayerPrefs.SetInt(itemLevelKey, (int)itemLevel);
        PlayerPrefs.Save();
    }
}
