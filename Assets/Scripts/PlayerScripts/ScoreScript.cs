using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    private TMP_Text coinTextScore;
    private AudioSource audioManager;
    private int scoreCount;

    private void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }
    void Start()
    {
        coinTextScore = GameObject.Find("CoinText").GetComponent<TMP_Text>();

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.COIN_TAG)
        {
            collision.gameObject.SetActive(false);
            scoreCount++;
            coinTextScore.text = 'x' + scoreCount.ToString();
            audioManager.Play();
        }
    }
}
