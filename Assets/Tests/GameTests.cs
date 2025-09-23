using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using TMPro;

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

    [UnityTest]
    public IEnumerator BallExists()
    {
        // GIVEN
        BallController ball = Object.FindFirstObjectByType<BallController>();

        // WHEN
        // loaded

        // THEN
        Assert.That(ball, Is.Not.Null);
        yield break;
    }

    [UnityTest]
    public IEnumerator BallMoves()
    {
        // GIVEN
        BallController ball = Object.FindFirstObjectByType<BallController>();
        Vector2 originalPosition = ball.transform.position;

        // WHEN
        yield return new WaitForSeconds(.5f);

        // THEN
        Assert.That(ball.transform.position.x, Is.GreaterThan(originalPosition.x));
        Assert.That(ball.transform.position.y, Is.GreaterThan(originalPosition.y));
    }

    [UnityTest]
    public IEnumerator BallScores()
    {
        // GIVEN
        BallController ball = Object.FindFirstObjectByType<BallController>();
        ball.transform.position = new Vector2(8, 3);
        TextMeshProUGUI score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        string originalScore = score.text;

        // WHEN
        yield return new WaitForSeconds(.5f);

        // THEN
        Assert.That(originalScore, Is.EqualTo("0"));
        Assert.That(score.text, Is.EqualTo("1"));
    }
}
