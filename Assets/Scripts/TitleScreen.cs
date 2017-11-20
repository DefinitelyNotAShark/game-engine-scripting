using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleScreen : MonoBehaviour
{
    public static int screenNumber = 1;

    public void StartGameButtonClicked()
    {
        CoinMechanics.score = 0;
        screenNumber = 1;

        SceneManager.LoadScene("Level 1");
        //load the next scene
    }
}
