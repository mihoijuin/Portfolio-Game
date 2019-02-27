using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMenu : MonoBehaviour
{
    //The list of messages for the Dropdown
    List<Dropdown.OptionData>[] m_MessagesArray = new List<Dropdown.OptionData>[2];

    Dropdown[] m_Dropdowns;
    Button confirmButton;

    private void Awake(){
        m_Dropdowns = FindObjectsOfType<Dropdown>();
        confirmButton = transform.Find("Scroll View/Viewport/Content/ConfirmButton").GetComponent<Button>();
    }

    private void Start()
    {
        // ドロップダウン
        Dropdown.OptionData[] m_NewDataArray = new Dropdown.OptionData[(int)SceneBase.SCENARIO.NUM];  // シナリオ選択
        m_MessagesArray[0] = new List<Dropdown.OptionData>();
        int scenarioIndex = 0;
        foreach(string sceneName in  Enum.GetNames(typeof(SceneBase.SCENARIO))){
            if(sceneName != "NONE" && sceneName != "NUM"){
                m_NewDataArray[scenarioIndex] = new Dropdown.OptionData();
                m_NewDataArray[scenarioIndex].text = sceneName;
                m_MessagesArray[0].Add(m_NewDataArray[scenarioIndex]);
                scenarioIndex += 1;
            }
        }

        m_NewDataArray = new Dropdown.OptionData[(int)SceneBase.SCENE.NUM];   // シーン選択
        m_MessagesArray[1] = new List<Dropdown.OptionData>();
        int sceneIndex = 0;
        foreach(string sceneName in  Enum.GetNames(typeof(SceneBase.SCENE))){
            if(sceneName != "NONE" && sceneName != "NUM"){
                m_NewDataArray[sceneIndex] = new Dropdown.OptionData();
                m_NewDataArray[sceneIndex].text = sceneName;
                m_MessagesArray[1].Add(m_NewDataArray[sceneIndex]);
                sceneIndex += 1;
            }
        }


        for(int index=0; index<m_MessagesArray.Length; ++index){    // ドロップダウンに内容を入れていく
            m_Dropdowns[index].ClearOptions();
            foreach(Dropdown.OptionData message in m_MessagesArray[index]){
                m_Dropdowns[index].options.Add(message);
            }
        }

        // 確認ボタン
        m_Dropdowns[1].captionText.text = Enum.GetNames(typeof(SceneBase.SCENE))[0];    // 実操作時はNullになるのでデフォルト値を設定
        m_Dropdowns[0].captionText.text = Enum.GetNames(typeof(SceneBase.SCENARIO))[0];
        UpdateConfirmButton();

        int dropIndex = 0;
        foreach(Dropdown m_Dropdown in m_Dropdowns){
            m_Dropdowns[dropIndex].onValueChanged.AddListener(delegate {
                UpdateConfirmButton();
            });
            dropIndex += 1;
        }
    }

    private void UpdateConfirmButton(){
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(() => SceneBase.LoadScenario(m_Dropdowns[1].captionText.text, m_Dropdowns[0].captionText.text));
        confirmButton.onClick.AddListener(() => Debug.Log("[Debug Menu]シーン：" + m_Dropdowns[1].captionText.text + "、シナリオ：" + m_Dropdowns[0].captionText.text));
        confirmButton.onClick.AddListener(() => transform.Find("Scroll View/").gameObject.SetActive(false));
    }
}
