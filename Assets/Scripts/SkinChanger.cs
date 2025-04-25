using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    // Публичные переменные для спрайтов. Их значения будут задаваться в инспекторе.
    public Sprite defaultSkin;
    public Sprite alternateSkin;

    // Приватная переменная для хранения ссылки на компонент SpriteRenderer.
    private SpriteRenderer spriteRenderer;

    // Приватная переменная для отслеживания текущего скина.
    private bool isAlternateSkin = false;

    // Метод Start вызывается один раз при запуске игры.
    void Start()
    {
        // Получаем ссылку на компонент SpriteRenderer.
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Устанавливаем начальный скин.
        spriteRenderer.sprite = defaultSkin;
    }

    // Метод Update вызывается каждый кадр.
    void Update()
    {
        // Проверяем, была ли нажата клавиша "S".
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Меняем значение переменной isAlternateSkin на противоположное.
            isAlternateSkin = !isAlternateSkin;

            // Используем тернарный оператор для выбора скина.
            // Если isAlternateSkin == true, то устанавливаем alternateSkin, иначе defaultSkin.
            spriteRenderer.sprite = isAlternateSkin ? alternateSkin : defaultSkin;
        }
    }
}