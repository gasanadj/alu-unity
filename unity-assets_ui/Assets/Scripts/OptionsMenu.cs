using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void Back()
    {
        int previousScene = SceneManager.GetActiveScene().buildIndex - 1;
        if (previousScene >= 0)
        {
            SceneManager.LoadScene(previousScene);
        } else
        {
            Debug.LogWarning("No previous scene to load!");
        }

    }
}
