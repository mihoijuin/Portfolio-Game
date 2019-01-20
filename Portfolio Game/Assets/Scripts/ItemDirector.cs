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


    void ShowAcquiredItems()
    {
        switch (itemLevel)
        {
            case ITEM.NONE:
                Debug.Log("none");
                break;
            case ITEM.ITEM0:
                Debug.Log("1");
                break;
            case ITEM.ITEM1:
                Debug.Log("2");
                break;
            case ITEM.ITEM2:
                Debug.Log("3");
                break;

        }
    }

    public void UpdateItemLevel()
    {
        itemLevel = (ITEM)Enum.ToObject(typeof(ITEM),
            (int)itemLevel + 1
        );
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
