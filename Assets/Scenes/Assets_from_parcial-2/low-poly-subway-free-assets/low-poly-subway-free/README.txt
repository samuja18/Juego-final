Low Poly Subway Free
====================

16 low-poly subway props for a stretch of metro platform whose machines work, taken from Low Poly
Subway (116 props, 33 working machines, a station to bring back to life):
https://heyheythere.itch.io/low-poly-subway
Built on Low Poly Industrial Facility's grid and look, as Low Poly Bunker and Low Poly Sewers are,
so the four combine:
https://heyheythere.itch.io/low-poly-industrial-facility
One 2048x2048 texture atlas filtered with mipmaps, the occlusion baked into vertex colours,
real-world scale (1 unit = 1 metre).

The bench seats and backs have separate colliders so items placed on a seat remain reachable. The fare-gate cabinets are separate so the opened aisle stays clear.

What's in the zip
-----------------
glb/        one file per prop, with its animations (the best format for Godot, Blender, three.js)
fbx/        one file per prop, with its animations as takes (Unreal, Unity, most 3D apps)
obj/        one file per prop, still (any 3D app)
textures/   atlas.png, the one texture every prop uses, its glow map, and the seamless floor,
            wall, ceiling and trackway textures it tiles from, 128x128 a metre, for your own
            geometry
icons/      an icon per prop, 256x256 PNG with transparency
props.json  every prop: title, group, size, triangles, parts, animations and its "use" (what kind
            of machine it is and how it's set up)
blender/    every prop in one .blend, the atlas packed in
addons/     the Godot addon, low_poly_subway/: this folder is a Godot 4.3+ project that opens on
            its gallery (.gdignore keeps Godot out of the other folders)
unity/      a .unitypackage for Unity 6.3+ (Built-in and URP): prefabs with Machine.cs, the
            pack's lit shader and a demo scene

The machines
------------
A prop that works has a machine on it (machine.gd in Godot, Machine.cs in Unity, the same script),
set up as its "use" in props.json says: the fare gate takes a ticket from what the player carries,
opens a few seconds and gives it back; the ticket machine drops a ticket at each use; the ticket
is picked up into what the player carries; the departure board and the trough light switch on a
use with nothing to need. A machine is powered while every machine it needs is live, and live
while it's on and powered; it refuses a use without power or without the item it takes.

The grid
--------
Everything snaps to a 2 m grid, 4 m high. A floor or ceiling piece covers one 2 x 2 m cell, its
pivot at the cell's centre on the floor (a ceiling sits 4 m above its pivot, so both go at the
same point). A wall is 2 m long and 0.25 m thick, centred on a cell's edge, its front facing -Y
in Blender (+Z in Godot, -Z in Unity); turn it 90 degrees for the other edges. The platform is at
the floor and the track's slab 1.1 m below it: a track piece is two cells across and one along,
so it goes on the line between two cells, and a platform edge is a floor piece with its edge on
its -Y side, turned to face the track. A wall prop (the poster) has its pivot on the wall's face,
at the floor: put it 0.125 m off the wall's line. A hanging sign, lamp or board hangs from a
ceiling 4 m above its pivot.

Godot 4.3 and later
-------------------
Copy addons/low_poly_subway/ into your project's addons/ folder. Each prop is a scene in props/:
drag it into your level and turn on grid snapping at 1 m. It has a box collider (StaticBody3D) on
each of its parts, the gate's paddles' moving with them, and a prop with animations has an
AnimationPlayer. Wire what a machine needs in the inspector (needs), or in code, and listen for
its signals:

    gate.refused.connect(func(why): print("the gate says no: ", why))   # gate: the fare gate
    gate.use(carried)                            # what the player's use key calls

demo/gallery.tscn shows every prop: drag to turn, arrows to browse, A for all of them.
Low Poly Subway uses the same addon folder: it installs over this one.
The props use one material, props.tres: the atlas times the vertex colours, lit, with the glow map.

Unity 6.3 and later
-------------------
Import the .unitypackage in unity/. Every prop is a prefab with box colliders and an Animation
component with its clips; a machine's has Machine.cs, set up in the inspector, with UnityEvents
for what it does. Documentation.txt there has the details.

Other engines and apps
----------------------
Use fbx/, glb/ or obj/ with textures/atlas.png, filtered, with mipmaps, multiplied by the vertex
colours (the baked occlusion) in your material. The machines are Godot's and Unity's scripts;
elsewhere their animations are there to play, and props.json says how each is meant to work.

License: CC BY 4.0, see LICENSE.txt for the credit line. Made by heyheythere:
https://heyheythere.itch.io
