extends Area2D

onready var player_sprite = get_node("../../PlayerSprite")
onready var global_data = get_node("/root/GlobalData")
onready var signals_manager = get_node_or_null("/root/SignalsManager")
onready var travel_path_tile_map: TileMap = get_node("../TravelPathTileMap")

var debug_this = true

# Called when the node enters the scene tree for the first time.
func _ready():
	if debug_this: print(self.name + "._ready")
	pass # Replace with function body.

func on_area_2d_body_entered(_body: KinematicBody2D):
	if debug_this: print(self.name + ".on_area_2d_body_entered")
	
	if travel_path_tile_map == null:
		if debug_this: print(self.name + ".TravelPathTileMap not loaded. return")
		return
	
	var player_pos = travel_path_tile_map.world_to_map(player_sprite.position)
	player_pos.y -= 4
	if debug_this: print(self.name + ".player_pos: ", player_pos)
	signals_manager.emit_signal("location_entered_move_player", self.name, travel_path_tile_map.map_to_world(player_pos))
	signals_manager.emit_signal("location_entered_present_scene", self.name, self)
	signals_manager.emit_signal("disable_location_buttons", self.name, true)
	signals_manager.emit_signal("location_entered_stop_movement", self.name, false)
