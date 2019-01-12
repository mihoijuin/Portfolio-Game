using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections;

public class TestItemDirector {

    [SetUp]
    public void Init()
    {
        SceneManager.LoadScene("Explore");
    }


    [UnityTest]
    public IEnumerator TestDisplayItemCount() {

        GameObject itemCountText = GameObject.Find("ItemCountText");
        string itemCountKey = "itemCount";
        int itemCount = PlayerPrefs.GetInt(itemCountKey, 0);

        yield return null;

        // Item：<itemCount>/6 と表示される
        int actual = int.Parse(itemCountText.GetComponent<Text>().text.Split('：')[1].Split('/')[0]);
       
        Assert.AreEqual(itemCount, actual);
    }
}
