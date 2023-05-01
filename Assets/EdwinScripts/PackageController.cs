using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageController : MonoBehaviour
{
    public enum PackageStatus { None, Delivered, WrongDelivery, KnockedOutPerson }
    public PackageStatus packageStatus = PackageStatus.None;
    public int packageId;

    private Rigidbody2D rb;
    private GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            HouseController houseController = other.gameObject.GetComponent<HouseController>();
            if (houseController && !houseController.packageDelivered)
            {
                houseController.packageDelivered = true;
                packageStatus = PackageStatus.Delivered;
                gameManager.PackageDelivered(packageId, houseController.houseNumber);

            }
            else
            {
                packageStatus = PackageStatus.WrongDelivery;
                gameManager.WrongDelivery(packageId);
            }
        }
        else if (other.gameObject.CompareTag("Outhouse"))
        {
            packageStatus = PackageStatus.WrongDelivery;
            gameManager.DeliveredToOuthouse(packageId);

        }
        else if (other.gameObject.CompareTag("Person"))
        {
            PersonController personController = other.gameObject.GetComponent<PersonController>();
            if (personController)
            {
                personController.PlayHitAnimationAndSound();
            }
            packageStatus = PackageStatus.KnockedOutPerson;
            gameManager.KnockOutPerson(packageId);

        }

        if (packageStatus != PackageStatus.None)
        {
            //rb.bodyType = RigidbodyType2D.Static;
            //rb.velocity = Vector2.zero;
            //rb.angularVelocity = 0f;
            //gameObject.layer = LayerMask.NameToLayer("DeliveredPackage");
        }
    }
}
