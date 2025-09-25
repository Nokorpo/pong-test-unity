using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine.InputSystem;

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
        yield return EditorSceneManager.LoadSceneAsyncInPlayMode("Assets/Paddle/Tests/PaddleTestScene.unity", new LoadSceneParameters());
        yield return null; // wait for scene object's Start() method to run
    }
}

public class PaddleTests: BasePaddleTest
{
    public IEnumerator PaddleCanBeMoved()
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

        yield break;
    }

}
