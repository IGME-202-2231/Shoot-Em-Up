using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        // Reload the current scene (restart the game)
        SceneManager.LoadScene("Gameplay");
    }

}
