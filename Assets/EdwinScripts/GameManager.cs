using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject endScreenBackground;
    [SerializeField]
    private GameObject endScreenTitle;
    [SerializeField]
    private GameObject replayButton;
    [SerializeField]
    private DeliveryMessageAsset deliveryMessageAsset;

    public int totalPackages = 3;
    public TMPro.TextMeshProUGUI endScreenText;
    public Fader fader;
    private Dictionary<int, string> packageResults = new Dictionary<int, string>();
    private bool personKnockedOut = false;

    private Dictionary<int, string> houseIdToAddress = new Dictionary<int, string>
    {
        {0, "4011 Reiter Rd" },
        {1, "4036 Reiter Rd" },
        {2, "4038 Reiter Rd" },
    };

    private void Start()
    {
        Debug.Log("start game manager");
    }

    public void PackageDelivered(int packageId, int houseNumber)
    {
        string address = houseIdToAddress[houseNumber];
        string message = deliveryMessageAsset.GetRandomSuccessfulDelivery();
        message = message.Replace("{address}", $"{address}");
        packageResults[packageId] = message;
        CheckGameState();
    }

    public void WrongDelivery(int packageId)
    {
        string message = deliveryMessageAsset.GetRandomWrongDelivery();
        packageResults[packageId] = message;
        CheckGameState();
    }

    public void DeliveredToOuthouse(int packageId)
    {
        string message = deliveryMessageAsset.GetRandomOuthouseDelivery();
        packageResults[packageId] = message;
        CheckGameState();
    }

    public void KnockOutPerson(int packageId)
    {
        personKnockedOut = true;
        string message = $"Edwin was hit in the head by a 40 lb box. \n";
        packageResults[packageId] = message;
        CheckGameState();
    }

    private void CheckGameState()
    {
        if (totalPackages == 0)
        {
            ShowEndScreen();
        }
    }

    private void ShowEndScreen()
    {
        StartCoroutine(ShowEndScreenCoroutine());
    }

    private IEnumerator ShowEndScreenCoroutine()
    {
        fader.FadeIn();
        yield return new WaitForSeconds(fader.fadeDuration);
        string endMessage = $"Drone has delivered all the packages and has returned to the delivery center. \n\n";
        var resultList = packageResults.Values.ToList();
        resultList.ForEach((val) => {
            endMessage += "\n";
            endMessage += val;
        });
        endMessage += "\n";
        if (personKnockedOut)
        {
            endMessage += "Edwin Lee was on a lunchtime stroll when he was struck by a falling package. He fell and hit his head on uneven concrete and was immediately concussed. It took a long time for someone to find him, unconscious, out by Reiter Road. He took a sabbatical from his work because he was unable to think clearly through the brain fog. Sometimes he wonders how different his life would be today if he hadn't been hit. \n ";
        }
        else
        {
            endMessage += "Edwin Lee enjoyed his lunchtime stroll and went back to his house to resume his work day. He was entertained by seeing a delivery drone hard at work today. \n";
        }
        endScreenText.text = endMessage;
        endScreenText.gameObject.SetActive(true);
        endScreenBackground.SetActive(true);
        replayButton.SetActive(true);
        endScreenTitle.SetActive(true);
        fader.FadeOut();
    }
}
