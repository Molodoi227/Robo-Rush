using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    protected int Bestscore;

    protected void LoadScore()
    {
        Bestscore = PlayerPrefs.GetInt("BestScore");
    }

    protected void SaveScore()
    {
        PlayerPrefs.SetInt("BestScore", Bestscore);
    }

    protected void SetNewBestScore(int newBestscore)
    {
        if (Bestscore < newBestscore)
        {
            Bestscore = newBestscore;
            SaveScore();
        }
    }
}
