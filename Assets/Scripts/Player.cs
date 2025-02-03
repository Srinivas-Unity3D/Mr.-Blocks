using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    public float speed = 5f;

    private Rigidbody2D rb;

    public LevelManager levelManager;

    private SoundManager soundManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        soundManager = FindObjectOfType<SoundManager>();

        if (soundManager == null)
        {
            Debug.LogError("SoundManager not found in the scene.");
        }
    }

    private void Update()
    {
        GetInput();
       // MovePlayer();
    }

    private void FixedUpdate() => MovePlayer();

    private void GetInput() 
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer() 
    {
        //Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        //Vector3 moveDelta = moveDirection.normalized * speed * Time.deltaTime;
        //transform.position += moveDelta;

        Vector2 newVelocity = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle")) 
        {
            PlayerDie();
        }
    }

    private void PlayerDie() 
    {
        soundManager.PlayGameOverAudio();
        levelManager.OnPlayerDeath();
        // Restart Level while clicking button
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Finish")) 
        {
            LevelComplete();
        }
    }

    private void LevelComplete() 
    {
        soundManager.PlayLevelCompleteAudio();
        levelManager.OnLevelComplete();
    }
}
