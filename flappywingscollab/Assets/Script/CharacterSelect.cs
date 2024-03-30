using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;
    public Character[] characters;

    public Button buyButton;
    public Text coinsText;
    public GameObject diMiliki;

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skins)
        player.SetActive(false);

        skins[selectedCharacter].SetActive(true);

        foreach(Character c in characters)
        {
            if (c.price == 0)
                c.isUnlocked = true;
            else
            {
                c.isUnlocked =  PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();
    }

    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if(selectedCharacter == skins.Length)
           selectedCharacter = 0;

        skins[selectedCharacter].SetActive(true);
        GameObject.Find ("klik").GetComponent<AudioSource> ().Play ();
        if(characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        UpdateUI();
    }

    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter == -1)
           selectedCharacter = skins.Length -1;

        skins[selectedCharacter].SetActive(true);
        GameObject.Find ("klik").GetComponent<AudioSource> ().Play ();
        if(characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        UpdateUI();
    }

    public void UpdateUI()
    {
        coinsText.text = "" + PlayerPrefs.GetInt("Coins", 0);
    if (characters[selectedCharacter].isUnlocked == true)
        {
        buyButton.gameObject.SetActive(false);
        diMiliki.gameObject.SetActive(true);
        }
    else
    {
        diMiliki.gameObject.SetActive(false);
        buyButton.GetComponentInChildren<Text>().text = "Harga: "+ characters[selectedCharacter].price;
        if (PlayerPrefs.GetInt("Coins", 0) < characters[selectedCharacter].price)
        {
            buyButton.gameObject.SetActive(true);
            buyButton.interactable = false;
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.interactable = true;
        }
    }
    }

    public void Unlock()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        int price = characters[selectedCharacter].price;
        PlayerPrefs.SetInt("Coins", coins - price);
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        characters[selectedCharacter].isUnlocked = true;
        GameObject.Find ("buySound").GetComponent<AudioSource> ().Play ();
        UpdateUI(); 
    }
}
