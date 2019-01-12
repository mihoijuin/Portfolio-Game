using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestScreenController {

    private class GoToExprore_TestScenario : ScreenController, IMonoBehaviourTest
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

            GoToExprore();
            // EXPLOREのインデックスは0
            Assert.That((int)ScreenState, Is.EqualTo(0));

            IsTestFinished = true;
            gameObject.SetActive(false);
        }
    }

    private class GoToCharactor_TestScenario : ScreenController, IMonoBehaviourTest
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

            GoToCharactor();
            // CHARACTORのインデックスは1
            Assert.That((int)ScreenState, Is.EqualTo(1));

            IsTestFinished = true;
            gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// シーン切り替えテスト
    /// </summary>
    [UnityTest]
    public IEnumerator SwitchExploreScreen()
    {
        yield return new MonoBehaviourTest<GoToExprore_TestScenario>();
    }

    [UnityTest]
    public IEnumerator SwitchCharactorScreen()
    {
        yield return new MonoBehaviourTest<GoToCharactor_TestScenario>();
    }



}
