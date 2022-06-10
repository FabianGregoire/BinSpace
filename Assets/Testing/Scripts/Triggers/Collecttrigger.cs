using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecttrigger : MonoBehaviour
{
    public AudioSource collectSound;
    public int scoreCounter = 0;
    public TMPro.TMP_Text texte;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            collectSound.Play();
            scoreCounter++;
            UpdateScoreText();
            Debug.Log(scoreCounter);
        }
    }

    public void UpdateScoreText(){
        texte.text = scoreCounter.ToString();
    }
}
