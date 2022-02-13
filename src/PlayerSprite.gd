extends Node2D

onready var scene_01_area2d =  get_node_or_null("../WalkingPath/Scene01")
onready var scene_02_area2d =  get_node_or_null("../WalkingPath/Scene02")
onready var scene_03_area2d =  get_node_or_null("../WalkingPath/Scene03")
onready var scene_04_area2d =  get_node_or_null("../WalkingPath/Scene04")
onready var scene_05_area2d =  get_node_or_null("../WalkingPath/Scene05")
onready var scene_06_area2d =  get_node_or_null("../WalkingPath/Scene06")
onready var scene_07_area2d =  get_node_or_null("../WalkingPath/Scene07")
onready var scene_08_area2d =  get_node_or_null("../WalkingPath/Scene08")
onready var scene_09_area2d =  get_node_or_null("../WalkingPath/Scene09")
onready var scene_10_area2d =  get_node_or_null("../WalkingPath/Scene10")
onready var scene_11_area2d =  get_node_or_null("../WalkingPath/Scene11")
onready var scene_12_area2d =  get_node_or_null("../WalkingPath/Scene12")
onready var scene_13_area2d =  get_node_or_null("../WalkingPath/Scene13")

onready var scene_01_node = get_node_or_null("../InfoScene/Scene01")
onready var scene_02_node = get_node_or_null("../InfoScene/Scene02")
onready var scene_03_node = get_node_or_null("../InfoScene/Scene03")
onready var scene_04_node = get_node_or_null("../InfoScene/Scene04")
onready var scene_05_node = get_node_or_null("../InfoScene/Scene05")
onready var scene_06_node = get_node_or_null("../InfoScene/Scene06")
onready var scene_07_node = get_node_or_null("../InfoScene/Scene07")
onready var scene_08_node = get_node_or_null("../InfoScene/Scene08")
onready var scene_09_node = get_node_or_null("../InfoScene/Scene09")
onready var scene_10_node = get_node_or_null("../InfoScene/Scene10")
onready var scene_11_node = get_node_or_null("../InfoScene/Scene11")
onready var scene_12_node = get_node_or_null("../InfoScene/Scene12")
onready var scene_13_node = get_node_or_null("../InfoScene/Scene13")

onready	var travel_path_node = get_node_or_null("../../TravelPath")

export var movement_path = PoolVector2Array()
export var START_POS = Vector2(31, 10)

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")
	
	if scene_01_area2d != null:
		connect_signals()
	
	if travel_path_node != null:
		travel_path_node.connect("position_updated", self, "update_sprite_position")
	
#	if get_node_or_null("../TravelPath") != null:
#		if debug_this: print(self.name + ".if get_node_or_null(\"/root/RootScene/TravelPath\") != null:")
#		var travel_path_node = get_node_or_null("../TravelPath")
#		travel_path_node.connect("position_updated", self, "update_sprite_position")
#	elif get_node_or_null("../TravelPath") != null:
#		if debug_this: print(self.name + ".elif get_node_or_null(\"/root/TravelPath\") != null:")
#		var travel_path_node = get_node_or_null("/root/TravelPath")
#		travel_path_node.connect("position_updated", self, "update_sprite_position")

func connect_signals():
	if debug_this: print(self.name + ".connect_signals")
	
	scene_01_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_02_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_03_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_04_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_05_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_06_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_07_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_08_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_09_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_10_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_11_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_12_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	scene_13_area2d.connect("location_entered_move_player", self, "update_sprite_position")
	
	scene_01_node.connect("update_position", self, "update_sprite_position")	
	scene_02_node.connect("update_position", self, "update_sprite_position")	
	scene_03_node.connect("update_position", self, "update_sprite_position")
	scene_04_node.connect("update_position", self, "update_sprite_position")
	scene_05_node.connect("update_position", self, "update_sprite_position")
	scene_06_node.connect("update_position", self, "update_sprite_position")
	scene_07_node.connect("update_position", self, "update_sprite_position")
	scene_08_node.connect("update_position", self, "update_sprite_position")
	scene_09_node.connect("update_position", self, "update_sprite_position")
	scene_10_node.connect("update_position", self, "update_sprite_position")
	scene_11_node.connect("update_position", self, "update_sprite_position")
	scene_12_node.connect("update_position", self, "update_sprite_position")
	scene_13_node.connect("update_position", self, "update_sprite_position")

func update_sprite_position(pos: Vector2):
	if debug_this: print(self.name + ".update_sprite_position" + ".pos.x " + pos.x as String + " pos.y " + pos.y as String )
	self.position = pos

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
