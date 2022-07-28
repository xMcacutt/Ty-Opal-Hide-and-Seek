
-----------------------------------------------------------------------------------------------------------------
Ty The Tasmanian Tiger - Opal Hide & Seek Creator by xMcacutt
-----------------------------------------------------------------------------------------------------------------

Bundled with this download:
  - Typos.exe
  - TyOpalHideAndSeekCreator.exe
  - OpalHideAndSeekBase folder
  - README.txt
  - OpenAL32.dll


Background

	This application bundle can be used to quickly place a single opal
	into any (non hub boss) level for hide and seek challenges without
	any need to learn how to use modding tools.
	

How to use

   Setting up and backing up old / clean files

 	- Find folder that contains Ty.exe (Probably in steam folder)
 	- Create a new folder called PC_External in this folder
 	- If you already have a PC_External, ensure all .lv2s are backed up and removed
	- The file OpenAL32.dll in the same folder as TY.exe needs to be patched to run mods properly.
		This application has a built in patching tool. Simply hit the 'Select TY.exe folder' button,
		select the folder and press patch. When you want to play the game normally / speedrun the game,
		you will have to unpatch this file. Repeat the process and press unpatch.
	SPEEDRUNNING THE GAME WITH THE PATCHED DLL WONT WORK AND IS AGAINST SRC RULES

   Using the applications

	- Open Ty.exe and TyOpalHideAndSeekCreator.exe
	- In the hide and seek creator, select the OpalHideAndSeekBase folder and your PC_External folder
	- Enter signature initials (any 3 letters to identify yourself)
	- Go through each level and find your hiding spot. Then, press the 'Get Current Ty Pos' button.
	- Copy these coordinates into the corresponding text fields in the hide and seek creator
	- Once all levels (with the checkbox ticked) have values in their fields, hit Create.
	- The lv2s have now been copied, and edited to put opals in the coordinates you defined.

	LEVELS IN HUB 1 HAVE RED OPALS (FIRE)
	LEVELS IN HUB 2 HAVE BLUE OPALS (ICE)
	LEVELS IN HUB 3 HAVE GREEN OPALS (AIR)
	RAINBOW CLIFFS HAS RAINBOW SCALES
	LEVELS IN HUB 4 HAVE YELLOW OPALS (EARTH)
	CASS' CREST HAS GREEN OPALS (AIR)


More Detailed Explanation

	To place game objects into levels, the game uses the lv2 file type which is unencrypted
	and can be edited using a simple text editor. 
	This application simply appends the required text onto the appropriate lv2 file.
	Levels within Ty are given a number letter code based loosely on the hub the level
	was originally intended to be in and the intended order of play.

	a1 Two Up, a2 Walk In The Park, a3 Ship Rex, a4 Bull's Pen
	b1 Bridge On The River Ty, b2 Snow Worries, b3 Outback Safari,
	c1 Lyre Lyre Pants On Fire, c2 Beyond The Black Stump, c3 Rex Marks The Spot, c4 Fluffy's Fjord
	d2 Cass' Crest, d4 Crikey's Cove
	e1 Cass' Pass, e2 Bonus World 1, e3 Bonus World 2, e4 Final Battle

	PC_External is a way of injecting files into the game to overwrite other existing files.
	By placing the edited lv2s into the PC_External folder, we overwrite the level data.
	This application will not place the edited lv2s into the PC_External folder if
	lv2s are already present in the PC_External folder to avoid accidental overwrite.
	Therefore, if you wish to change your Opal hiding spots or have other lv2 mods you
	are currently working on, you will have to first back up and move the lv2s to a different folder.

	Alternatively, the application does not check that the PC_External folder is in the correct parent folder.
	It simply checks whether the folder is called PC_External. Therefore, you may simply create a PC_External
	folder anywhere else in your file system. 


Suggested Rules

	Share your created hide and seek challenges with the community.
	Either race on the same one or race on each others.
	Rank your challenges by difficulty according to the following guidelines.

	Easy - Visible and easily reachable opals with only basic movement and no major glitches or tricks
	Medium - Visible but not necessarily easily reachable opals that may require basic glitches.
	Hard - Not necessarily visible or easily reachable opals which may require major glitches NO OUT OF BOUNDS
	Intense - Not easily reachable or visible opals which mostly require major glitches and out of bounds tricks

	Happy Hiding :)

-----------------------------------------------------------------------------------------------------------------

Author: Matthew Cacutt
Version: 2.0.0
Date: 28/07/2022

CHANGELOG
- Typos rewrite and integration removing the need for a third application.
- Automatic detection of bushpig coordinate memory address switching.
- New file, save, saveas, and load buttons with .seek file format for the application to read/write to.
- OpenAL32.dll patcher.
- Modified Rainbow Cliffs to give all rangs on load in lv2. (Thanks to Floralz for the lv2 script)

PLANNED CHANGES
- Create trigger spheres and sound props check box.
- Distance to opal UI (Likely using memory address of in game counter)

-----------------------------------------------------------------------------------------------------------------

