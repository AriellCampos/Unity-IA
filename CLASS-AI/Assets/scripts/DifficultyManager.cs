using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public int playerScore = 0;
    public int playerDeaths = 0;

    public float enemyHealthMultiplier = 1.0f;
    public int difficultyLevel = 1;

    private bool difficultyChanged = false; // Flag para controlar a mudança de dificuldade
    private float difficultyChangeCooldown = 2.0f; // Tempo em segundos antes que a dificuldade possa mudar novamente
    private float cooldownTimer; // Temporizador para o cooldown

    void Start()
    {
        cooldownTimer = difficultyChangeCooldown; // Inicializa o temporizador com o valor do cooldown
    }
    private void Update()
    {
        AdjustDifficulty();
        //AdjustDifficultyByTme();
    }

    void AdjustDifficulty()
    {

        if (playerScore > 100 * difficultyLevel) //300
        {
            difficultyLevel++;
            enemyHealthMultiplier += 0.5f; // Aumenta a saúde dos inimigos
            NotifyEnemies(); // Notifica os inimigos
            Debug.Log("Dificuldade aumentada! Nível: " + difficultyLevel);
        }
        else if (playerDeaths > difficultyLevel * 3) //14 > 9
        {
            difficultyLevel = Mathf.Max(1, difficultyLevel - 1);
            enemyHealthMultiplier = Mathf.Max(1.0f, enemyHealthMultiplier - 0.5f); // Reduz a saúde dos inimigos
            NotifyEnemies(); // Notifica os inimigos
            Debug.Log("Dificuldade reduzida! Nível: " + difficultyLevel);
        }
    }
    void AdjustDifficultyConditional()
    {
        if (!difficultyChanged) // Apenas permite mudar a dificuldade se não mudou recentemente
                                //{
            if (playerScore >= 100 * difficultyLevel)
            {
                difficultyLevel++;
                enemyHealthMultiplier += 0.5f; // Aumenta a saúde dos inimigos
                difficultyChanged = true; // Marca que a dificuldade mudou
                NotifyEnemies(); // Notifica os inimigos
                Debug.Log("Dificuldade aumentada! Nível: " + difficultyLevel);
            }
            else if (playerDeaths > difficultyLevel * 3)
            {
                difficultyLevel = Mathf.Max(1, difficultyLevel - 1);
                enemyHealthMultiplier = Mathf.Max(1.0f, enemyHealthMultiplier - 0.5f); // Reduz a saúde dos inimigos
                difficultyChanged = true; // Marca que a dificuldade mudou
                NotifyEnemies(); // Notifica os inimigos
                Debug.Log("Dificuldade reduzida! Nível: " + difficultyLevel);
            }
    

        // Resetar a flag  quando certas condições forem atendidas
  
        if (playerScore > 100 * difficultyLevel && difficultyLevel <=  difficultyLevel * 3)
        {
            difficultyChanged = false; // Permite mudanças novamente se nenhuma condição de mudança estiver ativa
        }

    }

    // Resetar a flag após um certo período
    void AdjustDifficultyByTme()
    {
        if (difficultyChanged)
        {
            cooldownTimer -= Time.deltaTime; // Decrementa o temporizador

            // Se o timer chegar a zero, reseta a flag e o timer
            if (cooldownTimer <= 0.0f)
            {
                difficultyChanged = false; // Permite mudanças de dificuldade novamente
                cooldownTimer = difficultyChangeCooldown; // Reseta o temporizador para o valor original
            }
        }
        else // Apenas permite mudar a dificuldade se não mudou recentemente
        {
            if (playerScore >= 100 * difficultyLevel)
            {
                difficultyLevel++;
                enemyHealthMultiplier += 0.5f; // Aumenta a saúde dos inimigos
                difficultyChanged = true; // Marca que a dificuldade mudou
                cooldownTimer = difficultyChangeCooldown; // Reseta o temporizador para o valor original
                NotifyEnemies(); // Notifica os inimigos
                Debug.Log("Dificuldade aumentada! Nível: " + difficultyLevel);
            }
            else if (playerDeaths > difficultyLevel * 3)
            {
                difficultyLevel = Mathf.Max(1, difficultyLevel - 1);
                enemyHealthMultiplier = Mathf.Max(1.0f, enemyHealthMultiplier - 0.5f); // Reduz a saúde dos inimigos
                difficultyChanged = true; // Marca que a dificuldade mudou
                cooldownTimer = difficultyChangeCooldown; // Reseta o temporizador para o valor original
                NotifyEnemies(); // Notifica os inimigos
                Debug.Log("Dificuldade reduzida! Nível: " + difficultyLevel);
            }
        }

    }

    void NotifyEnemies()
    {
        foreach (var enemy in Object.FindObjectsByType<EnemyController>(FindObjectsSortMode.None))
        {
            enemy.UpdateHealth(); // Atualiza a saúde dos inimigos
        }
    }
}