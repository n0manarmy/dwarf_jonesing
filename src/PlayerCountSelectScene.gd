extends Node2D

onready var signals_manager = get_node("/root/SignalsManager")
var debug_this = true

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func select_one_player():
	signals_manager.emit_signal("player_count_selected", 1)
	signals_manager.emit_signal("update_debug_scene")
	#emit_signal("update_value", 1, "total_player")
	queue_free()
	
func select_two_players():
	signals_manager.emit_signal("player_count_selected", 2)
	signals_manager.emit_signal("update_debug_scene")
	#emit_signal("update_value", 2, "total_player")
	queue_free()
	
func select_three_players():
	signals_manager.emit_signal("player_count_selected", 3)
	signals_manager.emit_signal("update_debug_scene")
	#emit_signal("update_value", 2, "total_player")
	
	queue_free()
	
func select_four_players():
	signals_manager.emit_signal("player_count_selected", 4)
	signals_manager.emit_signal("update_debug_scene")
	#emit_signal("update_value", 2, "total_player")
	
	queue_free()
