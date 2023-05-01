using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    //[SerializeField]
    //private UnityEngine.UI.RawImage packageImage;
    [SerializeField]
    private Sprite emptyDroneSprite;
    [SerializeField]
    private TMPro.TextMeshProUGUI address;

    public float moveSpeed = 5f;
    public GameObject packagePrefab;
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Movement Controls
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.velocity = movement * moveSpeed;

        // Package Drop Controls
        if (gameManager.totalPackages > 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1")))
        {
            DropPackage();
        }
    }

    private void DropPackage()
    {
        if (packagePrefab != null)
        {
            GameObject newPackage = Instantiate(packagePrefab, transform.position, Quaternion.identity);
            PackageController packageController = newPackage.GetComponent<PackageController>();
            if (packageController != null)
            {
                packageController.packageId = 3 - gameManager.totalPackages; // Assign packageId based on the current packageCount
            }
            Debug.Log($"package released with {packageController.packageId}");

            gameManager.totalPackages -= 1;
        }
        // Update the address text display
        if (gameManager.totalPackages == 2)
        {
            address.text = "Package Address: 4036 Reiter Rd";
        }
        else if (gameManager.totalPackages == 1)
        {
            address.text = "Package Address: 4038 Reiter Rd";
        }
        else if (gameManager.totalPackages == 0)
        {
            spriteRenderer.sprite = emptyDroneSprite;
            address.text = "All packages released!";
        }

        // Update the package image display
        //if (packageCount == 2)
        //{
        //    packageImage.texture = Resources.Load<Texture>("package1");
        //}
        //else if (packageCount == 1)
        //{
        //    packageImage.texture = Resources.Load<Texture>("package2");
        //}
        //else if (packageCount == 0)
        //{
        //    packageImage.texture = Resources.Load<Texture>("package3");
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            // Prevent the drone from going off the map boundaries
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            // Prevent the drone from going off the map boundaries
            rb.velocity = Vector2.zero;
        }
    }
}