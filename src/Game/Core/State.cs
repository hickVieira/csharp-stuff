/*
- Json Files
- Files Version Conversion
- Manifest Files
- Manifest Master/Plugin Files
- Cell Object
- Cell Files
- Unity interop

loadorder.txt (plugin load order) (maybe could make ops like add/mult)
/base
    player.json
    map.json
    ...
/dlc1
    santa.json
    ...
/mod1
    pistol.json
    ...

init
    load_modules
        sort_modules_by_loadorder
        create_manifest
    load_gamesettings
        load_graphics
        load_bindings
    load_mainmenu
        load_gamestate
        set_gamesettings
    loop
        create_objects_from_gamestate
        save_objects_to_gamestate
*/

// namespace Game.Core
// {
//     public class State
//     {
//     }
// }