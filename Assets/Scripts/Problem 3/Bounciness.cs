using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Kelas Bounciness Merupakan kelas Inheritance dari Kelas Movement
public class Bounciness: Movement
{
    // Inisialisasi Thrust dengan value 10f;
    private float Thrust = 10f;

    // Override
    private void FixedUpdate() { }

    // Override dari kelas Movement pada Method MovementBall
    protected override void Movementball()
    {
        //Mengambil Method MovementBall
        base.Movementball();
        //Memberi gaya Awal pada bola dimainkan dengan movement * movementSpeed
        RigidBody2D.AddForce(movement * movementSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Jika Colision Bertabrakan dengan object bernama wall dan RigidBody tidak null
        if (collision.gameObject.CompareTag("Wall") && RigidBody2D != null)
        {
            // Maka kecepatan diubah menjadi 0
            RigidBody2D.velocity = Vector2.zero;
            // Kemudian Menambahkan addforce pada bola ketika memantul kembali
            RigidBody2D.AddForce(Vector2.up * Thrust);
        }
        
    }
}
