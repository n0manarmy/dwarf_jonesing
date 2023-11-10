extends Node2D

signal update_value

@onready var global_data = get_node("/root/GlobalData")

var debug_this = true
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


func update_score(val, updated_score):
	var current_player = global_data.current_player
	match updated_score:
		"job":
			global_data.players[current_player].job = global_data.players[current_player].job + val
		"education":
			global_data.players[current_player].job = global_data.players[current_player].job + val
	
	emit_signal("update_value", updated_score)
	

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
