using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    private int score = 0;
    private int targetScore = 0;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private int studentPoint = 100;

    [SerializeField]
    private int otherPoint = -200;

    private WaitForSeconds wfs = new WaitForSeconds(0.02f);


    public int GetScore
    {
        get { return targetScore; }
    }

    public void ScoreCalc(int studentNum, int otherNum)
    {
        targetScore += studentNum * studentPoint;
        targetScore += otherNum * otherPoint;

        if (targetScore < 0)
        {
            targetScore = 0;
        }

        StartCoroutine(ScoreEffect());
    }

    IEnumerator ScoreEffect()
    {
        while(true)
        {
            if(score < targetScore)
            {
                score++;
            }
            else if(score > targetScore)
            {
                if(score > 0)
                score--;
            }
            else if(score == targetScore)
            {
                break;
            }

            scoreText.text = "Score : " + score.ToString();
            yield return wfs;
        }
    }
}
