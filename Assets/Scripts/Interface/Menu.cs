using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ActiveLevelScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ActiveInfiniteLevelScene()
    {
        SceneManager.LoadScene(2);
    }
}
