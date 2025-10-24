using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPosition;
    [SerializeField] private float shootInterval;

    private float lastShootTime;

    public void Tick()
    {
        if ((Time.time - lastShootTime) > shootInterval)
        {
            Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
            lastShootTime = Time.time;
        }
    }
}
