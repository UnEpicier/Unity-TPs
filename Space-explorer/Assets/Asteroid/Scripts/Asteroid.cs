using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    public float rotateSpeed = 0;
    public float speed = 0;
    public float size;

    private Animation explosion;

    private void Start()
    {
        explosion = GetComponent<Animation>();
        explosion.clip.legacy = true;

        speed = Random.Range(5, 10);
        rotateSpeed = Random.Range(50, 300);

        size = Random.Range(0.5f, 2f);

        transform.localScale = new Vector2(size, size);

    }

    void Update()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            StartCoroutine(WaitExplosionEnd());

            
        }
    }

    IEnumerator WaitExplosionEnd()
    {
        float actualSpeed = speed;
        float acutalRotationSpeed = rotateSpeed;
        explosion.Play();

        yield return new WaitForSeconds(explosion.clip.length);

        Destroy(gameObject);
        SpawnerManager.RemoveAsteroid(gameObject);

        GameObject debris = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        debris.transform.localScale = new Vector2(size / 2, size / 2);
        Asteroid debrisSpecs = debris.GetComponent<Asteroid>();
        debrisSpecs.rotateSpeed = acutalRotationSpeed * 1.2f;
        debrisSpecs.speed = actualSpeed;

        debrisSpecs.Start();

        SpawnerManager.AddAsteroid(debris);
    }
}
