using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestScreenController {

    private class SwitchExploreScreen_TestScenario : ScreenController, IMonoBehaviourTest
    {
        public bool IsTestFinished { get; private set; }

        private void Start()
        {
            StartCoroutine(TestScenario());
        }

        private IEnumerator TestScenario()
        {

            // キャラクターシーンからの遷移の状態
            ScreenState = SCREEN.CHARACTOR;
            // 1フレーム待機
            yield return null;

            // 違うシーンの場合はシーン遷移
            SwitchExploreScreen();
            Assert.That((int)ScreenState, Is.EqualTo(0));   // EXPLOREのインデックは0

            // 同じシーンの場合はログを吐く
            LogAssert.Expect(LogType.Log, "Same Scene");
            SwitchExploreScreen();

            IsTestFinished = true;
            gameObject.SetActive(false);
        }
    }

    private class SwitchCharactorScreen_TestScenario : ScreenController, IMonoBehaviourTest
    {
        public bool IsTestFinished { get; private set; }

        private void Start()
        {
            StartCoroutine(TestScenario());
        }

        private IEnumerator TestScenario()
        {
            ScreenState = SCREEN.EXPLORE;
            // 1フレーム待機
            yield return null;

            // 違うシーンの場合はシーン遷移
            SwitchCharactorScreen();
            Assert.That((int)ScreenState, Is.EqualTo(1));   // CHARACTORのインデックスは1

            // 同じシーンの際はログを吐く
            LogAssert.Expect(LogType.Log, "Same Scene");
            SwitchCharactorScreen();

            // 終了
            IsTestFinished = true;
            gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// シーンフラグ切り替えテスト
    /// </summary>
    [UnityTest]
    public IEnumerator SwitchExploreScreenTest()
    {
        yield return new MonoBehaviourTest<SwitchExploreScreen_TestScenario>();
    }

    [UnityTest]
    public IEnumerator SwitchCharactorScreenTest()
    {
        yield return new MonoBehaviourTest<SwitchCharactorScreen_TestScenario>();
    }



}
