using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Player player; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Jump
        // GetKeyDown() does not work in FixedUpdate()
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.Jump();
        }
    }

    void FixedUpdate()
    {
        // Roll left/right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.AddTorque(-40); // clockwise
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.AddTorque(40); // counter-clockwise
        }
    }
}
