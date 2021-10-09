using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inheritance Mengambil kelas Movement
public class PlayerMovement : Movement
{
    // Update is called once per frame
    void Update()
    {
        //Movement Player by Input Key - Movemet Horizontal
        movement.x = Input.GetAxisRaw("Horizontal");
        //Movement Player by Input Key -Movement Vertical
        movement.y= Input.GetAxisRaw("Vertical");

        IsMovement = movement !=  Vector2.zero ? true : false;
    }
}
