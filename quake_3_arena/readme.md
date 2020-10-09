# Quake 3 Arena Setup Guide  

## Unlocking All Levels
Player progress is tracked in the `../baseq3/q3config.cfg` file in the string  
```
seta g_spScores<difficulty> "\l<level#>\1\l<level#>\1"
```  
where `difficulty` represents a difficulty level (1 [I Can Win] - 5 [Nightmare]) and `level#` represents a level or 'deathmatch'. 

Quake 3 has 25 levels labelled 0 to 24 with 0 being the first level of tier 1 (Ranger) and 24 being the intro level with Crash (it seems that this level was built last) and 23 being the final tier with xaero.

The string
```
"\l0\1\l1\1\l2\1\l3\1\l4\1\l5\1\l6\1\l7\1\l8\1\l9\1\l10\1\l11\1\l12\1\l13\1\l14\1\l15\1\l16\1\l17\1\l18\1\l19\1\l20\1\l21\1\l22\1\l23\1\l24\1"
```
will unlock all levels of the game and can be generated with the `vi` command:
```
TODO
useful links:
https://stackoverflow.com/questions/29366266/write-lines-in-vim-using-a-for-loop
https://stackoverflow.com/questions/6577508/how-to-merge-multiple-lines-into-one-line-in-vim
```

## Graphics Settings
**Game crashes on some levels.**  

Follow [this](https://swissmacuser.ch/how-you-want-to-run-quake-iii-arena-in-2018-with-high-definition-graphics-120-fps-on-5k-resolution/#.XjcHAWhKiUl) link to change graphics settings.  

Need to try using [ioquake3](https://ioquake3.org/).  

