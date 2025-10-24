using UnityEngine;

[CreateAssetMenu(menuName = "Factories/EnemyFactory")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] private Enemy enemy;

    public Enemy Create(Transform positionTransform)
    {
        return Instantiate(enemy, positionTransform.position, positionTransform.rotation);
    }
}
