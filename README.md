# Xplosion Graphics Helper

This is a small tool that allows for the [graphics](https://github.com/GuildTV/xplosion-html) to have its visibility triggered from the ATEM.

It allows the graphics bar to perform its own animations and leaves the DSK enabled to allow other graphics to run normally.

This is done by monitoring the state of an unused upstream keyer. This can then be triggered on the ATEM by tieing during transitions and cuts or on its own via a macro.

It is written for .Net Core 2.0 and has been tested on Windows and Linux (including Raspberry Pi)

### Configuration

A config.json file should be located next to the executable, with the following structure. The meId and keyerId are the 0 indexed id of the keyer to monitor for changes (in this case ME1K2)

```
{
  "atemAddress": "127.0.0.1",
  "graphicsAddress": "http://127.0.0.1:3000",

  "meId": 0,
  "keyerId": 1
  
}
```

### Dependencies
* ATEM Client [LibAtem](https://github.com/LibAtem/LibAtem)

### License

This is distributed under the MIT license, see the file LICENSE.md for details.


