using System;
using UnityEngine;

public class ItemDirector : MonoBehaviour {

    // 1つ見つけるごとに見るレベルが上がり情報が増えていく
    public enum ITEM
    {
        NONE = 0,

        ITEM0,
        ITEM1,
        ITEM2,
        ITEM3,
        ITEM4,
        ITEM5,

        NUM
    }


    private readonly string itemLevelKey = "itemLevel";
    public ITEM itemLevel;

    private void OnEnable()
    {
        LoadItemLevel();
    }

    void Start ()
    {

    }
	
	
	void Update () {
		
	}

    
    public void LoadItemLevel()
    {
        // 所持アイテムのレベルを取得
        // なければNONE
         itemLevel = (ITEM)Enum.ToObject(typeof(ITEM),
            PlayerPrefs.GetInt(itemLevelKey, 0)
        );
    }

    public void SaveItemLevel()
    {
        PlayerPrefs.SetInt(itemLevelKey, (int)itemLevel);
        PlayerPrefs.Save();
    }
}
