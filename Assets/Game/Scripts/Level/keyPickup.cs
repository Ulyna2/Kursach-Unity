using UnityEngine;
using UnityEngine.UI;


public class KeyPickup : MonoBehaviour
{
    public bool keyCollected = false;
    public Sprite emptyKeySprite;
    public Sprite fullKeySprite;
    public Image keyImage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.hasKey = true;
                keyImage.sprite = fullKeySprite;  
            }
            Destroy(gameObject);
        }
    }
}