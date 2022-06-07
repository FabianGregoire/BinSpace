using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour {  
    public void PlayGame() {  
        SceneManager.LoadSceneAsync("SampleScene");
        Time.timeScale = 1.0f; 
    }
    public void GoToShop() {  
        SceneManager.LoadSceneAsync("ShopScene");
        Time.timeScale = 1.0f; 
    }
    public void QuitGame() {  
        Debug.Log("QUIT");  
        Application.Quit(); 
        Time.timeScale = 1.0f;
    }
    public void BacktoMenu() {  
        SceneManager.LoadSceneAsync("WelcomeScene"); 
        Time.timeScale = 1.0f;
    }
}