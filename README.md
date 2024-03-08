# AngryBirdsStyle

Welcome to AngryBirdsStyle, a small implementation of the well-known game [Angry Birds](https://www.angrybirds.com/).

## Description

- Enjoy 3 exciting levels with 3 difficulties to test your skills.
- Use the intuitive mechanics: Drag the bird backward to adjust the hook's force and release it when you find the perfect angle.
- Need a fresh start? No problem! Simply click the 'Reset' button to restart the current level.

Play now on [itch.io](https://parkpulse.itch.io/angrybirdsstyle)!

## Controls

- Drag bird: Adjust hook's force.
- Release: Launch the bird.
- Reset button: Restart the current level.

## Explanation of Algorithms, Components, and Techniques Used in Scripts

### AngryBird Script

- **Vector Calculation**: The script calculates the direction and magnitude of the bird's movement when dragged (See [line 31](https://github.com/ParkPulse-dev/AngryBirdsStyle/blob/a186e6eb9a08637456c87747d85b7aa5d8cc4671/Assets/Scripts/AngryBird.cs#L31)).
- **Coroutine for Delayed Release**: It uses a coroutine to release the bird after a short delay, simulating the slingshot mechanic (See [line 63](https://github.com/ParkPulse-dev/AngryBirdsStyle/blob/a186e6eb9a08637456c87747d85b7aa5d8cc4671/Assets/Scripts/AngryBird.cs#L63)).
- **Scene Management**: The script handles scene restarts when all objects are static or when the bird hits the boundary (See [line 71](https://github.com/ParkPulse-dev/AngryBirdsStyle/blob/a186e6eb9a08637456c87747d85b7aa5d8cc4671/Assets/Scripts/AngryBird.cs#L71)).

### Pig Script

- **Collision Detection**: Detects collisions with other objects, specifically with the bird, to calculate damage and health depletion (See [line 30](https://github.com/ParkPulse-dev/AngryBirdsStyle/blob/a186e6eb9a08637456c87747d85b7aa5d8cc4671/Assets/Scripts/Pig.cs#L30)).
- **Health Management**: Reduces the pig's health based on collision velocity and destroys it when health is depleted (See [lines 37-50](https://github.com/ParkPulse-dev/AngryBirdsStyle/blob/a186e6eb9a08637456c87747d85b7aa5d8cc4671/Assets/Scripts/Pig.cs#L37-L50)).
- **Sprite Change**: Changes the pig's sprite when its health is below a certain threshold (See [line 46](https://github.com/ParkPulse-dev/AngryBirdsStyle/blob/a186e6eb9a08637456c87747d85b7aa5d8cc4671/Assets/Scripts/Pig.cs#L46)).

### Restart Script

- **Scene Reloading**: Provides a simple functionality to reset the game by reloading the current scene (See [line 22](https://github.com/ParkPulse-dev/AngryBirdsStyle/blob/a186e6eb9a08637456c87747d85b7aa5d8cc4671/Assets/Scripts/Restart.cs#L22)).

