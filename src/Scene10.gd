extends Node2D

onready var info_scene = get_node("/root/RootScene/TravelPath/InfoScene")
onready var signals_manager = get_node_or_null("/root/SignalsManager")
var THIS_SCENE_EXIT = Vector2(7,33)

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")	
	signals_manager.connect("scene_change", self, "change_scene")
	self.hide()


func change_scene(caller, scene_name, state):
	if debug_this: print(self.name + ".change_scene() caller ", caller, " state ", state, " scene_name ", scene_name)	
	if scene_name == self.name:
		if state == info_scene.SCENE_STATE.HIDE:
			self.hide()
		else:
			self.show()
	
	
	
func on_done_clicked():
	if debug_this: print(self.name + ".on_done_clicked")
	var travel_path_tile_map: TileMap = get_node("../../WalkingPath/TravelPathTileMap")
	signals_manager.emit_signal("update_position", self.name, travel_path_tile_map.map_to_world(THIS_SCENE_EXIT))
	signals_manager.emit_signal("on_done_clicked", self.name)
	self.hide()
