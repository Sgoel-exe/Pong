using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartVsHuman()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartVsAI()
    {
        SceneManager.LoadScene("AImenu");
    }

    public void StartVsAIeasy()
    {
        SceneManager.LoadScene("Level1");
    }

    public void startVsAImed()
    {
        SceneManager.LoadScene("Level2");
    }

    public void startVsAIhard()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadScene("Start");
    }
}
