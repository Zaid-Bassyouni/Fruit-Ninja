using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score ;

    private Blade blade;
    private Spawner spawner;

    public Image fadeImage;

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
        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        scoreText.text = score.ToString();

        ClearScene();
    }

    private void ClearScene()
    {
        Fruit[] fruits=FindObjectsOfType<Fruit>();
        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

          Bomb[] bombs = FindObjectsOfType<Bomb>();
          foreach (Bomb bomb in bombs)
          {
              Destroy(bomb.gameObject);
          }
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
        
        StartCoroutine(ExplodeSequence());
    }
    // to do a custom animation like fade Image we are
    //going to use another coroutine.
    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);//what is the def between Clamp and Clamp01.
            fadeImage.color= Color.Lerp(Color.clear, Color.white, t);
         
            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);

        NewGame();
        elapsed = 0f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);//what is the def between Clamp and Clamp01.
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

        
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }
    }
}
