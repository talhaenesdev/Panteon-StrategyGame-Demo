# Panteon Strategy Game Demo

A Unity 2021 LTS strategy game prototype developed as a technical assessment.

---

# Overview

This project demonstrates a modular RTS-style game architecture focused on scalability, maintainability and clean code principles.

Players can:

- Place buildings on a grid
- Produce military units
- Select and control friendly units
- Attack enemy units and buildings
- Manage production through a responsive UI

---

# Screenshots

## Gameplay
![Gameplay](screenshotsgameplay-soldier-house.png)

## Building Placement
![Building Placement](screenshotsgameplay-ghost-builder.png)

## Combat
![Combat](screenshotsgameplay-enemy-build-attack.png)

## Production UI
![Production UI](screenshotsgameplay-soldier-house.png)
# Gameplay Features

---

- ✅ Grid-based building placement
- ✅ Building placement validation
- ✅ Building buffer rule
- ✅ Unit production system
- ✅ Production queue
- ✅ Unit selection
- ✅ Unit movement
- ✅ Combat system
- ✅ Enemy base spawning
- ✅ Health system
- ✅ Dynamic information panel
- ✅ Camera movement
- ✅ Camera zoom
- ✅ Toggle Build Panel (B)

---

# Controls

| Action | Input |
|---------|-------|
| Select Unit / Building | Left Mouse Button |
| Move Selected Unit | Right Mouse Button |
| Attack Enemy Unit / Building | Right Mouse Button |
| Place Building | Left Mouse Button |
| Cancel Building Placement | Right Mouse Button |
| Toggle Build Panel | **B** |
| Camera Move | Mouse Edge |
| Camera Zoom | Mouse Wheel |

---

# Technical Features

- Dependency Injection (Zenject)
- SignalBus Event System
- Object Pooling
- A* Pathfinding
- Factory Pattern
- Service Layer Architecture
- ScriptableObject Driven Data
- Modular UI Architecture
- SOLID Principles

---

# Project Structure

```
Assets
├── Buildings
├── CameraSystem
├── Combat
├── Common
├── Core
├── Enemies
├── Grid
├── Pathfinding
├── UI
└── Units
```

---

# Architecture

The project is built around a modular architecture.

```
Input
    │
    ▼
Controllers
    │
    ▼
Services
    │
    ▼
Factories
    │
    ▼
Entities
    │
    ▼
SignalBus
    │
    ▼
UI
```

The goal is to keep every system loosely coupled and easily extendable.

---

# Performance Optimizations

- Object Pooling
- Physics2D NonAlloc Queries
- Reduced UI Draw Calls
- Sprite Atlas Usage
- RectMask2D instead of Mask where possible
- Optimized TextMeshPro settings
- Clean dependency graph
- Modular installer architecture
- ScriptableObject driven configuration

---

# Technologies

- Unity 2021.3.45f1 LTS
- C#
- Zenject
- TextMeshPro
- ScriptableObjects

---

# Build

Windows x64 executable is available in the **Releases** section.

---

# Unity Version

```
2021.3.45f1
```

---

# Repository

Source Code

```
git clone https://github.com/talhaenesdev/Panteon-StrategyGame-Demo.git
```

---

# Author

**Talha Enes İSLAMOĞLU**

GitHub

https://github.com/talhaenesdev

LinkedIn

https://www.linkedin.com/in/talha-enes-i%CC%87slamo%C4%9Flu/

---

# Notes

This project was developed as a technical assessment to demonstrate:

- Clean Architecture
- Maintainable Code
- Performance Awareness
- Scalable System Design
- Unity Development Best Practices
