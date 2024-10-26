using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    // lista de Objetos que podem ser renderizados na scena
    public GameObject[] itemsToChoiceFrom;

    // Start is called before the first frame update
    void Start()
    {
        this.Choice();
    }


    void Choice()
    {
        //escolhe randomicamente um iem da lista
        int randomIndex = Random.Range(0, itemsToChoiceFrom.Length);
        // cria o item escolhido aleatóriamente na scena
        GameObject clone = Instantiate(itemsToChoiceFrom[randomIndex], transform.position, Quaternion.identity);
    }
}
