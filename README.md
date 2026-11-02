# 2D Dungeon Adventure

A 2D pixel-art dungeon platformer built in Unity with C#. You play a knight who moves through dungeon levels, picks up keys to open doors, fires arrows, avoids traps, and follows a short story from a start menu through to the end.

## What I built

The game itself, the parts that make it play, is my own work written in C#. That includes the arrow shooting and spawning, the doors and the big door, the blue-door interaction, key pickups, chest opening, the dialogue and story flow, and the level and menu structure that ties it all together. The levels (`level0`, `level1`, `level2`), the start menu, and the story scene were built and laid out by me in the Unity editor.

The pixel art, tiles, and the knight character come from free asset packs, which the game is built on top of. The code, the level design, the interactions, and how it all fits together are mine.

## Built with

- **Engine:** Unity
- **Language:** C#
- **Art and tiles:** Cainos "Pixel Art Platformer, Dungeon" (free asset pack)
- **Character sprites:** FreeKnight pack
- **Some tutorial-based helpers:** Brackeys 2D assets

## My main scripts

A few of the gameplay scripts I wrote: `Arrow.cs`, `ArrowSpawner.cs`, `Door.cs`, `BigDoor.cs`, `BlueDoorInteraction.cs`, `KeyPickup.cs`, and `DialogManager.cs`.

## How to open and play

1. Clone the repository:
   ```bash
   git clone https://github.com/Elishane786/2d-dungeon-adventure.git
   ```
2. Open Unity Hub, click Add, and point it at the cloned folder.
3. Open it with the Unity version it was built in. You can check that version in `ProjectSettings/ProjectVersion.txt`, and install the matching one from Unity Hub if you do not have it.
4. Once it opens, go to `Assets/Scenes`, open the `Start menu` scene, and press Play.

## Credits

The art and character assets belong to their original creators and are used under their free-asset terms. Cainos for the dungeon pixel art, and the FreeKnight pack for the knight. All gameplay code and level design is my own.
