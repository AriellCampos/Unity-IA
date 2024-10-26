using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceItem : MonoBehaviour
{
    // lista de Objetos que podem ser renderizados na scena
    public GameObject[] itemsToChoiceFrom; 
    
    void Start()
    {
        if (itemsToChoiceFrom.Length > 0)
        {
            Choice();
        }
        else
        {
            Debug.LogWarning("A lista de itens está vazia!");
        }
    }

    void Choice()
    {
        //escolhe randomicamente um iem da lista
        int randomIndex = Random.Range(0, itemsToChoiceFrom.Length); 
        // cria o item escolhido aleatóriamente na scena
        GameObject clone = Instantiate(itemsToChoiceFrom[randomIndex], transform.position, Quaternion.identity); 
    }
}
