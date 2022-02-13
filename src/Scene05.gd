extends Node2D

signal on_done_clicked
signal update_position(new_pos)

var THIS_SCENE_EXIT = Vector2(50,32)

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")	
	pass # Replace with function body.
	
	
func on_done_clicked():
	if debug_this: print(self.name + ".on_done_clicked")
	var travel_path_tile_map: TileMap = get_node("../../WalkingPath/TravelPathTileMap")
	emit_signal("update_position", travel_path_tile_map.map_to_world(THIS_SCENE_EXIT))
	emit_signal("on_done_clicked")
	self.hide()
