﻿# Resolutioner
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
 - [ ] `CORE` saving and loading config on start
 - [ ] `CORE` trigger: "Now" button
 - [ ] `CORE` trigger: user login
   - [ ] autostart
   - [ ] trigger: on start
 - [ ] `CORE` trigger: user switch
 - [X] `CORE` trigger: user logout
 - [ ] `FEAT` trigger: distinction between logoff and shutdown

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