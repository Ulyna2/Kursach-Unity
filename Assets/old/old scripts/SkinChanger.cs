using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    // ��������� ���������� ��� ��������. �� �������� ����� ���������� � ����������.
    public Sprite defaultSkin;
    public Sprite alternateSkin;

    // ��������� ���������� ��� �������� ������ �� ��������� SpriteRenderer.
    private SpriteRenderer spriteRenderer;

    // ��������� ���������� ��� ������������ �������� �����.
    private bool isAlternateSkin = false;

    // ����� Start ���������� ���� ��� ��� ������� ����.
    void Start()
    {
        // �������� ������ �� ��������� SpriteRenderer.
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ������������� ��������� ����.
        spriteRenderer.sprite = defaultSkin;
    }

    // ����� Update ���������� ������ ����.
    void Update()
    {
        // ���������, ���� �� ������ ������� "S".
        if (Input.GetKeyDown(KeyCode.S))
        {
            // ������ �������� ���������� isAlternateSkin �� ���������������.
            isAlternateSkin = !isAlternateSkin;

            // ���������� ��������� �������� ��� ������ �����.
            // ���� isAlternateSkin == true, �� ������������� alternateSkin, ����� defaultSkin.
            spriteRenderer.sprite = isAlternateSkin ? alternateSkin : defaultSkin;
        }
    }
}