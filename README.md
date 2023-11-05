# GTFOCharactersMod

A small mod to GTFO to add in a bit of flavor to each of the characters. They're given a small increase to a modifier in accordance with their backstory.

## Usage
This can be compiled and dropped into the plugins folder and should start working immediately. The logs can be consulted if you suspect it is not working.

## Compiling

This project was compiled with JetBrain's Rider on Linux, but can be compiled with `dotnet build` in the project root directory.

You will need to create a `deps` folder and put in specific .dll files from the BepInEx interop folder, created when you launch a modded instance with [R2Modman](https://thunderstore.io/package/ebkr/r2modman/) with BepInEx installed. You can copy the specific ones listed in GTFOCharacterMod.csproj file, or just copy over the entire directory just to be safe.

## Contributing

If you spot an issue, feel free to make a PR, and I'll try to get back to you in a few days!
