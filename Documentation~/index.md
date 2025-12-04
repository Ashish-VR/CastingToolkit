**Casting Toolkit**

_Version: 1.0.0 | Unity Version: 2021.3+_

The Casting Toolkit is a specialized SDK designed for Inion VR. It provides a robust wrapper around Exrnet networking protocols, enabling secure device authentication, persistent user sessions, and real-time control over streaming configurations directly from Unity.

*Key Features*

**Secure Authentication**
AES-256 encrypted token management mixed with device-specific hardware IDs ensures secure local storage.

**Session Management**
Automatic token caching and validation via PlayerPrefs handles the login lifecycle without manual intervention.

**Stream Control**
Runtime adjustment of video resolution, bitrate, and framerate allows for dynamic quality scaling based on network conditions.

**Device Metadata**
Synchronize device names and custom JSON configurations with the backend server seamlessly.

**Installation**

_This package is designed to be installed via the Unity Package Manager (UPM)._

Open Unity and navigate to the top menu: Window > Package Manager.

Click the + icon in the top left corner.

Select "Add package from disk...".

Navigate to the root folder of this toolkit, select package.json, and click Open.

**Dependencies**
This package automatically resolves the following dependencies:

_com.unity.webrtc (3.0.0)_
_com.unity.nuget.newtonsoft-json (3.2.2)_

**Quick Start Guide**

1. Namespace Import

Include the casting namespace in your script to access the toolkit:

using Exrnet.Casting;


2. Login Flow

The Platform class handles all networking logic. It is a static class and initializes itself automatically upon the first call.

_public void OnLoginButtonClicked()_
_{_
    _string user = usernameInput.text;_
    _string pass = passwordInput.text;_

    _Platform.Login(user, pass, (bool success) => {_
        _if (success)_
        _{_
            _Debug.Log($"Success! Logged in as: {Platform.GetUsername()}");_
            _// Load your next scene here_
        _}_
        _else_
        _{_
            _Debug.LogError("Login failed. Check credentials.");_
        _}_
    _});_
_}_


3. Adjusting Stream Quality

You can adjust streaming parameters at runtime to optimize performance:

// Set bitrate to 10 Mbps
_Platform.UpdateBitrate(10);_

// Set resolution to 1920x1080
_Platform.UpdateStreamResolution(1920, 1080);_

// Set target FPS to 60
_Platform.UpdateStreamFPS(60);_

**Platform Class Reference**

_Namespace: Exrnet.Casting_

The Platform class is the primary entry point for managing authentication, user profiles, and streaming settings. It is a Static class.

***Authentication Methods***

**Login**

Authenticates the device against the InionVR platform.

public static void Login(string username, string password, Action<bool> callback)


username: The user's login identifier.

password: The user's password.

callback: Delegate returning true if login succeeded.

**IsLoggedIn**

Checks if a valid token exists and ensures the network manager is initialized.

public static bool IsLoggedIn()


Returns: true if authorized; otherwise false.

**Logout**

Clears the stored authentication token and destroys the active network manager instance.

public static void Logout()


***User Management***

**GetUsername**

Retrieves the username associated with the current session.

public static string GetUsername()


**SetCurrnetUser**

Updates the username on the server for the current device.

public static void SetCurrnetUser(string name, Action<bool> callback)


**SetJsonString**

Sends a raw JSON string to update device-specific configuration or metadata on the server.

public static void SetJsonString(string json, Action<bool> callback)


***Streaming Configuration***

**UpdateBitrate**

Sets the target bitrate for the stream.

public static void UpdateBitrate(ulong bitrateInMbps)


**UpdateStreamResolution**

Sets the video dimensions for the stream.

public static void UpdateStreamResolution(int width, int height)


**UpdateStreamFPS**

Sets the target Frames Per Second (FPS) for the stream.

public static void UpdateStreamFPS(int fps)

**API Reference**

For a complete technical reference of all available methods, parameters, and return types, please refer to the specific class documentation:

Platform Class Reference
Detailed breakdown of Login, Logout, SetCurrentUser, and streaming configuration methods.

**Support**

Author: Exrnext Labs Private Limited
Email: contact@exrnext.com
Website: https://exrnext.com