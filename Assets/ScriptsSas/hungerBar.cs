using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class hungerBar : MonoBehaviour
{
    [SerializeField] stats statistics;

    [SerializeField] public TextMeshProUGUI hunCount;
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHunger=0;
    public float hunger=0;
    private float lerpSpeed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hunger = statistics.СurrentHunger;
        maxHunger = statistics.maxHunger;

        hunCount.text = hunger.ToString();
    }

    // Update is called once per frame
    void Update()    
    {
        // Çíà÷åíèå õï ñëàéäåðà = çíà÷åíèå õï
        healthSlider.value = hunger;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Ñêîëüêî íàíåñåíî óðîíà
            takeDamage(10);
        }
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
}
