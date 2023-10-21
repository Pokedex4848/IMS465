# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [2.0.0-pre.3] - 2023-05-31
### Added
* New `activated` property in NavMeshLink, useful to control whether agents are allowed to traverse the link
* New `occupied` property in NavMeshLink, useful to determine whether an agent is using the link
* New `startTransform`, `endTransform` properties in NavMeshLink, useful to define the ends of the link through Transform references as an alternative to points in 3D space
* New `autoUpdatePositions`, `biDirectional`, `costOverride` properties and the `UpdatePositions()` method, introduced as "deprecated" in order to facilitate the upgrade from OffMeshLinks

### Changed
* The `costModifier` property is now of type `float`, as expected by the Navigation system.

### Fixed
* Published the missing API reference documentation for the properties made available with 2022.2

## [1.1.3] - 2023-04-13
### Changed
* Remove some unnecessary files from the package

## [1.1.2] - 2023-04-03
### Changed
* The _AI Navigation_ overlay in the scene view remembers which sections have been collapsed
* Updated a large part of the documentation to reflect the current functionality

## [1.1.1] - 2022-10-21
### Changed
* Clarified the information text displayed by the NavMesh Updater

## [1.1.0-pre.2] - 2022-08-09
### Changed
* The Dungeon scene included in the package samples now uses tile prefabs that contain a `NavMeshSurface` component instead of the `NavMeshPrefabInstance` script.
* The Drop Plank scene included in the package samples now has a `NavMeshSurface` component and the `NavMeshSurfaceUpdater` script on the geometry, as well as the `DynamicNavMeshObject` script on the Plank prefab for dynamically updating the `NavMesh` when new Planks are instantiated.
* The offset when instantiating Planks in the Drop Plank scene has been reduced.
* The Sliding Window Infinite and the Sliding Window Terrain scenes included in the package samples now use the `NavMeshSurfaceVolumeUpdater` script instead of the `LocalNavMeshBuilder` and `NavMeshSourceTag` scripts for dynamically updating the `NavMesh`. 
* The Modify Mesh scene included in the package samples now uses a `NavMeshSurface` component on the Mesh Tool for dynamically updating the `NavMesh` instead of the `LocalNavMeshBuilder` and `NavMeshSourceTag` scripts. The `MeshTool` script now uses the `Update()` method of `NavMeshSurface` for updating the `NavMesh` whenever the mesh is modified.

### Fixed
* The Drop Plank scene included in the package samples now destroys instantiated Planks that have fallen off the edge.
* Missing agent type references in the samples.

### Removed
* The `NavMeshPrefabInstance` and `NavMeshPrefabInstanceEditor` scripts from the package samples were removed.
* The prefab editing scene `7b_dungeon_tile_prefabs` from the package samples was removed. The tiles can now be edited directly as prefabs.
* The `LocalNavMeshBuilder` and `NavMeshSourceTag` scripts from the package samples were removed.

## [1.1.0-pre.1] - 2022-04-27
### Added
* NavMeshSurface supports links generation.
* NavMeshSurface supports HeightMesh baking.
* New package Navigation window adapting the obsolete Unity Navigation window functionalities to the package workflow.

### Changed
* NavMeshSurface is using the _Background Tasks_ window to report the baking progress
* Minimum supported version is increased to Unity 2022.2

## [1.0.0-exp.4] - 2021-07-19
### Changed
* Documentation updated with changes from Unity manual
* Test scripts moved into namespaces Unity.AI.Navigation.Tests and Unity.AI.Navigation.Editor.Tests

## [1.0.0-exp.3] - 2021-06-16
### Fixed
* An assembly definition in the package sample was referencing an invalid AsmDef

## [1.0.0-exp.2] - 2021-05-19
### Fixed
* Baking a NavMeshSurface with a bounding volume was not detecting the geometry nearby the bounds (1027006)

### Changed
* New note in the documentation about the bounding volume of a NavMeshSurface

## [1.0.0-exp.1] - 2021-04-06

This is the first release of the *AI Navigation* package. It contains the scripts that were previously known as *NavMeshComponents* and it adds a few improvements.

### Fixed
* Disabling a NavMeshLink component in the Editor does not remove the link

### Added
* New `minRegionArea` property in `NavMeshSurface` that prevents small isolated patches from being built in the NavMesh
* Documentation for the new `minRegionArea` property

### Changed
* Documentation updated
* Script namespaces changed to Unity.AI.Navigation.*
* The [license](LICENSE.md) has changed.
* The folder structure has changed in accordance to the requirements of the Unity standards for packages.