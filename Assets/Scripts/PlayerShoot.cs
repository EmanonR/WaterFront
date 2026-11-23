using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;

    float timeBetweenShots = .2f;
    float shootTimer;

    private void Update()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime; 
            return;
        }

        Vector2 aimDir = InputManager.Instance.GetMouseInputDirection().normalized;

        if (InputManager.Instance.ShootInput.IsPressed())
        {
            shootTimer = timeBetweenShots;
            Shoot(aimDir, 60, 2);
        }
    }

    public void Shoot(Vector2 dir, float speed, float damage)
    {
        Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>().SetValues(dir, speed, damage);
    }
}
