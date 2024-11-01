using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI; // Required for accessing UI components

public class DisplayController : MonoBehaviour
{
    public Text hitsApplied; 
    public Text hitsReceived;
    public int hitsAppliedNumber = 0;
    public int hitsReceivedNumber = 0;
    private bool areButtonsVisible = true;
    private Button currentClickedButton = null;
    
    [SerializeField] private Button togglerButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button serverButton;
    [SerializeField] private Button clientButton;

    void Start()
    {
        // Initialize display hit counter
        hitsApplied = GameObject.Find("HitsApplied").GetComponent<Text>();
        hitsApplied.text = "Hits => 0";
        
        // TODO: update with Network variables
        hitsReceived = GameObject.Find("HitsReceived").GetComponent<Text>();
        hitsReceived.text = "Hits <= 0";

        // Reference UI buttons
        togglerButton = GameObject.Find("TogglerButton").GetComponent<Button>();
        hostButton = GameObject.Find("HostButton").GetComponent<Button>();
        serverButton = GameObject.Find("ServerButton").GetComponent<Button>();
        clientButton = GameObject.Find("ClientButton").GetComponent<Button>();

        // Add handlers to all buttons
        togglerButton.onClick.AddListener(() => {
            areButtonsVisible = !areButtonsVisible;
            togglerButton.transform.Rotate(new Vector3(0,0,areButtonsVisible ? -90 : 90));
            ToggleButtonsVisible(areButtonsVisible);
        });
        hostButton.onClick.AddListener(() => {
            if(currentClickedButton == hostButton){
                NetworkManager.Singleton.Shutdown();
                hostButton.GetComponentInChildren<Text>().text = "Host";
                currentClickedButton = null;
            } else {
                NetworkManager.Singleton.StartHost();
                hostButton.GetComponentInChildren<Text>().text = "Parar host";
                currentClickedButton = hostButton;
            }
        });
        serverButton.onClick.AddListener(() => {
            if(currentClickedButton == serverButton){
                NetworkManager.Singleton.Shutdown();
                serverButton.GetComponentInChildren<Text>().text = "Server";
                currentClickedButton = null;
            } else {
                NetworkManager.Singleton.StartServer();
                serverButton.GetComponentInChildren<Text>().text = "Parar server";
                currentClickedButton = serverButton;
            }
        });
        clientButton.onClick.AddListener(() => {
            if(currentClickedButton == clientButton){
                NetworkManager.Singleton.Shutdown();
                clientButton.GetComponentInChildren<Text>().text = "Client";
                currentClickedButton = null;
            } else {
                NetworkManager.Singleton.StartClient();
                clientButton.GetComponentInChildren<Text>().text = "Parar client";
                currentClickedButton = clientButton;
            }
        });
    }

    private void ToggleButtonsVisible(bool visible){
        hostButton.gameObject.SetActive(visible);
        serverButton.gameObject.SetActive(visible);
        clientButton.gameObject.SetActive(visible);
    }

    // This method will change the text dynamically when called (hits applied)
    public void IncreaseHit(int hitsToIncrease)
    {
        hitsAppliedNumber += hitsToIncrease;
        hitsApplied.text = "Hits => " + hitsAppliedNumber.ToString();
    }

    // This method will change the text dynamically when called
    public void IncreaseHitsReceived(int hitsToIncrease)
    {
        hitsReceivedNumber += hitsToIncrease;
        hitsReceived.text = "Hits <= " + hitsReceivedNumber.ToString();
    }
}
