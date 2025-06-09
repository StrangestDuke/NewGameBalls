using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class hungerBar : MonoBehaviour
{
    stats statistics;

    [SerializeField] public TextMeshProUGUI hunCount;
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHunger;
    public float hunger;
    private float lerpSpeed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static hungerBar instanceHungerBar;

    private void Awake()
    {
        if (instanceHungerBar != null)
        {
            Debug.LogWarning("You fucked up status instance");
            return;
        }
        instanceHungerBar = this;
    }
    void Start()
    {
        statistics = stats.instanceStats;
        hunger = statistics.СurrentHunger;
        maxHunger = statistics.maxHunger;

        hunCount.text = hunger.ToString();
    }

    // Update is called once per frame
    void Update()    
    {
        // Çíà÷åíèå õï ñëàéäåðà = çíà÷åíèå õï
        healthSlider.value = hunger;
        // Äîáàâëÿåò Àíèìàöèþ æåëòîãî áàðà ïðè óðîíå
        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, hunger, lerpSpeed);
    }

    public void takeDamage(float damage)
    {
        if (maxHunger >= hunger + damage)
        {
            hunger += damage;

            hunCount.text = hunger.ToString();
        }
    }

    public void maxDamage(float damage)
    {
        if (maxHunger >= hunger + damage)
        {
            hunger += damage;

            healthSlider.maxValue += damage;
            easeHealthSlider.maxValue += damage;
            hunCount.text = hunger.ToString();
        }
    }
}
