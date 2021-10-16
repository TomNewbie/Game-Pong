using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour
{
    public AudioManager song;

    public GamePlay Menu;
    public GamePlay Difficulty;
    public GamePlay Option;
    public GamePlay Continue;
    public Slider sliderBar;
    private float volumeBar;


    private float size;

    private void Start() {
        Menu.SetupGame(true);
        if(PlayerPrefs.GetFloat("continue") == 0){
            Continue.SetupGame(false);
        }       
        Difficulty.SetupGame(false);
        Option.SetupGame(false);
        AudioListener.pause = false;
        song.Play("intro");
    }

    public void Easy(){
        size = 2.5f;
        SetupGame(size); 
    }
    public void Difficult(){
        size = 1.5f;
        SetupGame(size); 
    }
    public void Hard(){
        size = 0.5f;
        SetupGame(size); 
    }
    public void SetupGame(float size){
        PlayerPrefs.SetFloat("paddleSize", size);
        PlayerPrefs.SetFloat("continue", size);
        PlayerPrefs.DeleteKey("continueCheck");        
        SceneManager.LoadScene("GamePlay");
    }
    public void ContinueButton(){
        PlayerPrefs.SetInt("continueCheck", 1);
        SceneManager.LoadScene("GamePlay");
    }
    public void ResetAll(){
        PlayerPrefs.DeleteAll();
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
