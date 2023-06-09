using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CampaignScript : MonoBehaviour
{
    public int score = 3;
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
        if (collision.gameObject.tag == "Ball")
        {
            score--;
            Text.text = score.ToString();
            if (score == 0)
            {
                SceneManager.LoadScene("YouLost");
            }
            collision.gameObject.GetComponent<BallScript>().ResetBall(transform.position.x);
        }
    }
}
