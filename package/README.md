# DadsDustBuster

Removes transient dust plumes from Valheim actions without muting sounds or removing non-dust fragments.

## Coverage

- Build-piece placement and dismantling
- Hoe leveling, raising, and path work
- Cultivator planting and terrain work
- Sawdust, footstep dust, impact dust, and other dust-tagged transient effects

Valheim's placement plume uses the `build_fog_lowres` material. Dismantling reuses the piece placement effect, so both operations are covered. Dust-tagged particle systems from other transient effect lists are also cleared, while fire smoke and persistent environmental systems are left unchanged.

## Configuration

`General.Enabled` defaults to `true`.

The configuration file is created at `BepInEx/config/com.dadisbored.dadsdustbuster.cfg` after the first launch.

## Installation

Install with a Thunderstore-compatible mod manager or place `DadsDustBuster.dll` in `BepInEx/plugins/DadsDustBuster/`.

This is a client-side visual mod. Server installation is not required.

## Compatibility

Built against Valheim `1.0.12` and BepInExPack Valheim `5.4.2350`.
