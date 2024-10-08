using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    private TMP_Text lifeText;
    private int lifeScoreCount;

    private bool canDamage;

    private void Awake()
    {
        lifeText = GameObject.Find("LifeText").GetComponent<TMP_Text>();
        lifeScoreCount = 3;
        lifeText.text = 'x' + lifeScoreCount.ToString();
        canDamage = true;
    }

    void Update()
    {
        
    }

    public void DealDamage()
    {
        if (canDamage)
        {
            lifeScoreCount--;

            if (lifeScoreCount >= 0)
            {
                lifeText.text = 'x' + lifeScoreCount.ToString();
            }

            if (lifeScoreCount == 0)
            {
                print("You died");
                Time.timeScale = 0f;
                StartCoroutine(RestartScene());
            }

            GameObject.Find("HitSound").GetComponent<AudioSource>().Play();

            canDamage = false;

            StartCoroutine(WaitForDamage());
        }
    }

    public void RestartSceneFunction()
    {
        StartCoroutine(RestartScene());
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Chapter_1");
        Time.timeScale = 1f;
    }
}
