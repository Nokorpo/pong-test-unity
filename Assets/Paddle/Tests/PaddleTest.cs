using System.Collections;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


 public class BasePaddleTest : InputTestFixture
    {

        protected Keyboard keyboard;

        public override void Setup()
        {
            base.Setup();
            keyboard = InputSystem.AddDevice<Keyboard>();
        }

        public override void TearDown()
        {
            InputSystem.RemoveDevice(keyboard);
            base.TearDown();
        }

        [UnitySetUp]
        public IEnumerator Before()
        {
            yield return EditorSceneManager.LoadSceneAsyncInPlayMode(
                "Assets/Paddle/Tests/PaddleTestScene.unity",
                new LoadSceneParameters()
            );
            yield return null;
        }
    }

public class PaddleTest : BasePaddleTest
{
    [UnityTest]
    public IEnumerator PaddleTestWithEnumeratorPasses()
    {
        // GIVEN
        PaddleController paddle = Object.FindFirstObjectByType<PaddleController>();
        var original_pos = paddle.transform.position.y;

        GameObject inputManagerObject = new GameObject();
        var inputManager = inputManagerObject.AddComponent<InputManager>();
        inputManager.player1 = paddle;

        // WHEN
        Press(keyboard.wKey);
        yield return new WaitForSeconds(0.5f);

        // THEN
        Assert.That(paddle.transform.position.y, Is.GreaterThan(original_pos), "Paddle didn't move");

    }
}
