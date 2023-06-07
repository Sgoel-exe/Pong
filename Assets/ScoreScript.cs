using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            score++;
            Text.text = score.ToString();
            if(score == 5)
            {
                WhoWon();
            }
            collision.gameObject.GetComponent<BallScript>().ResetBall(transform.position.x);
        }
    }

    void WhoWon()
    {
        if(transform.position.x > 0)
        {
            SceneManager.LoadScene("P1Won");
        }
        else
        {
            SceneManager.LoadScene("P2Won");
        }
    }

}
