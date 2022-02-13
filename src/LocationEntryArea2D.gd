extends Area2D

signal location_entered_move_player(pos)
signal location_entered_present_scene(scene)
signal location_entered_stop_movement()
signal disable_location_buttons()

onready var player_sprite = get_node("../../PlayerSprite")

var debug_this = true

# Called when the node enters the scene tree for the first time.
func _ready():
	if debug_this: print(self.name + "._ready")
	pass # Replace with function body.

func on_area_2d_body_entered(_body: KinematicBody2D):
	var travel_path_tile_map: TileMap = get_node("../TravelPathTileMap")
	var global_data = get_node("/root/GlobalData")
	
	if debug_this: print(self.name + ".on_area_2d_body_entered")
	if global_data == null:
		print(self.name + ".GlobalData not loaded. return")
		return
	
	if travel_path_tile_map == null:
		if debug_this: print(self.name + ".TravelPathTileMap not loaded. return")
		return
	
	var player_pos = travel_path_tile_map.world_to_map(player_sprite.position)
	player_pos.y -= 4
	if debug_this: print(self.name + ".player_pos: ", player_pos)
	emit_signal("location_entered_move_player", travel_path_tile_map.map_to_world(player_pos))
	emit_signal("location_entered_present_scene", self)
	emit_signal("disable_location_buttons")
	emit_signal("location_entered_stop_movement", false)
