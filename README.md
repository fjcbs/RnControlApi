# RnControlApi

RnControlApi is a very basic and simple .Net Core HTTP service for controlling (start/stop/restart) the &copy;Roon applications (Core or Server)  in a Microsoft Windows PC.

This is meant to solve a problem I have when my USB DAC is restarted and &copy;Roon loses the connection to the DAC and then I need to log on to the Windows PC and restart the &copy;Roon Core (or as some people do, restart/reboot the PC).

Since I usually leave my music streamer PC on and I only power off the DAC, when I want to listen to music again I turn the DAC back on but the &copy;Roon software does not recognize the DAC and I have to login to the PC and restart &copy;Roon manually.
I don't know if this is a &copy;Roon problem or an ASIO Driver problem but thr Roon restart works.

With this application all I need to do is open a browser in my phone/tablet and call the address for the machine of the audio player with the "restartCore" command... This way I don't need to log into the PC to restart the Roon Core application.

I created a shortcut for the "restart" address in my phone and now all I need to do is open this shortcut and Roon restarts and all is good :smile:



## Installation

Copy the files to a folder of your choice.

To enable this application to start automatically on windows logon, I you can make a shortcut for the executable on
(replace ``MyUserName`` with the username of the user that runs Roon on the streamer PC):
```
C:\Users\MyUserName\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
```



## Configuration

The file `appsettings.json` contains the application configuration.

One must change the settings that point to the Roon applications 
(replace ``MyUserName`` by your user):

```
    "coreAppPath": "C:\\Users\\MyUserName\\AppData\\Local\\Roon\\Application\\Roon.exe"
    "serverAppPath": "C:\\Users\\MyUserName\\AppData\\Local\\RoonServer\\Application\\RoonServer.exe"
```

The service listens on ``port 5214`` by default.
To change it to your desired port, change configuration (only the port number, leave the rest alone)
```
    "Url": "http://0.0.0.0:5214"
```



## Usage

Run the **RnControlApi.exe** executable to start the application.
You can minimize the window if you want.

To restart Roon Core simply call:
```
http://myRoonStreamer:5214/restartCore
```

Note: the restart commands are the same as a "stop" followed by a "start" with a 5 second delay between stop and start - this delay can also be adjusted in the `appsettings.json` file.

#### Other allowed commands ####
(replace `myRoonStreamer` by your machine name ou IP address)

 - Start Roon Core
    ```
    http://myRoonStreamer:5214/startCore
    ```
 - Stop Roon Core
    ```
    http://myRoonStreamer:5214/stopCore
    ```

 - Restart Roon Core
    ```
    http://myRoonStreamer:5214/restartCore
    ```

 - Start Roon Server
    ```
    http://myRoonStreamer:5214/startServer
    ```
 - Stop Roon Server
    ```
    http://myRoonStreamer:5214/stopServer
    ```
 - Restart Roon Server
    ```
    http://myRoonStreamer:5214/restartServer
    ```




## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.



## License

[The Unlicense](https://unlicense.org)
