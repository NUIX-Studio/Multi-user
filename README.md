# Multi-user
## Overview
Multi-user NUIX Studio is a different version of [NUIX-Studio Rooms](https://github.com/NUIX-Studio/NUIX-Studio-APP), developed specifically to support:
1. Multi-user interaction with objects
2. Different VR headsets (not only Oculus)

At the same time, to support OpenXR framework instead of Oculus framework (which is original NUIX-Studio is based on), the following functionality has been removed ot limited:
1. Hand grabbing
2. Gesture support

## Installation
Download this project from github and open it in [Unity HUB](https://unity.cn/releases), Unity v.2022.2+. After opening it, navigate to Sample scene. In () properties, set the IP address of the server/host. If your device is a server, then keep the default value.

## Synchronization of parameters
By using [Unity Netcode for GameObjects](https://unity.com/products/netcode), the positions and rotations of the selected GameObjects are synchronized. Of course, each project using NUIX-Studio requires its own set of objects and their characterictics to be synchronized for multiple users. In the example scene it is shown how to synchronize the Light states. Mention:
1. GameObjects to be synchronized should have scripts attached derived from NetworkBehaviour, but not MonoBehaviour.
2. NUIX-Studio has built-in functionality of saving and loading Objects and Actions. The server\host will load and save the states of the items in its instance. For example, the Light colour is not synchronized between devices. After the server has saved the devices parameters, and then a new client connects to it, the loaded Light colour will be the one which was saved by the server. Why don't we constantly syncronize all the devices parameters between users? The developer of NUIX-Studio has tried to create a special server for such purpose, but the latency was too high. Unity Netcode solved the latency problem, however, added the described limitations.
