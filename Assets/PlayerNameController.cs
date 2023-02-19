using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerNameController : MonoBehaviour
{
    public Text[] PlayerName; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerName[0].text == "" || PlayerName[0].text == "Player")
        {
            if (Localisation.CurrentLanguage == SystemLanguage.Russian)
            {
                PlayerName[0].text = "Игрок";
              
            }
            if (Localisation.CurrentLanguage == SystemLanguage.English)
            {
                PlayerName[0].text = "Player";
               
            }
            if (Localisation.CurrentLanguage == SystemLanguage.Ukrainian)
            {
                PlayerName[0].text = "Гравець";
               
            }
            if (Localisation.CurrentLanguage == SystemLanguage.German)
            {
                PlayerName[0].text = "Spieler";
              
            }
            if (Localisation.CurrentLanguage == SystemLanguage.Spanish)
            {
                PlayerName[0].text = "Jugador";

            }
            if (Localisation.CurrentLanguage == SystemLanguage.Arabic)
            {
                PlayerName[0].text = "لاعب";

            }
            if (Localisation.CurrentLanguage == SystemLanguage.Italian)
            {
                PlayerName[0].text = "Giocatore";

            }
            if (Localisation.CurrentLanguage == SystemLanguage.Portuguese)
            {
                PlayerName[0].text = "Jugador";

            }
            if (Localisation.CurrentLanguage == SystemLanguage.French)
            {
                PlayerName[0].text = "joueur";

            }
        }
        for (int namecount = 1; namecount < PlayerName.Length; namecount++)
        {
            PlayerName[namecount].text = PlayerName[0].text;
        }

    }
}
