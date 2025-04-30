using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.hasKey = true;
                Debug.Log("Ключ подобран!");
                Destroy(gameObject); // удаляем ключ
            }
        }
    }
}
