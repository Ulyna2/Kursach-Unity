using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. Уведомляем LevelManager, что ключ собран.

            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null)
            {
                levelManager.KeyCollected();  // Вызываем метод в LevelManager
            }
            else
            {
                Debug.LogError("LevelManager не найден на сцене!");
            }
            
            Destroy(gameObject);
        }
    }
}

