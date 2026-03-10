# ChirpTrek

An interactive hiking experience (CIS4930 Project 2)

This repository contains the Unity project files needed to open, build, and develop the project locally. Follow the steps below to run our project on your local machine:

---

## How to Set Up the Project Locally

### 1. Clone the Repository
DO NOT download the project as a ZIP file.

Use GitHub Desktop (recommended):

1. Open GitHub Desktop  
2. Select "File" → "Clone Repository"  
3. Choose this repository  
4. Select a local folder  
5. Click "Clone"

---

## 2. Open the Project in Unity Hub

1. Open Unity Hub  
2. Click "Open"  
3. Navigate to the folder you cloned  
4. Select the folder containing:
   - `Assets/`
   - `Packages/`
   - `ProjectSettings/`

Unity will automatically regenerate the following folders, which are intentionally not included in the repository:

- `Library/`
- `Temp/`
- `Logs/`
- `UserSettings/`

---

## 3. Unity Version

Use the same Unity version the project was created with.  
You can find this in Unity Hub under the project name or in `ProjectSettings/ProjectVersion.txt`.

Opening the project with a different version may cause errors or package conflicts.

---

## 4. XR Setup

This project uses Unity's XR Interaction Toolkit.

If Unity prompts you to install XR packages, accept the prompt.

To test without a VR headset, enable the XR Interaction Simulator in Project Settings.

---

## 5. Project Structure

ChirpTrek/

├── Assets/            # Scenes, scripts, prefabs, models, materials

├── Packages/          # Package manifest and XR packages

├── ProjectSettings/   # Unity project configuration

└── .gitignore         # Ensures Library/Temp/etc. are not committed

Unity will regenerate all other folders automatically.

---

## Troubleshooting

### Missing scripts or pink materials
Unity is still rebuilding the Library folder. Wait a moment or restart Unity.

### Scenes not opening
Verify you are using the correct Unity version.

### XR input not working
Enable the XR Interaction Simulator in Project Settings.

---

## Contributors

- Madelyne Wirbel
- Matthew Diaz
- Ashley James
- Sophie Shaw
- Gavin Schroeder
