using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool HasRing;
    private void Awake()
    {
        Instance = this;
    }

    public void SetRing()
    { 
        HasRing = true;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
