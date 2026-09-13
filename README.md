# DadsDustBuster

DadsDustBuster is a client-side Valheim mod that removes transient dust plumes while preserving sounds, fragments, and non-dust effects.

## Covered actions

- Placing and dismantling build pieces
- Hoe ground leveling, raising, and path work
- Cultivator planting and terrain work
- Sawdust, footstep dust, impact dust, and other transient effects identified by Valheim's dust particle or material names

The mod filters particle systems after Valheim spawns an effect. It removes `build_fog` and dust-tagged particles only, so stone chips, pebbles, placement audio, fire smoke, and persistent environmental effects remain.

## Configuration

`General.Enabled` controls the mod and defaults to `true`.

The configuration file is created at `BepInEx/config/com.dadisbored.dadsdustbuster.cfg` after the first launch.

## Installation

1. Install BepInExPack for Valheim.
2. Copy `DadsDustBuster.dll` into `BepInEx/plugins/DadsDustBuster/`.
3. Launch Valheim.

No server installation is required. Each client that needs dust suppression installs the mod locally.

## Compatibility

Built against Valheim `1.0.12` and BepInExPack Valheim `5.4.2350`.
