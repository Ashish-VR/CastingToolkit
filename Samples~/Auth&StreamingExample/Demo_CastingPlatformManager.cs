using Exrnet.Casting;
using TMPro;
using UnityEngine;

public class Demo_CastingPlatformManager : MonoBehaviour
{
    [SerializeField] bool useAutoLoginAtStart;
    [SerializeField] string autoLoginUsername, autoLoginPassword;
    [SerializeField] GameObject loginWindow, logoutWindow;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] TMP_InputField username, password, currentUserName, jsonString;
    [SerializeField] GameObject error;
    bool state = false;

    void Start()
    {
        loginWindow.SetActive(false);
        logoutWindow.SetActive(false);

        if (Platform.IsLoggedIn())
        {
            state = true;
            descriptionText.text = "Currently logged in as " + Platform.GetUsername();
            loginWindow.SetActive(false);
            logoutWindow.SetActive(true);
        }
        else
        {
            loginWindow.SetActive(true);
            logoutWindow.SetActive(false);
        }
        if (useAutoLoginAtStart)
        {
            Platform.Login(autoLoginUsername, autoLoginPassword, loggedIn =>
            {
                if (!loggedIn)
                    error.SetActive(true);
            });
        }
    }
    private void Update()
    {
        var temp = Platform.IsLoggedIn();
        if (state != temp)
        {
            if (temp)
            {
                descriptionText.text = "Currently logged in as " + Platform.GetUsername();
                loginWindow.SetActive(false);
                logoutWindow.SetActive(true);
            }
            else
            {
                loginWindow.SetActive(true);
                logoutWindow.SetActive(false);
            }
            state = temp;
        }
    }
    public void Submit()
    {
        if (Platform.IsLoggedIn())
        {
            Platform.Logout();
            return;
        }
 
        Platform.Login(username.text, password.text, loggedIn =>
        {
            if (!loggedIn)
                error.SetActive(true);
        });
    }
    public void SetName()
    {
        Platform.SetCurrnetUser(currentUserName.text, isSuccess=> {
            if (!isSuccess)
              //Debug.LogError("Failed to set user name");
            descriptionText.text = "Currently logged in as " + Platform.GetUsername();
        });
    }
    public void SetJSON()
    {
        Platform.SetJsonString(jsonString.text, isSuccess => {
            //if (!isSuccess)
              //Debug.LogError("Failed to set json string");
            //else
              //Debug.LogError("Successfully set json string");
        });


    }
}