    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCollision : MonoBehaviour
{
    public float stunDuration;
    public float pushBack;
    private PlayersMovement playersMovement;
    private GameManagementV2 localGameManagement;
    public GameObject stunEffect;
    public AudioClip bumpingSound;
    // Start is called before the first frame update
    void Start()
    {
       localGameManagement = FindObjectOfType<GameManagementV2>();
        playersMovement = GetComponent<PlayersMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        stunEffect.transform.position = new Vector2(transform.position.x, transform.position.y + 2.7f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Obstacle")
        {
            PlayBumpingSound();
            StartCoroutine(playersMovement.BumpedIntoObject(stunDuration, pushBack, stunEffect));
        }
       else if (collision.collider.tag == "Ground")
        {
            playersMovement.jumpingState = "ready_to_jump";
        }
       else if (collision.collider.tag == "Goal")
        {
            localGameManagement.WinGame();
            Debug.Log("Game won!");
        }
    }
    
    private void PlayBumpingSound()
    {
        if (bumpingSound != null)
        {
            GetComponent<AudioSource>().PlayOneShot(bumpingSound);
        }
    }

}
