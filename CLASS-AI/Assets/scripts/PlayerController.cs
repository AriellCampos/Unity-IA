using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DifficultyManager difficultyManager;

    private void Update()
    {
        // Simulação de pontuação e mortes
        if (Input.GetKeyDown(KeyCode.Space)) // Simula ganhar pontos
        {
            difficultyManager.playerScore += 10;
            Debug.Log("Pontuação: " + difficultyManager.playerScore);
        }

        if (Input.GetKeyDown(KeyCode.K)) // Simula a morte do jogador
        {
            difficultyManager.playerDeaths++;
            Debug.Log("Mortes: " + difficultyManager.playerDeaths);
        }
    }
}

