using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Тут хп и максимум хп моба
    public float maxHealth = 100f;
    public float currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    void Update()
    {
        
    }
}
