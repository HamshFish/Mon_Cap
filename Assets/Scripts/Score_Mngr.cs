using UnityEngine;
using TMPro;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

public class Score_Mngr : MonoBehaviour
{
    private List<string> names = new List<string>();
    private List<int> scores = new List<int>();
    public static Score_Mngr instance;
    private int currentScore = 0;
    public int CurrentScore { get => currentScore; private set { currentScore = value; } }
    public int highScore = 0;
    public TMP_Text uiTextHighscore;
    public TMP_Text uiTextScore;
    public GameObject scoresParent;
    public TMP_Text scorePrefab;
    public int maxScoresCount = 10;
    public void Awake()
    {
        if(instance == null) {  instance = this; }
        else { Destroy(this); }
        AddHighscore("test", 4);
        AddHighscore("Nymm", 10);
        RefreshScoreDisplay();
        HighScoreData data = Jason_Save.Load();
        scores = data.scores.ToList();
        names = data.names.ToList();
        RefreshScoreDisplay();
        HighScoreCleanUp();
    }
   
    public void IncreaseScore(int amount)
    {
        CurrentScore += amount;
        uiTextScore.text = "Score: " + currentScore;
    }
    public void RefreshScoreDisplay()
    {
        Order66(scoresParent);
        for (int i = 0; i < scores.Count; i++)
        {
            TMP_Text textBox = Instantiate(scorePrefab, scoresParent.transform);
            textBox.text = names[i] + "  " + scores[i];
        }
    }
    void Order66(GameObject parent)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>(true);

        for (int i = children.Length -1; i >=0; i--)
        {
            if (children[i] == parent.transform) continue;
            Destroy(children[i].gameObject);
        }
    }
    private void OnDestroy()
    {
        Score_Mngr.instance.AddHighscore(Score_Mngr.instance.CurrentScore);
        HighScoreData data = new HighScoreData(scores.ToArray(), names.ToArray());
        Jason_Save.Save(data);
    }
    public void AddHighscore(int score)
    {
        string[] possibleNames = new[] { "Grimm", "Brumm", "Nymm", "Radiance", "Hornet", "Cornifer", "Unn", "Divine", "Willow", "Iselda", "Sly", "Herrah", "Oro", "Mato", "Sheo", "Monomon", "Lurien"};
        string randomName = possibleNames[Random.Range(0, possibleNames.Length)];
        AddHighscore(randomName, score);
    }
    public void AddHighscore(string name, int score)
    {
        
        for (int i = 0; i < scores.Count; i++)
        { 
            if(score > scores[i])
            {
                scores.Insert(i, score);
                names.Insert(i, name);
                return;
            }
        }
        if (scores.Count < maxScoresCount)
        {
            scores.Add(score);
            names.Add(name);
        }
        HighScoreCleanUp();
        
    }
    void HighScoreCleanUp()
    {
        for (int i = maxScoresCount; i < scores.Count; i++)
        {
            names.RemoveAt(i);
            scores.RemoveAt(i);
        }
    }
}
