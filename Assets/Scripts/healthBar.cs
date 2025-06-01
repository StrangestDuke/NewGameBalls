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
        // Значение хп слайдера = значение хп
        healthSlider.value = health;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Сколько нанесено урона
            takeDamage(10);
        }
        // Добавляет Анимацию желтого бара при уроне
        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
    }

    void takeDamage(float damage)
    {
        //Собственно сама механика урона
        health -= damage;
    }
}
