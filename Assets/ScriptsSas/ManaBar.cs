using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;


public class manaBar : MonoBehaviour
{
    stats statistic;
    [SerializeField] public TextMeshProUGUI manaCount;
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxMana;
    public float mana;
    private float lerpSpeed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static manaBar instanceManaBar;

    private void Awake()
    {
        if (instanceManaBar != null)
        {
            Debug.LogWarning("You fucked up status instance");
            return;
        }
        instanceManaBar = this;
    }
    void Start()
    {
        statistic = stats.instanceStats;
        mana = statistic.СurrentMana;
        maxMana = statistic.maxMana;

        manaCount.text = mana.ToString();
    }

    // Update is called once per frame
    void Update()    
    {
        // Çíà÷åíèå õï ñëàéäåðà = çíà÷åíèå õï
        healthSlider.value = mana;
        // Äîáàâëÿåò Àíèìàöèþ æåëòîãî áàðà ïðè óðîíå
        easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, mana, lerpSpeed);
    }

    public void takeDamage(float damage)
    {
        //Ñîáñòâåííî ñàìà ìåõàíèêà óðîíà
        if (maxMana >= mana + damage)
        {
            mana += damage;

            manaCount.text = mana.ToString();
        }
    }
    public void maxDamage(float damage)
    {
        //Ñîáñòâåííî ñàìà ìåõàíèêà óðîíà
        if (maxMana >= mana + damage)
        {
            mana += damage;
            healthSlider.maxValue += damage;
            easeHealthSlider.maxValue += damage;
            manaCount.text = mana.ToString();
        }
    }
}
