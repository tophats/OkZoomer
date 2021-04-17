using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ZoomerMechanics : MonoBehaviour {

    //Public variables

    public float currentZoomPercentage = 1f;
    public PlayerController player;
    public float maxSpeedDefault;
    public float maxJumpDefault;
    public float defaultGravityMod;

    public float minZoom = 0.1f, maxZoom = 2.0f;
    public float changeSize;
    public float time;
    private float timePassed = 0.0f;
    private Vector3 originalScale;
    private bool active = false;

    //TODO - Over time
    private float progress;

    void Start()
    {
        originalScale = transform.localScale;
        maxSpeedDefault = player.maxSpeed;
        maxJumpDefault = player.jumpTakeOffSpeed;
        defaultGravityMod = player.gravityModifier;
    }

    private void FixedUpdate()
    {

        //Debug.Log(currentZoomPercentage);

        //Test Controls
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            shrink();
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            grow();
        }

        if (active) {
            timePassed += Time.deltaTime * 1000.0f;
            //0 - 1 with time
            progress = (timePassed / time);

            currentZoomPercentage = Mathf.Clamp(currentZoomPercentage, minZoom, maxZoom);

            transform.localScale = new Vector3(
                            currentZoomPercentage * originalScale.x,
                            currentZoomPercentage * originalScale.y,
                            currentZoomPercentage * originalScale.z
                        );
        }

        //player.maxSpeed = maxSpeedDefault * (currentZoomPercentage);
        //player.jumpTakeOffSpeed = maxJumpDefault * (currentZoomPercentage);
        //player.gravityModifier = defaultGravityMod * currentZoomPercentage;
    
    }

    public void grow()
    {
        active = true;
        currentZoomPercentage += changeSize;
        this.transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        timePassed = 0.0f;
    }

    public void shrink()
    {
        active = true;
        currentZoomPercentage -= changeSize;
        timePassed = 0.0f;
    }

    ///////////////////////////////////////////////////////////////////

    /*//Public variables
    //When triggering shrink() GameObject will scale down to [shrunkScale] over [time]
    public Vector3 shrunkScale;
    //When triggering grow() GameObject will scale up to [grownScale] over [time]
    public Vector3 grownScale;
    //Growth/shriuking time (MILLISECONDS)
    public float time;
    //Private variables
    private bool active = false;
    private Vector3 originalScale;
    //private bool shrinking;
    private float timePassed = 0.0f;
    private float progress;
    private enum State { SHRUNKEN, ORIGINAL_SIZE, GROWN }
    private State state = State.ORIGINAL_SIZE;
    private enum Actions { SHRINKING, NORMALIZING, GROWING }
    private Actions action = Actions.NORMALIZING;
 
    // Use this for initialization
    void Start ()
    {
        originalScale = transform.localScale;
    }
 
    private void FixedUpdate()
    {
          
           if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("TEST");
            shrink();
           }

            if (Input.GetKeyDown(KeyCode.S)) {

            grow();
           }



        if (active)
        {
            timePassed += Time.deltaTime * 1000.0f;
            //0 - 1 with time
            progress = (timePassed / time);
        }
        switch (action) {
            case Actions.NORMALIZING:
                switch (state) {
                    case State.SHRUNKEN:
                        transform.localScale = new Vector3(
                            (1 - progress) * shrunkScale.x + progress * originalScale.x,
                            (1 - progress) * shrunkScale.y + progress * originalScale.y,
                            (1 - progress) * shrunkScale.z + progress * originalScale.z
                        );
                        break;
                    case State.GROWN:
                        transform.localScale = new Vector3(
                            (1 - progress) * grownScale.x + progress * originalScale.x,
                            (1 - progress) * grownScale.y + progress * originalScale.y,
                            (1 - progress) * grownScale.z + progress * originalScale.z
                        );
                        break;
                    default:
                        break;
                }
                break;
            case Actions.GROWING:
                switch (state)
                {
                    case State.SHRUNKEN:
                        transform.localScale = new Vector3(
                            (1 - progress) * shrunkScale.x + progress * grownScale.x,
                            (1 - progress) * shrunkScale.y + progress * grownScale.y,
                            (1 - progress) * shrunkScale.z + progress * grownScale.z
                        );
                        break;
                    case State.ORIGINAL_SIZE:
                        transform.localScale = new Vector3(
                            (1 - progress) * originalScale.x + progress * grownScale.x,
                            (1 - progress) * originalScale.y + progress * grownScale.y,
                            (1 - progress) * originalScale.z + progress * grownScale.z
                        );
                        break;
                    default:
                        break;
                }
                break;
            case Actions.SHRINKING:
                switch (state)
                {
                    case State.ORIGINAL_SIZE:
                        transform.localScale = new Vector3(
                            (1 - progress) * originalScale.x + progress * shrunkScale.x,
                            (1 - progress) * originalScale.y + progress * shrunkScale.y,
                            (1 - progress) * originalScale.z + progress * shrunkScale.z
                        );
                        break;
                    case State.GROWN:
                        transform.localScale = new Vector3(
                            (1 - progress) * grownScale.x + progress * shrunkScale.x,
                            (1 - progress) * grownScale.y + progress * shrunkScale.y,
                            (1 - progress) * grownScale.z + progress * shrunkScale.z
                        );
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        if (progress >= 1)
        {
            active = false;
            switch (action) {
                case Actions.GROWING:
                    state = State.GROWN;
                    break;
                case Actions.NORMALIZING:
                    state = State.ORIGINAL_SIZE;
                    break;
                case Actions.SHRINKING:
                    state = State.SHRUNKEN;
                    break;
            }
        }
    }
 
    public void grow()
    {
        active = true;
        action = Actions.GROWING;
        timePassed = 0.0f;
    }
 
    public void shrink()
    {
        active = true;
        action = Actions.SHRINKING;
        timePassed = 0.0f;
    }
 
    public void originalSize()
    {
        active = true;
        action = Actions.NORMALIZING;
        timePassed = 0.0f;
    }*/
}
