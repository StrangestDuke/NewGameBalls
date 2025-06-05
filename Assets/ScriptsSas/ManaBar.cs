using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;


public class manaBar : MonoBehaviour
{
    [SerializeField] stats statistic;

    [SerializeField] public TextMeshProUGUI manaCount;
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxMana;
    public float mana;
    private float lerpSpeed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mana = statistic.СurrentMana;
        maxMana = statistic.maxMana;

        manaCount.text = mana.ToString();
    }

    // Update is called once per frame
    void Update()    
    {
        // Çíà÷åíèå õï ñëàéäåðà = çíà÷åíèå õï
        healthSlider.value = mana;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Ñêîëüêî íàíåñåíî óðîíà
            takeDamage(10);
        }
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
}
