using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            }

            canDamage = false;

            StartCoroutine(WaitForDamage());
        }
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }
}
