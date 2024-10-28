# RnControlApi

RnControlApi is a dotnet core simple webserver for controlling (start/stop/restart) the &copy;Roon applications (Core or Server)  in a Microsoft Windows PC.

This is meant to solve the problem when an USB DAC is restarted and &copy;Roon looses the connection to the DAC and one needs to log on to the Windows PC and restart the &copy;Roon Core (or as some people do, restart/reboot the PC).

Since I usually leave my music streamer PC on and I only power off the DAC, when I want to listen to music again and I power on the DAC the &copy;Roon software does not recognize the DAC and I have to login to the PC and restart &copy;Roon manually.
I don't know if this is a &copy;Roon problem or an ASIO Driver problem but thr &copy;Roon restart works.

With this application all I need to do is open a browser in my phone/tablet and call the address for the machine of the audio player with the "restartCore" command... This way I don't need to log into the PC to restart the &copy;Roon Core application.

I created a shortcut for the "restart" address in my phone and now all I need to do is open this shortcut and &copy;Roon restarts and all is good :smile:

## Installation

Copy the files to a folder of your choice.

To start this application automatically on windows logon, I made a shortcut for the executable on
C:\Users\\***MyUserName***\\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup

## Configuration

  "AppSettings": {
    "coreAppName": "Roon", // Replace with your application's process name
    "coreAppPath": "C:\\Users\\Francisco\\AppData\\Local\\Roon\\Application\\Roon.exe", // Replace with the full path to the executable
    "coreRestartDelay": 5, 
    "serverAppName": "RoonServer", // Replace with your application's process name
    "serverAppPath": "C:\\Users\\Francisco\\AppData\\Local\\RoonServer\\Application\\RoonServer.exe", // Replace with the full path to the executable
    "serverRestartDelay": 5 
  }


## Usage

Run the **RnControlApi.exe** executable to start the application.
You can minimize the window if you want.

```python
import foobar

# returns 'words'
foobar.pluralize('word')

# returns 'geese'
foobar.pluralize('goose')

# returns 'phenomenon'
foobar.singularize('phenomena')
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[The Unlicense](https://unlicense.org)