# 2D Unity Adventure Game

A 2D platform-style adventure game built with Unity and C#. The player explores different areas of the map, interacts with NPCs, fights enemies using a bow, and tries to reach the final objective: obtaining the legendary sword.

This project was completed as part of my bachelor's studies, where I worked on modifying, improving, and organizing the game mechanics and project structure.

## Project Overview

This game is a simple 2D adventure prototype focused on gameplay programming in Unity. The main goal is to move through the level, survive enemy encounters, and complete the final mission.

The game includes:

- Player movement and jumping
- Bow-and-arrow combat
- Health and damage system
- Friendly NPC interaction
- Enemy chase and attack behavior
- Multiple map sections
- Win and lose states
- Background music loop

## Gameplay Objective

The player progresses through the following sequence:

1. Interact with NPCs in the village
2. Receive the bow weapon
3. Leave the blocked village area
4. Survive enemy encounters in the forest
5. Reach and obtain the legendary sword to win the game

If the player's health reaches zero, the game ends.

## Features

### Player
- Left and right movement
- Jumping
- Projectile attack using bow and arrow
- Health system with 3 lives

### Friendly NPCs
- Interaction system
- Chief NPC gives the bow to the player
- Guard NPC helps guide game progression

### Enemy NPCs
- Detect and chase the player within range
- Damage the player on contact
- Health system for enemies
- Different enemy strength levels

### Environment
- Multiple sections: Village, Open Plains, Forest, Final Area
- Cloud movement
- Background soundtrack loop

### Game States
- Win screen when the sword is collected
- Game over screen when health reaches zero

## Tech Stack

- **Game Engine:** Unity
- **Programming Language:** C#
- **IDE:** Visual Studio Code
- **Deployment:** itch.io

## Project Structure

```text
Assets/
  C# Scripts/
  Music/
  Scenes/
  Sprites/
Packages/
ProjectSettings/
```
## Folder Description
Assets/C# Scripts: gameplay logic and mechanics
Assets/Music: background soundtrack
Assets/Scenes: main game scene
Assets/Sprites: character, NPC, and environment visuals
Packages and ProjectSettings: Unity-generated configuration files required for the project

## How to Run the Project
Clone this repository
Open the project in Unity
Load the main scene from the Scenes folder
Press Play in the Unity Editor

## Deployment

The project was deployed on itch.io using Unity WebGL build.

itch.io profile: [github.com//kamalzada37]

## Controls

Move Left / Right: Keyboard input
Jump: Keyboard input
Attack: Keyboard input
Interact: Keyboard input

## Note: This game is designed for keyboard-based play and is best used on laptop or desktop devices. Mobile touch controls are not implemented.

## My Contribution

This repository is part of my academic work, and I made changes to the project to improve and adapt it for my assignment. My work included modifying gameplay logic, adjusting project content, and preparing the repository as part of my bachelor's portfolio.

## Known Issues

Some issues that may still appear:

Player rotation caused by physics setup
Friendly NPCs may react to projectiles when they should not
Enemies may continue chasing longer than expected
Player may reach unintended parts of the map in some cases

## Future Improvements

Possible next steps for this project:

Add a boss fight
Add restart or respawn system
Add menu screen
Add safehouse or healing area
Add sprite animations
Improve enemy return behavior
Add mobile controls
Improve collision handling
Add smoother area-based music transitions

## Assets and References

This project uses learning material and external resources for guidance and inspiration, including Unity tutorials and public tools for audio and visuals.

Main references include:

Zigurous Unity tutorials
Game Maker's Toolkit Unity tutorial
Tony Morelli Unity audio tutorial
AIVA for music generation
Photoshop for sprite editing

## License

This project is for educational and portfolio purposes.
