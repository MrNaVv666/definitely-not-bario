using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClearScript : MonoBehaviour
{
    public void MainMenuF()
    {
        StartCoroutine(GoToMainMenu());
    }

    IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(6.5f);
        Debug.Log("Coroutine is here");
        SceneManager.LoadScene("MainMenu");
    }
}
