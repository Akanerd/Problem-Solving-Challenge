using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inheritance Mengambil kelas Movement
public class PlayerMovementbyMouse : Movement
{
    // Update is called once per frame
    void Update()
    {
        Vector3 inp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        movement = (inp - this.transform.position).normalized * 2f;

        IsMovement = Vector2.Distance(transform.position, inp) >= 1f ? true : false;
    }
}
