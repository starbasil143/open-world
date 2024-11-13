using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "T_PlantHealth", menuName = "Scriptable Objects/Transmutations/T_PlantHealth")]
public class T_PlantHealth : TransmutationSOBase
{
    public float healingAmount;
    public override void PerformTransmutation(GameObject player)
    {
        base.PerformTransmutation(player);
        
        player.GetComponent<Player>().Heal(healingAmount);
        Destroy(player.GetComponent<PlayerCasting>().currentObject);
    }
}
