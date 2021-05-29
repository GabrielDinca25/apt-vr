using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightController : MonoBehaviour
{
    public float speed = 5f;
    public float maxHeight = 100f;
    public bool isAdult = true;

    private GameObject player;
    private Rigidbody playerRB;
    private float playerMaxHeight;

    private GameObject playerSteamVr;
    private Transform playerSteamVrTransform;
    private Vector3 playerSteamVrInitialPosition;

    private Transform plank;
    private Rigidbody plankRB;
    private Vector3 plankInitialPosition;

    bool goUp;
    bool goDown;


    void Start()
    {
        plank = GameObject.FindGameObjectWithTag("Plank").transform;
        plankRB = plank.gameObject.GetComponent<Rigidbody>();
        plankInitialPosition = plank.position;

        player = GameObject.FindGameObjectWithTag("Player");

        playerSteamVr = GameObject.FindGameObjectWithTag("PlayerSteamVR");
        playerRB = playerSteamVr.GetComponent<Rigidbody>();
        playerSteamVrTransform = playerSteamVr.transform;
        playerSteamVrInitialPosition = playerSteamVrTransform.position;

        if (isAdult == false)
        {
            maxHeight = 10f;
        }

        playerMaxHeight = maxHeight + player.transform.position.y;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            goUp = true;
            // Vector3 nextPosition = plank.position + Vector3.up;

            // plank.position = Vector3.MoveTowards(plank.position, nextPosition, Time.fixedDeltaTime * speed);

            // float plankYPosition = Mathf.Clamp(plank.position.y, plankInitialPosition.y, maxHeight);
            // plank.position = new Vector3(plank.position.x, plankYPosition, plank.position.z);
        }
        else
        {
            goUp = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            goDown = true;
            // Vector3 nextPosition = plank.position - Vector3.up;

            // plank.position = Vector3.MoveTowards(plank.position, nextPosition, Time.fixedDeltaTime * speed);

            // float plankYPosition = Mathf.Clamp(plank.position.y, plankInitialPosition.y, maxHeight);
            // plank.position = new Vector3(plank.position.x, plankYPosition, plank.position.z);
        }
        else
        {
            goDown = false;
        }
    }

    void FixedUpdate()
    {
        if (goUp)
        {
            playerRB.MovePosition(playerSteamVrTransform.position + Vector3.up * Time.deltaTime * speed);
            plankRB.MovePosition(plank.position + Vector3.up * Time.deltaTime * speed);

            float playerYPosition = Mathf.Clamp(playerSteamVrTransform.position.y, playerSteamVrInitialPosition.y, playerMaxHeight);
            if (playerYPosition != playerSteamVrTransform.position.y)
            {
                playerSteamVrTransform.position = new Vector3(playerSteamVrTransform.position.x, playerYPosition, playerSteamVrTransform.position.z);
            }

            float plankYPosition = Mathf.Clamp(plank.position.y, plankInitialPosition.y, maxHeight);
            if (playerYPosition != playerSteamVrTransform.position.y)
            {
                plank.position = new Vector3(plank.position.x, plankYPosition, plank.position.z);
            }
        }

        if (goDown)
        {
            playerRB.MovePosition(playerSteamVrTransform.position - Vector3.up * Time.deltaTime * speed);
            plankRB.MovePosition(plank.position - Vector3.up * Time.deltaTime * speed);

            float playerYPosition = Mathf.Clamp(playerSteamVrTransform.position.y, playerSteamVrInitialPosition.y, playerMaxHeight);
            if (playerYPosition != playerSteamVrTransform.position.y)
            {
                playerSteamVrTransform.position = new Vector3(playerSteamVrTransform.position.x, playerYPosition, playerSteamVrTransform.position.z);
            }

            float plankYPosition = Mathf.Clamp(plank.position.y, plankInitialPosition.y, maxHeight);
            if (playerYPosition != playerSteamVrTransform.position.y)
            {
                plank.position = new Vector3(plank.position.x, plankYPosition, plank.position.z);
            }
        }
    }

    // void LateUpdate()
    // {
    //     if (goUp)
    //     {
    //         playerSteamVrTransform.position += Vector3.up * speed * Time.deltaTime;
    //     }

    //     if (goDown)
    //     {
    //         playerSteamVrTransform.position -= Vector3.up * speed * Time.deltaTime;
    //     }
    //     float playerYPosition = Mathf.Clamp(playerSteamVrTransform.position.y, playerSteamVrInitialPosition.y, maxHeight);
    //     playerSteamVrTransform.position = new Vector3(playerSteamVrTransform.position.x, playerYPosition, playerSteamVrTransform.position.z);
    // }


    // Vector3 nextPosition = plank.position + Vector3.up;

    //         plank.position = Vector3.MoveTowards(plank.position, nextPosition, Time.fixedDeltaTime * speed);

    //         float plankYPosition = Mathf.Clamp(plank.position.y, plankInitialPosition.y, maxHeight);
    //         plank.position = new Vector3(plank.position.x, plankYPosition, plank.position.z);

    //         playerSteamVrTransform.position += Vector3.MoveTowards(playerSteamVrTransform.position, nextPosition, Time.fixedDeltaTime * speed);

    //         float playerYPosition = Mathf.Clamp(playerSteamVrTransform.position.y, playerSteamVrInitialPosition.y, maxHeight);
    //         playerSteamVrTransform.position = new Vector3(playerSteamVrTransform.position.x, playerYPosition, playerSteamVrTransform.position.z);

}
