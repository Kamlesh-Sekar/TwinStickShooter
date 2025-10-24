using UnityEngine;

[CreateAssetMenu(menuName = "Factories/PlayerFactory")]
public class PlayerFactory : ScriptableObject
{
    [SerializeField] private Player player;

    public Player Create(Transform positionTransform)
    {
        return Instantiate(player, positionTransform.position,positionTransform.rotation);
    }
}
