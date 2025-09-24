using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{

    public UnityEvent goalScored;

    public TextMeshProUGUI scoreLabel;

    private int score = 0;

    void Start()
    {
        scoreLabel.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ball")
        {
            score++;
            scoreLabel.text = score.ToString();
            BallController ball = collision.GetComponent<BallController>();
            ball.Reset();
            goalScored.Invoke();
        }
    }

}
