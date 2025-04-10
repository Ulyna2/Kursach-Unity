using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 15f;
    private bool isGrounded = false;
    [SerializeField] private float fallThreshold = -10f;  // Порог для падения



    private Vector3 initialPosition;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Camera mainCamera; // Ссылка на основную камеру
    private float playerHeight; // Высота персонажа
    private bool isFalling = false;
    public int maxLives = 5; // Максимальное количество жизней
    public int currentLives; // Текущее количество жизней
    public Image[] livesImages; // Массив изображений для отображения жизней
    public Sprite fullHeart; // Спрайт полной жизни
    public Sprite emptyHeart; // Спрайт пустой жизни
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        mainCamera = Camera.main; // Получаем основную камеру
        playerHeight = sprite.bounds.size.y; // Получаем высоту персонажа
        currentLives = maxLives; // Инициализируем жизни при старте
        UpdateLivesUI(); // Обновляем UI жизней
        initialPosition = transform.position;

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Или к чекпоинту
    }
    private void FixedUpdate()
    {
        CheckGround();
        CheckFall();  // Проверка на падение
        RestrictPosition();  // Ограничение по верхней границе экрана
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }

    // Проверка падения персонажа за пределы экрана
    private void CheckFall()
    {
        if (transform.position.y < fallThreshold && !isFalling)
        {
            isFalling = true;
            LoseLife();
        }
        else if (transform.position.y < fallThreshold )
        {
            isFalling = false;
        }
    }

    // Ограничение по верхней границе экрана
    private void RestrictPosition()
    {
        // Получаем координаты верхнего предела экрана в мировых единицах
        float cameraHalfHeight = mainCamera.orthographicSize;

        // Получаем текущую позицию персонажа
        Vector3 clampedPosition = transform.position;

        // Ограничиваем Y позиции (по высоте экрана)
        clampedPosition.y = Mathf.Min(clampedPosition.y, cameraHalfHeight - playerHeight / 2);

        // Применяем ограниченную позицию (по X оставляем без изменений)
        transform.position = clampedPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
        }
    }
    // Функция для уменьшения жизней
    public void LoseLife()
    {
        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            RestartLevel(); // Перезапуск уровня, если жизни закончились
        }
        else
        {
            transform.position = initialPosition;
            isFalling = false;
        }
    }
    void UpdateLivesUI()
    {
        for (int i = 0; i < livesImages.Length; i++)
        {
            if (i < currentLives)
            {
                livesImages[i].sprite = fullHeart;
            }
            else
            {
                livesImages[i].sprite = emptyHeart;
            }
        }
    }



}
