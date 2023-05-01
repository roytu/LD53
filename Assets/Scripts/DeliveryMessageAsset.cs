using UnityEngine;

[CreateAssetMenu(fileName = "DeliveryMessageAsset", menuName = "Delivery Messages/Create New Message Asset", order = 0)]
public class DeliveryMessageAsset : ScriptableObject
{
    [TextArea]
    public string[] successfulDeliveries;
    [TextArea]
    public string[] wrongDeliveries;
    [TextArea]
    public string[] outhouseDeliveries;

    public string GetRandomSuccessfulDelivery()
    {
        return successfulDeliveries[Random.Range(0, successfulDeliveries.Length)];
    }

    public string GetRandomWrongDelivery()
    {
        return wrongDeliveries[Random.Range(0, wrongDeliveries.Length)];
    }

    public string GetRandomOuthouseDelivery()
    {
        return outhouseDeliveries[Random.Range(0, outhouseDeliveries.Length)];
    }
}
