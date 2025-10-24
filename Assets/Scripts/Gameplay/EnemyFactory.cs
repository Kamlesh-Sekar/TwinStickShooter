using UnityEngine;

[CreateAssetMenu(menuName = "Factories/EnemyFactory")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] private Enemy[] enemies;

    public Enemy Create(Transform positionTransform)
    {
        Enemy enemy = enemies[Random.Range(0, enemies.Length)];
        return Instantiate(enemy, positionTransform.position, positionTransform.rotation);
    }
}
