using UnityEngine;

public class FreeScirpt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            other.gameObject.SetActive(false);
            RandomSpawner.freeObjects.Add(other.gameObject);
        }
    }
}
