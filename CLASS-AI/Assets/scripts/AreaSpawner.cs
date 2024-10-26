using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    public GameObject[] itemsToSpawn;
    public Vector2 areaSize;
    public int numberOfItemsToSpawn;
    public float raycastDistance = 100f; // Distância do Raycast

    void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        for (int i = 0; i < numberOfItemsToSpawn; i++)
        {
            Vector3 spawnPosition;

            // Tenta encontrar uma posição válida
            do
            {
                spawnPosition = GenerateRandomPosition();
            } while (!TryGetGroundPosition(spawnPosition, out spawnPosition));

            GameObject item = SelectRandomItem();
            // Ajusta a posição do objeto com base em sua altura
            float itemHeight = item.GetComponent<Renderer>().bounds.size.y; // Altura do objeto
            spawnPosition.y += itemHeight / 2; // Move para cima

            Instantiate(item, spawnPosition, Quaternion.identity);
            Debug.Log("Item spawned at: " + spawnPosition);
        }
    }

    GameObject SelectRandomItem()
    {
        int randomIndex = Random.Range(0, itemsToSpawn.Length);
        return itemsToSpawn[randomIndex];
    }

    Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(transform.position.x - areaSize.x / 2, transform.position.x + areaSize.x / 2);
        float randomZ = Random.Range(transform.position.z - areaSize.y / 2, transform.position.z + areaSize.y / 2);
        return new Vector3(randomX, 0, randomZ); // Começa com Y em 0
    }

    bool TryGetGroundPosition(Vector3 position, out Vector3 groundPosition)
    {
        RaycastHit hit;
        // Lança um Raycast para baixo a partir da posição gerada
        if (Physics.Raycast(position + Vector3.up * raycastDistance, Vector3.down, out hit, raycastDistance))
        {
            groundPosition = hit.point; // Ponto onde o Raycast acertou
            return true;
        }

        groundPosition = position; // Se não houver hit, retorna a posição original
        return false;
    }
}
