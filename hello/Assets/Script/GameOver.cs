 using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text playerScore;
    public TMP_Text highScoreText;
    public TMP_Text mode;

    public int highscore;


    public void PrintScore(int score, string state){
        if(PlayerPrefs.GetInt(state)!=0 && PlayerPrefs.GetInt(state)> score){
            highscore = PlayerPrefs.GetInt(state);
        }
        else{
            highscore = score;
            PlayerPrefs.SetInt(state, score);
        }
        gameObject.SetActive(true);
        mode.text = state;
        playerScore.text = "YOUR SCORE: " + score.ToString();
        highScoreText.text = "HIGH SCORE: " + highscore.ToString();
    }

    public void Inactive(){
        gameObject.SetActive(false);
    }
    public void Scene(string scene){
        SceneManager.LoadScene(scene); 
    }
    public void ReturnMenu(){
        SceneManager.LoadScene("MainMenu"); 

    }   
}
