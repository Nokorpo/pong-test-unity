using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class GameTests
{

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // yield return EditorSceneManager.LoadSceneAsyncInPlayMode(
        //     "Assets/Scenes/Pong.unity",
        //     new LoadSceneParameters()
        // );
        yield return SceneManager.LoadSceneAsync(0);
        yield return null;
    }

    [UnityTest]
    public IEnumerator GameStarts()
    {
        GameObject ball = GameObject.Find("Ball");
        Assert.That(ball, Is.Not.Null);
        yield break;
    }

    [UnityTest]
    public IEnumerator BallMovesWhenGameStarts()
    {
        // GIVEN
        GameObject ball = GameObject.Find("Ball");
        Vector2 initialPosition = ball.transform.position;

        // WHEN
        yield return new WaitForSeconds(1f);

        // THEN
        Assert.That(ball.transform.position.x, Is.GreaterThan(initialPosition.x));
        Assert.That(ball.transform.position.y, Is.GreaterThan(initialPosition.y));

        yield break;
    }

    [UnityTest]
    public IEnumerator BallReachingGoalScoresAPoint()
    {
        // GIVEN
        GameObject ball = GameObject.Find("Ball");
        ball.transform.position = new Vector2(8,3);
        GoalController goal = GameObject.Find("Goal2").GetComponent<GoalController>();
        TextMeshProUGUI score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        string initialScore = score.text;

        // WHEN
        bool eventReceived = false;
        goal.goalScored.AddListener(() => {
            eventReceived = true;
        });
        while (!eventReceived)
            yield return null;

        // THEN
        Assert.That(initialScore, Is.EqualTo("0"));
        Assert.That(score.text, Is.EqualTo("1"));

        yield break;
    }

}
