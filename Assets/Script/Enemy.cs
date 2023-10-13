using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        Vector3 start = gameObject.transform.position;
        Vector3 end = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), -10f);
        float timeToMove = 10f;

        float t = 0;
        while (t < 1)
        {
            transform.position = Vector3.Lerp(start, end, t);
            t += Time.deltaTime / timeToMove;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            GameManager.instance.UpdateScore();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game over");
            GameManager.instance.GameIsOver();
        }




    }
}
