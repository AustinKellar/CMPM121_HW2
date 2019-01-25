Name: Austin Kellar

Scene: Assets/Scenes/HW2

Controls:
- WASD to move
- Spacebar to jump
- Left Shift to sprint

Notes:
- I got the landscape scene, player character art/animations and chicken art/animations from the Unity asset store
- The player character came with a script that gave it movement but I deleted those scripts from the prefab so that 
  I could write my own movement for this assignment. I am ONLY using the art and animations. The asset came with 
  an animator component. I figured out how to use it by reading Character_Animations.cs from its Source/Scripts folder,
  then called the animator functions from my own PlayerAnimations.cs. The movement that you see in the scene is entirely
  my own code.
  - I left the movement code in the assets folder in case you want to compare them. 
  - The Asset's given code is in Assets/Medieval_Toon_Character/Source/Scripts
  - All of my own scripts are in Assets/Scripts
  - My movement scripts are in Assets/Scripts/Player (PlayerMovement.cs / PlayerInput.cs)