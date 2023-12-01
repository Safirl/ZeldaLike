using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantBehavior : MonoBehaviour
{
    [SerializeField] private RessourceManager ressourceManager;
    private GameObject DialogPanel;
    [SerializeField] private GameObject Ally;
    
    private bool canBuy = false;
    private bool closePanel = false;

    // Start is called before the first frame update
    void Start()
    {
        ressourceManager = FindAnyObjectByType<RessourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canBuy)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                DialogPanel.SetActive(false);
                canBuy = false;

            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                //SpawnTroupes
                for (int i = 0; i < 3; i++) {
                
                Instantiate(Ally, transform.position, transform.rotation);
                }
                ressourceManager.SubstractCoins(10);
                Debug.Log(ressourceManager.GetCoins());
                DialogPanel.SetActive(false);
                canBuy = false;
            }
        }
        else if (closePanel) 
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                DialogPanel.SetActive(false);

            }
        }
    }

    public void SellSoldiers()
    {
        if (ressourceManager == null)
            return;
        DialogPanel = ressourceManager.transform.Find("DialogPanel").gameObject;
        if (ressourceManager.GetCoins() >= 10)
        {
            DialogPanel.GetComponent<MerchantDialog>().text.text = "You can trade 10 eggs for 3 soldiers. 'N' to avoid; 'Y' to buy";
            DialogPanel.SetActive(true);
            canBuy = true;

        }
        else
        {
            DialogPanel.GetComponent<MerchantDialog>().text.text = "You don't have enough eggs, come and see me later. Press N to close";
            DialogPanel.SetActive(true);
            closePanel = true;

        }
    }
}
