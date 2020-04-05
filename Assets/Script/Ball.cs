using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    public float speed;
    public Text LeftScoreText;
    public Text RightScoreText;
    private int LeftScore;
    private int RightScore;
    public float random;
    public GameObject win;
    public GameObject leave;
    public GameObject lose;


    void Start()
    {
        win.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        leave.gameObject.SetActive(false);

        random = Random.Range(0, 100);

        // Initial Velocity
        if (random < 50) {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            Debug.Log("Right: "+random);
        }
        else if (random > 50) {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            Debug.Log("Left: "+random);
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
        if (col.gameObject.name == "Left Racket")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "Right Racket")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        //Score for Bot/Player2
        if (col.gameObject.name == "Left Wall")
        {
            RightScore++;
            RightScoreText.text = "" + RightScore;
        }
        //Score for Player1
        if (col.gameObject.name == "Right Wall")
        {
            LeftScore++;
            LeftScoreText.text = "" + LeftScore;
        }


        //Defeat for Player1
        if (RightScore == 10)
        {
            Time.timeScale = 0;
            lose.gameObject.SetActive(true);
            leave.gameObject.SetActive(true);

        }
        //Victory for Player1
        if (LeftScore == 10)
        {
            Time.timeScale = 0;
            win.gameObject.SetActive(true);
            leave.gameObject.SetActive(true);

        }

    }

}