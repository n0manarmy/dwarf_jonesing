extends Node2D


export var speed = 300
export var moving = false
var dest_name = ""
var MAX_TIME = 500

onready var scene_01_area2d = get_node("WalkingPath/Scene01")
onready var scene_02_area2d = get_node("WalkingPath/Scene02")
onready var scene_03_area2d = get_node("WalkingPath/Scene03")
onready var scene_04_area2d = get_node("WalkingPath/Scene04")
onready var scene_05_area2d = get_node("WalkingPath/Scene05")
onready var scene_06_area2d = get_node("WalkingPath/Scene06")
onready var scene_07_area2d = get_node("WalkingPath/Scene07")
onready var scene_08_area2d = get_node("WalkingPath/Scene08")
onready var scene_09_area2d = get_node("WalkingPath/Scene09")
onready var scene_10_area2d = get_node("WalkingPath/Scene10")
onready var scene_11_area2d = get_node("WalkingPath/Scene11")
onready var scene_12_area2d = get_node("WalkingPath/Scene12")
onready var scene_13_area2d = get_node("WalkingPath/Scene13")

onready var scene_01_node = get_node("InfoScene/Scene01")
onready var scene_02_node = get_node("InfoScene/Scene02")
onready var scene_03_node = get_node("InfoScene/Scene03")
onready var scene_04_node = get_node("InfoScene/Scene04")
onready var scene_05_node = get_node("InfoScene/Scene05")
onready var scene_06_node = get_node("InfoScene/Scene06")
onready var scene_07_node = get_node("InfoScene/Scene07")
onready var scene_08_node = get_node("InfoScene/Scene08")
onready var scene_09_node = get_node("InfoScene/Scene09")
onready var scene_10_node = get_node("InfoScene/Scene10")
onready var scene_11_node = get_node("InfoScene/Scene11")
onready var scene_12_node = get_node("InfoScene/Scene12")
onready var scene_13_node = get_node("InfoScene/Scene13")

onready var signals_manager = get_node("/root/SignalsManager")
onready var global_data = get_node("/root/GlobalData")
onready var root_scene = get_node_or_null("/root/RootScene")
onready var player_sprite = get_node("PlayerSprite")
onready var start_values_scene = get_node_or_null("/root/RootScene/StartValuesScene")

var debug_this = false

# Called when the node enters the scene tree for the first time.
func _ready():
	if debug_this: print(self.name + "._ready()")
	player_sprite.hide()
	
	if self.get_parent() == get_node("/root"):
		if debug_this:print(self.name + ".running scene")
		setup_player_for_move()
	else:
		if debug_this:print(self.name + ".running project")
	
	
	signals_manager.connect("player_time_up", self, "player_time_up")
	signals_manager.connect("player_data_updated", self, "setup_player_for_move")
	
	if start_values_scene != null:
		start_values_scene.connect("reset_players", self, "setup_player_for_move")
		start_values_scene.connect("enable_location_buttons", self, "disable_location_buttons")
	
	if scene_01_area2d != null && scene_01_node != null:
		connect_signals()
		
	if root_scene != null:
		root_scene.connect("startup_disable_location_buttons", self, "disable_location_buttons")
		
	if get_node_or_null("/root/RootScene/LocationEntryArea2D") != null:
		if debug_this: print(self.name + ".if get_node_or_null(\"/root/RootScene/LocationEntryArea2D\") != null:")
		var location_entry_area_2d = get_node_or_null("/root/RootScene/LocationEntryArea2D")
		location_entry_area_2d.connect("location_entered", self, "my_set_process")
	elif get_node_or_null("/root/LocationEntryArea2D") != null:
		if debug_this: print(self.name + ".elif get_node_or_null(\"/root/LocationEntryArea2D\") != null:")
		var location_entry_area_2d = get_node_or_null("/root/LocationEntryArea2D")
		location_entry_area_2d.connect("location_entered", self, "my_set_process")

	my_set_process(false)
#	setup_player_for_move()
	
func connect_signals():
	
	scene_01_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_02_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_03_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_04_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_05_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_06_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_07_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_08_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_09_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_10_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_11_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_12_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	scene_13_area2d.connect("location_entered_stop_movement", self, "my_set_process")
	
	scene_01_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_02_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_03_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_04_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_05_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_06_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_07_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_08_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_09_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_10_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_11_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_12_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	scene_13_area2d.connect("disable_location_buttons", self, "disable_location_buttons")
	
	scene_01_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_02_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_03_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_04_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_05_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_06_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_07_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_08_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_09_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_10_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_11_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_12_node.connect("on_done_clicked", self, "disable_location_buttons")
	scene_13_node.connect("on_done_clicked", self, "disable_location_buttons")
	
