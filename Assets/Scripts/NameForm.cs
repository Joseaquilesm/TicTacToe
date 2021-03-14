using System.Collections;
using System.Collections.Generic;
using Scripts.Networking;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameForm : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_InputField nameTextField;
    public TextMeshProUGUI txt;
    private bool IsSending = false;
  


    // Start is called before the first frame update
    void Start()
    {

      
        if (nameTextField == null)
        {
            throw new System.Exception("Empty name field.");
        }


    }

    // Update is called once per frame
    void Update()
    {
       
     
        
    }

    
    public void OnButtonClick ()
    {
        if(txt.text == "CONNECT")
        {
            if (IsSending)
            {
                return;
            }

            string name = nameTextField.text.Trim();

            if (name == string.Empty)
            {
                return;
            }

            if (NetworkManager.Instance.ConnectionState == DarkRift.ConnectionState.Connected || NetworkManager.Instance.Connect())
            {
                IsSending = true;
                NetworkManager.Instance.MessageToServer(name);

                txt.text = "PLAY";
            }
        }
        else
        {
            if (NetworkManager.Instance.IsConnected)
            {
                SceneManager.LoadScene("Game");
            }
           
        }
     

    }
}
