using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;
    [SerializeField] private ScoreUI ScoreUI;
    [SerializeField] private int score = 0;
    private int currentBrickCount;
    private int totalBrickCount;

    private void OnEnable()
    {
       
        InputHandler.Instance.OnFire.RemoveListener(FireBall);
        ball.ResetBall();
        totalBrickCount = bricksContainer.childCount;
        currentBrickCount = bricksContainer.childCount;
        InputHandler.Instance.OnFire.AddListener(FireBall);
    }

    private void OnDisable()
    {
        InputHandler.Instance.OnFire.RemoveListener(FireBall);
    }

    private void FireBall()
    {
        ball.FireBall();
    }

    public void OnBrickDestroyed(Vector3 position)
    {
        // fire audio here (Ariana note: decided to instead put in Brick.cs because this method is 
        // called after a delay and i want player to get instant feedback that they've hit a brick)

        // implement particle effect here
        // add camera shake here
        currentBrickCount--;
        increaseScore();
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");

        if (currentBrickCount == 0) // end of level
        {
            SceneHandler.Instance.LoadNextScene();
            playLevelCompleteSFX();
        }
    }
    public void increaseScore() {
        score++;
        ScoreUI.UpdateScore(score);
    }

    public void KillBall()
    {
        loseLife();
        if (maxLives <= 0)
        {   // game over UI if maxLives < 0, then exit to main menu after delay
            SceneHandler.Instance.LoadMenuScene();
        }
        else {
            ball.ResetBall();
        } 
    }
    private void loseLife() {
        maxLives--;
        ScoreUI.LoseLife(maxLives);
    }
    private void playLevelCompleteSFX()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.levelCompleteClip);
        }
    }
}
