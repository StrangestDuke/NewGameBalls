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
        // Çíà÷åíèå õï ñëàéäåðà = çíà÷åíèå õï да
        healthSlider.value = health;
        // Äîáàâëÿåò Àíèìàöèþ æåëòîãî áàðà ïðè óðîíå
        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
    }
}
