## Simple Calculator

## Description
This project is a simple calculator that supports only one math operation, addition. It is developed as part of a test case for Loppi Poppi LLC. The application saves state between sessions, including entered expressions and calculation history.

## Features
- Supports entering expressions in the format: `number + number` (e.g. `54+21`).
- Displays an error message for invalid expressions (e.g., `45+-88`).
- Saves the state of the application between sessions.
- Computation history is displayed on the screen.
- Implemented using Clean Architecture and MVP (Model-View-Presenter) pattern.
- The application is broken into modules for code reuse.

## Technical Details
- **Architecture:** Clean Architecture.
- **Template:** MVP (Model-View-Presenter).
- **DI container:** Zenject.
- **Modules:**
  - **Core Calculator:** Expression processing logic.
  - **UI Module:**UI display and error handling.

## Usage Scenario
1- Opening the application: User sees the input field and the `Result` button.
2. Entering an expression: The user enters an expression in the format `number + number`.
3. Pressing `Result`: 
   - On correct entry, the result is displayed.
   - If there is an error, `Error` is displayed and a dialog box with an explanation appears.
4. Closing and reopening the application: The state (input and history) is saved and restored.

Translated with DeepL.com (free version)
## Installation and startup
1. Clone the repository:
   ```bash
   git clone https://github.com/Haleralex/CalculatorLoppi.git
2. Open the project in Unity (recommended version: 2021.3 or higher).

3. Build the project:
   - In Unity, select **File > Build Settings**.
   - Specify the target platform (Windows, macOS, or Linux, or Android or iOS).
   - Click **Build**.

4. Run the built application on the selected platform.
