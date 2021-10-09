using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Note : [SerializeField] Digunakan untuk menampilkan variabel yang diprivate atau protected pada Inspector

    //Inisialisasi variabel RigidBody2D pada Bola
    [SerializeField] protected Rigidbody2D RigidBody2D;
    //Inisialisasi variabel kecepatan pada Bola
    [SerializeField] protected float movementSpeed;
    //Inisialisasi variabel pergerakan (arah) bola
    protected Vector2 movement;
    //Inisialisasi variabel boolean untuk menentukan true / falsenya bola 
    protected bool IsMovement;

    private void Start()
    {
        //Run Method MovementBall
        Movementball();
    }

    protected virtual void Movementball()
    {
        //Set Ismovement mejadi True 
        IsMovement = true;
        // Set Arah bola menjadi random
        movement = Random.insideUnitCircle.normalized;
    }

    private void FixedUpdate()
    {
        //Jika IsMovement ==  true
        if (IsMovement)
        {
            // Maka kecepatan bola dihitung dengan movement * movementSpeed * Time.deltaTime
            RigidBody2D.velocity = movement * movementSpeed * Time.deltaTime;
        }
        else
        {
            //Jika IsMovement == false maka set kecepatan menjadi 0
            RigidBody2D.velocity = Vector2.zero;
        }
    }
}
