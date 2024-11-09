using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public DifficultyManager difficultyManager;

    private float baseHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        UpdateHealth();
    }

    private void Update()
    {
        // Comportamento adaptativo baseado na dificuldade
        if (difficultyManager.difficultyLevel > 2)
        {
            AttackPlayer();
        }
        else
        {
            Patrol();
        }
    }

    public void UpdateHealth()
    {
        currentHealth = baseHealth * difficultyManager.enemyHealthMultiplier;
        Debug.Log("Saúde do inimigo: " + currentHealth);
    }

    void AttackPlayer()
    {
        Debug.Log("Inimigo atacando o jogador!");
        // Implementar lógica de ataque
    }

    void Patrol()
    {
        Debug.Log("Inimigo patrulhando.");
        // Implementar lógica de patrulha
    }
}
