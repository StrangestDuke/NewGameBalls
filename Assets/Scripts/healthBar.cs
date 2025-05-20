using UnityEngine;
using UnityEngine.UI;


public class healthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()    
    {
        // �������� �� �������� = �������� ��
        healthSlider.value = health;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //������� �������� �����
            takeDamage(10);
        }
        // ��������� �������� ������� ���� ��� �����
        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
    }

    void takeDamage(float damage)
    {
        //���������� ���� �������� �����
        health -= damage;
    }
}
