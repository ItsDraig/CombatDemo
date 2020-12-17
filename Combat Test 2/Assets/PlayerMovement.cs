using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;

    public float moveSpeed = 6f;   //speed of the player
    public bool canAct = true;

    private Vector3 origin;     // where the player starts - becomes centre point for fight
    private Vector3 target;     // destination for player movement

    float buttonCooldown = 0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        SetStart();
    }

    public void SetStart()
    {
        origin = transform.position;    // Can edit this to set origin to different position if area is small (or something)
        transform.position = origin;
    }

    void Update()     // Update is called once per frame
    {
        
    }

    void FixedUpdate()  // Update is called once per frame based on framerate
    {
        if (buttonCooldown > 0f)
        {
            buttonCooldown -= 0.5f * Time.deltaTime;
            if (buttonCooldown < 0.2f) 
            {
                StartCoroutine(PlayerMove(origin));
            }
        } 
        else 
        {
            buttonCooldown = 0f;   
        }

        if (Input.GetKeyDown("d") && canAct) { 
        // BASIC EVADE: Press once from neutral
        // SLASH: Single tap while pressing K
        // LUNGE: Double tap while pressing K on second input
        // SHIELD BASH: Double tap while pressing L on second input

            if (transform.position == origin && buttonCooldown == 0f) { // Basic evade
                buttonCooldown = 1f;
                target.y = origin.y;
                target.x = origin.x+0.4f;

                StartCoroutine(PlayerMove(target));              
            }
            else if (transform.position.x >= origin.x && buttonCooldown >= 0.8) // Set up for attack
            {
                Debug.Log("Ready for Counter!");
            } 
        }

        if (Input.GetKeyDown("a") && canAct) { 
        // BASIC EVADE: Press once from neutral
        // ROLL/DASH: Press twice in quick succession
        // DODGE DIAGONAL UP: Press once then press W (quarter circle up)
        // DODGE DIAGONAL DOWN: Press once then press S (quarter circle down)

            if (transform.position == origin && buttonCooldown == 0f) { // Basic evade
                buttonCooldown = 1f;
                target.y = origin.y;
                target.x = origin.x-0.4f;

                StartCoroutine(PlayerMove(target));
            }
            else if (transform.position.x <= origin.x && buttonCooldown >= 0.6) // Roll
            {
                target.x = origin.x-2f;
                
                StartCoroutine(PlayerMove(target));
            } 
        }

        if (Input.GetKeyDown("w") && canAct) { 
        // BASIC EVADE: Press once from neutral

            if (transform.position == origin && buttonCooldown == 0f) { // Basic evade
                buttonCooldown = 1f;
                target.x = origin.x;
                target.y = origin.y+1.5f;

                StartCoroutine(PlayerMove(target));
            }
        }

        if (Input.GetKeyDown("s") && canAct) { 
        // BASIC EVADE: Press once from neutral

            if (transform.position == origin && buttonCooldown == 0f) { // Basic evade
                buttonCooldown = 1f;
                target.x = origin.x;
                target.y = origin.y-1.5f;

                StartCoroutine(PlayerMove(target));
            }
        }
     
        if (Input.GetKeyDown("j")) // BLOCK
        {
            //anim.SetTrigger("block")
        }

    }

    private IEnumerator PlayerMove(Vector3 target)
    {
        //animator.SetBool("Dashing", true);
        canAct = false;
        while(transform.position != target) {
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
        canAct = true;
    }
}
