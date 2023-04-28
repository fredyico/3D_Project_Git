using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody rb;

    private bool isGrounded;

    public int score;
    public TextMeshProUGUI scoreText;

    public int healthPoints = 2;
    public TextMeshProUGUI healthText;
    public AudioClip hitSound;

    private void Start()
    {
        healthText.text = "HP: " + healthPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // getting the keyboard inputs 
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float z = Input.GetAxisRaw("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);

        // create a temporary velocity vector and cancel out the y.
        Vector3 vel = rb.velocity;
        vel.y = 0;

        // if the player is moving, rotate to face that direction
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        //lock the jump in the air || If press SPACE and are on the ground, jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (transform.position.y <= -5)
        {
            GameOver();
        }

        if (healthPoints == 0)
        {
            GameOver();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the player collided with a ground surface, he is grounded
        if (collision.GetContact(0).normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void GameOver()
    {
        //Index of the current scene. This will loop the game to the 1st scene whenever enters game over
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        //Update score text UI
        scoreText.text = "Score: " + score.ToString();
    }

    public void ControlHealth(int hit)
    {
        healthPoints -= hit;
        AudioSource.PlayClipAtPoint(hitSound, transform.position);
        //update healthPoints text UI
        healthText.text = "HP: " + healthPoints.ToString();
    }
}
