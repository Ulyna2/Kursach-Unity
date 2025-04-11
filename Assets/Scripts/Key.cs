using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. ���������� LevelManager, ��� ���� ������.

            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null)
            {
                levelManager.KeyCollected();  // �������� ����� � LevelManager
            }
            else
            {
                Debug.LogError("LevelManager �� ������ �� �����!");
            }
            
            Destroy(gameObject);
        }
    }
}

