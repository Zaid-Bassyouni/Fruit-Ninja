using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score ;

    private Blade blade;
    private Spawner spawner;


    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
    }
    private void Start()
    {
        NewGame();

    }
    private void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString();

    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text=score.ToString();
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;
        
    }
}
