using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y= Input.GetAxisRaw("Vertical");
        IsMovement = movement !=  Vector2.zero ? true : false;
    }
}
