using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMenu : MonoBehaviour
{
    Dropdown[] m_Dropdowns;
    Button confirmButton;

    private void Awake(){
        m_Dropdowns = FindObjectsOfType<Dropdown>();
        Array.Reverse(m_Dropdowns); // 表示順になるように
        confirmButton = transform.Find("Scroll View/Viewport/Content/ConfirmButton").GetComponent<Button>();
    }

    private void Start()
    {
        List<Dropdown.OptionData>[] m_OptionDataListArray = new List<Dropdown.OptionData>[m_Dropdowns.Length];

        // ドロップダウン
        Type[] choiceArray = new Type[] {typeof(SceneBase.SCENE), typeof(SceneBase.SCENARIO)};   // ドロップダウンで選択するもの
        foreach(Type choice in choiceArray){
            string[] nameArray = choice.GetEnumNames();
            Dropdown.OptionData[] m_NewDataArray = new Dropdown.OptionData[nameArray.Length-2];     // NONE, NUMを数えない
            m_OptionDataListArray[Array.IndexOf(choiceArray, choice)] = new List<Dropdown.OptionData>();
            foreach(string name in  nameArray){
                if(name != "NONE" && name != "NUM"){
                    m_NewDataArray[Array.IndexOf(nameArray, name)] = new Dropdown.OptionData();
                    m_NewDataArray[Array.IndexOf(nameArray, name)].text = name;
                    m_OptionDataListArray[Array.IndexOf(choiceArray, choice)].Add(m_NewDataArray[Array.IndexOf(nameArray, name)]);
                }
            }
        }

        for(int index=0; index<m_OptionDataListArray.Length; ++index){    // ドロップダウンに内容を入れていく
            m_Dropdowns[index].ClearOptions();
            foreach(Dropdown.OptionData message in m_OptionDataListArray[index]){
                m_Dropdowns[index].options.Add(message);
            }
        }

        // 確認ボタン
        foreach(Dropdown m_Dropdown in m_Dropdowns){
            m_Dropdown.captionText.text = Enum.GetNames(choiceArray[Array.IndexOf(m_Dropdowns, m_Dropdown)])[0];    // 初期起動時はNullになるのでデフォルト値を設定
            m_Dropdowns[Array.IndexOf(m_Dropdowns, m_Dropdown)].onValueChanged.AddListener(delegate {
                UpdateConfirmButton();
            });
        }
        UpdateConfirmButton();  // 初期起動時用

        // ゲーム開始時は操作不可に
        transform.Find("Scroll View/").gameObject.SetActive(false);
    }

    private void UpdateConfirmButton(){
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(() => SceneBase.LoadScenario(m_Dropdowns[0].captionText.text, m_Dropdowns[1].captionText.text));
        confirmButton.onClick.AddListener(() => Debug.Log("[Debug Menu]シーン：" + m_Dropdowns[0].captionText.text + "、シナリオ：" + m_Dropdowns[1].captionText.text));
        confirmButton.onClick.AddListener(() => transform.Find("Scroll View/").gameObject.SetActive(false));
    }

}
