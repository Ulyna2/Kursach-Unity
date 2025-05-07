// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;


// public class Key : MonoBehaviour
// {
//     public bool keyCollected = false;
//     public Sprite emptyKeySprite;
//     public Sprite fullKeySprite;
//     public Image keyImage;
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             LevelManager levelManager = FindObjectOfType<LevelManager>();
//             if (levelManager != null)
//             {
//                 keyCollected = true;
//                 Debug.Log("Ключ собран!");
//                 keyImage.sprite = fullKeySprite;
//             }
//             Destroy(gameObject);
//         }
//     }
// }

