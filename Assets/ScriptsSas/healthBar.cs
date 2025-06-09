using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;


public class healthBar : MonoBehaviour
{
    stats statistic;

    [SerializeField] public TextMeshProUGUI hpCount;
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth;
    public float health;
    private float lerpSpeed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static healthBar instanceHPBar;

    private void Awake()
    {
        if (instanceHPBar != null)
        {
            Debug.LogWarning("You fucked up status instance");
            return;
        }
        instanceHPBar = this;
    }
    void Start()
    {
        statistic = stats.instanceStats;
        health = statistic.СurrentHealth;
        maxHealth = statistic.maxHealth;
        hpCount.text = health.ToString();
    }

    // Update is called once per frame
    void Update()    
    {
        // Çíà÷åíèå õï ñëàéäåðà = çíà÷åíèå õï
        healthSlider.value = health;
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

    public void maxDamage(float damage)
    {
        if (maxHealth >= health + damage)
        {
            health += damage;
            healthSlider.maxValue += damage;
            easeHealthSlider.maxValue += damage;
            hpCount.text = health.ToString();
        }

    }
}
