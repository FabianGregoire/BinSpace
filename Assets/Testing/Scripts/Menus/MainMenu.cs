using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour {  
    public void PlayGame() {  
        SceneManager.LoadSceneAsync("SampleScene");  
    }
    public void GoToShop() {  
        SceneManager.LoadSceneAsync("ShopScene");  
    }
    public void QuitGame() {  
        Debug.Log("QUIT");  
        Application.Quit(); 
    }
    public void BacktoMenu() {  
        SceneManager.LoadSceneAsync("WelcomeScene");  
    }
}