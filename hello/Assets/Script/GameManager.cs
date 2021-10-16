using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    private int _playerScore;
    private int _computerScore;
    public TMP_Text computerScoreText;
    public TMP_Text playerScoreText;
    public Paddle playerPaddle;
    public Paddle computerPaddle;
    public Ball ball;
    public GamePlay gamePlay;
    public GameOver GameOver;
    public GamePlay GamePause;
    public GameObject humanPaddleSize;
    private float paddleSize;
    
    private float continueCode;
    public Slider sliderBar;
    private float volumeBar;

    public static bool GameisPaused = false;
    private void Awake(){
        paddleSize = PlayerPrefs.GetFloat("paddleSize");
        
        humanPaddleSize.transform.localScale = new Vector3(0.25f, paddleSize, 1);
        ball._rigidbody = ball.GetComponent<Rigidbody2D>();
    }
    private void Start() 
    {
        gamePlay.SetupGame(true);
        GamePause.SetupGame(false);
        GameOver.Inactive();
        Reset();
        ContinueCheck();
        FindObjectOfType<AudioManager>().Play("playMusic");
        ContinueGame();

    }
    public void PauseGame(){
        GamePause.SetupGame(true);
        GameisPaused = true;
        FindObjectOfType<AudioManager>().IgnorePause("waiting");
        Time.timeScale = 0.0f;
        AudioListener.pause = true;
    }

    public void ContinueGame(){
        GamePause.SetupGame(false);           
        GameisPaused = false;
        FindObjectOfType<AudioManager>().Stop("waiting");
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            if(GameisPaused){
                ContinueGame();        
            }else{
                GetVolume();
                PauseGame(); 
            }            
        }
    }
    
    public void ComputerScore(){
        if(_computerScore == 3){
            EndGame();
        }
        else{
        _computerScore++ ;
        computerScoreText.text = _computerScore.ToString();
        Reset();
        }
    }
    public void PlayerScore(){
        _playerScore++ ;
        playerScoreText.text = _playerScore.ToString();
        Reset();
    }
    public void Reset(){
        ball.ResetPosition();      
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.AddStartingForce();
    }

    public void EndGame(){
        continueCode = PlayerPrefs.GetFloat("continue");     
        gamePlay.SetupGame(false);
        if(continueCode == 0.5){
            GameOver.PrintScore(_playerScore, "Hard");
        }else if(continueCode == 1.5){
            GameOver.PrintScore(_playerScore, "Medium");
        }else{
            GameOver.PrintScore(_playerScore, "Easy");
        }
        PlayerPrefs.DeleteKey("continue");          
        FindObjectOfType<AudioManager>().Stop("playMusic");  
        FindObjectOfType<AudioManager>().Play("lose");
    }

    public void MainMenu(){
        PlayerPrefs.SetInt("playerScore", _playerScore);
        PlayerPrefs.SetInt("computerScore", _computerScore);        
        SceneManager.LoadScene("MainMenu");        

    }

    public void ContinueCheck(){
        if(PlayerPrefs.GetInt("continueCheck") !=0){
            _playerScore = PlayerPrefs.GetInt("playerScore");
            _computerScore = PlayerPrefs.GetInt("computerScore");
            playerScoreText.text = _playerScore.ToString();
            computerScoreText.text = _computerScore.ToString();
        }
    }
    public void GetVolume(){
        if(PlayerPrefs.GetFloat("volume")!= 0)
        {
        volumeBar = PlayerPrefs.GetFloat("volume");
        }
        else{
            volumeBar = 1;
        }
        sliderBar.value = volumeBar;
    }
}
