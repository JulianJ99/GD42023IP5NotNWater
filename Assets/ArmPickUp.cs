using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmPickUp : MonoBehaviour
{
    public LayerMask mask;
    public Sprite closed;
    public float radius = 1f;
    public float offSet;
    public AudioClip clipToPlay;
    public new Collider2D collider;
    private int soapDestroyCount = 0;

    public GameManagementV2 gameManagement;

    private AudioSource audioSource = null;

    [SerializeField]
    private ArmMechanic armMechanic;

    private void Awake()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        //gameManagement = GameObject.FindGameObjectWithTag("gamemanager");
        //armMechanic = new ArmMechanic();
    }

    // Update is called once per frame
    void Update()
    {
        collider = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + offSet), radius, mask);
        if (collider != null)
        {
            //Debug.Log(collider.name);
            Destroy(collider.transform.gameObject);
            this.PlaySound();
            GetComponent<SpriteRenderer>().sprite = closed;
            soapDestroyCount++;
            armMechanic.IsSoapPickedUp();
            if (soapDestroyCount == 3)
            {
                gameManagement.WinGame();
                Debug.Log("Game won!");
            }
        }
    }

    private void PlaySound()
    {
        if (this.audioSource == null)
            return;

        this.audioSource.PlayOneShot(clipToPlay);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y + offSet), radius);
    }
}
