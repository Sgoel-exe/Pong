using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CampaignAI : MonoBehaviour
{
    public int score = 3;
    public Text Text;
    public int nextLevel = 2;
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
        if (collision.gameObject.tag == "Ball")
        {
            score--;
            Text.text = score.ToString();
            if (score == 0)
            {
                SceneManager.LoadScene("Level" + nextLevel);
            }
            collision.gameObject.GetComponent<BallScript>().ResetBall(transform.position.x);
        }
    }
}
