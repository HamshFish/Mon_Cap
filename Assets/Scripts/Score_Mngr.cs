using UnityEngine;
using TMPro;

public class Score_Mngr : MonoBehaviour
{
    public static Score_Mngr instance;
    private int currentScore = 0;
    public int CurrentScore { get => currentScore; private set { currentScore = value; } }
    public int highScore = 0;
    public TMP_Text uiTextHighscore;
    public TMP_Text uiTextScore;
    public void Awake()
    {
        if(instance == null) {  instance = this; }
        else { Destroy(this); }
    }
    public void IncreaseScore(int amount)
    {
        CurrentScore += amount;
        uiTextScore.text = "Score: " + currentScore;
    }
}
