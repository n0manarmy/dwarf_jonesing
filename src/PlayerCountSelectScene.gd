extends Node2D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
signal player_count_selected
signal update_debug_scene

var debug_this = true

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func select_one_player():
	emit_signal("player_count_selected", 1)
	emit_signal("update_debug_scene")
	#emit_signal("update_value", 1, "total_player")
	queue_free()
	
func select_two_players():
	emit_signal("player_count_selected", 2)
	emit_signal("update_debug_scene")
	#emit_signal("update_value", 2, "total_player")
	queue_free()
	
func select_three_players():
	emit_signal("player_count_selected", 3)
	emit_signal("update_debug_scene")
	#emit_signal("update_value", 2, "total_player")
	
	queue_free()
	
func select_four_players():
	emit_signal("player_count_selected", 4)
	emit_signal("update_debug_scene")
	#emit_signal("update_value", 2, "total_player")
	
	queue_free()
	
	

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
