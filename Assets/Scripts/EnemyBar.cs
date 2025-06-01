using UnityEngine;
using UnityEngine.UI;

public class enemyBar: MonoBehaviour
{
    [SerializeField] Enemy enemyBarHp;
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = enemyBarHp.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Значение хп слайдера = значение хп
        healthSlider.value = health;
        // Добавляет Анимацию желтого бара при уроне
        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
    }
}
