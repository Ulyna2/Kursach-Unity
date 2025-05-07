// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class FlyingEnemy_5 : MonoBehaviour
// {
//     public LevelManager levelManager;
//     public float speed = 2f;

//     private Transform player;
//     private Vector3 initialPosition;

//     private void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player").transform;
//         initialPosition = transform.position; // запоминаем стартовую позицию
//     }

//     private void FixedUpdate()
//     {
//         if (player != null)
//         {
//             transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Player"))
//         {
//             hero playerScript = collision.GetComponent<hero>();

//             if (playerScript != null)
//             {
//                 playerScript.LoseLife();

//                 // После потери жизни враг возвращается в начальную позицию
//                 transform.position = initialPosition;
//             }
//         }
//     }
// }
