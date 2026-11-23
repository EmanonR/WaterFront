using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed;
    float damage;
    Vector2 dir;

    float liveTimer;

    public void SetValues(Vector2 aDir, float aSpeed, float aDamage)
    {
        speed = aSpeed;
        damage = aDamage;
        dir = aDir;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * dir);

        liveTimer += Time.deltaTime;

        if (liveTimer > 2)
        {
            Destroy(gameObject);
        }
    }
}
