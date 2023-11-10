extends Node2D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

signal update_round_timer
signal update_rounds_increment

@onready var global_data = get_node("/root/GlobalData")

var debug_this = true
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func reset_time_used():
	# set current player time to 0
	var current_player = global_data.current_player
	global_data.players[current_player].turn_time = 0
	emit_signal("update_round_timer", 0)

func increment_time_value(val):
	# capture current player time
	var current_player = global_data.current_player
	global_data.players[current_player].turn_time += val
	emit_signal("update_round_timer", global_data.players[current_player].turn_time)

func update_rounds_increment():
	global_data.game_rounds += 1
	emit_signal("update_rounds_increment")
	
	
	
# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
