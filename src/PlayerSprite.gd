extends Node2D

@onready var scene_01_area2d =  get_node_or_null("../WalkingPath/Scene01")
@onready var scene_02_area2d =  get_node_or_null("../WalkingPath/Scene02")
@onready var scene_03_area2d =  get_node_or_null("../WalkingPath/Scene03")
@onready var scene_04_area2d =  get_node_or_null("../WalkingPath/Scene04")
@onready var scene_05_area2d =  get_node_or_null("../WalkingPath/Scene05")
@onready var scene_06_area2d =  get_node_or_null("../WalkingPath/Scene06")
@onready var scene_07_area2d =  get_node_or_null("../WalkingPath/Scene07")
@onready var scene_08_area2d =  get_node_or_null("../WalkingPath/Scene08")
@onready var scene_09_area2d =  get_node_or_null("../WalkingPath/Scene09")
@onready var scene_10_area2d =  get_node_or_null("../WalkingPath/Scene10")
@onready var scene_11_area2d =  get_node_or_null("../WalkingPath/Scene11")
@onready var scene_12_area2d =  get_node_or_null("../WalkingPath/Scene12")
@onready var scene_13_area2d =  get_node_or_null("../WalkingPath/Scene13")

@onready var scene_01_node = get_node_or_null("../InfoScene/Scene01")
@onready var scene_02_node = get_node_or_null("../InfoScene/Scene02")
@onready var scene_03_node = get_node_or_null("../InfoScene/Scene03")
@onready var scene_04_node = get_node_or_null("../InfoScene/Scene04")
@onready var scene_05_node = get_node_or_null("../InfoScene/Scene05")
@onready var scene_06_node = get_node_or_null("../InfoScene/Scene06")
@onready var scene_07_node = get_node_or_null("../InfoScene/Scene07")
@onready var scene_08_node = get_node_or_null("../InfoScene/Scene08")
@onready var scene_09_node = get_node_or_null("../InfoScene/Scene09")
@onready var scene_10_node = get_node_or_null("../InfoScene/Scene10")
@onready var scene_11_node = get_node_or_null("../InfoScene/Scene11")
@onready var scene_12_node = get_node_or_null("../InfoScene/Scene12")
@onready var scene_13_node = get_node_or_null("../InfoScene/Scene13")

@onready var signals_manager = get_node_or_null("/root/SignalsManager")
@onready	var travel_path_node = get_node_or_null("../../TravelPath")
@onready var global_data = get_node("/root/GlobalData")

@export var movement_path = PackedVector2Array()
@export var START_POS = Vector2(31, 11)

var debug_this = false

func _ready():
	if debug_this: print(self.name + "._ready")
	
	# if scene_01_area2d != null:
	# connect_signals()
	# signals_manager.connect("location_entered_move_player", self, "update_sprite_position")

	if travel_path_node != null:
		signals_manager.connect("location_entered_move_player", Callable(self, "update_sprite_position"))
		signals_manager.connect("player_position_updated", Callable(self, "update_sprite_position"))
		signals_manager.connect("update_position", Callable(self, "update_sprite_position"))	


func update_sprite_position(caller: String, pos: Vector2):
	if debug_this: print(self.name + ".update_sprite_position", " caller: ", caller)
	if debug_this: print(self.name + ".pos.x " + str(pos.x) + " pos.y " + str(pos.y))
	self.position = pos

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
