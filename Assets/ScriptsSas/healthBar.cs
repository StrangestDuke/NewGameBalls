using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;


public class healthBar : MonoBehaviour
{
    [SerializeField] stats statistic;

    [SerializeField] public TextMeshProUGUI hpCount;
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth;
    public float health;
    private float lerpSpeed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = statistic.СurrentHealth;
        maxHealth = statistic.maxHealth;
        hpCount.text = health.ToString();
    }

    // Update is called once per frame
    void Update()    
    {
        // Çíà÷åíèå õï ñëàéäåðà = çíà÷åíèå õï
        healthSlider.value = health;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Ñêîëüêî íàíåñåíî óðîíà
            takeDamage(10);
        }
        // Äîáàâëÿåò Àíèìàöèþ æåëòîãî áàðà ïðè óðîíå
        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);

    }

    public void takeDamage(float damage)
    {
        if (maxHealth >= health + damage)
        {
            health += damage;

            hpCount.text = health.ToString();
        }

    }
}