func player_time_up():
	if debug_this: print(self.name, ".player_time_up()")
	var travel_path_tile_map: TileMap = get_node("WalkingPath/TravelPathTileMap")
	signals_manager.emit_signal("player_position_updated", travel_path_tile_map.map_to_world(player_sprite.START_POS))
	signals_manager.emit_signal("player_turn_over")	
	my_set_process(false)
	
	
func setup_player_for_move():
	if debug_this: print(self.name + ".setup_player_for_move()")
	var this_player = global_data.players[global_data.current_player - 1]
	player_sprite.modulate = this_player.color
	if debug_this: print(self.name + "start_values_scene: ", start_values_scene)
	player_sprite.show()
	
func move_along_path(dist: float):
	if debug_this: print(self.name + ".move_along_path")
	
	# get current player
	var this_player = global_data.players[global_data.current_player - 1]
#	var player = get_node("/root/Player")
	player_sprite.modulate = this_player.color
	
	if debug_this: print(self.name + ".this_player ", this_player.to_string())
	# get player path
	var player_path: PoolVector2Array = player_sprite.movement_path
	# get player sprite
#	var player_sprite: Sprite = player.get_child(0)
	# get current player position
	var last_pos = player_sprite.position
	# our path position variable
	var x = 0	
	
	if player_path.size() == 0:
		if debug_this: print(self.name + ".player_path.size() == ", player_path.size())
		my_set_process(false)

	if debug_this: print(self.name + ".player_path.size() ", player_path.size())
	if debug_this: print(self.name + ".player_path: ", player_path)
	
	while player_path.size() > 0 && x != player_path.size():
		if debug_this: print(self.name + ".x: ", x)
		
		var dist_to_next = last_pos.distance_to(player_path[x])
		this_player.turn_time_used += 1
		signals_manager.emit_signal("player_data_updated")
		
#		if player_path.size() == 0:
#			if debug_this: print(self.name + ".Pop Menu for location")
#			my_set_process(false)
#			break
			
		if this_player.turn_time_used >= MAX_TIME:
			if debug_this: print(self.name + ".player.turn_time_used >= MAX_TIME")
			player_time_up()
			break
			
#		if dist < 0.0:
#			if debug_this: print(self.name + ".dist < 0.0")
#			my_set_process(false)
#			emit_signal("position_updated", player_path[x])
#			break
		
		if dist <= dist_to_next:
			if debug_this: print(self.name + ".dist <= dist_to_next")
			var pos = last_pos.linear_interpolate(player_path[x], dist / dist_to_next)
			signals_manager.emit_signal("player_position_updated", pos)
			break
			
		dist -= dist_to_next
		last_pos = player_path[x]
		if debug_this: print(self.name + ".player_path[x]: ", player_path[x])
		
		player_path.remove(x)
		x = x + 1
		
		if debug_this: print(self.name + ".for_loop end")
		
	if debug_this: print(self.name + ".current player sprite: ", player_sprite.position)
	if debug_this: print(self.name + ".end player_path: ", player_path)
	player_sprite.movement_path = player_path
	if debug_this: print(self.name + ".end this_player.movement_path: ", player_sprite.movement_path)	
	
	
func on_button_move_pressed(dest: Vector2):
	if debug_this: print(self.name + ".on_button_move_pressed, dest: ", dest)
	
#	var this_player = global_data.players[global_data.current_player - 1]
#	var player_sprite: Sprite = player.get_child(0)
	
	my_set_process(true)
	
	var travel_path_tile_map: TileMap = get_node("WalkingPath/TravelPathTileMap")
	if debug_this: print(self.name + ".travel_path_tile_map: ", travel_path_tile_map)	
	var tile_map_dest = travel_path_tile_map.map_to_world(dest)
	if debug_this: print(self.name + ".tile_map_dest: ", tile_map_dest)
	var path = get_node("WalkingPath").get_simple_path(player_sprite.global_position, tile_map_dest)
	if debug_this: print(self.name + ".path: ", path)
	player_sprite.movement_path = PoolVector2Array(path)


func _process(delta):
	if debug_this: print(self.name + "._process")
	move_along_path(speed * delta)
	

func disable_location_buttons():
	if debug_this: print(self.name + ".disable_location_buttons")
	var button_group: ButtonGroup = load("res://res/LocationButtonResource.tres")
	for _button in button_group.get_buttons():
		var button: Button = _button
		if button.disabled:
			button.disabled = !button.disabled
			if debug_this: print(self.name + ".button.disabled ", button.disabled)			
		else:
			button.disabled = !button.disabled
			if debug_this: print(self.name + ".button.disabled ", button.disabled)			
		
func my_set_process(val: bool):
	if debug_this: print(self.name + ".my_set_process ", val)
	set_process(val)
