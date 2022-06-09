using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameObject _victoryText;
    [SerializeField] private GameObject _looseText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndLevelTimer());
        //StopCoroutine(EndLevelTimer());
    }

    void Update()
    {

    }

    IEnumerator EndLevelTimer(){
        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
        _endMenu.SetActive(true);
        _victoryText.SetActive(true);
        _endMenu.SetActive(false);
        Debug.Log("Finished"); 
    }
}