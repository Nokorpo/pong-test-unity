using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class GameTests
{
    [UnitySetUp]
    public IEnumerator Before()
    {
        yield return EditorSceneManager.LoadSceneAsyncInPlayMode("Assets/Scenes/Pong.unity", new LoadSceneParameters());
        //yield return SceneManager.LoadSceneAsync(0); // Podemos usar este método si lo hemos configurado en Build Profiles > Scene List
        yield return null; // Avanzamos 1 frame para que Unity pueda ejecutar los Start, que tardan 1 frame en ejecutarse
    }

    [UnityTest]
    public IEnumerator TestGameCanLoad()
    {
        // GIVEN
        Scene scene = SceneManager.GetActiveScene();

        // WHEN
        // loaded

        // THEN
        Assert.That(scene.name, Is.EqualTo("Pong"));
        yield break;
    }
}
