using UnityEngine;

public class Enemy : MonoBehaviour
{
    //��� �� � �������� �� ����
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
