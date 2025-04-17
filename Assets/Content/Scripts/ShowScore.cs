using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    ScoreSystem[] allScores;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allScores = FindObjectsByType<ScoreSystem>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        int totalScore = 0;

        foreach (ScoreSystem scoreSystem in allScores)
        {
            totalScore += scoreSystem.Score;
        }

        scoreText.text = "Score: " + totalScore;

    }
}
