using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peixe : MonoBehaviour
{
    [SerializeField] GameObject[] peixePrefab;

    [SerializeField] float secondSpawn = 0.5f;[SerializeField] float minTras;

    [SerializeField] float maxTras;

    void Start()
    {
        StartCoroutine(PeixeSpawn());
    }

    IEnumerator PeixeSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(peixePrefab[Random.Range(0, peixePrefab.Length)]);
            gameObject.transform.position = position;
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
}
