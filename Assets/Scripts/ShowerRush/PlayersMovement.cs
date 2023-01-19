using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayersMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playersSpeed;
    public float playersJumpForce;
    public string jumpingState = "ready_to_jump";
    public bool couldMove = true;
    public GameObject crouchingSprite;
    private Sprite normalSprite;
    public float jumpingTime = 0.5f;
    private bool isCrouching = false;
    private Vector2 initialPosition;
    
    void Start()
    {
        normalSprite = GetComponent<SpriteRenderer>().sprite;
        couldMove = true;
        initialPosition = transform.position;
    }
    private void Update()
    {
        if (couldMove)
        {
            if (Input.GetKeyDown(KeyCode.W) && jumpingState == "ready_to_jump" && !isCrouching)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 765));
                jumpingState = "currently_jumping";
                StartCoroutine(JumpingSequence());
            }
            else if (Input.GetKeyDown(KeyCode.S)&& jumpingState != "currently_jumping")
            {
                if (!isCrouching)
                {
                    GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 0.38f);
                    GetComponent<SpriteRenderer>().sprite = crouchingSprite.GetComponent<SpriteRenderer>().sprite;
                    isCrouching = true;
                }
                else
                {
                    GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 0.5f);
                    GetComponent<SpriteRenderer>().sprite = normalSprite;
                    isCrouching = false;
                }
            }
        }
      
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (couldMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                Debug.Log("TRUE");
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + playersSpeed, gameObject.transform.position.y);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("TRUE");
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - playersSpeed, gameObject.transform.position.y);
            }
            if (jumpingState == "currently_jumping")
            {
               // gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + playersJumpForce / (50 / 3));

            }
        }
    }

    public IEnumerator JumpingSequence()
    {
        yield return new WaitForSeconds(0.33f);
        jumpingState = "could_not_jump";
    }
    public IEnumerator BumpedIntoObject(float stunDuration, float pushBack, GameObject objectToDisplay)
    {
        couldMove = false;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - pushBack, gameObject.transform.position.y);
        objectToDisplay.SetActive(true);
        yield return new WaitForSeconds(stunDuration);
        objectToDisplay.SetActive(false);
        couldMove = true;
    }

}
