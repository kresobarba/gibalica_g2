# Gibalica G2 🤸
## INNOSID Erasmus+ Valencia Hackathon 2022

Gibalica is a part of the INNOSID Erasmus+ Valencia Hackathon, and is intended to use the Google's state of the art machine learning library MediaPipe in conjunction with Unity to deliver an interactive light excercise assistant app, with pose detection, excercise tracking, repetition counting and minigames to stimulate health awareness in users and promote fitness and improve motor skills and coordination.

[Find more on Gibalica and INNOSID here](https://sociallab.fer.hr/innosid/valencia-2022-hackathon/case-studies/gibalica/)

------------------------------------------------
## Getting started

### Prerequisites

This project requires Unity 2020.3.30f1 LTS.

### Instalation

```
git clone https://github.com/kresobarba/gibalica_g2.git
```

In order to work with the project, you need to download the MediaPipe libraries that are built and distributed separately because of their large file size:

- Clone this repository and navigate to the GibalicaG2 subfolder.
- Download .zip file from this link [GibalicaG2Assets_Packages.zip](https://drive.google.com/file/d/1fWA2DUBxoXQvR8ZQQCGqmrlm0GveiHMN/view?usp=sharing).
- Extract Assets and Packages from .zip file into the GibalicaG2 folder and merge with existing Assets and Packages folders.

### Starting the application

To start the application on Windows, simply run the .exe file. To run the application on Android mobile phone, install the .apk file using File Manager.


## Technology

- **Unity 2020.3.30f1 LTS** 
- **C#** - used for writing scripts
- **MediaPipe libraries** - used for pose detection

## About the application

It is intuitive that for the overall wellbeing of people, especially people with disabilities, a proper level of physical activities is necessary. This product is intended to be used as a virtual fitness trainer. It aims to encourage physical activities of all people.

## Application usage

The app is designed to help user do squats through 3 different modes:
- **Day/Night Game** - the user plays the game Day/Night in which he or she needs to squat when the application says it is night and stand up when it is day
- **Timed Mode** - the user does the squats for a specific amount of time (default: 60 seconds)
- **Free Mode** - the user does the squats for unlimited amount of time

In all modes the application counts the number of squats the user has done. After finishing the exercise, the application gives statistics about the number of squats and the time of exercising. Ten highest scores overall are saved and the user can access them navigating from the main screen.

## Accessibility features

The following accessibility features are implemented to ease the use for people with disabilities:

- **Dark/light theme** – sets the preferred contrast
- **Font change** – font becomes easier to read for people with dyslexia
- **Sound on/off** - feature that enables blind people to use the app via sound

## Pose detection

Pose detection and classification are achieved by MediaPipe libraries. MediaPipe Pose is a ML solution for high fidelity body pose tracking, inferring 33 3D landmarks. The landmarks are used for classifying the pose.

In our application the squat is detected by using MediaPipe GHUM model. The application detects the landmarks for the hips and the knees and checks if they are close together. If the distance is smaller than the specified threshold, the pose is classified as a squat. Otherwise, it is assumed that the user is standing. The landmarks of the ankles are used as control variables, to assure that the whole body of the user is visible and not to close to the camera.

## Team

- **Krešimir Barbarić** - Project Manager & Developer
- **Jelena Nemčić** - Developer
- **Diego Giménez Asensi** - Tester

## Acknowledgements

Many thanks to the [homuler's MediaPipeUnityPlugin](https://github.com/homuler/MediaPipeUnityPlugin) and to our supervisor Jurica Babić
