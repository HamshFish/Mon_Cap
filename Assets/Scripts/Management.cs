using UnityEngine;
using UnityEngine.SceneManagement;

public class Management : MonoBehaviour
{
    private GameObject player;
    private Score_Mngr score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player_Move>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -10)
        {
            Score_Mngr.instance.AddHighscore(Score_Mngr.instance.CurrentScore);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
