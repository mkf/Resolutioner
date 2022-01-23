# Resolutioner
## a Windows program

![](Zrzut ekranu - taskbar - 2022-01-23 152652.png)

![](Zrzut ekranu - window - 2022-01-23 152812.png)

screenshot is a bit outdated

**Resolutioner is a program for changing primary screen's
resolution on triggers.**

It could be written as a Windows Service to be above all users
and sessions but is not, and instead aims to work by autostarting.

### To do
 - [ ] `CORE` actual resolution setting
   - see https://www.codeproject.com/Articles/36664/Changing-Display-Settings-Programmatically#Changing
     - https://www.codeproject.com/Questions/5261046/How-do-I-change-screen-resolution-C-sharp
     - http://www.jasinskionline.com/WindowsApi/ref/c/changedisplaysettings.html
     - https://docs.microsoft.com/pl-pl/windows/win32/api/wingdi/ns-wingdi-devmodea?redirectedfrom=MSDN
     - https://stackoverflow.com/questions/15897847/how-to-change-screen-resolution-programmatically
     - aaaaaaaaaa
 - [ ] `CORE` saving and loading config on start
 - [ ] `CORE` trigger: "Now" button
 - [ ] `CORE` trigger: user login
   - [ ] autostart
   - [ ] trigger: on start
 - [ ] `CORE` trigger: user switch
 - [X] `CORE` trigger: user logout
 - [ ] `FEAT` trigger: distinction between logoff and shutdown
 - [ ] `FEAT` change scaling too, i think it's even in DEVMODE

### Usage

Click "swap" button to swap "for own use" and "to restore"
resolutions.

Click fetch buttons on the sides to fetch current screen
resolutions into the inputs. If the exact resolution was already
in the opposite inputs, resolution will not be inserted and
the "swap" button will be assigned focus.

"Config Saved" is checked when the config has not changed
since load or since last write. Checking the box triggers write
(save).

"Don't do things" will be stored in the config too and will
inhibit just the resolution changes.